using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SmileServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && textBox2.Text.Trim().Length > 0)
            {
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = string.Empty;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                for (int i = listBox1.Items.Count - 1; i > -0; i--)
                {
                    if (listBox1.GetSelected(i))
                    {
                        listBox1.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void buttonBlock_Click(object sender, EventArgs e)
        {
            int indeks = listBox1.SelectedIndex;
            if (indeks > -1)
            {
                string pozycja = listBox1.Items[indeks].ToString();
                listBox1.Items.RemoveAt(indeks);
                if (pozycja.StartsWith("(Zablokowany) "))
                {
                    listBox1.Items.Insert(indeks, pozycja.Remove(0, "(Zablokowany) ".Length));
                }
                else
                {
                    listBox1.Items.Insert(indeks, "(Zablokowany) " + pozycja);
                }
            }
        }

        private void otwórzListęKontaktówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (MessageBox.Show("Wczytanie pliku powoduje skasowanie dotychczasowej listy", "Ostrzeżenie", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)

                {
                    return;
                }
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string linia;
                        listBox1.Items.Clear();
                        while ((linia = sr.ReadLine()) != null)
                        {
                            listBox1.Items.Add(linia);
                        }
                    }
                }
            }
        }

        private void zapiszListęKontaktówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (string wpis in listBox1.Items)
                    {
                        sw.WriteLine(wpis);
                    }
                }
            }
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz wyjść?", "Zakończenie pracy ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
            {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Byte[] bufor = Encoding.ASCII.GetBytes(textBox1.Text);
            foreach (string host in listBox1.Items)
            {
                try
                {
                    if (host.StartsWith("(Zablokowany) ") == false)
                    {
                        using (UdpClient klient = new UdpClient(host, (int)numericUpDown1.Value))
                        {
                            klient.Send(bufor, bufor.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można nawiązać połączenia. " + ex.Message, "Błąd");
                }
            }
        }


    }
}
