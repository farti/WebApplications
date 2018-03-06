using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ZdalnyScreenshotKlient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IPHostEntry adresyIP = Dns.GetHostEntry(Dns.GetHostName());
            adresLokalnyIP = adresyIP.AddressList[0].ToString();
            backgroundWorker1.RunWorkerAsync();
        }

        private int serwerKomendPort = 1978;
        private IPAddress serwerDanychIP = IPAddress.Parse("127.0.0.1");
        private int serwerDanychport = 25000;
        private string adresLokalnyIP;
        private Bitmap obraz;

        private Bitmap wykonajScreenshot()
        {
            Bitmap bitmapa = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            Graphics screenshot = Graphics.FromImage(bitmapa);
            screenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bitmapa;
        }

        delegate void SetTextCallBack(string tekst);
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TcpListener serwer = new TcpListener(IPAddress.Parse(adresLokalnyIP), serwerKomendPort);
            serwer.Start();
            this.SetText("Oczekuję na komendy ...");
            while (true)
            {
                TcpClient klientKomend = serwer.AcceptTcpClient();
                this.SetText("Otrzymano komendę.");
                NetworkStream ns = klientKomend.GetStream();
                Byte[] bufor = new Byte[5];
                int odczyt = ns.Read(bufor, 0, bufor.Length);
                String s = Encoding.ASCII.GetString(bufor);
                string wiadomosc = Encoding.ASCII.GetString(bufor);
                if (wiadomosc=="##S##")
                {
                    this.SetText("Zrzut ekranu w trakcie wykonywania...");
                    obraz = wykonajScreenshot();
                    MemoryStream ms = new MemoryStream();
                    obraz.Save(ms, ImageFormat.Jpeg);
                    byte[] obrazByte = ms.GetBuffer();
                    ms.Close();
                    try
                    {
                        TcpClient klient2 = new TcpClient(serwerDanychIP.ToString(), serwerDanychport);
                        NetworkStream ns2 = klient2.GetStream();
                        this.SetText("Wysyłanie zrzutu...");
                        using(BinaryWriter bw = new BinaryWriter(ns2))
                        {
                            bw.Write((int)obrazByte.Length);
                            bw.Write(obrazByte);
                        }
                        this.SetText("Zrzut ekranu przesłany.");
                    }catch (Exception ex)
                    {
                        this.SetText("Nie mozna połączyć z serwerem");
                    }
                }
            }
        }
        // Metoda przesyłająca wiadomość przy użyciu protokołu UDP
        private void WyslijWiadomoscUDP(string wiadomosc)
        {
            UdpClient klient = new UdpClient(serwerDanychIP.ToString(), 43210);
            byte[] bufor = Encoding.ASCII.GetBytes(wiadomosc);
            klient.Send(bufor, bufor.Length);
            klient.Close();
        }
        // Wysłanie wiadomości o gotowości klienta
        private void Form1_Load(object sender, EventArgs e)
        {
            WyslijWiadomoscUDP(adresLokalnyIP + ":HI");
        }
        // Wysłanie wiadomości o zakończeniu pracy przez klienta
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WyslijWiadomoscUDP(adresLokalnyIP + ":BYE");
        }
        



    }
}
