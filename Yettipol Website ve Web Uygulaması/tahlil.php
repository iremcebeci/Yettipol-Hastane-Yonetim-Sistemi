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

$tahlil_sorgu = $conn->prepare("SELECT * FROM tahliller WHERE tc_no = ? ORDER BY istek_tarihi DESC");
$tahlil_sorgu->bind_param("s", $hasta_tc);
$tahlil_sorgu->execute();
$tahlil_result = $tahlil_sorgu->get_result();

$sql2 = "SELECT hasta_isimsoyisim, hasta_dog_tar, hasta_cinsiyet
                FROM hastalar
                WHERE tc_no = '$hasta_tc'";
$result2 = $conn->query($sql2);
$hastabilgi = $result2->fetch_assoc();

?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>YETTİPOL ONLINE</title>
    <link rel="icon" type="image/x-icon" href="img/logo.jpg">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
    <link rel="stylesheet" href="styleonline.css">
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

            <div class="islemsayfasi">

                <div class="tahlilgir">
                    <div class="islembaslik">
                        <h3>Tahlilller</h3>
                        <button onclick="openModalCustom('tahlilModal')"> + Tahlil </button>
                    </div>
                    <div class="islemicerik">
                        <div class="kutukategori">
                            <p>HASTA TC NO</p>
                            <p>İSİM SOYİSİM</p>
                            <p>KATEGORİ</p>
                            <p>TÜR</p>
                            <p>İSTEK TARİHİ</p>
                            <p>SONUÇ</p>
                        </div>
                        <div class="tahlil-listesi">
                            <?php while ($tahlil = $tahlil_result->fetch_assoc()): ?>
                                <?php
                                // Sonuç girilmiş mi kontrolü
                                $tahlil_id = $tahlil['id'];
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

                                $hasta_tc = $tahlil['tc_no'];
                                $tahlil_turu_id = $tahlil['tahlil_turu']; // Eğer id değilse düzelt
                                ?>

                                <div class="tahlil-kart">
                                    <div class="tahlil-detay hasta-tc"><?= $tahlil['tc_no'] ?></div>
                                    <div class="tahlil-detay hasta-ad"><?= $hastabilgi['hasta_isimsoyisim'] ?? '-' ?></div>
                                    <div class="tahlil-detay kategori"><?= ucfirst($tahlil['tahlil_kategori']) ?></div>
                                    <div class="tahlil-detay tur"><?= $tahlil['tahlil_turu'] ?></div>
                                    <div class="tahlil-detay istek-tarihi">
                                        <?= date("d.m.Y H:i", strtotime($tahlil['istek_tarihi'])) ?>
                                    </div>

                                    <div class="tahlil-islem">
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


            <!-- Tahlil İste Modal -->
            <div id="tahlilModal" class="custom-modal">
                <div class="modal-content2">
                    <span class="close" onclick="closeModalCustom('tahlilModal')">&times;</span>
                    <h2>Tahlil İste</h2>

                    <form id="tahlilForm" action="tahlil_iste.php" method="POST">
                        <input type="hidden" name="tc_no" value="<?= $hasta_tc ?>">

                        <div id="tahlil-container" style="
    display: flex;
    flex-direction: column;
    gap: 20px;
    margin-bottom: 20px;
">
                            <div class="tahlil-group">
                                <label>Kategori Seç:</label>
                                <select name="tahlil_kategori[]" onchange="tahlilSecenekleriGetir(this)" required>
                                    <option value="" disabled selected>Seç</option>
                                    <option value="kan">Kan Testleri</option>
                                    <option value="idrar">İdrar Testleri</option>
                                    <option value="görüntüleme">Görüntüleme</option>
                                </select>

                                <div id="tahlil-secenekleri" class="tahlil-secim-alani"></div>

                                <button type="button" class="remove-btn" onclick="removeTahlilGroup(this)"
                                    style="display:none;">Kaldır</button>
                            </div>
                        </div>
                        <div class="tahlilmodalbutonlar">
                            <button type="button" class="kaydetmebutonu" onclick="addTahlilGroup()">+ Yeni Tahlil
                                Ekle</button>
                            <button type="submit" class="kaydetmebutonu">Kaydet</button>
                        </div>

                    </form>

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
                function closeModalCustom(modalId) {
                    const modal = document.getElementById(modalId);
                    modal.style.display = "none";

                    // Formu sıfırla
                    const form = document.getElementById("tahlilForm");
                    form.reset();
                }


                // Dışarı tıklanınca modalı kapat
                window.addEventListener("click", function (event) {
                    if (event.target.classList.contains('custom-modal') || event.target.classList.contains('modal')) {
                        event.target.style.display = "none";
                    }
                });

                function addTahlilGroup() {
                    const container = document.getElementById('tahlil-container');
                    const firstGroup = container.querySelector('.tahlil-group');

                    const newGroup = firstGroup.cloneNode(true);
                    newGroup.querySelector('select').value = '';
                    newGroup.querySelector('.tahlil-secim-alani').innerHTML = '';
                    newGroup.querySelector('.remove-btn').style.display = 'inline-block';

                    container.appendChild(newGroup);
                }

                function removeTahlilGroup(button) {
                    button.parentElement.remove();
                }

                function tahlilSecenekleriGetir(selectElem) {
                    const kategori = selectElem.value;
                    const secenekAlani = selectElem.parentElement.querySelector('.tahlil-secim-alani');

                    const veriler = {
                        "kan": ["Hemogram (Tam Kan Sayımı)", "Biyokimya", "Vitamin Testi", "Hormon Testi", "Kan Şekeri"],
                        "idrar": ["Tam İdrar Tahlili", "İdrar Kültürü", "24 Saatlik İdrar"],
                        "görüntüleme": ["Röntgen", "MR", "BT", "Ultrason"]
                    };

                    secenekAlani.innerHTML = ''; // önce temizle

                    if (!veriler[kategori]) return;

                    veriler[kategori].forEach(item => {
                        secenekAlani.innerHTML += `
      <label><input type="checkbox" name="tahliller[${getIndex(selectElem)}][]" value="${item}"> ${item}</label><br>
    `;
                    });
                }

                // Hangi grubun kaçıncı olduğunu bulmak için yardımcı fonksiyon
                function getIndex(selectElem) {
                    const container = document.getElementById('tahlil-container');
                    const groups = container.querySelectorAll('.tahlil-group');
                    return Array.from(groups).indexOf(selectElem.parentElement);
                }



                // Şifre değiştirme modalı için özel buton
                document.addEventListener("DOMContentLoaded", function () {
                    const modal = document.getElementById("changePasswordModal");
                    const btn = document.getElementById("changePasswordBtn");

                    btn.onclick = function () {
                        modal.style.display = "block";
                    }
                });

                // Tahlil formunu AJAX ile gönder
                document.getElementById("tahlilForm").addEventListener("submit", function (e) {
                    e.preventDefault(); // Sayfa yenilenmesin

                    const form = this;
                    const formData = new FormData(form);

                    // (İsteğe bağlı) Checkbox kontrolü
                    const groups = document.querySelectorAll('.tahlil-group');
                    let valid = true;

                    groups.forEach(group => {
                        const checked = group.querySelectorAll('input[type="checkbox"]:checked');
                        if (checked.length === 0) {
                            valid = false;
                        }
                    });

                    if (!valid) {
                        alert("Her tahlil grubu için en az bir seçenek seçmelisin!");
                        return;
                    }

                    fetch("tahlil_iste.php", {
                        method: "POST",
                        body: formData
                    })
                        .then(response => response.text())
                        .then(data => {
                            console.log("Sunucudan gelen:", data);
                            alert("Tahlil isteği başarıyla gönderildi!");
                            closeModalCustom('tahlilModal');

                            // (İsteğe bağlı) Formu sıfırlamak istersen:
                            form.reset();
                            const removeBtns = document.querySelectorAll('.remove-btn');
                            removeBtns.forEach(btn => btn.closest('.tahlil-group').remove()); // İlk grup hariç hepsini sil
                        })
                        .catch(error => {
                            console.error("Hata:", error);
                            alert("Bir hata oluştu. Lütfen tekrar deneyin.");
                        });
                });





            </script>


</body>

</html>