namespace hastaneRandevuSistemi
{
    partial class receteEkle
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
            btnKaydet = new Button();
            cmbSıklık = new ComboBox();
            cmbDoz = new ComboBox();
            label1 = new Label();
            txtIlacadi = new TextBox();
            rtxtAciklama = new RichTextBox();
            btnTemizle = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.Navy;
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.ForeColor = Color.FromArgb(254, 190, 4);
            btnKaydet.Location = new Point(321, 194);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 31);
            btnKaydet.TabIndex = 0;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // cmbSıklık
            // 
            cmbSıklık.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSıklık.FormattingEnabled = true;
            cmbSıklık.Items.AddRange(new object[] { "", "Gün", "Hafta", "Ay" });
            cmbSıklık.Location = new Point(167, 73);
            cmbSıklık.Name = "cmbSıklık";
            cmbSıklık.Size = new Size(112, 23);
            cmbSıklık.TabIndex = 1;
            // 
            // cmbDoz
            // 
            cmbDoz.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDoz.FormattingEnabled = true;
            cmbDoz.Items.AddRange(new object[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbDoz.Location = new Point(296, 73);
            cmbDoz.Name = "cmbDoz";
            cmbDoz.Size = new Size(100, 23);
            cmbDoz.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 55);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "İlaç adı:";
            // 
            // txtIlacadi
            // 
            txtIlacadi.BorderStyle = BorderStyle.FixedSingle;
            txtIlacadi.Location = new Point(32, 73);
            txtIlacadi.Name = "txtIlacadi";
            txtIlacadi.Size = new Size(117, 23);
            txtIlacadi.TabIndex = 4;
            // 
            // rtxtAciklama
            // 
            rtxtAciklama.BorderStyle = BorderStyle.None;
            rtxtAciklama.Location = new Point(32, 122);
            rtxtAciklama.Name = "rtxtAciklama";
            rtxtAciklama.Size = new Size(364, 66);
            rtxtAciklama.TabIndex = 5;
            rtxtAciklama.Text = "";
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.ForeColor = Color.FromArgb(254, 190, 4);
            btnTemizle.Location = new Point(247, 194);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(68, 31);
            btnTemizle.TabIndex = 6;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 55);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 7;
            label2.Text = "Sıklık:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(298, 55);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 8;
            label3.Text = "Doz:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 104);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 9;
            label4.Text = "Açıklama:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(145, 9);
            label5.Name = "label5";
            label5.Size = new Size(134, 32);
            label5.TabIndex = 10;
            label5.Text = "Reçete Yaz";
            // 
            // receteEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(254, 190, 4);
            ClientSize = new Size(429, 229);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnTemizle);
            Controls.Add(rtxtAciklama);
            Controls.Add(txtIlacadi);
            Controls.Add(label1);
            Controls.Add(cmbDoz);
            Controls.Add(cmbSıklık);
            Controls.Add(btnKaydet);
            FormBorderStyle = FormBorderStyle.None;
            Name = "receteEkle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "receteEkle";
            Load += receteEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKaydet;
        private ComboBox cmbSıklık;
        private ComboBox cmbDoz;
        private Label label1;
        private TextBox txtIlacadi;
        private RichTextBox rtxtAciklama;
        private Button btnTemizle;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}