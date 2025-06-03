<?php
// Veritabanı bağlantısını dahil et
include('baglanti.php');
session_start();

// Kullanıcı ID'si oturumdan alınır
$user_id = $_SESSION['user_id'];  // Kullanıcı ID'si

// Kullanıcı bilgilerini almak için veritabanı sorgusu
$sql = "SELECT 
            doktorlar.doktor_id,
            doktorlar.doktor_isim,
            doktorlar.tc_no,
            doktorlar.bolum_id,
            bolumler.bolum_isim,
            doktorlar.hastane_id,
            hastaneler.hastane_isim,
            kullanicilar.hasta_isimsoyisim,
            kullanicilar.hasta_cinsiyet,
            kullanicilar.hasta_dog_tar,
            kullanicilar.hasta_telefon,
            kullanicilar.email
        FROM doktorlar
        JOIN bolumler ON doktorlar.bolum_id = bolumler.bolum_id
        JOIN hastaneler ON doktorlar.hastane_id = hastaneler.hastane_id
        JOIN kullanicilar ON doktorlar.tc_no = kullanicilar.tc_no
        WHERE doktorlar.tc_no = '$user_id'";

$result = $conn->query($sql);
$user = $result->fetch_assoc();  // Veriyi al

$sql2 = "SELECT doktor_id FROM doktorlar WHERE tc_no = '$user_id'";
$result2 = $conn->query($sql2);
$user2 = $result2->fetch_assoc();
$doktor_id = $user2['doktor_id'];

$randevu = "SELECT * FROM randevular WHERE doktor_id = '{$user2['doktor_id']}'";
$result3 = $conn->query($randevu);
$randevular = $result3->fetch_assoc();

$hastatcno = "SELECT tc_no FROM randevular WHERE doktor_id = '{$user2['doktor_id']}'";
$result4 = $conn->query($hastatcno);
$hastatc = $result4->fetch_assoc();

$hastabilgiler = "SELECT * FROM hastalar WHERE tc_no = '{$hastatc['tc_no']}'";
$result5 = $conn->query($hastabilgiler);
$hastabilgi = $result5->fetch_assoc();

// Türkçe karakterleri ASCII karşılıklarına dönüştür
$ad_soyad = $user['hasta_isimsoyisim'];
$ad_soyad = str_replace(array('Ö', 'Ü', 'Ş', 'Ç', 'İ', 'Ğ', 'ı'), array('O', 'U', 'S', 'C', 'I', 'G', 'i'), $ad_soyad);

// Adın baş harflerini al
$ad_soyad = strtoupper($ad_soyad); // Büyük harfe çevir
$harfler = explode(" ", $ad_soyad); // Ad ve soyadı ayır

// Baş harfleri al
$ilk_harfler = $harfler[0][0] . $harfler[1][0];  // Adın ve soyadın ilk harfini al

$bugun = date("Y-m-d");
$user_id = $_SESSION['user_id'];

// Bugünden önceki tarihli, geçmiş durumundaki randevuları sorgula
// Şimdi bu doktorun geçmiş randevularını çek
$sqlGecmis = "SELECT r.tc_no, k.hasta_isimsoyisim, k.hasta_dog_tar, k.hasta_cinsiyet, 
                     r.randevu_tarih, r.randevu_saat, r.randevu_durumu
              FROM randevular r
              JOIN hastalar h ON r.tc_no = h.tc_no
              JOIN kullanicilar k ON h.tc_no = k.tc_no
              WHERE r.randevu_tarih < CURDATE()
              AND r.doktor_id = '$doktor_id'
              ORDER BY r.randevu_tarih DESC, r.randevu_saat DESC";

// Veritabanı sorgusunu çalıştır
$resultGecmis = $conn->query($sqlGecmis);

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
            <div class="headericerik">
                <div class="header-fotograf"><?php echo $ilk_harfler; ?></div>
                <li class="acilirMenu">
                    <div class="header-isim"><i class="fa-solid fa-chevron-down"></i><a href=""
                            id="username"><?php echo $user['hasta_isimsoyisim']; ?></a></div>
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

            <div class="menuButonlar">
                <button><a href="doktoranasayfa.php">Bugünün<br>Randevuları</a></button>
                <button><a href="gelecekrandevular.php">Gelecek<br>Randevular</a></button>
            </div>
        </header>

        <div class="icerik">
            <div class="solmenu">
                <div class="profilbaslik">DOKTOR BİLGİLERİ</div>
                <div class="profilfotograf">
                    <div class="pp"><?php echo $ilk_harfler; ?></div>
                </div>
                <div class="profilisim" id="username"><?php echo $user['doktor_isim']; ?></div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Hastane:</div>
                    <div class="bilgiicerik"><?php echo $user['hastane_isim']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Bölüm:</div>
                    <div class="bilgiicerik"><?php echo $user['bolum_isim']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">TC Kimlik No:</div>
                    <div class="bilgiicerik"><?php echo $user['tc_no']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Doğum Tarihi:</div>
                    <div class="bilgiicerik"><?php echo $user['hasta_dog_tar']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Cinsiyet:</div>
                    <div class="bilgiicerik"><?php echo $user['hasta_cinsiyet']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">E-posta:</div>
                    <div class="bilgiicerik"><?php echo $user['email']; ?></div>
                </div>
                <div class="profilbilgiler">
                    <div class="bilgiismi">Telefon No:</div>
                    <div class="bilgiicerik"><?php echo $user['hasta_telefon']; ?></div>
                </div>
                <div class="altbolge">
                    <button><a href="girisyap.html">Çıkış Yap</a></button>
                    <button><a href="index.html">Sitemizi Ziyaret Et</a></button>
                </div>
            </div>

            <div class="hayaletdiv2"></div>

            <div class="gelecekrandevular">
                <div class="gelecekrand">
                    <div class="gelecek-kutusu-baslik">Geçmiş Randevular</div>
                    <div class="kutukategori">
                        <p>HASTA TC NO</p>
                        <p>İSİM SOYİSİM</p>
                        <p>DOĞUM TARİHİ</p>
                        <p>CİNSİYET</p>
                        <p>RANDEVU TARİHİ</p>
                        <p>RANDEVU SAATİ</p>
                        <p>AYRINTILAR</p>
                    </div>
                    <?php while ($row = $resultGecmis->fetch_assoc()): ?>
                        <div class="randevu-kart">
                            <div class="randevu-detay hasta-tc"><?= $row['tc_no'] ?></div>
                            <div class="randevu-detay hasta-ad"><?= $row['hasta_isimsoyisim'] ?></div>
                            <div class="randevu-detay hasta-dogum"><?= turkceTarih($row['hasta_dog_tar']) ?></div>
                            <div class="randevu-detay hasta-cinsiyet"><?= $row['hasta_cinsiyet'] ?></div>
                            <div class="randevu-detay randevu-tarih"><?= turkceTarih($row['randevu_tarih']) ?></div>
                            <div class="randevu-detay randevu-saat"><?= date("H:i", strtotime($row['randevu_saat'])) ?>
                            </div>
                            <form action="ayrinti.php" method="GET">
                                <input type="hidden" name="tc_no" value="<?= $row['tc_no'] ?>">
                                <input type="hidden" name="tarih" value="<?= $row['randevu_tarih'] ?>">
                                <input type="hidden" name="saat" value="<?= $row['randevu_saat'] ?>">
                                <div class="randevu-islem">
                                <button class="randevu-btn" type="submit">Ayrıntı</button>
                                </div>
                            </form>
                        </div>
                    <?php endwhile; ?>
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
                    // Modal açma ve kapama işlemleri
                    var modal = document.getElementById("changePasswordModal");
                    var btn = document.getElementById("changePasswordBtn");
                    var span = document.getElementsByClassName("close")[0];

                    // Modal'ı aç
                    btn.onclick = function () {
                        modal.style.display = "block";
                    }

                    // Modal'ı kapat
                    span.onclick = function () {
                        modal.style.display = "none";
                    }

                    // Modal dışına tıklanarak kapatma
                    window.onclick = function (event) {
                        if (event.target == modal) {
                            modal.style.display = "none";
                        }
                    }
                </script>

</body>

</html>