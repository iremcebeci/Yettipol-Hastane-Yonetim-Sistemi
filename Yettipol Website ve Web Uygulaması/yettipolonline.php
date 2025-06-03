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

// Geçmiş randevuları güncelle
$guncelle_randevular = $conn->prepare("UPDATE randevular SET randevu_durumu = 'Geçmiş' WHERE tc_no = ? AND randevu_tarih < ?");
$guncelle_randevular->bind_param("ss", $user_id, $bugun); // Bind param ile kullanıcı ID'si ve tarih parametrelerini ekliyoruz
$guncelle_randevular->execute();

// Randevuları almak için sorgu
$sql = "
    SELECT 
        h.hastane_isim, 
        b.bolum_isim, 
        d.doktor_isim, 
        r.randevu_tarih, 
        r.randevu_saat, 
        r.randevu_turu, 
        r.randevu_durumu,
        r.randevu_id
    FROM randevular r
    JOIN hastaneler h ON r.hastane_id = h.hastane_id
    JOIN bolumler b ON r.bolum_id = b.bolum_id
    JOIN doktorlar d ON r.doktor_id = d.doktor_id
    WHERE r.tc_no = '$user_id'
    ORDER BY r.randevu_tarih DESC
";
$result = $conn->query($sql);

// Randevuları kontrol et ve döngü ile listele
$normalRandevular = [];
$onlineRandevular = [];

if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        // Tarih ve saati DateTime objesi ile formatlayalım
        $randevu_datetime = new DateTime($row['randevu_tarih'] . ' ' . $row['randevu_saat']);
        // Türkçe tarih biçimi ayarla
        $locale = 'tr_TR';  // Türkçe yerel ayar
        $fmt = new IntlDateFormatter($locale, IntlDateFormatter::LONG, IntlDateFormatter::NONE, null, null, 'd MMMM yyyy');

        // Türkçe tarih formatı çıktı (örn: 4 Mayıs 2025)
        $tarih = $fmt->format($randevu_datetime);
        $saat = $randevu_datetime->format('H:i');     // Örneğin: 13:00

        // Randevuları türlerine göre ayıralım
        if ($row['randevu_turu'] == 'Online') {
            $onlineRandevular[] = $row;  // Görüntülü görüşme randevusu
        } else {
            $normalRandevular[] = $row;  // Normal hastane randevusu
        }
    }
}

// Reçeteleri al
$recete_sql = "SELECT * FROM receteler WHERE tc_no = '$user_id' LIMIT 1";
$recete_result = $conn->query($recete_sql);
$recete = $recete_result->fetch_assoc();

// Hastalık verilerini çek
$hastalik_query = "SELECT * FROM hastaliklar WHERE tc_no = '$user_id' ORDER BY hastalik_id DESC"; // Hastaya ait hastalıklar
$hastalik_result = $conn->query($hastalik_query);

// Reçeteleri çek
$recete_query = "SELECT * FROM receteler WHERE tc_no = '$user_id'  ORDER BY recete_id DESC"; // Hastaya ait reçeteler
$recete_result2 = $conn->query($recete_query);

$sql2 = "SELECT *
        FROM tahliller
        WHERE tc_no = '$user_id' ORDER BY istek_tarihi DESC";
$tahlil_result = $conn->query($sql2);


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
                                <p id="changeEmailBtn">E-posta Değiştir</p>
                                <hr>
                            </div>
                            <div class="acilirEleman">
                                <p id="kisiselBtn">Kişisel Bilgi Ekle</p>
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
                <button><a href="randevu.php">Hastane<br>Randevusu Al</a></button>
                <button><a href="goruntulu.php">Görüntülü Görüşme<br>Randevusu Al</a></button>
            </div>
        </header>

        <div id="chatButton" title="Mesajlaşmayı aç">
            <img src="img/mesajicon4.png" alt="">
        </div>

        <div class="icerik">
            <div class="solmenu">
                <div class="profilbaslik">KULLANICI BİLGİLERİ</div>
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
                    <div class="bilgiicerik">
                        <?php
                        $fmt = new IntlDateFormatter('tr_TR', IntlDateFormatter::LONG, IntlDateFormatter::NONE);
                        $dogum_datetime = new DateTime($user['hasta_dog_tar']);
                        echo $fmt->format($dogum_datetime);
                        ?>
                    </div>
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
            <div class="alticerik">
                <div class="ustkisim">
                    <div class="icerik-kutusu">
                        <div class="icerik-kutusu-baslik">Randevular</div>
                        <div class="icerik-kutusu-icerigi">
                            <div class="bozulma_artik_yeter">
                                <?php
                                // İki diziyi birleştir
                                $tumRandevular = array_merge($normalRandevular, $onlineRandevular);

                                // Tarihe göre sıralama (artıyor)
                                usort($tumRandevular, function ($a, $b) {
                                    $dateA = strtotime($a['randevu_tarih'] . ' ' . $a['randevu_saat']);
                                    $dateB = strtotime($b['randevu_tarih'] . ' ' . $b['randevu_saat']);
                                    return $dateB - $dateA;
                                });

                                if (empty($tumRandevular)): ?>
                                    <p class="message">Bu alanda kayıt bulunmamaktadır.</p>
                                <?php else: ?>
                                    <?php foreach ($tumRandevular as $row): ?>
                                        <div class="randevukart">
                                            <p><b> <?php echo $row['hastane_isim']; ?> | <?php echo $row['bolum_isim']; ?></b>
                                            </p>
                                            <p><?php echo $row['doktor_isim']; ?></p>
                                            <?php
                                            $randevu_datetime = new DateTime($row['randevu_tarih'] . ' ' . $row['randevu_saat']);
                                            $tarih = $fmt->format($randevu_datetime);
                                            $saat = $randevu_datetime->format('H:i');
                                            ?>
                                            <p><strong>Tarih:</strong> <?php echo $tarih; ?></p>
                                            <p><strong>Saat:</strong> <?php echo $saat; ?></p>
                                            <p><strong>Tür:</strong> <?php echo $row['randevu_turu']; ?></p>
                                            <p><strong>Durum:</strong> <?php echo $row['randevu_durumu']; ?></p>
                                            <?php
                                            $simdi = new DateTime(); // Şu anki zaman
                                            $randevu_datetime = new DateTime($row['randevu_tarih'] . ' ' . $row['randevu_saat']);
                                            ?>

                                            <?php if ($randevu_datetime > $simdi): ?>
                                                <a href="iptal.php?randevu_id=<?php echo $row['randevu_id']; ?>"
                                                    class="iptal-button">Randevuyu İptal Et</a>
                                            <?php endif; ?>

                                        </div>
                                    <?php endforeach; ?>
                                <?php endif; ?>
                            </div>


                        </div>
                    </div>
                    <div class="icerik-kutusu">
                        <div class="icerik-kutusu-baslik">Tahliller</div>
                        <div class="icerik-kutusu-icerigi">
                            <div class="bozulma_artik_yeter">

                                <?php while ($tahlil = $tahlil_result->fetch_assoc()): ?>
                                    <?php

                                    // Sonuç girilmiş mi kontrolü
                                    $tahlil_id = $tahlil['id'];
                                    $kontrol_sql = "SELECT COUNT(*) AS sonuc_sayisi FROM tahlil_sonuclari WHERE tahlil_id = ?";
                                    $kontrol_stmt = $conn->prepare($kontrol_sql);
                                    $kontrol_stmt->bind_param("i", $tahlil['id']);
                                    $kontrol_stmt->execute();
                                    $kontrol_result = $kontrol_stmt->get_result();
                                    $kontrol_data = $kontrol_result->fetch_assoc();
                                    $sonuc_var = $kontrol_data['sonuc_sayisi'] > 0;

                                    // Görüntüleme raporu var mı kontrolü
                                    $rapor_sql = "SELECT COUNT(*) AS rapor_sayisi FROM goruntuleme_raporlari WHERE tahlil_id = ?";
                                    $rapor_stmt = $conn->prepare($rapor_sql);
                                    $rapor_stmt->bind_param("i", $tahlil['id']);
                                    $rapor_stmt->execute();
                                    $rapor_result = $rapor_stmt->get_result();
                                    $rapor_data = $rapor_result->fetch_assoc();
                                    $rapor_var = $rapor_data['rapor_sayisi'] > 0;

                                    // Butonun aktif olması için her iki tablonun da boş olması lazım
                                    $buton_pasif = $sonuc_var || $rapor_var;

                                    $hasta_tc = $tahlil['tc_no'];
                                    $tahlil_turu_id = $tahlil['tahlil_turu']; // Eğer id değilse düzelt
                                    ?>

                                    <div class="tahlil-kart2">
                                        <div class="tahlil-detay2 kategori"><?= ucfirst($tahlil['tahlil_kategori']) ?></div>
                                        <div class="tahlil-detay2 tur"><?= $tahlil['tahlil_turu'] ?></div>
                                        <div class="tahlil-detay2 istek-tarihi">
                                            <?php
                                            $fmt = new IntlDateFormatter('tr_TR', IntlDateFormatter::LONG, IntlDateFormatter::SHORT);
                                            $randevu_datetime = new DateTime($tahlil['istek_tarihi']);
                                            echo $fmt->format($randevu_datetime);
                                            ?>
                                        </div>


                                        <div class="tahlil-islem2">
                                            <?php if ($tahlil['tahlil_kategori'] == 'Görüntüleme'): ?>
                                                <?php if ($rapor_var): ?>
                                                    <!-- PDF indir -->
                                                    <form action="gor_rapor.php" method="GET" target="_blank">
                                                        <input type="hidden" name="hasta_tc" value="<?= $hasta_tc ?>">
                                                        <input type="hidden" name="tahlil_id" value="<?= $tahlil_id ?>">
                                                        <input type="hidden" name="tahlil_turu_id" value="<?= $tahlil_turu_id ?>">
                                                        <button class="btn-sonuc-ekle" type="submit">Sonucu Gör</button>
                                                    </form>
                                                <?php else: ?>
                                                    <!-- Sonuç yoksa pasif buton -->
                                                    <button class="btn-sonuc-ekle" disabled
                                                        style="background: #ccc; cursor: not-allowed;">
                                                        Sonuç Eklenmedi
                                                    </button>
                                                <?php endif; ?>



                                            <?php else: ?>
                                                <?php if ($sonuc_var): ?>
                                                    <!-- PDF indir -->
                                                    <form action="ref_rapor.php" method="GET" target="_blank">
                                                        <input type="hidden" name="hasta_tc" value="<?= $hasta_tc ?>">
                                                        <input type="hidden" name="tahlil_id" value="<?= $tahlil_id ?>">
                                                        <input type="hidden" name="tahlil_turu_id" value="<?= $tahlil_turu_id ?>">
                                                        <button class="btn-sonuc-ekle" type="submit">Sonucu Gör</button>
                                                    </form>
                                                <?php else: ?>
                                                    <!-- Sonuç yoksa pasif buton -->
                                                    <button class="btn-sonuc-ekle" disabled
                                                        style="background: #ccc; cursor: not-allowed;">
                                                        Sonuç Eklenmedi
                                                    </button>
                                                <?php endif; ?>

                                            <?php endif; ?>

                                        </div>
                                    </div>
                                <?php endwhile; ?>
                            </div>


                        </div>
                    </div>

                </div>
                <div class="altkisim">
                    <!-- Hastalıklar -->
                    <div class="icerik-kutusu">
                        <div class="icerik-kutusu-baslik">Hastalıklar</div>
                        <div class="icerik-kutusu-icerigi">
                            <?php if ($hastalik_result->num_rows > 0): ?>
                                <div class="bozulma_artik_yeter">
                                    <?php while ($hastalik = $hastalik_result->fetch_assoc()): ?>
                                        <div class="hastalikkarti">
                                            <h4><?php echo $hastalik['hastalik_adi']; ?></h4>
                                            <p><strong>Açıklama:</strong> <?php echo $hastalik['hastalik_aciklama']; ?></p>
                                            <p><strong>Teşhis Tarihi:</strong>
                                                <?php
                                                $fmt = new IntlDateFormatter('tr_TR', IntlDateFormatter::LONG, IntlDateFormatter::NONE);
                                                $teshis_datetime = new DateTime($hastalik['teshis_tarihi']);
                                                echo $fmt->format($teshis_datetime);
                                                ?>
                                            </p>
                                        </div>
                                    <?php endwhile; ?>
                                </div>
                            <?php else: ?>
                                Bu alanda kayıt bulunmamaktadır.
                            <?php endif; ?>
                        </div>
                    </div>

                    <!-- Reçeteler -->
                    <div class="icerik-kutusu">
                        <div class="icerik-kutusu-baslik">Reçeteler</div>
                        <div class="icerik-kutusu-icerigi">
                            <?php if ($recete_result2->num_rows > 0): ?>
                                <div class="bozulma_artik_yeter">
                                    <?php while ($recete = $recete_result2->fetch_assoc()): ?>
                                        <div class="hastalikkarti">
                                            <h4><?php echo $recete['ilac_adi']; ?></h4>
                                            <p><strong>Doz:</strong> <?php echo $recete['dozaj']; ?></p>
                                            <p><strong>Sıklık:</strong> <?php echo $recete['kullanım_sıklığı']; ?></p>
                                            <p><strong>Açıklama:</strong> <?php echo $recete['aciklama']; ?></p>
                                        </div>
                                    <?php endwhile; ?>
                                </div>
                            <?php else: ?>
                                Bu alanda kayıt bulunmamaktadır.
                            <?php endif; ?>
                        </div>
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

        <!-- E-posta Değiştirme Modalı -->
        <div id="changeEmailModal" class="modal">
            <div class="modal-content">
                <span class="close">&times;</span>
                <h2>E-posta Değiştir</h2>
                <form action="eposta_degistir.php" method="POST">
                    <label for="eski_email">Eski E-posta:</label>
                    <input type="email" name="eski_email" required><br><br>

                    <label for="yeni_email">Yeni E-posta:</label>
                    <input type="email" name="yeni_email" required><br><br>

                    <button type="submit">E-postayı Değiştir</button>
                </form>
            </div>
        </div>

        <!-- Kişisel Bilgi Modalı -->
        <div id="kisiselBilgiModal" class="modal">
            <div class="modal-content">
                <span class="close" onclick="closeModal()">&times;</span>
                <h2>Kişisel Bilgi Ekle</h2>
                <form id="kisiselbilgi" action="kisisel_bilgi_kaydet.php" method="POST">

                    <label for="kan_grubu">Kan Grubu:</label>
                    <select id="kan_grubu" name="kan_grubu" required>
                        <option value="">Seçiniz</option>
                        <option value="A+">A+</option>
                        <option value="A-">A-</option>
                        <option value="B+">B+</option>
                        <option value="B-">B-</option>
                        <option value="AB+">AB+</option>
                        <option value="AB-">AB-</option>
                        <option value="0+">0+</option>
                        <option value="0-">0-</option>
                    </select>

                    <label for="boy">Boy (cm):</label>
                    <input type="number" id="boy" name="boy" min="100" max="250" required>

                    <label for="kilo">Kilo (kg):</label>
                    <input type="number" id="kilo" name="kilo" min="30" max="250" required>

                    <label for="alerji">Alerji Bilgisi:</label>
                    <textarea id="alerji" name="alerji" rows="3" placeholder="Yoksa 'Yok' yazın" required></textarea>

                    <button type="submit">Kaydet</button>
                </form>
            </div>
        </div>


        <script>

            document.getElementById('chatButton').addEventListener('click', () => {
                window.open('mesajlasma.php'); // mesajlasma.php büyük mesajlaşma sayfan olacak
            });

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

            // Modal açma ve kapama işlemleri
            var modalEmail = document.getElementById("changeEmailModal");
            var btnEmail = document.getElementById("changeEmailBtn");
            var spanEmail = modalEmail.getElementsByClassName("close")[0];

            // Modal'ı aç
            btnEmail.onclick = function () {
                modalEmail.style.display = "block";
            }

            // Modal'ı kapat
            spanEmail.onclick = function () {
                modalEmail.style.display = "none";
            }

            // Modal dışına tıklanarak kapatma
            window.onclick = function (event) {
                if (event.target == modalEmail) {
                    modalEmail.style.display = "none";
                }
            }

            // Modal açma ve kapama işlemleri - Kişisel Bilgi
            var modalBilgi = document.getElementById("kisiselBilgiModal");
            var btnBilgi = document.getElementById("kisiselBtn");
            var spanBilgi = modalBilgi.getElementsByClassName("close")[0];

            // Modal'ı aç
            btnBilgi.onclick = function () {
                modalBilgi.style.display = "block";
            }

            // Modal'ı kapat
            spanBilgi.onclick = function () {
                modalBilgi.style.display = "none";
            }

            // Modal dışına tıklanarak kapatma
            window.onclick = function (event) {
                if (event.target == modalBilgi) {
                    modalBilgi.style.display = "none";
                }
            }

        </script>

</body>

</html>