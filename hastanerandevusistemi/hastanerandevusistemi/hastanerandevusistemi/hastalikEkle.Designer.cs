namespace hastaneRandevuSistemi
{
    partial class hastalikEkle
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
            label5 = new Label();
            label4 = new Label();
            btnTemizle = new Button();
            rtxtAciklama = new RichTextBox();
            txtHastalikadi = new TextBox();
            label1 = new Label();
            btnKaydet = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(145, 6);
            label5.Name = "label5";
            label5.Size = new Size(158, 32);
            label5.TabIndex = 21;
            label5.Text = "Hastalık Ekle";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 101);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 20;
            label4.Text = "Açıklama:";
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.ForeColor = Color.FromArgb(254, 190, 4);
            btnTemizle.Location = new Point(247, 191);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(68, 31);
            btnTemizle.TabIndex = 17;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // rtxtAciklama
            // 
            rtxtAciklama.BorderStyle = BorderStyle.None;
            rtxtAciklama.Location = new Point(32, 119);
            rtxtAciklama.Name = "rtxtAciklama";
            rtxtAciklama.Size = new Size(364, 66);
            rtxtAciklama.TabIndex = 16;
            rtxtAciklama.Text = "";
            // 
            // txtHastalikadi
            // 
            txtHastalikadi.BorderStyle = BorderStyle.FixedSingle;
            txtHastalikadi.Location = new Point(32, 70);
            txtHastalikadi.Name = "txtHastalikadi";
            txtHastalikadi.Size = new Size(364, 23);
            txtHastalikadi.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 52);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 14;
            label1.Text = "Hastalık adı:";
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.Navy;
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.ForeColor = Color.FromArgb(254, 190, 4);
            btnKaydet.Location = new Point(321, 191);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 31);
            btnKaydet.TabIndex = 11;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // hastalikEkle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 190, 4);
            ClientSize = new Size(429, 229);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnTemizle);
            Controls.Add(rtxtAciklama);
            Controls.Add(txtHastalikadi);
            Controls.Add(label1);
            Controls.Add(btnKaydet);
            FormBorderStyle = FormBorderStyle.None;
            Name = "hastalikEkle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "hastalikEkle";
            Load += hastalikEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Button btnTemizle;
        private RichTextBox rtxtAciklama;
        private TextBox txtHastalikadi;
        private Label label1;
        private Button btnKaydet;
    }
}