using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AsyncTCPServer
{
    public partial class Form1 : Form
    {
        //pola prywatne
        private TcpListener serwer;
        private TcpClient klient;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Oczekiwanie na połączenie ... ");
            IPAddress adresIP;

            try
            {
                adresIP = IPAddress.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Błedny format adresu IP!", "Błąd");
                textBox1.Text = String.Empty;
                return;
            }

            int port = (int)numericUpDown1.Value;

            try
            {
                serwer = new TcpListener(adresIP, port);
                serwer.Start();

                serwer.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), serwer);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Bład: " + ex.Message);
            }

        }
        private void AcceptTcpClientCallback(IAsyncResult asyncResult)
        {
            TcpListener s = (TcpListener)asyncResult.AsyncState;
            klient = s.EndAcceptTcpClient(asyncResult);
            SetListBoxText("Połączenie się powiodło!");
            klient.Close();
            serwer.Stop();
        }
        private delegate void SettextCallBack(string tekst);
        private void SetListBoxText(string tekst)
        {
            if (listBox1.InvokeRequired)
            {
                SettextCallBack f = new SettextCallBack(SetListBoxText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                listBox1.Items.Add(tekst);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serwer!=null)
            {
                serwer.Stop();
            }
        }
    }
}
