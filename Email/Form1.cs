using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Email
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailAddress Od;
            MailAddress Do;
            MailAddress Cc = null;
            SmtpClient klient = null;
            try
            {
                Od = new MailAddress(textBoxOd.Text);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy adres e-mail nadawcy");
                textBoxOd.Text = String.Empty;
                return;
            }
            try
            {
                Do = new MailAddress(textBoxDo.Text);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy adres e-mail odbiorcy");
                textBoxDo.Text = String.Empty;
                return;
            }
            if (textBoxCc.Text != string.Empty)
            {
                try
                {
                    Cc = new MailAddress(textBoxCc.Text);
                }
                catch
                {
                    MessageBox.Show("Nieprawidłowy adres e-mail odbiorców");
                    textBoxCc.Text = String.Empty;
                    return;
                }
            }
            MailMessage wiadomosc = new MailMessage(Od, Do);
            wiadomosc.Subject = textBoxTemat.Text;
            wiadomosc.Body = textBoxList.Text;
            if (Cc != null)
                wiadomosc.CC.Add(Cc);
            try
            {
                klient = new SmtpClient(textBoxAdres.Text);
                klient.Credentials = CredentialCache.DefaultNetworkCredentials;
                klient.Send(wiadomosc);
                listBox1.Items.Add("Wiadomość zostala wysłana");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Brak połaczenia z serwerem : " + ex.Message);
            }

        }
    }
}
