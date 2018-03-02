using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlientFTP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private FtpClient client = new FtpClient();

        //funkcja wypisująca listę plików i katalogów w kontrolce listBoxFtpDir
        private void GetFtpContent(ArrayList directoriesList)
        {
            listBoxFtpDir.Items.Clear();
            listBoxFtpDir.Items.Add("[..]");
            directoriesList.Sort();
            foreach (string name in directoriesList)
            {
                string position = name.Substring(name.LastIndexOf(' ') + 1, name.Length - name.LastIndexOf(' ') - 1);
                if (position!=".." && position !=".")
                {
                    switch (name[0])
                    {
                        case 'd':
                            listBoxFtpDir.Items.Add("[" + position + "]");
                            break;
                        case '1':
                            listBoxFtpDir.Items.Add("->" + position);
                            break;
                        default:
                            listBoxFtpDir.Items.Add(position);
                            break;
                    }
                }
            }
        }



        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBoxLocalPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (comboBoxServer.Text != string.Empty && comboBoxServer.Text.Trim() != string.Empty)
            {
                try
                {
                    string serverName = comboBoxServer.Text;
                    //nazwa hosta nie może zaczynać się od ftp://
                    if (serverName.StartsWith("ftp://"))

                        serverName = serverName.Replace("ftp://", "");

                    client = new FtpClient(serverName, textBoxLogin.Text, textBoxPass.Text);
                    GetFtpContent(client.GetDirectories());
                    textBoxFtpDir.Text = client.FtpDirectory;
                    toolStripStatusLabelServer.Text = "Serwer: ftp://" + client.Host;
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    buttonDownload.Enabled = true;
                    buttonSend.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wprowadź nazwę serwera FTP", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Wprowadź nazwę serwera FTP", "Błąd");
                comboBoxServer.Text = string.Empty;
            }
            
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {

        }

        private void listBoxFtpDir_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxFtpDir.SelectedIndex;
            try
            {
                if (index>-1)
                {
                    if (index==0)
                    {
                        GetFtpContent(client.ChangeDirectoryUp());
                    }
                    else
                    {
                        if (listBoxFtpDir.Items[index].ToString()[0]=='[')
                        {
                            string directory = listBoxFtpDir.Items[index].ToString().Substring(1, listBoxFtpDir.Items[index].ToString().Length - 2);
                            GetFtpContent(client.ChangeDirectory(directory));
                        }
                        else
                        {
                            if (listBoxFtpDir.Items[index].ToString()[0]=='-'&listBoxFtpDir.Items[index].ToString()[2]=='.')
                            {
                                string link = listBoxFtpDir.Items[index].ToString().Substring(5, listBoxFtpDir.Items[index].ToString().Length - 5);
                                client.FtpDirectory = "ftp://" + client.Host;
                                GetFtpContent(client.ChangeDirectory(link));
                            }
                            else
                            {
                                this.buttonUpDir_Click(sender, e);
                            }
                            listBoxFtpDir.SelectedIndex = 0;
                        }
                    }

                    
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd");
            }
        }

        private void buttonUpDir_Click(object sender, EventArgs e)
        {

        }
        // zatwierdzanie katalogu enterem
        private void listBoxFtpDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.listBoxFtpDir_MouseDoubleClick(sender, null);
            }
        }




    }
}
