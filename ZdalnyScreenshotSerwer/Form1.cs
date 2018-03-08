using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ZdalnyScreenshotSerwer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Bezpieczne odwoływanie się z innego wątku do własności kontrolek
        delegate void SetTextCallBack(string tekst);

        private void SetText(string tekst)
        {
            if (listBox1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }else
            {
                this.listBox1.Items.Add(tekst)
;            }
        }

        delegate void RemoveTextCallBack(int pozycja);
        //Metoda pozwalająca bezpiecznie usunąć wpis z listy listBox1
        private void RemoveText(int pozycja)
        {
            if (listBox1.InvokeRequired)
            {
                RemoveTextCallBack f = new RemoveTextCallBack(RemoveText);
                this.Invoke(f, new object[] { pozycja });
            }else
            {
                listBox1.Items.RemoveAt(pozycja);
            }
        }
        //Oczekiwanie na pakiety UDP
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            IPEndPoint zdalnyIP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient klient = new UdpClient(43210);
            while (true)
            {
                Byte[] bufor = klient.Receive(ref zdalnyIP);
                string dane = Encoding.ASCII.GetString(bufor);
                string[] cmd = dane.Split(new char[] { ':' });
                if (cmd[1]=="HI")
                {
                    foreach (string  wpis in listBox1.Items)
                    {
                        if (wpis==cmd[0])
                        {
                            MessageBox.Show("Próba nawiązania połączenia z " + cmd[0] + " odrzucona, ponieważ na liście istnieje już taki wpis");
                            return;
                        }
                    }
                    this.SetText(cmd[0]);
                }
                if (cmd[1]=="BYE")
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        if (listBox1.Items[i].ToString() == cmd[0])
                            this.RemoveText(i);
                    }
                }
            }
        }
        //  Metoda pobierająca zrzut ekranu

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex==-1)
            {
                return;

            }
            try
            {
                TcpClient klient = new TcpClient(listBox1.Items[listBox1.SelectedIndex].ToString(), 1978);
                NetworkStream ns = klient.GetStream();
                byte[] bufor = new byte[5];
                bufor = Encoding.ASCII.GetBytes("##S##");
                ns.Write(bufor, 0, bufor.Length);
                if (backgroundWorker1.IsBusy == false)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Nie można teraz zrealizować zrzutu ekranu");
                }
            }
            catch
            {
                MessageBox.Show("Błąd: Nie można nawiązać połączenia");
            }
        }
        //  Odebranie zrzutu ekranu wysłanego przez klienta
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serwer2 = new TcpListener(IPAddress.Parse(textBox1.Text), (int)numericUpDown1.Value);
            serwer2.Start();
            TcpClient klient2 = serwer2.AcceptTcpClient();
            NetworkStream ns = klient2.GetStream();
            byte[] obrazByte;
            using(BinaryReader odczytobrazu = new BinaryReader(ns))
            {
                int rozmiarObrazu = odczytobrazu.ReadInt32();
                obrazByte = odczytobrazu.ReadBytes(rozmiarObrazu);
            }
            using(MemoryStream ms = new MemoryStream(obrazByte))
            {
                Image obraz = Image.FromStream(ms);
                pictureBox1.Image = obraz;
            }
            serwer2.Stop();
        }
    }
}
