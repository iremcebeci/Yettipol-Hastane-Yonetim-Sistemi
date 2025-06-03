namespace hastaneRandevuSistemi
{
    partial class ortopediDoktorlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ortopediDoktorlar));
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblHastane = new Label();
            ok1 = new Label();
            lblBolum = new Label();
            ok2 = new Label();
            lblRandevutipi = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label10 = new Label();
            grpBayrampasa1 = new GroupBox();
            label3 = new Label();
            pictureBox3 = new PictureBox();
            button3 = new Button();
            grpBayrampasa2 = new GroupBox();
            label4 = new Label();
            pictureBox4 = new PictureBox();
            button4 = new Button();
            grpSariyer1 = new GroupBox();
            label5 = new Label();
            pictureBox5 = new PictureBox();
            button5 = new Button();
            grpSariyer2 = new GroupBox();
            label6 = new Label();
            pictureBox6 = new PictureBox();
            button6 = new Button();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            grpBayrampasa1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            grpBayrampasa2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            grpSariyer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            grpSariyer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.FromArgb(44, 62, 80);
            flowLayoutPanel2.Controls.Add(lblHastane);
            flowLayoutPanel2.Controls.Add(ok1);
            flowLayoutPanel2.Controls.Add(lblBolum);
            flowLayoutPanel2.Controls.Add(ok2);
            flowLayoutPanel2.Controls.Add(lblRandevutipi);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(685, 75);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // lblHastane
            // 
            lblHastane.AutoSize = true;
            lblHastane.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHastane.ForeColor = SystemColors.ButtonFace;
            lblHastane.Location = new Point(20, 10);
            lblHastane.Margin = new Padding(20, 10, 0, 0);
            lblHastane.Name = "lblHastane";
            lblHastane.Size = new Size(114, 20);
            lblHastane.TabIndex = 2;
            lblHastane.Text = "Seçilen Hastane";
            lblHastane.Click += lblHastane_Click;
            // 
            // ok1
            // 
            ok1.AutoSize = true;
            ok1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok1.ForeColor = SystemColors.ButtonFace;
            ok1.Location = new Point(154, 10);
            ok1.Margin = new Padding(20, 10, 3, 0);
            ok1.Name = "ok1";
            ok1.Size = new Size(31, 20);
            ok1.TabIndex = 1;
            ok1.Text = "-->";
            // 
            // lblBolum
            // 
            lblBolum.AutoSize = true;
            lblBolum.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBolum.ForeColor = SystemColors.ButtonFace;
            lblBolum.Location = new Point(208, 10);
            lblBolum.Margin = new Padding(20, 10, 0, 0);
            lblBolum.Name = "lblBolum";
            lblBolum.Size = new Size(103, 20);
            lblBolum.TabIndex = 0;
            lblBolum.Text = "Seçilen Bölüm";
            lblBolum.Click += lblHastane_Click;
            // 
            // ok2
            // 
            ok2.AutoSize = true;
            ok2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ok2.ForeColor = SystemColors.ButtonFace;
            ok2.Location = new Point(331, 10);
            ok2.Margin = new Padding(20, 10, 3, 0);
            ok2.Name = "ok2";
            ok2.Size = new Size(31, 20);
            ok2.TabIndex = 3;
            ok2.Text = "-->";
            // 
            // lblRandevutipi
            // 
            lblRandevutipi.AutoSize = true;
            lblRandevutipi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblRandevutipi.ForeColor = SystemColors.ButtonFace;
            lblRandevutipi.Location = new Point(385, 10);
            lblRandevutipi.Margin = new Padding(20, 10, 0, 0);
            lblRandevutipi.Name = "lblRandevutipi";
            lblRandevutipi.Size = new Size(146, 20);
            lblRandevutipi.TabIndex = 4;
            lblRandevutipi.Text = "Seçilen Randevu Tipi";
            lblRandevutipi.Click += lblHastane_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(200, 0, 0, 0);
            flowLayoutPanel1.Controls.Add(label10);
            flowLayoutPanel1.Controls.Add(grpBayrampasa1);
            flowLayoutPanel1.Controls.Add(grpBayrampasa2);
            flowLayoutPanel1.Controls.Add(grpSariyer1);
            flowLayoutPanel1.Controls.Add(grpSariyer2);
            flowLayoutPanel1.Location = new Point(57, 99);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(576, 445);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label10.ForeColor = SystemColors.ButtonFace;
            label10.Location = new Point(13, 10);
            label10.Margin = new Padding(13, 10, 130, 20);
            label10.Name = "label10";
            label10.Size = new Size(366, 25);
            label10.TabIndex = 7;
            label10.Text = "Lütfen randevu alacağınız doktoru seçiniz.";
            // 
            // grpBayrampasa1
            // 
            grpBayrampasa1.BackColor = Color.White;
            grpBayrampasa1.Controls.Add(label3);
            grpBayrampasa1.Controls.Add(pictureBox3);
            grpBayrampasa1.Controls.Add(button3);
            grpBayrampasa1.Location = new Point(10, 58);
            grpBayrampasa1.Margin = new Padding(10, 3, 10, 10);
            grpBayrampasa1.Name = "grpBayrampasa1";
            grpBayrampasa1.Size = new Size(161, 178);
            grpBayrampasa1.TabIndex = 3;
            grpBayrampasa1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(23, 10);
            label3.Name = "label3";
            label3.Size = new Size(114, 20);
            label3.TabIndex = 2;
            label3.Text = "Dr. Owen HUNT";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(31, 33);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 99);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // button3
            // 
            button3.Location = new Point(31, 138);
            button3.Name = "button3";
            button3.Size = new Size(100, 34);
            button3.TabIndex = 0;
            button3.Text = "Randevu al";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DoktorButon_Click;
            // 
            // grpBayrampasa2
            // 
            grpBayrampasa2.BackColor = Color.White;
            grpBayrampasa2.Controls.Add(label4);
            grpBayrampasa2.Controls.Add(pictureBox4);
            grpBayrampasa2.Controls.Add(button4);
            grpBayrampasa2.Location = new Point(191, 58);
            grpBayrampasa2.Margin = new Padding(10, 3, 10, 10);
            grpBayrampasa2.Name = "grpBayrampasa2";
            grpBayrampasa2.Size = new Size(161, 178);
            grpBayrampasa2.TabIndex = 4;
            grpBayrampasa2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(18, 10);
            label4.Name = "label4";
            label4.Size = new Size(125, 20);
            label4.TabIndex = 2;
            label4.Text = "Dr. Callie TORRES";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(31, 33);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 99);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(31, 138);
            button4.Name = "button4";
            button4.Size = new Size(100, 34);
            button4.TabIndex = 0;
            button4.Text = "Randevu al";
            button4.UseVisualStyleBackColor = true;
            button4.Click += DoktorButon_Click;
            // 
            // grpSariyer1
            // 
            grpSariyer1.BackColor = Color.White;
            grpSariyer1.Controls.Add(label5);
            grpSariyer1.Controls.Add(pictureBox5);
            grpSariyer1.Controls.Add(button5);
            grpSariyer1.Location = new Point(372, 58);
            grpSariyer1.Margin = new Padding(10, 3, 10, 10);
            grpSariyer1.Name = "grpSariyer1";
            grpSariyer1.Size = new Size(161, 178);
            grpSariyer1.TabIndex = 5;
            grpSariyer1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.Location = new Point(21, 10);
            label5.Name = "label5";
            label5.Size = new Size(119, 20);
            label5.TabIndex = 2;
            label5.Text = "Dr. Eylül DİNÇER";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(31, 33);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(100, 99);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            // 
            // button5
            // 
            button5.Location = new Point(31, 138);
            button5.Name = "button5";
            button5.Size = new Size(100, 34);
            button5.TabIndex = 0;
            button5.Text = "Randevu al";
            button5.UseVisualStyleBackColor = true;
            button5.Click += DoktorButon_Click;
            // 
            // grpSariyer2
            // 
            grpSariyer2.BackColor = Color.White;
            grpSariyer2.Controls.Add(label6);
            grpSariyer2.Controls.Add(pictureBox6);
            grpSariyer2.Controls.Add(button6);
            grpSariyer2.Location = new Point(10, 249);
            grpSariyer2.Margin = new Padding(10, 3, 10, 10);
            grpSariyer2.Name = "grpSariyer2";
            grpSariyer2.Size = new Size(161, 178);
            grpSariyer2.TabIndex = 6;
            grpSariyer2.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.Location = new Point(24, 10);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 2;
            label6.Text = "Dr. Bahar TUNÇ";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(31, 33);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(100, 99);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 1;
            pictureBox6.TabStop = false;
            // 
            // button6
            // 
            button6.Location = new Point(31, 138);
            button6.Name = "button6";
            button6.Size = new Size(100, 34);
            button6.TabIndex = 0;
            button6.Text = "Randevu al";
            button6.UseVisualStyleBackColor = true;
            button6.Click += DoktorButon_Click;
            // 
            // ortopediDoktorlar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(flowLayoutPanel2);
            Name = "ortopediDoktorlar";
            Size = new Size(685, 561);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            grpBayrampasa1.ResumeLayout(false);
            grpBayrampasa1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            grpBayrampasa2.ResumeLayout(false);
            grpBayrampasa2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            grpSariyer1.ResumeLayout(false);
            grpSariyer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            grpSariyer2.ResumeLayout(false);
            grpSariyer2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblHastane;
        private Label ok1;
        private Label lblBolum;
        private Label ok2;
        private Label lblRandevutipi;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label10;
        private GroupBox grpBayrampasa1;
        private Label label3;
        private PictureBox pictureBox3;
        private Button button3;
        private GroupBox grpBayrampasa2;
        private Label label4;
        private PictureBox pictureBox4;
        private Button button4;
        private GroupBox grpSariyer1;
        private Label label5;
        private PictureBox pictureBox5;
        private Button button5;
        private GroupBox grpSariyer2;
        private Label label6;
        private PictureBox pictureBox6;
        private Button button6;
    }
}
