using System;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace KomunikatorKlient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.webBrowser1.Navigate("about:blank");
            this.webBrowser1.Document.Write("<html><head><style>body,table { fontsize: 10pt; font-family: Verdana; margin: 3px 3px 3px 3px; font-color: black; }</style></head><body width =\"" + (webBrowser1.ClientSize.Width - 20).ToString() + "\">");
        }

        // Prywatne pola klasy Form1
        private TcpClient klient;
        private BinaryWriter pisanie;
        private BinaryReader czytanie;
        private string serwerIP = "127.0.0.1";
        private int PozycjaKursora;
        private bool polaczenieAktywne;


        // Komplet funkcji niezbędnych do bezpiecznego modyfikowania własności kontrolek formy
        // głównej z poziomu innego wątku

        delegate void SetTextCallBack(string tekst);
        delegate void SetScrollBack();

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
                SetScrollBack s = new SetScrollBack(SetScroll);
                this.Invoke(s);
            }
            else
            {
                this.webBrowser1.Document.Window.ScrollTo(1, Int32.MaxValue);
            }
        }

        private void WpiszTekst(string kto, string wiadomosc)
        {
            SetTextHTML("<table><tr><td width=\"10%\"><b>" + kto + "</b></td><td width=\"90%\">(" + DateTime.Now.ToShortTimeString() + "):</td></tr>");
            SetTextHTML("<tr><td colspan=2>" + wiadomosc + "</td></tr></table>");
            SetTextHTML("<hr>");
            SetScroll();
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                klient = new TcpClient(serwerIP, (int)numericUpDown1.Value);
                NetworkStream ns = klient.GetStream();
                czytanie = new BinaryReader(ns);
                pisanie = new BinaryWriter(ns);
                pisanie.Write("###HI###");
                this.SetText("Autoryzacja ...");
                polaczenieAktywne = true;
                backgroundWorker2.RunWorkerAsync();
            }
            catch
            {
                this.SetText("Nie można nawiązać połaczenie");
                polaczenieAktywne = false;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SetText("Autoryzacja zakończona");
            string wiadomosc;
            try
            {
                while ((wiadomosc = czytanie.ReadString()) != "##BYE###")
                {
                    WpiszTekst("ktoś", wiadomosc);
                }
            }
            catch
            {
                SetText("Polaczenie z serwerem została przerwane");
                polaczenieAktywne = false;
                klient.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (polaczenieAktywne == false)
            {
                backgroundWorker1.RunWorkerAsync();
                webBrowser1.Navigate("about:blank");
            }
            else
            {
                polaczenieAktywne = false;
                if (klient != null)
                {
                    pisanie.Write("###BYE###");
                    klient.Close();
                }
            }
        }

        // edycja tekstu
        private void WprowadzTag(string tag)
        {
            string kod = textBox1.Text;
            textBox1.Text = kod.Insert(PozycjaKursora, tag);
            textBox1.Focus();
            if (tag == "<br>" || tag == "<hr>")
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


        private void wyczyśćToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("about:blank");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            WprowadzTag("<i></i>");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WprowadzTag("<b></b>");
        }


        private void zapiszToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            serwerIP = comboBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
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
            if (e.KeyChar == (char)13)
            {
                this.button4_Click(sender, e);
            }
        }
    }


}
