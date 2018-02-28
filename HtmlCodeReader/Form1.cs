using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlCodeReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sciezka;
            if (!textBox1.Text.StartsWith("http://"))
            {
                sciezka = "http://" + textBox1.Text;
            }
            else
            {
                sciezka = textBox1.Text;
            }
            try
            {
                WebRequest zadanie = WebRequest.Create(sciezka);
                zadanie.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse odpowiedz = (HttpWebResponse)zadanie.GetResponse();
                string s = odpowiedz.ContentEncoding;
                Stream strumien = odpowiedz.GetResponseStream();
                StreamReader sr = new StreamReader(strumien, Encoding.Default, false);
                string tekst = sr.ReadToEnd();
                textBox2.Text = tekst;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
                
            }
        }
    }
}
