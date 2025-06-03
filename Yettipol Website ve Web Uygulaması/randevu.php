<?php
session_start();
include('baglanti.php'); // Veritabanı bağlantısı

// Kullanıcı ID kontrolü
if (isset($_SESSION['user_id'])) {
    $user_id = $_SESSION['user_id'];

    // Güvenli SQL Sorgusu
    $stmt = $conn->prepare("SELECT * FROM kullanicilar WHERE tc_no = ?");
    $stmt->bind_param("s", $user_id);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        $user = $result->fetch_assoc();
    } else {
        echo "Kullanıcı bulunamadı.";
        exit;
    }
} else {
    echo "Lütfen giriş yapın.";
    exit;
}

// Ad soyad baş harflerini al
$ad_soyad = str_replace(['Ö', 'Ü', 'Ş', 'Ç', 'İ', 'Ğ', 'ı'], ['O', 'U', 'S', 'C', 'I', 'G', 'i'], $user['hasta_isimsoyisim']);
$ad_soyad = strtoupper($ad_soyad);
$harfler = explode(" ", $ad_soyad);

$ilk_harfler = $harfler[0][0];
if (isset($harfler[1])) {
    $ilk_harfler .= $harfler[1][0];
}


// Saat ve gün listeleri
$saatler = ['09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00'];
$gunler = ['Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi', 'Pazar'];

$aylar = [
    '01' => 'Ocak',
    '02' => 'Şubat',
    '03' => 'Mart',
    '04' => 'Nisan',
    '05' => 'Mayıs',
    '06' => 'Haziran',
    '07' => 'Temmuz',
    '08' => 'Ağustos',
    '09' => 'Eylül',
    '10' => 'Ekim',
    '11' => 'Kasım',
    '12' => 'Aralık'
];


?>

<!DOCTYPE html>
<html lang="tr">

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
                <div class="header-fotograf"><?php echo $ilk_harfler; ?>
                </div>
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
                                <p><a href="cikisyap.php" style="color: rgb(149, 7, 7);">Çıkış Yap</a></p>
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
        <div class="icerik">
            <div class="yanmenu">
                <button><a href="yettipolonline.php">Anasayfa</a></button>
                <button id="logout" class="ikincibuton"><a href="cikisyap.php">Çıkış Yap</a></button>

            </div>
            <div class="hayaletdiv"></div>

            <form action="randevu_kaydet.php" method="POST" class="randevu-al-form">
                <div class="randevu-al-container">

                    <div class="randevu-al-kutusu">
                        <div class="randevu-al-baslik">Hastane Randevusu Al</div>
                        <div class="randevu-al">
                            <p>Lütfen randevu almak istediğiniz hastane, bölüm ve doktor seçimini yapınız.</p>
                            <h3>Hastane Seçiniz:</h3>
                            <select id="hastane" class="custom-combo" name="hastane">
                                <option value="" disabled selected hidden>Hastane seçiniz</option>
                            </select>

                            <h3>Bölüm Seçiniz:</h3>
                            <select id="bolum" class="custom-combo" name="bolum">
                                <option value="" disabled selected hidden>Önceki adımı tamamlayınız.</option>
                            </select>

                            <h3>Doktor Seçiniz:</h3>
                            <div id="doktor" class="doctor-cards">
                                <p>Önceki adımı tamamlayınız.</p>
                            </div>

                            <button class="temizlebuton" type="button" onclick="formuTemizle()">Temizle</button>
                        </div>
                    </div>

                    <div class="randevu-takvimi-kutusu">
                        <!-- Takvim Başlığı -->
                        <div class="randevu-takvimi-baslik">
                            Gün ve Saat Seçiniz
                        </div>

                        <fieldset class="gunbuttonkutu">
                            <legend>Bir gün seçin:</legend>
                            <?php
                            // Bugünün tarihi
                            $bugun = new DateTime();

                            // Haftanın başlangıcı (Pazartesi)
                            $haftaBaslangic = new DateTime();
                            $haftaBaslangic->modify('last monday'); // Pazartesi'yi bul
                            
                            // Haftanın bitişi (Pazar)
                            $haftaBitisi = clone $haftaBaslangic;
                            $haftaBitisi->modify('next sunday'); // Pazar'ı bul
                            
                            // Eğer bugün haftasonuysa, bir sonraki hafta başlasın
                            if ($bugun > $haftaBitisi) {
                                $haftaBaslangic->modify('+1 week'); // Bir hafta ileri al
                            }

                            // Günler ve aylar
                            $gunler = ['Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma']; // Haftalık günler
                            $aylar = [
                                '01' => 'Ocak',
                                '02' => 'Şubat',
                                '03' => 'Mart',
                                '04' => 'Nisan',
                                '05' => 'Mayıs',
                                '06' => 'Haziran',
                                '07' => 'Temmuz',
                                '08' => 'Ağustos',
                                '09' => 'Eylül',
                                '10' => 'Ekim',
                                '11' => 'Kasım',
                                '12' => 'Aralık'
                            ];

                            $gunSayaci = 0;

                            // 3 hafta boyunca döngü
                            for ($week = 0; $week < 3; $week++) {
                                echo "<div class='gun-grubu'>"; // 5'li grup başlangıcı
                                for ($i = 0; $i < 5; $i++) { // Pazartesi-Cuma günleri
                                    // Her hafta başından itibaren günü doğru ayarlıyoruz
                                    $gunTarihi = clone $haftaBaslangic;
                                    $gunTarihi->modify("+$week week +$i day"); // 3 hafta boyunca döngü
                            
                                    // Haftanın gününü almak
                                    $gunIndex = (int) $gunTarihi->format('w');  // 'w' => haftanın günü (0=Sunday, 1=Monday, ..., 6=Saturday)
                            
                                    // Hafta sonlarını (Pazar ve Cumartesi) atla
                                    if ($gunIndex == 0 || $gunIndex == 6) {
                                        continue;
                                    }

                                    // Tarih ve etiket hazırlama
                                    $tarih = $gunTarihi->format('Y-m-d');
                                    $gün = $gunTarihi->format('d');
                                    $ay = $aylar[$gunTarihi->format('m')];
                                    $yil = $gunTarihi->format('Y');
                                    $gosterilecek = "$gün $ay $yil";

                                    // Eğer gün geçmişse, devre dışı bırak
                                    if ($gunTarihi->format('Y-m-d') < $bugun->format('Y-m-d')) {
                                        echo "<input type='radio' name='gun' value='$tarih' id='$tarih' class='gun-radio hidden-radio' disabled>
                      <label for='$tarih' class='gun-button' style='background-color: gray; cursor: not-allowed; opacity: 0.6;'>$gosterilecek  {$gunler[$i]}</label><br>";
                                    } else {
                                        echo "<input type='radio' name='gun' value='$tarih' id='$tarih' class='gun-radio hidden-radio'>
                      <label for='$tarih' class='gun-button'>$gosterilecek  {$gunler[$i]}</label><br>";
                                    }

                                    $gunSayaci++;

                                    // 5'li grup tamamlandıysa, yeni gruba geç
                                    if ($gunSayaci % 5 === 0) {
                                        echo "</div><div class='gun-grubu'>";
                                    }
                                }
                                echo "</div>"; // 5'li grup sonu
                            }
                            ?>
                        </fieldset>







                        <!-- Saat Seçimi -->
                        <fieldset class="saatbuttonkutu">
                            <legend>Bir saat seçin:</legend>
                            <?php
                            $saatler = ['09:00', '10:00', '11:00', '13:00', '14:00', '15:00', '16:00', '17:00'];
                            foreach ($saatler as $saat) {
                                echo "<input type='radio' name='saat' value='$saat' id='$saat' class='saat-radio hidden-radio'>
                                        <label for='$saat' class='saat-button'>$saat</label><br>";
                            }
                            ?>
                        </fieldset>

                        <!-- Onay Butonu -->
                        <div class="rndalbutonyeri">
                            <button class="randevu-onayla-button" type="submit" name="onayla">Onayla</button>
                        </div>
                    </div>

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

        window.onload = function () {
            // İlk başta hastaneleri yükle
            fetch('hastane_getir.php')
                .then(response => response.text())
                .then(data => {
                    document.getElementById("hastane").innerHTML += data;
                });

            document.getElementById("hastane").addEventListener("change", function () {
                const hastaneID = this.value;
                fetch('bolum_getir.php?hastane_id=' + hastaneID)
                    .then(response => response.text())
                    .then(data => {
                        document.getElementById("bolum").innerHTML = '<option value="" disabled selected hidden>Bölüm seçiniz</option>' + data;
                        document.getElementById("doktor").innerHTML = '<option value="" disabled selected hidden>Önceki adımı tamamlayınız.</option>';
                    });
            });

            document.getElementById("bolum").addEventListener("change", function () {
                const bolumID = this.value;
                fetch('doktor_getir.php?bolum_id=' + bolumID)
                    .then(response => response.text())
                    .then(data => {
                        document.getElementById("doktor").innerHTML = '' + data;
                    });
            });

            document.querySelectorAll('.gun-radio').forEach(gunRadio => {
                gunRadio.addEventListener("change", function () {
                    const secilenTarih = this.value;
                    const doktorID = document.getElementById("doktor").value;
                    const hastaneID = document.getElementById("hastane").value;
                    const bolumID = document.getElementById("bolum").value;

                    fetch('gun_getir.php?doktor_id=' + doktorID)
                        .then(response => response.json())
                        .then(data => {
                            const saatler = document.querySelectorAll('.saat-radio');

                            // Tüm saatleri aktif hale getir
                            saatler.forEach(saat => {
                                saat.disabled = false;
                                const label = document.querySelector(`label[for='${saat.id}']`);
                                if (label) {
                                    label.style.backgroundColor = '';
                                    label.style.cursor = '';
                                    label.style.opacity = '';
                                }
                            });

                            // Bugünün tarihi ve saat bilgisi
                            const simdi = new Date();
                            const bugunStr = simdi.toISOString().split('T')[0];

                            if (secilenTarih === bugunStr) {
                                saatler.forEach(saat => {
                                    const saatDegeri = saat.value; // örn: "13:00"
                                    const [saatH, dakika] = saatDegeri.split(':');
                                    const saatTarihi = new Date(secilenTarih);
                                    saatTarihi.setHours(parseInt(saatH));
                                    saatTarihi.setMinutes(parseInt(dakika));
                                    saatTarihi.setSeconds(0);

                                    if (saatTarihi <= simdi) {
                                        saat.disabled = true;
                                        const label = document.querySelector(`label[for='${saat.id}']`);
                                        if (label) {
                                            label.style.backgroundColor = 'gray';
                                            label.style.cursor = 'not-allowed';
                                            label.style.opacity = '0.6';
                                        }
                                    }
                                });
                            }

                            // Filtrele ve eşleşenleri pasifleştir
                            data.forEach(randevu => {
                                const randevuSaat = randevu.randevu_saat.substring(0, 5); // "11:00:00" → "11:00"

                                if (
                                    randevu.randevu_tarih === secilenTarih &&
                                    randevu.doktor_id === doktorID &&
                                    randevu.hastane_id === hastaneID &&
                                    randevu.bolum_id === bolumID &&
                                    (randevu.randevu_durumu === 'aktif' || randevu.randevu_durumu === 'geçmiş')
                                ) {
                                    saatler.forEach(saat => {
                                        if (saat.value === randevuSaat) {
                                            saat.disabled = true;

                                            const label = document.querySelector(`label[for='${saat.id}']`);
                                            if (label) {
                                                label.style.backgroundColor = 'gray';
                                                label.style.cursor = 'not-allowed';
                                                label.style.opacity = '0.6';
                                            }
                                        }
                                    });
                                }
                            });
                        });
                });
            });

            // Doktor seçildiğinde dolu günleri hemen gri yapacak kodu ekliyoruz
            document.getElementById("doktor").addEventListener("change", function () {
                const doktorID = this.value;
                const hastaneID = document.getElementById("hastane").value;
                const bolumID = document.getElementById("bolum").value;

                if (doktorID && hastaneID && bolumID) {
                    fetch('gun_getir.php?doktor_id=' + doktorID)
                        .then(response => response.json())
                        .then(data => {
                            document.querySelectorAll('.gun-radio').forEach(gunBtn => {
                                const gunTarih = gunBtn.value;

                                const gununRandevulari = data.filter(r =>
                                    r.randevu_tarih === gunTarih &&
                                    r.doktor_id === doktorID &&
                                    r.hastane_id === hastaneID &&
                                    r.bolum_id === bolumID &&
                                    (r.randevu_durumu === 'aktif' || r.randevu_durumu === 'geçmiş')
                                );

                                const doluSaatler = [...new Set(gununRandevulari.map(r => r.randevu_saat.substring(0, 5)))];

                                if (doluSaatler.length >= 8) {
                                    gunBtn.disabled = true;
                                    const gunLabel = document.querySelector(`label[for='${gunBtn.id}']`);
                                    if (gunLabel) {
                                        gunLabel.style.backgroundColor = 'gray';
                                        gunLabel.style.cursor = 'not-allowed';
                                        gunLabel.style.opacity = '0.6';
                                    }
                                }
                            });
                        });
                }
            });

            // Bugünün tarihini al
            const today = new Date().toISOString().split('T')[0]; // YYYY-MM-DD formatında

            // Sayfa yüklendiğinde geçmiş günleri gri yap
            disablePastDays(today);

        }

        // Geçmiş günleri gri yapacak fonksiyon
        function disablePastDays(today) {
            document.querySelectorAll('.gun-radio').forEach(gunBtn => {
                const gunTarih = gunBtn.value;

                if (gunTarih < today) { // Eğer tarih bugünden önceyse
                    gunBtn.disabled = true;
                    const gunLabel = document.querySelector(`label[for='${gunBtn.id}']`);
                    if (gunLabel) {
                        gunLabel.style.backgroundColor = 'gray';
                        gunLabel.style.cursor = 'not-allowed';
                        gunLabel.style.opacity = '0.6';
                    }
                }
            });
        }

        function formuTemizle() {
            // inputları temizle
            document.getElementById("hastane").value = "";

            // Bölüm dropdown'ını sıfırla
            const bolumSelect = document.getElementById("bolum");
            bolumSelect.innerHTML = '<option value="">Önceki adımı tamamlayınız.</option>';

            // Doktor dropdown'ını sıfırla
            const doktorSelect = document.getElementById("doktor");
            doktorSelect.innerHTML = '<option value="">Önceki adımı tamamlayınız.</option>';
        }


    </script>
</body>

</html>