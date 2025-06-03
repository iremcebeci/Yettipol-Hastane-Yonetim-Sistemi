using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastaneRandevuSistemi
{
    public partial class bolumOneri : UserControl
    {
        public bolumOneri(string hastalikTahmini, List<KeyValuePair<string, int>> kesinBolumler, List<KeyValuePair<string, int>> olasiBolumler)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(hastalikTahmini))
            {
                lblHastalik.Text = $"⚠️ Tahmini Hastalık: {hastalikTahmini}";
            }

            foreach (var item in kesinBolumler)
                PanelBolumOlustur(item.Key, item.Value, true);

            foreach (var item in olasiBolumler)
                PanelBolumOlustur(item.Key, item.Value, false);
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        private void PanelBolumOlustur(string bolumAdi, int puan, bool kesin)
        {
            var panel = new Panel
            {
                Width = 480,
                Height = 60,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            var label = new Label
            {
                Text = $"{(kesin ? "Kesin" : "Olası")} Bölüm: {bolumAdi} ({puan} puan)",
                Location = new Point(10, 20),
                AutoSize = true
            };

            var button = new Button
            {
                Text = "Randevu Al",
                Location = new Point(370, 15),
                Width = 90,
                Height = 30,
                Tag = bolumAdi,
                BackColor = Color.Navy,
            };
            button.Click += RandevuAl_Click;

            panel.Controls.Add(label);
            panel.Controls.Add(button);
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void RandevuAl_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string bolumAdi = btn.Tag.ToString().ToLower(); // Bölüm adı

            UserControl uc = null;

            switch (bolumAdi)
            {
                case "dahiliye":
                    uc = new dahiliyeDoktorlar(bolumAdi); break;
                case "kardiyoloji":
                    uc = new kardiyolojiDoktorlar(bolumAdi); break;
                case "kadın hastalıkları ve doğum":
                    uc = new kadınHastDoktorlar(bolumAdi); break;
                case "kulak burun boğaz (kbb)":
                    uc = new KBBDoktorlar(bolumAdi); break;
                case "nefroloji":
                    uc = new nefrolojiDoktorlar(bolumAdi); break;
                case "nöroloji":
                    uc = new norolojiDoktorlar(bolumAdi); break;
                case "ortopedi ve travmatoloji":
                    uc = new ortopediDoktorlar(bolumAdi); break;
                case "psikiyatri":
                    uc = new psikiyatriDoktorlar(bolumAdi); break;
                default:
                    MessageBox.Show("Bu bölüm için randevu sayfası tanımlı değil.");
                    return;
            }

            if (uc != null)
            {
                LoadUserControlIcerik(uc);
            }
            else
            {
                return;
            }
        }
    }
}