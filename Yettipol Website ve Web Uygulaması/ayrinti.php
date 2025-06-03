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

$hasta_tc = $_GET['tc_no'];
$randevu_tarih = $_GET['tarih'];
$randevu_saat = $_GET['saat'];

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

// Hastalık verilerini çek (son eklenen en üstte)
$hastalik_query = "SELECT * FROM hastaliklar WHERE tc_no = '$hasta_tc' ORDER BY hastalik_id DESC";
$hastalik_result = $conn->query($hastalik_query);

// Reçeteleri çek (son eklenen en üstte)
$recete_query = "SELECT * FROM receteler WHERE tc_no = '$hasta_tc' ORDER BY recete_id DESC";
$recete_result = $conn->query($recete_query);


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
                <div class="profilbaslik">HASTANIN BİLGİLERİ</div>
                <div class="profilfotograf">
                    <div class="pp"><?php echo $hasta_ilk_harfler; ?></div>

                </div>
                <div class="profilisim" id="username"><?= $hasta['hasta_isimsoyisim']; ?></div>
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

            <div class="islemsayfasi">

                <div class="hastalikgir">
                    <div class="islembaslik">
                        <h3>HASTALIKLAR</h3>
                    </div>
                    <div class="islemicerik">
                        <div class="hastalik-cards">
                            <?php while ($hastalik = $hastalik_result->fetch_assoc()): ?>
                                <div class="hastalikkarti">
                                    <h4><?php echo $hastalik['hastalik_adi']; ?></h4>
                                    <p><strong>Açıklama:</strong> <?php echo $hastalik['hastalik_aciklama']; ?></p>
                                    <p><strong>Teşhis Tarihi:</strong> <?php echo $hastalik['teshis_tarihi']; ?></p>
                                </div>
                            <?php endwhile; ?>
                        </div>
                    </div>

                </div>

                <div class="recetegir">
                    <div class="islembaslik">
                        <h3>REÇETELER</h3>

                    </div>
                    <div class="islemicerik">
                        <div class="recete-cards">
                            <?php while ($recete = $recete_result->fetch_assoc()): ?>
                                <div class="hastalikkarti">
                                    <h4><?php echo $recete['ilac_adi']; ?></h4>
                                    <p><strong>Doz:</strong> <?php echo $recete['dozaj']; ?></p>
                                    <p><strong>Sıklık:</strong> <?php echo $recete['kullanim_sikligi']; ?></p>
                                    <p><strong>Açıklama:</strong> <?php echo $recete['aciklama']; ?></p>
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

                // Dinamik hastalık inputu ve açıklama alanı ekle
                function ekleInput(parentId, placeholder) {
                    const container = document.getElementById(parentId);

                    const wrapper = document.createElement("div");
                    wrapper.classList.add("hastalik-item");

                    const input = document.createElement("input");
                    input.type = "text";
                    input.name = "hastalik[]";
                    input.placeholder = placeholder;
                    input.required = true;

                    const textarea = document.createElement("textarea");
                    textarea.name = "hastalikAciklama[]";
                    textarea.placeholder = "Açıklama";
                    textarea.rows = 4;
                    textarea.required = true;
                    textarea.style.resize = "none"; // Büyütmeyi kapatıyoruz

                    wrapper.appendChild(input);
                    wrapper.appendChild(textarea);

                    container.appendChild(wrapper);
                }

                document.getElementById("hastalikForm").addEventListener("submit", function (e) {
                    e.preventDefault(); // Formun sayfayı yenilemesini engelle
                    console.log("Form gönderildi!");
                    // Burada AJAX ile formu gönderebilirsin
                });


                // İlaç ekleme fonksiyonu
                function ekleIlac() {
                    const ilacInputs = document.getElementById("ilacInputs");

                    const newIlacItem = document.createElement("div");
                    newIlacItem.classList.add("ilac-item");
                    newIlacItem.innerHTML = `
        <div class="ilac-row">
            <input type="text" name="ilac[]" placeholder="İlaç Adı" required>
            <select name="siklik[]">
                <option value="" disabled selected>Sıklık</option>
                <option value="gün">Gün</option>
                <option value="hafta">Hafta</option>
                <option value="ay">Ay</option>
            </select>
            <select name="dozaj[]">
                <option value="" disabled selected>Doz</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
                <option value="8">8</option>
                <option value="9">9</option>
                <option value="10">10</option>
            </select>
            <textarea name="receteAciklama[]" placeholder="Açıklama" rows="4" required></textarea><br><br>
        </div>
    `;
                    ilacInputs.appendChild(newIlacItem);
                }

                // Butonlara tıklanınca aktif class’ı ekle
                document.addEventListener("click", function (e) {
                    if (e.target.classList.contains("secenek")) {
                        e.preventDefault();
                        const btnGroup = e.target.parentElement;
                        [...btnGroup.children].forEach(btn => btn.classList.remove("active"));
                        e.target.classList.add("active");
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

                // Modal kapandığında formu temizle
                function closeModalCustom(modalId) {
                    const modal = document.getElementById(modalId);
                    modal.style.display = "none";

                    // Formu sıfırla
                    const form = document.getElementById("hastalikForm");
                    form.reset();
                }

                document.getElementById("hastalikForm").addEventListener("submit", function (e) {
                    e.preventDefault(); // Formun sayfayı yenilemesini engelle

                    const formData = new FormData(this); // Form verilerini al

                    fetch('hastalik_ekle.php', {
                        method: 'POST',
                        body: formData
                    })
                        .then(response => response.text())
                        .then(data => {
                            console.log(data); // PHP'den gelen yanıt
                            alert("Hastalık başarıyla kaydedildi!");
                            closeModalCustom('hastalikModal');
                        })
                        .catch(error => {
                            console.error('Hata:', error);
                        });
                });


                // Modal kapandığında formu temizle
                function closeModalCustom(modalId) {
                    const modal = document.getElementById(modalId);
                    modal.style.display = "none";

                    // Formu sıfırla
                    const form = document.getElementById("receteForm");
                    form.reset();
                }

                // Formu AJAX ile gönder
                document.getElementById("receteForm").addEventListener("submit", function (e) {
                    e.preventDefault(); // Formun normal gönderimini engelle

                    var formData = new FormData(this);

                    fetch("recete_ekle.php", {
                        method: "POST",
                        body: formData
                    })
                        .then(response => response.text())
                        .then(data => {
                            console.log(data); // PHP'den gelen yanıt
                            alert("Hastalık başarıyla kaydedildi!");
                            closeModalCustom('receteModal');
                        })
                        .catch(error => {
                            console.error('Error:', error);
                        });
                });

            </script>


</body>

</html>