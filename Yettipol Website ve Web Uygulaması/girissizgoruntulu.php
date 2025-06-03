<?php
session_start();
include('baglanti.php'); // Veritabanı bağlantısı


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


            <div class="menuButonlar2">
                <button><a href="girissizrandevu.php">Hastane<br>Randevusu Al</a></button>
                <button><a href="girisyap.html">Giriş Yap</a></button>
            </div>
        </header>
        <div class="icerik">

            <form action="girissiz_goruntulu_kaydet.php" method="POST" class="randevu-al-form2">
                <div class="randevu-al-container2">

                    <div class="hayaletdiv3"></div>

                    <div class="girissizrandevuform">
                        <div class="girissiz-baslik">Bilgilerinizi Giriniz</div>
                        <div class="girissizrand">
                            <label for="tc_no">TC Kimlik Numarası:</label>
                            <input type="text" id="tc_no" name="tc_no" required pattern="\d{11}"
                                title="TC Kimlik Numarası 11 haneli olmalıdır">

                            <label for="isim">İsim Soyisim:</label>
                            <input type="text" id="isimsoyisim" name="isimsoyisim" required>

                            <label for="cinsiyet">Cinsiyet:</label>
                            <select id="cinsiyet" name="cinsiyet" required>
                                <option value="" disabled selected>Cinsiyet Seçiniz</option>
                                <option value="erkek">Erkek</option>
                                <option value="kadın">Kadın</option>
                            </select>

                            <label for="telefon_no">Telefon Numarası:</label>
                            <input type="text" id="telefon_no" name="telefon_no" required pattern="\d{11}"
                                title="Telefon numarası 11 haneli olmalıdır">

                            <label for="dogtar">Doğum Tarihi:</label>
                            <input type="date" id="dogtar" name="dogtar" required>
                        </div>

                    </div>

                    <div class="randevu-al-kutusu2">
                        <div class="randevu-al-baslik">Görüntülü Görüşme Randevusu Al</div>
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

                    <div class="randevu-takvimi-kutusu2">
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
                            
                            // Eğer bugün Cumartesi'yi geçtiyse, bir sonraki haftaya geçelim
                            if ($bugun > $haftaBitisi) {
                                $haftaBaslangic->modify('+1 week'); // Bir hafta ileri al
                            }

                            // Aylar
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

                            // 3 hafta boyunca Cumartesi'leri göster
                            for ($week = 0; $week < 3; $week++) {
                                // Cumartesi'yi almak için hafta başından 5 gün sonrası (Cumartesi'yi bul)
                                $cumartesiTarihi = clone $haftaBaslangic;
                                $cumartesiTarihi->modify("+$week week +5 day"); // Cumartesi günü
                            
                                // Tarih ve etiket hazırlama
                                $tarih = $cumartesiTarihi->format('Y-m-d');
                                $gün = $cumartesiTarihi->format('d');
                                $ay = $aylar[$cumartesiTarihi->format('m')];
                                $yil = $cumartesiTarihi->format('Y');
                                $gosterilecek = "$gün $ay $yil";

                                // Eğer gün geçmişse, devre dışı bırak
                                if ($cumartesiTarihi->format('Y-m-d') < $bugun->format('Y-m-d')) {
                                    echo "<input type='radio' name='gun' value='$tarih' id='$tarih' class='gun-radio' disabled>
            <label for='$tarih' class='gun-button' style='background-color: gray; cursor: not-allowed; opacity: 0.6;'>$gosterilecek  Cumartesi</label><br>";
                                } else {
                                    echo "<input type='radio' name='gun' value='$tarih' id='$tarih' class='gun-radio'>
            <label for='$tarih' class='gun-button'>$gosterilecek  Cumartesi</label><br>";
                                }
                            }
                            ?>
                        </fieldset>









                        <!-- Saat Seçimi -->
                        <fieldset class="saatbuttonkutu">
                            <legend>Bir saat seçin:</legend>
                            <?php
                            $saatler = ['09:00', '10:00', '11:00', '13:00', '14:00', '15:00'];
                            foreach ($saatler as $saat) {
                                echo "<input type='radio' name='saat' value='$saat' id='$saat' class='saat-radio  hidden-radio'>
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
    <script>

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
                        document.getElementById("doktor").innerHTML = '<option value="" disabled selected hidden>Doktor seçiniz</option>' + data;
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