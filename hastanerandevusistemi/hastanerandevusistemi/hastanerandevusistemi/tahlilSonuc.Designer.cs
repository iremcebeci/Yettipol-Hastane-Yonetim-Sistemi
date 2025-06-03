namespace hastaneRandevuSistemi
{
    partial class tahlilSonuc
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
            checkBox5 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label5 = new Label();
            label2 = new Label();
            btnTemizle = new Button();
            cmbtahlil = new ComboBox();
            btnKaydet = new Button();
            SuspendLayout();
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(237, 140);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(83, 19);
            checkBox5.TabIndex = 36;
            checkBox5.Tag = "checkbox";
            checkBox5.Text = "checkBox5";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(237, 115);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(83, 19);
            checkBox4.TabIndex = 35;
            checkBox4.Tag = "checkbox";
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(43, 153);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 19);
            checkBox3.TabIndex = 34;
            checkBox3.Tag = "checkbox";
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(43, 128);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(83, 19);
            checkBox2.TabIndex = 33;
            checkBox2.Tag = "checkbox";
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(43, 103);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 32;
            checkBox1.Tag = "checkbox";
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(142, 8);
            label5.Name = "label5";
            label5.Size = new Size(122, 32);
            label5.TabIndex = 31;
            label5.Text = "Tahlil İste";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 47);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 30;
            label2.Text = "Tahlil türü:";
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Navy;
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.ForeColor = Color.FromArgb(254, 190, 4);
            btnTemizle.Location = new Point(237, 190);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(68, 31);
            btnTemizle.TabIndex = 29;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            // 
            // cmbtahlil
            // 
            cmbtahlil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbtahlil.FormattingEnabled = true;
            cmbtahlil.Items.AddRange(new object[] { "Kan Testleri", "İdrar Testleri", "Görüntüleme" });
            cmbtahlil.Location = new Point(43, 65);
            cmbtahlil.Name = "cmbtahlil";
            cmbtahlil.Size = new Size(343, 23);
            cmbtahlil.TabIndex = 28;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.Navy;
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.ForeColor = Color.FromArgb(254, 190, 4);
            btnKaydet.Location = new Point(311, 190);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 31);
            btnKaydet.TabIndex = 27;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            // 
            // tahlilSonuc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(254, 190, 4);
            ClientSize = new Size(429, 229);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnTemizle);
            Controls.Add(cmbtahlil);
            Controls.Add(btnKaydet);
            FormBorderStyle = FormBorderStyle.None;
            Name = "tahlilSonuc";
            StartPosition = FormStartPosition.CenterParent;
            Text = "tahlilSonuc";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label5;
        private Label label2;
        private Button btnTemizle;
        private ComboBox cmbtahlil;
        private Button btnKaydet;
    }
}