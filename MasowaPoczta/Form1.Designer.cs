namespace MasowaPoczta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.listBoxAdresy = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSerwer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxTemat = new System.Windows.Forms.TextBox();
            this.listBoxZalaczniki = new System.Windows.Forms.ListBox();
            this.buttonZalacz = new System.Windows.Forms.Button();
            this.buttonWyslij = new System.Windows.Forms.Button();
            this.textBoxList = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxNadawca = new System.Windows.Forms.TextBox();
            this.labelNadawca = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDodaj);
            this.groupBox1.Controls.Add(this.textBoxAdres);
            this.groupBox1.Controls.Add(this.listBoxAdresy);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.Location = new System.Drawing.Point(49, 397);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(75, 23);
            this.buttonDodaj.TabIndex = 2;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(7, 369);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(160, 20);
            this.textBoxAdres.TabIndex = 1;
            // 
            // listBoxAdresy
            // 
            this.listBoxAdresy.FormattingEnabled = true;
            this.listBoxAdresy.Location = new System.Drawing.Point(7, 20);
            this.listBoxAdresy.Name = "listBoxAdresy";
            this.listBoxAdresy.Size = new System.Drawing.Size(160, 342);
            this.listBoxAdresy.TabIndex = 0;
            this.listBoxAdresy.DoubleClick += new System.EventHandler(this.listBoxAdresy_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serwer SMTP";
            // 
            // textBoxSerwer
            // 
            this.textBoxSerwer.Location = new System.Drawing.Point(195, 48);
            this.textBoxSerwer.Name = "textBoxSerwer";
            this.textBoxSerwer.Size = new System.Drawing.Size(176, 20);
            this.textBoxSerwer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "login:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "hasło:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Temat:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(251, 75);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(120, 20);
            this.textBoxLogin.TabIndex = 6;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(251, 102);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(120, 20);
            this.textBoxPass.TabIndex = 7;
            // 
            // textBoxTemat
            // 
            this.textBoxTemat.Location = new System.Drawing.Point(195, 176);
            this.textBoxTemat.Name = "textBoxTemat";
            this.textBoxTemat.Size = new System.Drawing.Size(176, 20);
            this.textBoxTemat.TabIndex = 8;
            // 
            // listBoxZalaczniki
            // 
            this.listBoxZalaczniki.FormattingEnabled = true;
            this.listBoxZalaczniki.HorizontalScrollbar = true;
            this.listBoxZalaczniki.Location = new System.Drawing.Point(195, 203);
            this.listBoxZalaczniki.Name = "listBoxZalaczniki";
            this.listBoxZalaczniki.Size = new System.Drawing.Size(120, 95);
            this.listBoxZalaczniki.TabIndex = 9;
            // 
            // buttonZalacz
            // 
            this.buttonZalacz.Location = new System.Drawing.Point(322, 239);
            this.buttonZalacz.Name = "buttonZalacz";
            this.buttonZalacz.Size = new System.Drawing.Size(49, 23);
            this.buttonZalacz.TabIndex = 10;
            this.buttonZalacz.Text = "...";
            this.buttonZalacz.UseVisualStyleBackColor = true;
            this.buttonZalacz.Click += new System.EventHandler(this.buttonZalacz_Click);
            // 
            // buttonWyslij
            // 
            this.buttonWyslij.Location = new System.Drawing.Point(251, 425);
            this.buttonWyslij.Name = "buttonWyslij";
            this.buttonWyslij.Size = new System.Drawing.Size(75, 23);
            this.buttonWyslij.TabIndex = 11;
            this.buttonWyslij.Text = "Wyślij";
            this.buttonWyslij.UseVisualStyleBackColor = true;
            this.buttonWyslij.Click += new System.EventHandler(this.buttonWyslij_Click);
            // 
            // textBoxList
            // 
            this.textBoxList.Location = new System.Drawing.Point(195, 307);
            this.textBoxList.Multiline = true;
            this.textBoxList.Name = "textBoxList";
            this.textBoxList.Size = new System.Drawing.Size(176, 112);
            this.textBoxList.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxNadawca
            // 
            this.textBoxNadawca.Location = new System.Drawing.Point(251, 131);
            this.textBoxNadawca.Name = "textBoxNadawca";
            this.textBoxNadawca.Size = new System.Drawing.Size(120, 20);
            this.textBoxNadawca.TabIndex = 14;
            // 
            // labelNadawca
            // 
            this.labelNadawca.AutoSize = true;
            this.labelNadawca.Location = new System.Drawing.Point(198, 134);
            this.labelNadawca.Name = "labelNadawca";
            this.labelNadawca.Size = new System.Drawing.Size(56, 13);
            this.labelNadawca.TabIndex = 13;
            this.labelNadawca.Text = "Nadawca:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 466);
            this.Controls.Add(this.textBoxNadawca);
            this.Controls.Add(this.labelNadawca);
            this.Controls.Add(this.textBoxList);
            this.Controls.Add(this.buttonWyslij);
            this.Controls.Add(this.buttonZalacz);
            this.Controls.Add(this.listBoxZalaczniki);
            this.Controls.Add(this.textBoxTemat);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSerwer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.ListBox listBoxAdresy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSerwer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxTemat;
        private System.Windows.Forms.ListBox listBoxZalaczniki;
        private System.Windows.Forms.Button buttonZalacz;
        private System.Windows.Forms.Button buttonWyslij;
        private System.Windows.Forms.TextBox textBoxList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxNadawca;
        private System.Windows.Forms.Label labelNadawca;
    }
}

