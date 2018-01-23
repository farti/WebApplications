using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ConnectionTCPServer
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
            IPAddress adresIP=null;
            try
            {
                adresIP = IPAddress.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Błędny format adresu IP!", "Błąd");
                textBox1.Text = string.Empty;
                return;
            }
            int port = System.Convert.ToInt16(numericUpDown1.Value);

            try
            {
                serwer = new TcpListener(adresIP, port);
                serwer.Start();
                klient = serwer.AcceptTcpClient();
                IPEndPoint IP = (IPEndPoint)klient.Client.RemoteEndPoint;
                listBox1.Items.Add("["+IP.ToString()+"]:Nawiązano połaczenie");
                button1.Enabled = false;
                button2.Enabled = true;
                klient.Close();
                serwer.Stop();
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("Błąd inicjacji serwera!");
                MessageBox.Show(ex.ToString(),"Błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serwer.Stop();
            klient.Close();
            listBox1.Items.Add("Zakończono pracę serwera ...");
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
