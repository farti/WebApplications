using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DownloadManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox1.Text.Trim() != string.Empty)
            {
                listBox1.Items.Add(textBox1.Text);
            }
            textBox1.Text = string.Empty;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int indeks = listBox1.SelectedIndex;
            if (indeks == -1)
            {
                return;
            }
            listBox1.Items.Remove(indeks);
        }


        private int aktualnyIndeks = 0;
        private WebClient klient;
        private bool pobieranie = false;

        //Metoda pobierająca plik asynchronicznie z użyciem protokołu HTTP
        private void PobierzAsynchronicznie(Uri url)
        {
            listBox1.SelectedIndex = aktualnyIndeks;
            listBox1.Focus();
            pobieranie = true;
            klient = new WebClient();
            klient.DownloadFileCompleted += new AsyncCompletedEventHandler(klient_DownloadFileCompleted);
            klient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Klient_DownloadProgressChanged);
            string sciezka = url.ToString();
            string nazwaPliku = textBox2.Text + "\\" + sciezka.Substring(sciezka.LastIndexOf("/") + 1, sciezka.Length - sciezka.LastIndexOf("/") - 1);
            try
            {
                FileInfo plik = new FileInfo(nazwaPliku);
                if (plik.Exists == false)
                {
                    klient.DownloadFileAsync(url, textBox2.Text + "\\" + sciezka.Substring(sciezka.LastIndexOf("/") + 1, sciezka.Length - sciezka.LastIndexOf("/") - 1));
                    aktualnyIndeks++;
                }
                else
                {
                    MessageBox.Show("Plik o nazwie :" + nazwaPliku + " istnieje");
                    pobieranie = false;
                    if (++aktualnyIndeks < listBox1.Items.Count)
                    {
                        Uri nowy = new Uri(listBox1.Items[aktualnyIndeks].ToString());
                        PobierzAsynchronicznie(nowy);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nie można pobrać pliku " + nazwaPliku);
            }

        }

        private void Klient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = "Pobrano: " + (Math.Round(e.BytesReceived / (double)1024, 2)).ToString() + " kB z " + (Math.Round(e.TotalBytesToReceive / (double)1024, 2)).ToString() + " kB";
            label4.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void klient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (aktualnyIndeks < listBox1.Items.Count)
            {
                Uri url = new Uri(listBox1.Items[aktualnyIndeks].ToString());
                PobierzAsynchronicznie(url);
            }
            else
            {
                if (e.Cancelled || e.Error != null)
                {
                    MessageBox.Show("Pobieranie przerwane bądź wystapił błąd. (" + e.Error.Message + ")", "Informacja");

                }
                pobieranie = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            aktualnyIndeks = 0;
            Uri url = new Uri(listBox1.Items[aktualnyIndeks].ToString());
            PobierzAsynchronicznie(url);
        }

        private void PrzerwijPobieranie()
        {
            klient.CancelAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno przerwać pobieranie?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
            {
                PrzerwijPobieranie();
                progressBar1.Value = 0;
                label3.Text = "Pobrano: ";
                label4.Text = "0%";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pobieranie)
            {
                if (MessageBox.Show("Pobieranie w trakcie. Czy na pewni zakończyć?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }



}
