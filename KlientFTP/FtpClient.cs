﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.IO;

namespace KlientFTP
{
    class FtpClient
    {
        #region  Pola
        private string host;
        private string userName;
        private string password;
        private string ftpDirectory;
        private bool downloadCompleted;
        private bool uploadCompleted;
        #endregion

        #region Własności
        public string Host {
            get { return host; }
            set { host = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { UserName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string FtpDirectory
        {
            get
            {
                if (ftpDirectory.StartsWith("ftp://"))
                {
                    return ftpDirectory;
                } else
                {
                    return "ftp://" + ftpDirectory;
                }
            }
            set { ftpDirectory = value; }
        }
        public bool DownloadCompleted
        {
            get { return downloadCompleted; }
            set { downloadCompleted = value; }
        }
        public bool UploadCompleted
        {
            get { return uploadCompleted; }
            set { uploadCompleted = value; }
        }
        #endregion

        // konstruktor bezargumentowy
        public FtpClient()
        {
            downloadCompleted = true;
            uploadCompleted = true;
        }
        //konstruktor 4 argumentowy
        public FtpClient(string host, string userName, string password)
        {
            this.host = host;
            this.userName = userName;
            this.password = password;
            ftpDirectory = "ftp://" + this.host;
        }

        // metoda zwracająca liste plików i katalogów z serwera FTP
        public ArrayList GetDirectories()
        {
            ArrayList directories = new ArrayList();
            FtpWebRequest request;
            try
            {
                request = (FtpWebRequest)WebRequest.Create(ftpDirectory);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(this.userName, this.password);
                request.KeepAlive = false;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string directory;
                        while ((directory = reader.ReadLine()) != null)
                        {
                            directories.Add(directory);
                        }
                    }
                }
                return directories;
            }
            catch
            {

                throw new Exception("Błąd: Nie można nawiązać połaczenia z " + host);
            }



        }
        // metoda do zmiany katalogu
        public ArrayList ChangeDirectory(string DirectoryName)
        {
            ftpDirectory += "/" + DirectoryName;
            return GetDirectories();
        }
        // zmiana katalogu i jeden w górę
        public ArrayList ChangeDirectoryUp()
        {
            if (ftpDirectory != "ftp://" + host)
            {
                ftpDirectory = ftpDirectory.Remove(ftpDirectory.LastIndexOf("/"), ftpDirectory.Length - ftpDirectory.LastIndexOf("/"));
                return GetDirectories();
            }
            else
            {
                return GetDirectories();
            }
        }
        //Kod metody pobierającej plik asynchronicznie z serwera FTP
        public void DownloadFileAsync(string ftpFileName, string localFileName)
        {
            WebClient client = new WebClient();
            try
            {
                Uri uri = new Uri(ftpDirectory + "/" + ftpFileName);
                FileInfo file = new FileInfo(localFileName);
                if (file.Exists)
                {
                    throw new Exception("Błąd: Plik " + localFileName + " istnieje");

                }
                else
                {

                    client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Client_DownloadFileCompleted);
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                    client.Credentials = new NetworkCredential(this.userName, this.password);
                    client.DownloadFileAsync(uri, localFileName);
                    downloadCompleted = false;
                }
            }
            catch
            {
                client.Dispose();
                throw new Exception("Błąd: Pobieranie pliku niemozliwe");
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.OnDownloadProgressChanged(sender, e);
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.OnDownloadCompleted(sender, e);
        }


        #region Zdarzenia
        public delegate void DownProgressChangeEventHandler(object sender, DownloadProgressChangedEventArgs e);  // deklaracja delegecji
        public event DownProgressChangeEventHandler DownProgressChanged;                                          // tworzymy zdarzenie event
        protected virtual void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)       // pomocna metoda do wywołania zdarzenia
        {
            if (DownProgressChanged != null)
            {
                DownProgressChanged(sender, e);
            }
        }

        //delegacja odpowiedzilna za sygnał zakończenia pobierania pliku
        public delegate void DownCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
        public event DownCompletedEventHandler DownCompleted;
        protected virtual void OnDownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (DownCompleted!= null)
            {
                DownCompleted(sender, e);
            }
        }
        //Definicja zdarzenia związanego z zakończeniem wysyłania pliku na serwer FTP
        public delegate void UpCompletedEventHandler(object sender, UploadFileCompletedEventArgs e);
        public event UpCompletedEventHandler UpCompleted;
        protected virtual void OnUploadCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            if (UpCompleted!= null )
            {
                UpCompleted(sender, e);
            }
        }

        //Utworzenie nowego zdarzenia UploadProgressChangedEventHandler
        public delegate void UpProgressChangedEventHandler(object sender, UploadProgressChangedEventArgs e);
        public event UpProgressChangedEventHandler UpProgressChanged;
        protected virtual void OnUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            if (UpProgressChanged!= null)
            {
                UpProgressChanged(sender, e);
            }
        }

        #endregion

        // Metoda wysyłająca asynchronicznie plik na serwer FTP
        public void UploadFileAsync(string FileName)
        {
            try
            {
                System.Net.Cache.RequestCachePolicy cache = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.Reload);
                WebClient client = new WebClient();
                FileInfo file = new FileInfo(FileName);
                Uri uri = new Uri((ftpDirectory + '/' + file.Name).ToString());
                client.Credentials = new NetworkCredential(this.userName, this.password);
                uploadCompleted = false;
                if (file.Exists)
                {
                    client.UploadFileCompleted += new UploadFileCompletedEventHandler(Client_UploadFileCompleted);
                    client.UploadProgressChanged += new UploadProgressChangedEventHandler(Client_UploadProgressChanged);
                }
            }
            catch
            {
                throw new Exception("Błąd: Nie można wysłać pliku");
            }
        }

        private void Client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            this.OnUploadProgressChanged(sender, e);
        }

        private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            this.OnUploadCompleted(sender, e);
        }

        //Metoda kasująca plik z zasobów FTP
        public string DeleteFile(string nazwa)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpDirectory + "//" + nazwa);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(this.userName, this.password);
                request.KeepAlive = false;
                request.UsePassive = true;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                return response.StatusDescription;
            }
            catch (Exception ex)
            {
                throw new Exception("Błąd: Nie można usunąć pliku " + nazwa + " (" + ex.Message + ")");
            }
        }
    }

}
