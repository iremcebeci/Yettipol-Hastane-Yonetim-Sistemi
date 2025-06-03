using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hastaneRandevuSistemi
{
    public partial class sonucEkle : UserControl
    {
        private string connectionString = "server=localhost;database = yettipol;uid=root;password='141002';";
        int tahlil_id;
        public sonucEkle(int tahlilId)
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int tahlilId = this.tahlil_id; 
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is NumericUpDown num && num.Tag != null)
                    {
                        string parametreIsmi = num.Tag.ToString();
                        decimal deger = num.Value;

                        var getIdCmd = new MySqlCommand("SELECT id FROM parametreler WHERE isim = @isim LIMIT 1", conn);
                        getIdCmd.Parameters.AddWithValue("@isim", parametreIsmi);
                        object result = getIdCmd.ExecuteScalar();

                        var getTahlilTuruCmd = new MySqlCommand("SELECT id FROM parametreler WHERE isim = @isim LIMIT 1", conn);
                        getIdCmd.Parameters.AddWithValue("@isim", parametreIsmi);
                        object results = getIdCmd.ExecuteScalar();

                        if (result != null || results != null)
                        {
                            int parametreId = Convert.ToInt32(result);
                            int tah_tur_id = Convert.ToInt32(results);

                            var insertCmd = new MySqlCommand("INSERT INTO tahlil_sonuclari (parametre_id, hasta_id, deger) VALUES (@pid, @tid, @val)", conn);
                            insertCmd.Parameters.AddWithValue("@pid", parametreId);
                            insertCmd.Parameters.AddWithValue("@tid", tahlilId);
                            insertCmd.Parameters.AddWithValue("@val", deger);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                conn.Close();
            }

            MessageBox.Show("Tahlil sonuçları başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
