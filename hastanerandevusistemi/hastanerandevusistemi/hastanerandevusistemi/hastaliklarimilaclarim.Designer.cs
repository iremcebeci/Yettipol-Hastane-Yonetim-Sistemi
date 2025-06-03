namespace hastaneRandevuSistemi
{
    partial class hastaliklarimilaclarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hastaliklarimilaclarim));
            panel2 = new Panel();
            btnhastalik = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label5 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            btnilac = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label6 = new Label();
            label3 = new Label();
            panel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel2.Controls.Add(btnhastalik);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(label2);
            panel2.ForeColor = SystemColors.ButtonFace;
            panel2.Location = new Point(27, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(623, 266);
            panel2.TabIndex = 6;
            // 
            // btnhastalik
            // 
            btnhastalik.BackColor = Color.Navy;
            btnhastalik.Cursor = Cursors.Hand;
            btnhastalik.Location = new Point(540, 9);
            btnhastalik.Name = "btnhastalik";
            btnhastalik.Size = new Size(71, 23);
            btnhastalik.TabIndex = 5;
            btnhastalik.Text = "+hastalık";
            btnhastalik.UseVisualStyleBackColor = false;
            btnhastalik.Click += btnhastalik_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Transparent;
            flowLayoutPanel2.Controls.Add(label5);
            flowLayoutPanel2.Location = new Point(6, 42);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(605, 204);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.ButtonShadow;
            label5.Location = new Point(155, 80);
            label5.Margin = new Padding(155, 80, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(312, 20);
            label5.TabIndex = 2;
            label5.Text = "Sistemimizde hastalık bilgisi bulunmamaktadır.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(251, 9);
            label2.Name = "label2";
            label2.Size = new Size(117, 30);
            label2.TabIndex = 1;
            label2.Text = "Hastalıklar";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            panel1.Controls.Add(btnilac);
            panel1.Controls.Add(flowLayoutPanel3);
            panel1.Controls.Add(label3);
            panel1.ForeColor = SystemColors.ButtonFace;
            panel1.Location = new Point(27, 295);
            panel1.Name = "panel1";
            panel1.Size = new Size(623, 251);
            panel1.TabIndex = 5;
            // 
            // btnilac
            // 
            btnilac.BackColor = Color.Navy;
            btnilac.Cursor = Cursors.Hand;
            btnilac.Location = new Point(550, 13);
            btnilac.Name = "btnilac";
            btnilac.Size = new Size(61, 23);
            btnilac.TabIndex = 6;
            btnilac.Text = "+ilaç";
            btnilac.UseVisualStyleBackColor = false;
            btnilac.Click += btnilac_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Transparent;
            flowLayoutPanel3.Controls.Add(label6);
            flowLayoutPanel3.Location = new Point(3, 42);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(608, 195);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 162);
            label6.ForeColor = SystemColors.ButtonShadow;
            label6.Location = new Point(155, 80);
            label6.Margin = new Padding(155, 80, 3, 0);
            label6.Name = "label6";
            label6.Size = new Size(300, 20);
            label6.TabIndex = 2;
            label6.Text = "Sistemimizde reçete bilgisi bulunmamaktadır.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(265, 9);
            label3.Name = "label3";
            label3.Size = new Size(72, 30);
            label3.TabIndex = 1;
            label3.Text = "İlaçlar";
            // 
            // hastaliklarimilaclarim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "hastaliklarimilaclarim";
            Size = new Size(685, 561);
            Load += hastaliklarimilaclarim_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label5;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label6;
        private Label label3;
        private Label label2;
        private Button btnhastalik;
        private Button btnilac;
    }
}
