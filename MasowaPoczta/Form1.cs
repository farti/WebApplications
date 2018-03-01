using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace MasowaPoczta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // asynhroniczne wysyłanie wiadomości e-mail

        private void WyslijAsynchronicznie(MailMessage wiadomosc)
        {
            try
            {
                SmtpClient klient = new SmtpClient(textBoxSerwer.Text);
                if (textBoxLogin.Text != string.Empty && textBoxPass.Text!=string.Empty)
                {
                    klient.Credentials = new NetworkCredential(textBoxLogin.Text, textBoxPass.Text);
                }
                else
                {
                    MessageBox.Show("Proszę podac nazwę użytkownika i hasło");
                    return;
                }
                klient.SendCompleted += new SendCompletedEventHandler(WiadomoscWyslana);
                klient.SendAsync(wiadomosc, null);
            }
            catch(Exception ex
            )
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void WiadomoscWyslana(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled | e.Error!=null)
            {
                MessageBox.Show("Błąd: Wysyłanie anulowane bądź wystąpil błąd serwera");
            }
            else
            {
                MessageBox.Show("Wiadomość wysłana");
            }
        }

        //

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            if (textBoxAdres.Text != String.Empty)
            {
                if (textBoxAdres.Text.Trim().Length>0)
                {
                    listBoxAdresy.Items.Add(textBoxAdres.Text);
                    textBoxAdres.Clear();
                }
            }
        }

        private void listBoxAdresy_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxAdresy.SelectedIndex!=-1)
            {
                listBoxAdresy.Items.RemoveAt(listBoxAdresy.SelectedIndex);
            }
        }

        private void buttonZalacz_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                listBoxZalaczniki.Items.Add(openFileDialog1.FileName);
            }
        }

        private void buttonWyslij_Click(object sender, EventArgs e)
        {
            MailAddress Od;
            MailAddress Do;
            MailMessage wiadomosc = new MailMessage();
            try
            {
                Od = new MailAddress(textBoxNadawca.Text);
            }
            catch
            {
                MessageBox.Show("Nieprawisłowy adres nadawcy");
                textBoxNadawca.Clear();
                return;
            }
            wiadomosc.From = Od;
            if (listBoxZalaczniki.Items.Count>0)
            {
                foreach (string plik in listBoxZalaczniki.Items)
                {
                    Attachment zalacznik = new Attachment(plik);
                    wiadomosc.Attachments.Add(zalacznik);
                }
            }
            try
            {
                foreach (string adres in listBoxAdresy.Items)
                {
                    Do = new MailAddress(adres);
                    wiadomosc.To.Add(Do);
                }
                wiadomosc.Subject = textBoxTemat.Text;
                wiadomosc.Body = textBoxList.Text;
                WyslijAsynchronicznie(wiadomosc);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }


        }
    }
}
