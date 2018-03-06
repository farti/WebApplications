using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace KomunikatorSerwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigate("about:blank");
            webBrowser1.Document.Write("<html><head><style>body,table " +
                "{ font-size:10pt; font - family: Verdana; margin: 3px 3px 3px 3px; font - color: black;}" +
                "</style></head><body width =\"" + (webBrowser1.ClientSize.Width-20).ToString() + "\">");
            IPHostEntry adresyIP = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress pozycja in adresyIP.AddressList)
            {
                comboBox1.Items.Add(pozycja.ToString());
            }
        }
        private int PozycjaKursora = 0;
        private TcpListener serwer = null;
        private TcpClient klient = null;
        private string adresIP = "127.0.0.1";
        private BinaryReader czytanie = null;
        private BinaryWriter pisanie = null;
        private bool polaczenieAktywne = false;

        private void WprowadzTag(string tag)
        {
            string kod = textBox1.Text;
            textBox1.Text = kod.Insert(PozycjaKursora, tag);
            textBox1.Focus();
            if (tag=="<br>" ||tag =="<hr>")
            {
                textBox1.Select(PozycjaKursora + tag.Length, 0);
                PozycjaKursora += tag.Length;
            }
            else
            {
                textBox1.Select(PozycjaKursora + tag.Length / 2, 0);
                PozycjaKursora += tag.Length / 2;
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PozycjaKursora = textBox1.SelectionStart;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            PozycjaKursora = textBox1.SelectionStart;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WprowadzTag("<b></b>");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WprowadzTag("<i></i>");
        }

        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("about:blank");
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    try
                    {
                        sw.Write(webBrowser1.DocumentText);
                    }
                    catch
                    {
                        MessageBox.Show("Nie można zapisać pliku: " + saveFileDialog1.FileName);
                    }
            }
        }

        //Bezpieczne odwoływanie się do własności kontrolek formy z poziomu innego wątku
        delegate void SetTextCallBack(string tekst);
        delegate void SetScrollCallBack();

        private void SetText(string tekst)
        {
            if (listBox1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.listBox1.Items.Add(tekst);
            }
        }
        private void SetTextHTML(string tekst)
        {
            if (webBrowser1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetTextHTML);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.webBrowser1.Document.Write(tekst);
            }
        }
        private void SetScroll()
        {
            if (webBrowser1.InvokeRequired)
            {
                SetScrollCallBack s = new SetScrollCallBack(SetScroll);
                this.Invoke(s);
            }
            else
            {
                this.webBrowser1.Document.Window.ScrollTo(1, Int32.MaxValue);
            }
        }

        private void WpiszTekst(string kto, string wiadomosc)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b>" + kto + "</b></td><td width=\"90%\">(" + DateTime.Now.ToShortTimeString()+"):</td></tr>");
            SetTextHTML("<tr><td colspan=2>" + wiadomosc + "</td></tr></table>");
            SetTextHTML("<hr>");
            SetScroll();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            adresIP = comboBox1.Text;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            IPAddress serwerIP;
            try
            {
                serwerIP = IPAddress.Parse(adresIP);
            }
            catch
            {
                MessageBox.Show("Błędny adres IP");
                polaczenieAktywne = false;
                return;
            }
            serwer = new TcpListener(serwerIP, (int)numericUpDown1.Value);
            try
            {
                serwer.Start();
                SetText("Oczekuje na połaczenie ...");
                klient = serwer.AcceptTcpClient();
                NetworkStream ns = klient.GetStream();
                SetText("Klient próbuje się połaczyć");
                czytanie = new BinaryReader(ns);
                pisanie = new BinaryWriter(ns);
                if (czytanie.ReadString() == "###HI###")
                {
                    SetText("Klient połaczony");
                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    SetText("Klient nie dokonał wymaganej autoryzacji. Połączenie przerwane");
                    klient.Close();
                    serwer.Stop();
                    polaczenieAktywne = false;
                }

            }
            catch
            {
                SetText("Połaczenie zostało przerwane");
                polaczenieAktywne = false;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string wiadomosc;
            try
            {
                while ((wiadomosc=czytanie.ReadString())!="###BYE###")
                {
                    WpiszTekst("ktoś", wiadomosc);
                }
                klient.Close();
                serwer.Stop();
                SetText("Połaczenie zostało przerwane przez klienta");
            }
            catch
            {
                SetText("Klient rozłączony");
                polaczenieAktywne = false;
                klient.Close();
                serwer.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (polaczenieAktywne==false)
            {
                polaczenieAktywne = true;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                polaczenieAktywne = false;
                if (klient!=null)
                {
                    klient.Close();
                }
                serwer.Stop();
                backgroundWorker1.CancelAsync();
                if (backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.CancelAsync();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WpiszTekst("ja", textBox1.Text);
            if (polaczenieAktywne)
            {
                pisanie.Write(textBox1.Text);
            }
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)13)
            {
                this.button2_Click(sender, e);
            }
        }
    }
}
