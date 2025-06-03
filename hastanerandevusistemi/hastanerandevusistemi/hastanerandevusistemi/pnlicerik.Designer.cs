namespace hastaneRandevuSistemi
{
    partial class pnlicerik
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pnlicerik));
            panel1 = new Panel();
            btnDevam = new Button();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            radGoruntulu = new RadioButton();
            radHastane = new RadioButton();
            CmbHastane = new ComboBox();
            CmbBolum = new ComboBox();
            label2 = new Label();
            btnTemizle = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnTemizle);
            panel1.Controls.Add(btnDevam);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(radGoruntulu);
            panel1.Controls.Add(radHastane);
            panel1.Controls.Add(CmbHastane);
            panel1.Controls.Add(CmbBolum);
            panel1.Controls.Add(label2);
            panel1.ForeColor = SystemColors.ButtonFace;
            panel1.Location = new Point(107, 51);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 455);
            panel1.TabIndex = 2;
            // 
            // btnDevam
            // 
            btnDevam.BackColor = Color.Navy;
            btnDevam.Cursor = Cursors.Hand;
            btnDevam.Font = new Font("Segoe UI", 11.25F);
            btnDevam.ForeColor = SystemColors.ButtonFace;
            btnDevam.Location = new Point(350, 385);
            btnDevam.Margin = new Padding(3, 4, 3, 4);
            btnDevam.Name = "btnDevam";
            btnDevam.Size = new Size(145, 45);
            btnDevam.TabIndex = 10;
            btnDevam.Text = "Devam et";
            btnDevam.UseVisualStyleBackColor = false;
            btnDevam.Click += btnDevam_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 11.25F);
            label7.Location = new Point(71, 319);
            label7.Name = "label7";
            label7.Size = new Size(371, 40);
            label7.TabIndex = 8;
            label7.Text = "Hastane seçimi zorunlu bir alan değildir. Doktor seçim \r\nsayfasına gitmek için devam et butonuna tıklayınız.\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F);
            label6.Location = new Point(71, 93);
            label6.Name = "label6";
            label6.Size = new Size(329, 20);
            label6.TabIndex = 7;
            label6.Text = "Lütfen randevu almak istediğiniz bölümü seçiniz.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(70, 250);
            label4.Name = "label4";
            label4.Size = new Size(340, 20);
            label4.TabIndex = 6;
            label4.Text = "Lütfen randevu almak istediğiniz hastaneyi seçiniz.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(157, 21);
            label3.Name = "label3";
            label3.Size = new Size(206, 30);
            label3.TabIndex = 5;
            label3.Text = "HIZLI RANDEVU AL";
            // 
            // radGoruntulu
            // 
            radGoruntulu.AutoSize = true;
            radGoruntulu.BackColor = Color.Transparent;
            radGoruntulu.Font = new Font("Segoe UI", 11.25F);
            radGoruntulu.Location = new Point(70, 208);
            radGoruntulu.Margin = new Padding(3, 4, 3, 4);
            radGoruntulu.Name = "radGoruntulu";
            radGoruntulu.Size = new Size(225, 24);
            radGoruntulu.TabIndex = 4;
            radGoruntulu.TabStop = true;
            radGoruntulu.Text = "Görüntülü görüşme randevusu";
            radGoruntulu.UseVisualStyleBackColor = false;
            // 
            // radHastane
            // 
            radHastane.AutoSize = true;
            radHastane.BackColor = Color.Transparent;
            radHastane.Font = new Font("Segoe UI", 11.25F);
            radHastane.ForeColor = SystemColors.ButtonFace;
            radHastane.Location = new Point(301, 208);
            radHastane.Margin = new Padding(3, 4, 3, 4);
            radHastane.Name = "radHastane";
            radHastane.Size = new Size(152, 24);
            radHastane.TabIndex = 3;
            radHastane.TabStop = true;
            radHastane.Text = "Hastane randevusu";
            radHastane.UseVisualStyleBackColor = false;
            // 
            // CmbHastane
            // 
            CmbHastane.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbHastane.FormattingEnabled = true;
            CmbHastane.Location = new Point(71, 287);
            CmbHastane.Margin = new Padding(3, 4, 3, 4);
            CmbHastane.Name = "CmbHastane";
            CmbHastane.Size = new Size(383, 28);
            CmbHastane.TabIndex = 2;
            // 
            // CmbBolum
            // 
            CmbBolum.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbBolum.FormattingEnabled = true;
            CmbBolum.Items.AddRange(new object[] { "Dahiliye (İç Hastalıkları)", "Genel Cerrahi", "Kadın Hastalıkları ve Doğum", "Kardiyoloji (Kalp ve Damar Hastalıkları)", "Kulak Burun Boğaz (KBB)", "Nefroloji", "Nöroloji (Sinir Sistemi Hastalıkları)", "Ortopedi ve Travmatoloji", "Pediatri (Çocuk Sağlığı ve Hastalıkları)", "Psikiyatri", "Plastik, Rekonstüktif ve Estetik Cerrahi" });
            CmbBolum.Location = new Point(71, 126);
            CmbBolum.Margin = new Padding(3, 4, 3, 4);
            CmbBolum.Name = "CmbBolum";
            CmbBolum.Size = new Size(382, 28);
            CmbBolum.TabIndex = 1;
            CmbBolum.SelectedIndexChanged += CmbBolum_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(71, 174);
            label2.Name = "label2";
            label2.Size = new Size(204, 20);
            label2.TabIndex = 0;
            label2.Text = "Lütfen randevu türünü seçiniz.";
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.Font = new Font("Segoe UI", 11.25F);
            btnTemizle.ForeColor = SystemColors.ButtonFace;
            btnTemizle.Location = new Point(199, 385);
            btnTemizle.Margin = new Padding(3, 4, 3, 4);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(145, 45);
            btnTemizle.TabIndex = 11;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // pnlicerik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "pnlicerik";
            Size = new Size(685, 561);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDevam;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private RadioButton radGoruntulu;
        private RadioButton radHastane;
        private ComboBox CmbHastane;
        private ComboBox CmbBolum;
        private Label label2;
        private Button btnTemizle;
    }
}
