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
            MailAddress Bc = null; ;
            SmtpClient klient = null;
            try
            {
                Od = new MailAddress(textBoxOd.Text);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy adres e-mail nadawcy");
                textBoxOd.Focus();
                textBoxOd.SelectAll();
                return;
            }
            try
            {
                Do = new MailAddress(textBoxDo.Text);
            }
            catch
            {
                MessageBox.Show("Nieprawidłowy adres e-mail odbiorcy");
                textBoxOd.Focus();
                textBoxDo.SelectAll();
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
                    textBoxOd.Focus();
                    textBoxCc.SelectAll();
                    return;
                }
            }
            if (textBoxBc.Text != string.Empty)
            {
                if (textBoxBc.Text.Trim().Length>0)

                {
                    try
                    {
                        Bc = new MailAddress(textBoxBc.Text);
                    }
                    catch 
                    {
                        MessageBox.Show("Nieprawidłowy adres e-mail odbiorców ukrytych");
                        textBoxOd.Focus();
                        textBoxBc.SelectAll();
                        return;
                    }
                }
            }


            MailMessage wiadomosc = new MailMessage(Od, Do);
            wiadomosc.Subject = textBoxTemat.Text;
            wiadomosc.Body = textBoxList.Text;
            if (Cc != null)
                wiadomosc.CC.Add(Cc);
            if (Bc != null)
                wiadomosc.Bcc.Add(Bc);
            if (listBox2.Items.Count>0)
            {
                foreach (string plik in listBox2.Items)
                {
                    Attachment zalacznik = new Attachment(plik);
                    wiadomosc.Attachments.Add(zalacznik);
                }
            }
            wiadomosc.IsBodyHtml = checkBox1.Checked;




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

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                listBox2.Items.Add(openFileDialog1);
            }
        }

        private void buttonCzysc_Click(object sender, EventArgs e)
        {
            textBoxOd.Clear();
            textBoxDo.Clear();
            textBoxCc.Clear();
            textBoxBc.Clear();
            textBoxTemat.Clear();
            textBoxList.Clear();
        }
    }
}
