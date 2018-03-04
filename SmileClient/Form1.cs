using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmileClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        bool zamykanie = false;
        private void pokazForme()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }
        private void ukryjForme()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }
        private void zamknijForme()
        {
            zamykanie = true;
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (zamykanie== false)
            {
                e.Cancel = true;
                ukryjForme();
                if (backgroundWorker1.IsBusy==false)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zamknijForme();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zamknijForme();
        }

        private void pokażToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pokazForme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy==false)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            ukryjForme();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            pokazForme();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "Nowy dowcip ... ";
            notifyIcon1.ShowBalloonTip(15);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (UdpClient klient = new UdpClient(25000))
            {
                IPEndPoint IPSerwera = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 25000);
                Byte[] odczyt = klient.Receive(ref IPSerwera);
                string tekst = Encoding.ASCII.GetString(odczyt);
                this.SetText(tekst);
                //textBox1.Text = tekst; // ten kod jest noebezpieczny
            }
        }

        delegate void SetTextCallBack(string tekst);

        private void SetText(string tekst)
        {
            if (textBox1.InvokeRequired)
            {
                SetTextCallBack f = new SetTextCallBack(SetText);
                this.Invoke(f, new object[] { tekst });
            }
            else
            {
                this.textBox1.Text = tekst;
            }
        }
    }

}
