using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace EdytorHTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            webBrowser1.Url = new Uri(PlikTymczasowy);
            ZapiszDoPlikuTekstowego(PlikTymczasowy, new string[0]);

        }
        // metoda zapisu pliku
        private void ZapiszDoPlikuTekstowego(string NazwaPliku, string[] tekst)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(NazwaPliku))
                    foreach (string linia in tekst)
                    {
                        sw.WriteLine(linia);
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd zapisu pliku: " + NazwaPliku+" ("+ex.Message+" )", "Błąd");
            }
        }  
        // metoda odczytu pliku
        private string[] OdczytajZPlikuTekstowego(string NazwaPliku)
        {
            List<string> tekst = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(NazwaPliku))
                {
                    string linia;
                    while ((linia=sr.ReadLine())!= null)
                    {
                        tekst.Add(linia);
                    }
                    return tekst.ToArray();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Błąd odczytu pliku: " + NazwaPliku + " (" + ex.Message + ") ", "Błąd");
                return null;
            }
        }

        private void tagHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // menu otwieranie pliku
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string NazwaPliku = openFileDialog1.FileName;
                textBox1.Lines = OdczytajZPlikuTekstowego(NazwaPliku);
                toolStripStatusLabel1.Text = "Otwarty plik: " + NazwaPliku.Substring(NazwaPliku.LastIndexOf("\\") + 1, NazwaPliku.Length - NazwaPliku.LastIndexOf("\\") - 1);
            }
        }
        // menu zapisanie pliku
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NazwaPliku = openFileDialog1.FileName;
            if (NazwaPliku != String.Empty) saveFileDialog1.FileName = NazwaPliku;
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                NazwaPliku = saveFileDialog1.FileName;
                ZapiszDoPlikuTekstowego(NazwaPliku, textBox1.Lines);
                toolStripStatusLabel1.Text = "Otwarty plik: " + NazwaPliku.Substring(NazwaPliku.LastIndexOf("\\") + 1, NazwaPliku.Length - NazwaPliku.LastIndexOf("\\") - 1);
            }
            
        }
        
        #region metody dla edycji
        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

        private void zaznaczWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        #endregion

        private int PozycjaKursora;

        #region metody dla tagów
        private void WprowadzTag(string tag)
        {
            string kod = textBox1.Text;
            textBox1.Text = kod.Insert(PozycjaKursora, tag);
            textBox1.Focus();
            if (tag == "<br>"|| tag == "<hr>")
            {
                textBox1.Select(PozycjaKursora + tag.Length, 0);
                PozycjaKursora += tag.Length;
            }
            else
            {
                textBox1.Select(PozycjaKursora + tag.Length / 2, 0);
                PozycjaKursora += tag.Length / 2;
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PozycjaKursora = textBox1.SelectionStart;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            PozycjaKursora = textBox1.SelectionStart;
        }

        // przypisanie tagów z menu
        private void buttonTagB_Click(object sender, EventArgs e)
        {
            WprowadzTag("<b></b>");
        }

        private void buttonTagI_Click(object sender, EventArgs e)
        {
            WprowadzTag("<i></i>");
        }

        private void buttonTagTable_Click(object sender, EventArgs e)
        {
            WprowadzTag("<table></table>");
        }

        private void buttonTagTr_Click(object sender, EventArgs e)
        {
            WprowadzTag("<tr></tr>");
        }

        private void buttonTagTd_Click(object sender, EventArgs e)
        {
            WprowadzTag("<td></td>");
        }

        private void buttonTagBr_Click(object sender, EventArgs e)
        {
            WprowadzTag("<br></br>");
        }

        private void buttonTagHr_Click(object sender, EventArgs e)
        {
            WprowadzTag("<hr></hr>");
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagBr_Click(sender, e);
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagI_Click(sender, e);
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagTable_Click(sender, e);
        }

        private void trToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagTr_Click(sender, e);
        }

        private void tdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagTd_Click(sender, e);
        }

        private void brToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagBr_Click(sender, e);
        }

        private void hrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.buttonTagHr_Click(sender, e);
        }

        #endregion

        string PlikTymczasowy = Environment.CurrentDirectory + "\\tmp.html";


        #region Podgląd bieżącej strony
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //ZapiszDoPlikuTekstowego(PlikTymczasowy, textBox1.Lines);
            webBrowser1.Document.Write(textBox1.Text);
            webBrowser1.Refresh();
        }
#endregion
        
    }
}
