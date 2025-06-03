<?php
// Veritabanı bağlantısını dahil et
include('baglanti.php');
session_start();

// Kullanıcı ID'si oturumdan alınır
$user_id = $_SESSION['user_id'];  // Kullanıcı ID'si

// Kullanıcı bilgilerini almak için veritabanı sorgusu
$sql = "SELECT 
            teknisyenler.teknisyen_id,
            teknisyenler.isimsoyisim,
            teknisyenler.tc_no,
            teknisyenler.hastane_id,
            teknisyenler.izin_gunu,
            teknisyenler.tek_tur,
            hastaneler.hastane_isim,
            kullanicilar.hasta_isimsoyisim,
            kullanicilar.hasta_cinsiyet,
            kullanicilar.hasta_dog_tar,
            kullanicilar.hasta_telefon,
            kullanicilar.email
        FROM teknisyenler
        JOIN hastaneler ON teknisyenler.hastane_id = hastaneler.hastane_id
        JOIN kullanicilar ON teknisyenler.tc_no = kullanicilar.tc_no
        WHERE teknisyenler.tc_no = '$user_id'";

$result = $conn->query($sql);
$user = $result->fetch_assoc();  // Veriyi al

// Türkçe karakterleri ASCII karşılıklarına dönüştür
$ad_soyad = $user['isimsoyisim'];
$ad_soyad = str_replace(array('Ö', 'Ü', 'Ş', 'Ç', 'İ', 'Ğ', 'ı'), array('O', 'U', 'S', 'C', 'I', 'G', 'i'), $ad_soyad);

// Adın baş harflerini al
$ad_soyad = strtoupper($ad_soyad); // Büyük harfe çevir
$harfler = explode(" ", $ad_soyad); // Ad ve soyadı ayır

// Baş harfleri al
$ilk_harfler = $harfler[0][0] . $harfler[1][0];  // Adın ve soyadın ilk harfini al




$bugun = date("Y-m-d");
$user_id = $_SESSION['user_id'];

$hasta_tc = $_GET['tc_no'];
$tahlil_id = $_GET['tahlil_id'];

$sqlHasta = "SELECT *
             FROM kullanicilar
             WHERE tc_no = '$hasta_tc'";
$resultHasta = $conn->query($sqlHasta);
$hasta = $resultHasta->fetch_assoc();

// Hastanın baş harflerini al
$hasta_adsoyad = str_replace(
    ['Ö', 'Ü', 'Ş', 'Ç', 'İ', 'Ğ', 'ı'],
    ['O', 'U', 'S', 'C', 'I', 'G', 'i'],
    strtoupper($hasta['hasta_isimsoyisim'])
);

$hasta_harfler = explode(" ", $hasta_adsoyad);
$hasta_ilk_harfler = $hasta_harfler[0][0] . $hasta_harfler[1][0];

function turkceTarih($date)
{
    $aylar = array(
        "01" => "Ocak",
        "02" => "Şubat",
        "03" => "Mart",
        "04" => "Nisan",
        "05" => "Mayıs",
        "06" => "Haziran",
        "07" => "Temmuz",
        "08" => "Ağustos",
        "09" => "Eylül",
        "10" => "Ekim",
        "11" => "Kasım",
        "12" => "Aralık"
    );

    $gun = date("d", strtotime($date));
    $ay = date("m", strtotime($date));
    $yil = date("Y", strtotime($date));

    return "$gun $aylar[$ay] $yil"; // 21 Nisan 2025 gibi döner
}

// tahlil_sonuc_ekle.php sayfasının en üstüne yaz
if (isset($_GET['tc_no']) && isset($_GET['tahlil_id'])) {
    $tc_no = $_GET['tc_no'];
    $tahlil_id = $_GET['tahlil_id'];

} else {
    // Parametreler eksikse yönlendirme ya da hata mesajı verebilirsin
    echo "Gerekli parametreler eksik!";
    exit;
}


// Bağlantıyı kapat
$conn->close();
?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>YETTİPOL ONLINE</title>
    <link rel="icon" type="image/x-icon" href="img/logo.jpg">
    <link rel="stylesheet" href="styleonline.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
</head>

<body>
    <div class="container">
        <header>
            <div class="baslikIsim">
                <img src="img/logo.jpg" alt="logo">
                <h2>YETTİPOL ONLINE</h2>
            </div>
            <div class="headericerik3">
                <div class="header-fotograf"><?php echo $ilk_harfler; ?></div>
                <li class="acilirMenu">
                    <div class="header-isim"><i class="fa-solid fa-chevron-down"></i><a href=""
                            id="username"><?php echo $user['isimsoyisim']; ?></a></div>
                    <div class="acilirIcerik">
                        <div class="acilirListe">
                            <div class="acilirEleman">
                                <p id="changePasswordBtn">Şifre Değiştir</p>
                                <hr>
                            </div>
                            <div class="acilirEleman">
                                <p><a href="girisyap.html" style="color: rgb(149, 7, 7);">Çıkış Yap</a></p>
                                <hr>
                            </div>
                        </div>
                    </div>
                </li>
            </div>
            <div class="menuButonlar3">
                <button><a href="teknisyenanasayfa.php">Anasayfa</a></button>
            </div>
        </header>

        <div class="icerik">
            <div class="solmenu">
                <div class="profilbaslik">HASTANIN BİLGİLERİ</div>
                <div class="profilfotograf">
                    <div class="pp"><?php echo $hasta_ilk_harfler; ?></div>

                </div>
                <div class="profilisim" id="username"><?= $hasta['hasta_isimsoyisim']; ?></div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">TC Kimlik No:</div>
                    <div class="bilgiicerik"><?= $hasta['tc_no']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Doğum Tarihi:</div>
                    <div class="bilgiicerik"><?= turkceTarih($hasta['hasta_dog_tar']) ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Cinsiyet:</div>
                    <div class="bilgiicerik"><?= $hasta['hasta_cinsiyet']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">E-Posta:</div>
                    <div class="bilgiicerik"><?= $hasta['email']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Telefon No:</div>
                    <div class="bilgiicerik"><?= $hasta['hasta_telefon']; ?></div>
                </div>
                <div class="altbolge">
                    <button><a href="girisyap.html">Çıkış Yap</a></button>
                    <button><a href="index.html">Sitemizi Ziyaret Et</a></button>
                </div>
            </div>

            <div class="hayaletdiv2"></div>

            <div class="islemsayfasi2">

                <div class="filtrelemebutonlari">
                    <label>Test Tipi:</label>
                    <select id="testTipiSec" onchange="formuGetir()">
                        <option value="" disabled selected>Test Seçiniz</option>
                        <option value="1">Hemogram (Tam Kan Sayımı)</option>
                        <option value="2">Biyokimya</option>
                        <option value="3">Vitamin Testi</option>
                        <option value="4">Hormon Testi</option>
                        <option value="5">Kan Şekeri</option>
                        <option value="6">Tam İdrar Tahlili</option>
                        <option value="7">İdrar Kültürü</option>
                        <option value="8">24 Saatlik İdrar</option>
                        <option value="9">Röntgen</option>
                        <option value="10">MR</option>
                        <option value="11">BT</option>
                        <option value="12">Ultrason</option>
                    </select>
                </div>

                <div class="sonucgiricerik" id="sonucFormu">

                </div>

            </div>








            <!-- Şifre Değiştirme Modalı -->
            <div id="changePasswordModal" class="modal">
                <div class="modal-content">
                    <span class="close">&times;</span>
                    <h2>Şifre Değiştir</h2>
                    <form action="sifre_degistir.php" method="POST">
                        <label for="eski_sifre">Eski Şifre:</label>
                        <input type="password" name="eski_sifre" required><br><br>

                        <label for="yeni_sifre">Yeni Şifre:</label>
                        <input type="password" name="yeni_sifre" required><br><br>

                        <label for="yeni_sifre_tekrar">Yeni Şifreyi Tekrar Girin:</label>
                        <input type="password" name="yeni_sifre_tekrar" required><br><br>

                        <button type="submit">Şifreyi Değiştir</button>
                    </form>
                </div>
            </div>

            <script>
                // Tüm .close butonlarına işlev ver
                document.addEventListener("DOMContentLoaded", function () {
                    const closeButtons = document.querySelectorAll(".close");
                    closeButtons.forEach(btn => {
                        btn.onclick = function () {
                            btn.closest(".modal, .custom-modal").style.display = "none";
                        };
                    });
                });

                // Modal açma fonksiyonu
                function openModalCustom(id) {
                    document.getElementById(id).style.display = "block";
                }

                // Modal kapama fonksiyonu
                function closeModalCustom(id) {
                    document.getElementById(id).style.display = "none";
                }

                // Dışarı tıklanınca modalı kapat
                window.addEventListener("click", function (event) {
                    if (event.target.classList.contains('custom-modal') || event.target.classList.contains('modal')) {
                        event.target.style.display = "none";
                    }
                });



                // Şifre değiştirme modalı için özel buton
                document.addEventListener("DOMContentLoaded", function () {
                    const modal = document.getElementById("changePasswordModal");
                    const btn = document.getElementById("changePasswordBtn");

                    btn.onclick = function () {
                        modal.style.display = "block";
                    }
                });

                const hastaTc = "<?= htmlspecialchars($hasta['tc_no']) ?>";
                const tahlilId = "<?= htmlspecialchars($tahlil_id) ?>";

                function formuGetir() {
                    const tahlilTuruId = parseInt(document.getElementById('testTipiSec').value);


                    if (!tahlilTuruId) return;

                    // Görüntüleme testleri: 9 = Röntgen, 10 = MR, 11 = BT, 12 = Ultrason
                    if ([9, 10, 11, 12].includes(tahlilTuruId)) {
                        // Seçilen çekim türü ID'ye göre belirlenebilir
                        const cekimTurleri = {
                            9: 'Röntgen',
                            10: 'MR',
                            11: 'BT',
                            12: 'Ultrason'
                        };

                        const cekimTuru = cekimTurleri[tahlilTuruId];

                        const html = `
            <form action="kaydet_sonuc.php" class="goruntulemeform" method="POST">
                <h3>${cekimTuru} Raporu</h3>
                <hr><br>

                <div class="g_grup">
                <label>Çekim Tarihi:</label>
                <input type="date" name="cekim_tarihi" required><br><br>
                </div>

                <div class="g_grup">
                <label>Teknik Bilgi:</label><br>
                <textarea name="teknik_bilgi" rows="2" required></textarea><br><br>
                </div>

                <div class="g_grup">
                <label>Bulgular:</label><br>
                <textarea name="bulgular" rows="2" required></textarea><br><br>
                </div>

                <div class="g_grup">
                <label>Sonuç - Değerlendirme:</label><br>
                <textarea name="sonuc_degerlendirme" rows="2" required></textarea><br><br>
                </div>

                <div class="g_grup">
                <label>Öneriler:</label><br>
                <textarea name="oneriler" rows="2"></textarea><br><br>
                </div>

                <div class="g_grup">
                <label>İmza:</label><br>
                <input type="text" name="imza" required><br><br>
                </div>


                <input type="hidden" name="hasta_tc" value="${hastaTc}">
        <input type="hidden" name="tahlil_id" value="${tahlilId}">
        <input type="hidden" name="tahlil_turu_id" value="${tahlilTuruId}">

                <button type="submit" class="tahlilikaydet3">Kaydet</button>
            </form>
        `;

                        document.getElementById("sonucFormu").innerHTML = html;
                        return;
                    }



                    // Parametreli testler için fetch
                    fetch('parametreleri_getir.php', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                        body: 'tahlil_turu_id=' + tahlilTuruId
                    })
                        .then(response => response.json())
                        .then(data => {
                            let html = `
                <form action="kaydet_sonuc.php" method="POST">
                <table class="parametre-tablosu">
                    <tr>
                        <th>Parametre</th>
                        <th>Değer</th>
                        <th>Birim</th>
                        <th>Referans Aralığı</th>
                    </tr>`;

                            data.forEach(p => {
                                const referans = p.kategorik_mi == 1
                                    ? p.referans_deger_metni
                                    : `${p.referans_min} - ${p.referans_max}`;

                                const input = p.kategorik_mi == 1
                                    ? `<input type="text" name="deger_metni[${p.id}]" required>`
                                    : `<input type="number" step="0.01" name="deger[${p.id}]" required>`;

                                html += `
                    <tr>
                        <td>${p.isim}</td>
                        <td>${input}</td>
                        <td>${p.birim || '-'}</td>
                        <td>${referans || '-'}</td>
                    </tr>`;
                            });

                            html += `
                </table>
                <input type="hidden" name="hasta_tc" value="${hastaTc}">
        <input type="hidden" name="tahlil_id" value="${tahlilId}">
<input type="hidden" name="tahlil_turu_id" value="${tahlilTuruId}">

                <input class="tahlilikaydet2" type="submit" value="Kaydet ve PDF Oluştur">
                
                </form>
                
                `;

                            document.getElementById("sonucFormu").innerHTML = html;
                        })
                        .catch(err => {
                            document.getElementById("sonucFormu").innerHTML = "<p>Form yüklenirken hata oluştu.</p>";
                            console.error("Hata:", err);
                        });
                }

                document.addEventListener('click', function (e) {
                    if (e.target.classList.contains('tahlilikaydet2')) {
                        e.preventDefault();

                        const form = e.target.closest('form');
                        const formData = new FormData(form);

                        fetch('kaydet_sonuc.php', {
                            method: 'POST',
                            body: formData
                        })
                            .then(res => {
                                if (!res.ok) throw new Error('Kayıt işlemi başarısız!');
                                return res.text();
                            })
                            .then(data => {
                                // ✅ burada çağır: veritabanına yazma tamamlandıktan sonra
                                const hasta_tc = formData.get('hasta_tc');
                                const tahlil_id = formData.get('tahlil_id');
                                const tahlil_turu_id = formData.get('tahlil_turu_id');

                                const url = `ref_rapor.php?hasta_tc=${encodeURIComponent(hasta_tc)}&tahlil_id=${encodeURIComponent(tahlil_id)}&tahlil_turu_id=${encodeURIComponent(tahlil_turu_id)}`;
                                window.open(url, '_blank');
                            })
                            .catch(err => alert(err.message));

                    }
                });

                document.addEventListener('click', function (e) {
                    if (e.target.classList.contains('tahlilikaydet3')) {
                        e.preventDefault();

                        const form = e.target.closest('form');
                        const formData = new FormData(form);

                        fetch('kaydet_sonuc.php', {
                            method: 'POST',
                            body: formData
                        })
                            .then(res => {
                                if (!res.ok) throw new Error('Kayıt işlemi başarısız!');
                                return res.text();
                            })
                            .then(data => {
                                // ✅ burada çağır: veritabanına yazma tamamlandıktan sonra
                                const hasta_tc = formData.get('hasta_tc');
                                const tahlil_id = formData.get('tahlil_id');
                                const tahlil_turu_id = formData.get('tahlil_turu_id');

                                const url = `gor_rapor.php?hasta_tc=${encodeURIComponent(hasta_tc)}&tahlil_id=${encodeURIComponent(tahlil_id)}&tahlil_turu_id=${encodeURIComponent(tahlil_turu_id)}`;
                                window.open(url, '_blank');
                            })
                            .catch(err => alert(err.message));

                    }
                });

                




            </script>


</body>

</html>