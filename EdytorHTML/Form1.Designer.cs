namespace EdytorHTML
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonTagB = new System.Windows.Forms.Button();
            this.buttonTagI = new System.Windows.Forms.Button();
            this.buttonTagTable = new System.Windows.Forms.Button();
            this.buttonTagTr = new System.Windows.Forms.Button();
            this.buttonTagTd = new System.Windows.Forms.Button();
            this.buttonTagBr = new System.Windows.Forms.Button();
            this.buttonTagHr = new System.Windows.Forms.Button();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koniecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edycjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cofnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wytnijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopiujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wklejToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaznaczWszystkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.edycjaToolStripMenuItem,
            this.tagHTMLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTagHr);
            this.groupBox1.Controls.Add(this.buttonTagBr);
            this.groupBox1.Controls.Add(this.buttonTagTd);
            this.groupBox1.Controls.Add(this.buttonTagTr);
            this.groupBox1.Controls.Add(this.buttonTagTable);
            this.groupBox1.Controls.Add(this.buttonTagI);
            this.groupBox1.Controls.Add(this.buttonTagB);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tagi HTML";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(13, 79);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(580, 181);
            this.webBrowser1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 266);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(580, 196);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(625, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonTagB
            // 
            this.buttonTagB.Location = new System.Drawing.Point(6, 17);
            this.buttonTagB.Name = "buttonTagB";
            this.buttonTagB.Size = new System.Drawing.Size(69, 23);
            this.buttonTagB.TabIndex = 5;
            this.buttonTagB.Text = "<b>";
            this.buttonTagB.UseVisualStyleBackColor = true;
            this.buttonTagB.Click += new System.EventHandler(this.buttonTagB_Click);
            // 
            // buttonTagI
            // 
            this.buttonTagI.Location = new System.Drawing.Point(81, 17);
            this.buttonTagI.Name = "buttonTagI";
            this.buttonTagI.Size = new System.Drawing.Size(69, 23);
            this.buttonTagI.TabIndex = 6;
            this.buttonTagI.Text = "<i>";
            this.buttonTagI.UseVisualStyleBackColor = true;
            this.buttonTagI.Click += new System.EventHandler(this.buttonTagI_Click);
            // 
            // buttonTagTable
            // 
            this.buttonTagTable.Location = new System.Drawing.Point(156, 17);
            this.buttonTagTable.Name = "buttonTagTable";
            this.buttonTagTable.Size = new System.Drawing.Size(69, 23);
            this.buttonTagTable.TabIndex = 7;
            this.buttonTagTable.Text = "<table>";
            this.buttonTagTable.UseVisualStyleBackColor = true;
            this.buttonTagTable.Click += new System.EventHandler(this.buttonTagTable_Click);
            // 
            // buttonTagTr
            // 
            this.buttonTagTr.Location = new System.Drawing.Point(231, 17);
            this.buttonTagTr.Name = "buttonTagTr";
            this.buttonTagTr.Size = new System.Drawing.Size(69, 23);
            this.buttonTagTr.TabIndex = 8;
            this.buttonTagTr.Text = "<tr>";
            this.buttonTagTr.UseVisualStyleBackColor = true;
            this.buttonTagTr.Click += new System.EventHandler(this.buttonTagTr_Click);
            // 
            // buttonTagTd
            // 
            this.buttonTagTd.Location = new System.Drawing.Point(306, 17);
            this.buttonTagTd.Name = "buttonTagTd";
            this.buttonTagTd.Size = new System.Drawing.Size(69, 23);
            this.buttonTagTd.TabIndex = 9;
            this.buttonTagTd.Text = "<td>";
            this.buttonTagTd.UseVisualStyleBackColor = true;
            this.buttonTagTd.Click += new System.EventHandler(this.buttonTagTd_Click);
            // 
            // buttonTagBr
            // 
            this.buttonTagBr.Location = new System.Drawing.Point(381, 17);
            this.buttonTagBr.Name = "buttonTagBr";
            this.buttonTagBr.Size = new System.Drawing.Size(69, 23);
            this.buttonTagBr.TabIndex = 10;
            this.buttonTagBr.Text = "<br>";
            this.buttonTagBr.UseVisualStyleBackColor = true;
            this.buttonTagBr.Click += new System.EventHandler(this.buttonTagBr_Click);
            // 
            // buttonTagHr
            // 
            this.buttonTagHr.Location = new System.Drawing.Point(456, 17);
            this.buttonTagHr.Name = "buttonTagHr";
            this.buttonTagHr.Size = new System.Drawing.Size(69, 23);
            this.buttonTagHr.TabIndex = 11;
            this.buttonTagHr.Text = "<hr>";
            this.buttonTagHr.UseVisualStyleBackColor = true;
            this.buttonTagHr.Click += new System.EventHandler(this.buttonTagHr_Click);
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowyToolStripMenuItem,
            this.otwórzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zamknijToolStripMenuItem,
            this.koniecToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // nowyToolStripMenuItem
            // 
            this.nowyToolStripMenuItem.Name = "nowyToolStripMenuItem";
            this.nowyToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.nowyToolStripMenuItem.Text = "Nowy";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            // 
            // koniecToolStripMenuItem
            // 
            this.koniecToolStripMenuItem.Name = "koniecToolStripMenuItem";
            this.koniecToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.koniecToolStripMenuItem.Text = "Koniec";
            // 
            // edycjaToolStripMenuItem
            // 
            this.edycjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cofnijToolStripMenuItem,
            this.wytnijToolStripMenuItem,
            this.kopiujToolStripMenuItem,
            this.wklejToolStripMenuItem,
            this.usuńToolStripMenuItem,
            this.zaznaczWszystkoToolStripMenuItem});
            this.edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            this.edycjaToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.edycjaToolStripMenuItem.Text = "Edycja";
            // 
            // cofnijToolStripMenuItem
            // 
            this.cofnijToolStripMenuItem.Name = "cofnijToolStripMenuItem";
            this.cofnijToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.cofnijToolStripMenuItem.Text = "Cofnij";
            this.cofnijToolStripMenuItem.Click += new System.EventHandler(this.cofnijToolStripMenuItem_Click);
            // 
            // wytnijToolStripMenuItem
            // 
            this.wytnijToolStripMenuItem.Name = "wytnijToolStripMenuItem";
            this.wytnijToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.wytnijToolStripMenuItem.Text = "Wytnij";
            this.wytnijToolStripMenuItem.Click += new System.EventHandler(this.wytnijToolStripMenuItem_Click);
            // 
            // kopiujToolStripMenuItem
            // 
            this.kopiujToolStripMenuItem.Name = "kopiujToolStripMenuItem";
            this.kopiujToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.kopiujToolStripMenuItem.Text = "Kopiuj";
            this.kopiujToolStripMenuItem.Click += new System.EventHandler(this.kopiujToolStripMenuItem_Click);
            // 
            // wklejToolStripMenuItem
            // 
            this.wklejToolStripMenuItem.Name = "wklejToolStripMenuItem";
            this.wklejToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.wklejToolStripMenuItem.Text = "Wklej";
            this.wklejToolStripMenuItem.Click += new System.EventHandler(this.wklejToolStripMenuItem_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            this.usuńToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.usuńToolStripMenuItem.Text = "Usuń";
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // zaznaczWszystkoToolStripMenuItem
            // 
            this.zaznaczWszystkoToolStripMenuItem.Name = "zaznaczWszystkoToolStripMenuItem";
            this.zaznaczWszystkoToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.zaznaczWszystkoToolStripMenuItem.Text = "Zaznacz wszystko";
            this.zaznaczWszystkoToolStripMenuItem.Click += new System.EventHandler(this.zaznaczWszystkoToolStripMenuItem_Click);
            // 
            // tagHTMLToolStripMenuItem
            // 
            this.tagHTMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bToolStripMenuItem,
            this.iToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.trToolStripMenuItem,
            this.tdToolStripMenuItem,
            this.brToolStripMenuItem,
            this.hrToolStripMenuItem});
            this.tagHTMLToolStripMenuItem.Name = "tagHTMLToolStripMenuItem";
            this.tagHTMLToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.tagHTMLToolStripMenuItem.Text = "Tag HTML";
            this.tagHTMLToolStripMenuItem.Click += new System.EventHandler(this.tagHTMLToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.bToolStripMenuItem.Text = "<b>";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.iToolStripMenuItem.Text = "<i>";
            this.iToolStripMenuItem.Click += new System.EventHandler(this.iToolStripMenuItem_Click);
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.tableToolStripMenuItem.Text = "<table>";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.tableToolStripMenuItem_Click);
            // 
            // trToolStripMenuItem
            // 
            this.trToolStripMenuItem.Name = "trToolStripMenuItem";
            this.trToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.trToolStripMenuItem.Text = "<tr>";
            this.trToolStripMenuItem.Click += new System.EventHandler(this.trToolStripMenuItem_Click);
            // 
            // tdToolStripMenuItem
            // 
            this.tdToolStripMenuItem.Name = "tdToolStripMenuItem";
            this.tdToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.tdToolStripMenuItem.Text = "<td>";
            this.tdToolStripMenuItem.Click += new System.EventHandler(this.tdToolStripMenuItem_Click);
            // 
            // brToolStripMenuItem
            // 
            this.brToolStripMenuItem.Name = "brToolStripMenuItem";
            this.brToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.brToolStripMenuItem.Text = "<br>";
            this.brToolStripMenuItem.Click += new System.EventHandler(this.brToolStripMenuItem_Click);
            // 
            // hrToolStripMenuItem
            // 
            this.hrToolStripMenuItem.Name = "hrToolStripMenuItem";
            this.hrToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.hrToolStripMenuItem.Text = "<hr>";
            this.hrToolStripMenuItem.Click += new System.EventHandler(this.hrToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "html";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Plik HTML (*.html)|*.html|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Wczytaj plik";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 488);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koniecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edycjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cofnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wytnijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopiujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wklejToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaznaczWszystkoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tdToolStripMenuItem;
        private System.Windows.Forms.Button buttonTagHr;
        private System.Windows.Forms.Button buttonTagBr;
        private System.Windows.Forms.Button buttonTagTd;
        private System.Windows.Forms.Button buttonTagTr;
        private System.Windows.Forms.Button buttonTagTable;
        private System.Windows.Forms.Button buttonTagI;
        private System.Windows.Forms.Button buttonTagB;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem brToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hrToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

