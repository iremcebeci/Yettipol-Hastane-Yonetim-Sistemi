<?php
// Veritabanı bağlantısını dahil et
include('baglanti.php');
session_start();

// Kullanıcı ID'si oturumdan alınır
$user_id = $_SESSION['user_id'];  // Kullanıcı ID'si

// Kullanıcı bilgilerini almak için veritabanı sorgusu
$sql = "SELECT * FROM kullanicilar WHERE tc_no = '$user_id'";
$result = $conn->query($sql);
$user = $result->fetch_assoc();  // Veriyi al

// Türkçe karakterleri ASCII karşılıklarına dönüştür
$ad_soyad = $user['hasta_isimsoyisim'];
$ad_soyad = str_replace(array('Ö', 'Ü', 'Ş', 'Ç', 'İ', 'Ğ', 'ı'), array('O', 'U', 'S', 'C', 'I', 'G', 'i'), $ad_soyad);

// Adın baş harflerini al
$ad_soyad = strtoupper($ad_soyad); // Büyük harfe çevir
$harfler = explode(" ", $ad_soyad); // Ad ve soyadı ayır

// Baş harfleri al
$ilk_harfler = $harfler[0][0] . $harfler[1][0];  // Adın ve soyadın ilk harfini al

// Bugünün tarihini al
$bugun = date("Y-m-d");

$tarih = date('Y-m-d'); // Bugünün tarihi (isteğe bağlı filtre)

$sql = "SELECT * FROM teknisyenler WHERE tc_no = '$user_id'";
$result = $conn->query($sql);
$user2 = $result->fetch_assoc();

$teknisyen_id = $user2['teknisyen_id'];

$teknisyen_sorgu = $conn->prepare("
    SELECT t.id, t.tc_no, t.tahlil_kategori, t.tahlil_turu, t.istek_tarihi, k.hasta_isimsoyisim AS hasta_adi
    FROM tahliller t
    JOIN kullanicilar k ON t.tc_no = k.tc_no
    WHERE t.teknisyen_id = ?
    ORDER BY t.istek_tarihi DESC
");

$teknisyen_sorgu->bind_param("i", $teknisyen_id);
$teknisyen_sorgu->execute();
$result = $teknisyen_sorgu->get_result();

$sql2 = "SELECT teknisyen_id
                FROM teknisyenler
                WHERE tc_no = '$user_id'";
$result2 = $conn->query($sql2);
$teknisyen = $result2->fetch_assoc();

$sql3 = "SELECT id
                FROM tahliller
                WHERE teknisyen_id = '{$teknisyen['teknisyen_id']}'";
$result3 = $conn->query($sql3);
$tahlilid = $result3->fetch_assoc();


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
            <div class="headericerik2">
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
        </header>

        <div class="icerik">
            <div class="solmenu">
                <div class="profilbaslik">TEKNİSYEN BİLGİLERİ</div>
                <div class="profilfotograf">
                    <div class="pp"><?php echo $ilk_harfler; ?></div>
                </div>
                <div class="profilisim" id="username"><?php echo $user['hasta_isimsoyisim']; ?></div>
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
            <div class="islemsayfasi">

                <div class="tahlilgir">
                    <div class="islembaslik">
                        <h3>Üzerinize Atanmış Tahliller</h3>
                    </div>
                    <div class="islemicerik">
                        <div class="kutukategori">
                            <p>HASTA TC NO</p>
                            <p>İSİM SOYİSİM</p>
                            <p>KATEGORİ</p>
                            <p>TÜR</p>
                            <p>İSTEK TARİHİ</p>
                            <p>İŞLEM</p>
                        </div>
                        <?php while ($row = $result->fetch_assoc()): ?>
                            <?php
                            $tahlil_id = $row['id'];
                            $hasta_tc = $row['tc_no'];

                            // Tahlil sonucu var mı kontrolü
                            $kontrol_sql = "SELECT COUNT(*) AS sonuc_sayisi FROM tahlil_sonuclari WHERE tahlil_id = ?";
                            $kontrol_stmt = $conn->prepare($kontrol_sql);
                            $kontrol_stmt->bind_param("i", $tahlil_id);
                            $kontrol_stmt->execute();
                            $kontrol_result = $kontrol_stmt->get_result();
                            $kontrol_data = $kontrol_result->fetch_assoc();
                            $sonuc_var = $kontrol_data['sonuc_sayisi'] > 0;

                            // Görüntüleme raporu var mı kontrolü
                            $rapor_sql = "SELECT COUNT(*) AS rapor_sayisi FROM goruntuleme_raporlari WHERE tahlil_id = ?";
                            $rapor_stmt = $conn->prepare($rapor_sql);
                            $rapor_stmt->bind_param("i", $tahlil_id);
                            $rapor_stmt->execute();
                            $rapor_result = $rapor_stmt->get_result();
                            $rapor_data = $rapor_result->fetch_assoc();
                            $rapor_var = $rapor_data['rapor_sayisi'] > 0;

                            // Butonun aktif olması için her iki tablonun da boş olması lazım
                            $buton_pasif = $sonuc_var || $rapor_var;
                            ?>

                            <div class="tahlil-kart">
                                <div class="tahlil-detay hasta-tc"><?= $row['tc_no'] ?></div>
                                <div class="tahlil-detay hasta-ad"><?= $row['hasta_adi'] ?></div>
                                <div class="tahlil-detay kategori"><?= $row['tahlil_kategori'] ?></div>
                                <div class="tahlil-detay tur"><?= $row['tahlil_turu'] ?></div>
                                <div class="tahlil-detay istek-tarihi">
                                    <?= date("d.m.Y H:i", strtotime($row['istek_tarihi'])) ?></div>

                                <div class="tahlil-islem">
                                    <?php if ($row['tahlil_kategori'] == 'Görüntüleme'): ?>
                                        <!-- Görüntüleme teknisyeni için buton -->
                                        <form action="tahlil_sonuc_ekle.php" method="GET">
                                            <input type="hidden" name="tahlil_id" value="<?= $tahlil_id ?>">
                                            <input type="hidden" name="tc_no" value="<?= $hasta_tc ?>">
                                            <button class="btn-sonuc-ekle" type="submit" <?= $rapor_var ? 'disabled style="background: #ccc; cursor: not-allowed;"' : '' ?>>
                                                <?= $rapor_var ? 'Rapor Girildi' : 'Rapor Ekle' ?>
                                            </button>
                                        </form>
                                    <?php else: ?>
                                        <!-- Kan ya da İdrar için tahlil sonucu butonu -->
                                        <form action="tahlil_sonuc_ekle.php" method="GET">
                                            <input type="hidden" name="tahlil_id" value="<?= $tahlil_id ?>">
                                            <input type="hidden" name="tc_no" value="<?= $hasta_tc ?>">
                                            <button class="btn-sonuc-ekle" type="submit" <?= $sonuc_var ? 'disabled style="background: #ccc; cursor: not-allowed;"' : '' ?>>
                                                <?= $sonuc_var ? 'Sonuç Girildi' : 'Sonuç Ekle' ?>
                                            </button>
                                        </form>
                                    <?php endif; ?>
                                </div>
                            </div>
                        <?php endwhile; ?>



                    </div>

                </div>


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