namespace hastaneRandevuSistemi
{
    partial class dokGelecekrandevular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dokGelecekrandevular));
            pnlBugun = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblilk = new Label();
            lblson = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblRandevu = new Label();
            pnlBugun.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBugun
            // 
            pnlBugun.BackColor = Color.FromArgb(200, 0, 0, 0);
            pnlBugun.Controls.Add(flowLayoutPanel2);
            pnlBugun.Controls.Add(label1);
            pnlBugun.Controls.Add(flowLayoutPanel1);
            pnlBugun.ForeColor = SystemColors.ButtonFace;
            pnlBugun.Location = new Point(25, 39);
            pnlBugun.Name = "pnlBugun";
            pnlBugun.Size = new Size(637, 483);
            pnlBugun.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(lblilk);
            flowLayoutPanel2.Controls.Add(lblson);
            flowLayoutPanel2.Location = new Point(286, 442);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(64, 32);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // lblilk
            // 
            lblilk.AutoSize = true;
            lblilk.Location = new Point(13, 10);
            lblilk.Margin = new Padding(13, 10, 3, 0);
            lblilk.Name = "lblilk";
            lblilk.Size = new Size(13, 15);
            lblilk.TabIndex = 6;
            lblilk.Text = "1";
            // 
            // lblson
            // 
            lblson.AutoSize = true;
            lblson.Location = new Point(42, 10);
            lblson.Margin = new Padding(13, 10, 3, 0);
            lblson.Name = "lblson";
            lblson.Size = new Size(13, 15);
            lblson.TabIndex = 5;
            lblson.Text = "2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(197, 9);
            label1.Name = "label1";
            label1.Size = new Size(239, 32);
            label1.TabIndex = 0;
            label1.Text = "Gelecek Randevular";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(lblRandevu);
            flowLayoutPanel1.Location = new Point(14, 44);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(610, 374);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // lblRandevu
            // 
            lblRandevu.AutoSize = true;
            lblRandevu.BackColor = Color.Transparent;
            lblRandevu.Location = new Point(3, 0);
            lblRandevu.Name = "lblRandevu";
            lblRandevu.Size = new Size(231, 15);
            lblRandevu.TabIndex = 1;
            lblRandevu.Text = "Henüz aktif bir randevu bulunmamaktadır.";
            // 
            // dokGelecekrandevular
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pnlBugun);
            Name = "dokGelecekrandevular";
            Size = new Size(685, 561);
            Load += dokGelecekrandevular_Load;
            pnlBugun.ResumeLayout(false);
            pnlBugun.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBugun;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblilk;
        private Label lblson;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblRandevu;
    }
}
