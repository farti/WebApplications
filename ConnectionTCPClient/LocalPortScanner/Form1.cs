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

namespace LocalPortScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value>numericUpDown2.Value)
            {
                MessageBox.Show("Błędny zakres portów.");
                return;
            }
            listBox1.Items.Add("Rozpoczęcie skanowania ...");
            int start = (int)numericUpDown1.Value;
            int stop = (int)numericUpDown2.Value;
            progressBar1.Minimum = start;
            progressBar1.Maximum = stop;
            for (int  i=start ;i  < stop; i++)
            {
                this.Refresh();
                label3.Text = "aktualnie skanowany port: " + i;
                try
                {
                    TcpListener serwer = new TcpListener(IPAddress.Loopback, i);
                    serwer.Start();
                    serwer.Stop();
                }
                catch
                {
                    listBox1.Items.Add("Port: " + i + " jest zajęty");
                }
                progressBar1.Value = i;
            }
            listBox1.Items.Add("Zakończono skanowanie");
        }
    }
}
