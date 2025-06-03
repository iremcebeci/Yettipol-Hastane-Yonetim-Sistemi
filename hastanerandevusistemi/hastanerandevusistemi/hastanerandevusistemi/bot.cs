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
    public partial class bot : UserControl
    {
        public bot()
        {
            InitializeComponent();
        }
        private void LoadUserControlIcerik(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Right;
            this.Controls.Add(uc);
        }
        Dictionary<string, Dictionary<string, int>> bolumskorlari = new Dictionary<string, Dictionary<string, int>>
        {
            { "Dahiliye", new Dictionary<string, int>
                {
                    { "halsizlik", 3 },
                    { "baş dönmesi", 3 },
                    { "mide yanması", 3 },
                    { "yorgunluk", 3 },
                    { "bitkinlik", 3 },
                    { "yüksek ateş", 2 },
                    { "titreme", 1 },
                    { "terleme", 1 },
                    { "kabızlık", 2 },
                    { "ishal", 2 },
                    { "iştahsızlık", 2 },
                    { "sebebsiz kilo kaybı", 3 },
                    { "idrar miktarında azalma", 2 },
                    { "idrarında yanma", 3 },
                    { "idrarında kan görme", 4 },
                    { "çok sık tuvalete çıkma", 3 },
                    { "yüksek tansiyon", 4 },
                    { "nefes darlığı", 3 },
                    { "ani nefes daralması", 4 },
                    { "kalp çarpıntısı", 3 },
                    { "bacaklarda şişlik", 2 },
                    { "bacakta ağrı", 2 },
                    { "göz altlarında şişlik", 2 },
                    { "yüzde ağrı", 2 }
                }
            },
            { "Kadın Hastalıkları ve Doğum", new Dictionary<string, int>
                {
                    { "adet düzensizliği", 4 },
                    { "adet gecikmesi", 4 },
                    { "aşırı adet kanaması", 4 },
                    { "aşırı ağrı", 3 },
                    { "alt karın ağrısı", 3 },
                    { "karında şişkinlik", 2 },
                    { "yorgunluk", 2 }
                }
            },
            { "Kardiyoloji", new Dictionary<string, int>
                {
                    { "göğüs ağrısı", 4 },
                    { "göğüs sıkışması", 4 },
                    { "kalp çarpıntısı", 4 },
                    { "ani nefes daralması", 4 },
                    { "bacaklarda şişlik", 3 },
                    { "bacakta ağrı", 2 },
                    { "bayılma", 3 },
                    { "baş dönmesi", 3 },
                    { "yüksek tansiyon", 4 }
                }
            },
            { "Kulak Burun Boğaz (KBB)", new Dictionary<string, int>
                {
                    { "burun tıkanıklığı", 3 },
                    { "burun kanaması", 3 },
                    { "boğaz ağrısı", 3 },
                    { "boğazda yanma", 3 },
                    { "boğazda batma", 3 },
                    { "kulak ağrısı", 3 },
                    { "kulak çınlaması", 3 },
                    { "geniz akıntısı", 3 },
                    { "ses kısıklığı", 3 },
                    { "burun akıntısı", 3 },
                    { "yutkunurken zorlanma", 3 }
                }
            },
            { "Nefroloji", new Dictionary<string, int>
                {
                    { "idrarında kan görme", 4 },
                    { "idrarında yanma", 4 },
                    { "çok sık tuvalete çıkma", 3 },
                    { "idrar miktarında azalma", 3 },
                    { "bacaklarda şişlik", 3 },
                    { "bitkinlik", 2 },
                    { "yüksek tansiyon", 3 },
                    { "göz altlarında şişlik", 3 }
                }
            },
            { "Nöroloji", new Dictionary<string, int>
                {
                    { "baş ağrısı", 4 },
                    { "baş dönmesi", 3 },
                    { "denge kaybı", 4 },
                    { "bilinç kaybı", 4 },
                    { "vücudun bir tarafında güçsüzlük", 4 },
                    { "konuşma bozukluğu", 4 },
                    { "kaslarda seğirme", 2 },
                    { "kas zayıflığı", 3 },
                    { "görme bozukluğu", 3 },
                    { "ışığa hassasiyet", 2 },
                    { "hafıza problemleri", 3 },
                    { "boyun sertliği", 3 }
                }
            },
            { "Ortopedi ve Travmatoloji", new Dictionary<string, int>
                {
                    { "dizde ağrı", 3 },
                    { "dizlerde zorlanma", 3 },
                    { "belden bacağa vuran ağrı", 3 },
                    { "eklemde şişlik ve tutulma", 3 },
                    { "kas ağrısı", 3 },
                    { "kemik ağrısı", 3 },
                    { "kol veya bacakta ağrı", 3 },
                    { "hareket kısıtlılığı", 4 },
                    { "oturup kalkarken dizlerde zorlanma", 3 },
                    { "yürümede zorluk", 3 }
                }
            },
            { "Psikiyatri", new Dictionary<string, int>
                {
                    { "aşırı stres", 4 },
                    { "sürekli mutsuzluk", 4 },
                    { "uyku bozukluğu", 4 },
                    { "sinirlilik", 3 },
                    { "ölüm korkusu", 3 },
                    { "yorgunluk", 3 },
                    { "bitkinlik", 3 },
                    { "halsizlik", 2 },
                    { "hafıza problemleri", 2 }
                }
            }
        };
        // Hastalıklar örneği
        Dictionary<string, (List<string> semptomlar, string bolum)> hastaliklar = new Dictionary<string, (List<string>, string)>
        {
            { "Gastrit", (new List<string> { "mide yanması", "iştahsızlık", "karında şişkinlik" }, "Dahiliye") },
            { "Reflü", (new List<string> { "mide yanması", "boğazda yanma", "ağız kuruluğu" }, "Dahiliye") },
            { "Kabızlık", (new List<string> { "kabızlık", "karında şişkinlik" }, "Dahiliye") },
            { "İrritabl Bağırsak Sendromu", (new List<string> { "ishal", "karında şişkinlik", "ağız kuruluğu" }, "Dahiliye") },
            { "Anemi", (new List<string> { "halsizlik", "bitkinlik", "terleme", "baş dönmesi" }, "Dahiliye") },
            { "Hipotiroidi", (new List<string> { "halsizlik", "kabızlık", "ağız kuruluğu", "soğuk hissetme" }, "Dahiliye") },
            { "Polikistik Over Sendromu", (new List<string> { "adet düzensizliği", "aşırı adet kanaması", "alt karın ağrısı" }, "Kadın Hastalıkları ve Doğum") },
            { "Dismenore", (new List<string> { "alt karın ağrısı", "adet düzensizliği" }, "Kadın Hastalıkları ve Doğum") },
            { "Miyom", (new List<string> { "aşırı adet kanaması", "adet düzensizliği" }, "Kadın Hastalıkları ve Doğum") },
            { "Kalp Yetmezliği", (new List<string> { "nefes darlığı", "bacaklarda şişlik", "göğüs ağrısı", "terleme" }, "Kardiyoloji") },
            { "Aritmi", (new List<string> { "kalp çarpıntısı", "bayılma", "baş dönmesi" }, "Kardiyoloji") },
            { "Angina", (new List<string> { "göğüs ağrısı", "nefes darlığı" }, "Kardiyoloji") },
            { "KBB Enfeksiyonu", (new List<string> { "boğazda yanma", "ses kısıklığı", "yutkunurken zorlanma" }, "Kulak Burun Boğaz") },
            { "Sinüzit", (new List<string> { "baş ağrısı", "geniz akıntısı", "burun tıkanıklığı" }, "Kulak Burun Boğaz") },
            { "Orta Kulak İltihabı", (new List<string> { "kulak ağrısı", "kulak çınlaması", "baş dönmesi" }, "Kulak Burun Boğaz") },
            { "Ses Teli Nodülü", (new List<string> { "ses kısıklığı", "boğazda batma" }, "Kulak Burun Boğaz") },
            { "İdrar Yolu Enfeksiyonu", (new List<string> { "idrarda yanma", "çok sık tuvalete çıkma", "idrarda kan görme" }, "Nefroloji") },
            { "Böbrek Taşı", (new List<string> { "idrarda yanma", "aşırı ağrı", "idrarda kan görme" }, "Nefroloji") },
            { "Glomerülonefrit", (new List<string> { "idrarda kan görme", "göz altlarında şişlik", "yüksek tansiyon" }, "Nefroloji") },
            { "Epilepsi", (new List<string> { "bayılma", "kaslarda seğirme", "bilinç kaybı" }, "Nöroloji") },
            { "Multipl Skleroz", (new List<string> { "el veya ayakta uyuşma", "gözlerde geçici kararma", "konuşma bozukluğu" }, "Nöroloji") },
            { "Parkinson Hastalığı", (new List<string> { "vücut titremesi", "kaslarda seğirme", "hareket kısıtlılığı" }, "Nöroloji") },
            { "Bel Fıtığı", (new List<string> { "belden bacağa vuran ağrı", "yürümede zorluk", "bacakta ağrı" }, "Ortopedi ve Travmatoloji") },
            { "Menisküs Yırtığı", (new List<string> { "dizde ağrı", "dizlerde zorlanma", "yürümede zorluk" }, "Ortopedi ve Travmatoloji") },
            { "Karpal Tünel Sendromu", (new List<string> { "el ve ayakta uyuşma", "Kol veya bacakta ağrı", "kas zayıflığı" }, "Ortopedi ve Travmatoloji") },
            { "Romatoid Artrit", (new List<string> { "eklemde şişlik ve tutulma"}, "Ortopedi ve Travmatoloji") },
            { "Depresyon", (new List<string> { "sürekli mutsuzluk", "uyku bozukluğu", "iştahsızlık", "sinirlilik" }, "Psikiyatri") },
            { "Anksiyete Bozukluğu", (new List<string> { "aşırı stres", "kalp çarpıntısı", "ani nefes daralması" }, "Psikiyatri") },
            { "Panik Atak", (new List<string> { "kalp çarpıntısı", "nefes darlığı", "bayılma hissi", "ölüm korkusu"}, "Psikiyatri") },
            { "Endometriozis", (new List<string> { "alt karın ağrısı", "aşırı adet kanaması" }, "Kadın Hastalıkları ve Doğum") },
            { "Tiroid Yetmezliği", (new List<string> { "halsizlik", "kabızlık", "ağız kuruluğu" }, "Dahiliye") },
            { "Vertigo", (new List<string> { "baş dönmesi", "Gözlerde geçici kararma", "denge kaybı" }, "Nöroloji") },
            { "Soğuk Algınlığı", (new List<string> { "sürekli burun akıntısı", "boğazda yanma", "baş dönmesi" }, "Kulak Burun Boğaz") },
            { "Grip", (new List<string> { "halsizlik", "terleme", "yüksek ateş", "boğaz ağrısı" }, "Dahiliye") },
            { "Tonsillit", (new List<string> { "boğazda yanma", "yutkunurken zorlanma", "ateş" }, "Kulak Burun Boğaz") },
            { "Astım", (new List<string> { "nefes darlığı", "öksürük", "göğüs sıkışması" }, "Kardiyoloji") },
            { "Bronşit", (new List<string> { "öksürük", "nefes darlığı", "göğüs ağrısı" }, "Dahiliye") },
            { "İnme", (new List<string> { "vücudun bir tarafında güçsüzlük", "konuşma bozukluğu", "bayılma" }, "Nöroloji") },
            { "Sakroileit", (new List<string> { "sırt ağrısı", "hareket kısıtlılığı" }, "Ortopedi ve Travmatoloji") },
            { "Gebelik", (new List<string> { "adet gecikmesi", "alt karın ağrısı", "iştahsızlık" }, "Kadın Hastalıkları ve Doğum") },
            { "Diyabet", (new List<string> { "ağız kuruluğu", "çok sık tuvalete çıkma", "terleme", "halsizlik" }, "Dahiliye") },
            { "Zatürre", (new List<string> { "öksürük", "nefes darlığı", "yüksek ateş", "terleme" }, "Dahiliye") },
            { "Kaygı Bozukluğu", (new List<string> { "aşırı stres", "uykusuzluk", "nefes daralması" }, "Psikiyatri") },
            { "Katarakt", (new List<string> { "görme bozukluğu", "ışığa hassasiyet" }, "Nöroloji") },
            { "Sinir Sıkışması", (new List<string> { "el ve ayakta uyuşma", "kaslarda seğirme", "aşırı ağrı" }, "Ortopedi ve Travmatoloji") },
            { "Migren", (new List<string>{ "baş ağrısı", "baş dönmesi", "ışığa hassasiyet" }, "Nöroloji") },
            { "Hipertansiyon", (new List<string>{ "baş dönmesi", "görme bozukluğu", "burun kanaması", "terleme", "yüksek tansiyon", "nefes darlığı" }, "Kardiyoloji") },
            { "Apandisit", (new List<string>{ "karın ağrısı", "bulantı", "yüksek ateş" }, "Genel Cerrahi") },
            { "BPPV", (new List<string>{ "baş dönmesi", "denge kaybı", "bulantı" }, "Kulak Burun Boğaz") },
            { "Kronik Böbrek Yetmezliği", (new List<string>{ "idrar miktarında azalma", "yorgunluk", "yorgunluk" }, "Nefroloji") },
            { "Alzheimer", (new List<string>{ "hafıza kaybı", "konuşma güçlüğü" }, "Nöroloji") },
            { "Gastrik Ülser", (new List<string>{ "mide ağrısı", "bulantı" }, "Dahiliye") },
            { "Menenjit", (new List<string>{ "baş ağrısı", "boyun sertliği", "yüksek ateş" }, "Nöroloji") },
            { "Çölyak Hastalığı", (new List<string>{ "ishal", "karın ağrısı", "sebepsiz kilo kaybı" }, "Dahiliye") },
            { "D Vitamini Eksikliği", (new List<string>{ "kas ağrısı", "yorgunluk", "kemik ağrısı" }, "Dahiliye") }
        };
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> secilenSemptomlar = new List<string>();

            foreach (Control control in panel3.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                    secilenSemptomlar.Add(checkBox.Text.ToLower());
            }

            if (secilenSemptomlar.Count < 5 || secilenSemptomlar.Count > 10)
            {
                MessageBox.Show("Lütfen en az 5, en fazla 10 semptom seçiniz.");
                return;
            }

            string tahminiHastalik = null;

            // Önce birebir eşleşen hastalık varsa tespit et
            foreach (var hastalik in hastaliklar)
            {
                var semptomlar = hastalik.Value.semptomlar.Select(s => s.ToLower()).ToList();

                if (semptomlar.All(s => secilenSemptomlar.Contains(s)))
                {
                    tahminiHastalik = hastalik.Key;
                    break;
                }
            }

            // Şimdi bölüm puanlama hesapla
            Dictionary<string, int> bolumPuanlari = new Dictionary<string, int>();

            foreach (var bolum in bolumskorlari)
            {
                int puan = 0;
                foreach (var semptom in secilenSemptomlar)
                {
                    if (bolum.Value.ContainsKey(semptom))
                        puan += bolum.Value[semptom];
                }

                if (puan >= 6)
                    bolumPuanlari[bolum.Key] = puan;
            }

            var kesinBolumler = bolumPuanlari.Where(b => b.Value >= 10).ToList();
            var olasiBolumler = bolumPuanlari.Where(b => b.Value >= 6 && b.Value < 10).ToList();

            if (kesinBolumler.Any() || olasiBolumler.Any())
            {
                LoadUserControlIcerik(new bolumOneri(tahminiHastalik, kesinBolumler, olasiBolumler));
            }
            else
            {
                MessageBox.Show("Seçilen semptomlara göre bir öneride bulunulamıyor.", "Bölüm Önerisi");
            }
        }
    }
}

