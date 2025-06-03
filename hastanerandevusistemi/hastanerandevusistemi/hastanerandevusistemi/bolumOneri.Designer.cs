namespace hastaneRandevuSistemi
{
    partial class bolumOneri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bolumOneri));
            panel3 = new Panel();
            lblHastalik = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel3.Controls.Add(lblHastalik);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.ForeColor = SystemColors.ButtonFace;
            panel3.Location = new Point(30, 33);
            panel3.Name = "panel3";
            panel3.Size = new Size(625, 494);
            panel3.TabIndex = 10;
            // 
            // lblHastalik
            // 
            lblHastalik.AutoSize = true;
            lblHastalik.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHastalik.Location = new Point(32, 53);
            lblHastalik.Name = "lblHastalik";
            lblHastalik.Size = new Size(0, 21);
            lblHastalik.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(32, 77);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(553, 400);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // bolumOneri
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel3);
            Name = "bolumOneri";
            Size = new Size(685, 561);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Label lblHastalik;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
