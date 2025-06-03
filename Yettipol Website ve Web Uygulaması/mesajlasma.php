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

$sql2 = "SELECT *
                FROM mesajlar
                WHERE gonderen_tc_no = '$user_id'";
$result2 = $conn->query($sql2);
$alicitc = $result2->fetch_assoc();

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

            <div class="menuButonlar3">
                <button><a href="yettipolonline.php">Anasayfa</a></button>
            </div>
        </header>

        <div class="mesajlasmasayfasi">
            <div class="mesajlasmacontainer">
                <div class="konusmalarlistesi">
                    <div class="m_baslik">
                        Sohbetler
                    </div>
                    <div class="m_icerik2">
                        <div class="sohbet-kart"
                            onclick='sohbetAc({name: "YettiBot", type: "bot", img: "img/yettibot.png"}, event)'>

                            <div class="s_kart_img">
                                <img src="img/yettibot.png" alt="">
                            </div>
                            <div class="s_kart_kisi">
                                <b>YettiBot </b>
                            </div>
                        </div>
                    </div>
                    <div class="m_icerik" style="height: 78%;">

                    </div>
                </div>
                <div class="mesajalani">
                    <div class="m_baslik" id="mesajBaslik">

                    </div>
                    <div class="m_icerik">
                        <div class="m_icerik mesajlar-listesi" id="mesajListesi" style="overflow-y:auto; flex-grow: 1;">
                            <!-- Mesajlar burada gösterilecek -->
                        </div>

                        <div class="m_gonderme_alani"
                            style="display:flex; padding:10px; border-top:1px solid #efefef; ">
                            <input type="text" id="mesajInput" placeholder="Mesajınızı yazın..."
                                style="flex-grow:1; padding:8px; border-radius:30px; border:1px solid #ccc;">
                            <button id="gonderBtn"
                                style="margin-left:10px; padding:8px 16px; border:none; background:#485867; color:#fff; border-radius:30px; cursor:pointer;">Gönder</button>
                        </div>
                    </div>
                </div>
                <div class="mumkunlistesi">
                    <div class="m_baslik">
                        İletişim Kurabileceğiniz Doktorlar
                    </div>
                    <div class="m_icerik">

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

            let secilenDoktorTc = null;
            let secilenDoktorIsim = null;
            let secilenDoktorFoto = null;


            fetch("iletisim_kurulabilecek.php")
                .then(res => {
                    if (!res.ok) throw new Error("Sunucu hatası");
                    return res.json();
                })
                .then(data => {
                    const sohbetContainer = document.querySelector(".konusmalarlistesi .m_icerik");
                    const iletisimContainer = document.querySelector(".mumkunlistesi .m_icerik");
                    sohbetContainer.innerHTML = "";
                    iletisimContainer.innerHTML = "";

                    // Sohbetler varsa ekle
                    data.sohbetler.forEach(doktor => {
                        const fotoYolu = doktor.fotograf ? `img/${doktor.fotograf}` : 'img/defaultdoc.png';
                        const kart = document.createElement("div");
                        kart.classList.add("sohbet-kart");
                        kart.innerHTML = `
                <div class="s_kart_img">
                    <img src="${fotoYolu}" alt="">
                </div>
                <div class="s_kart_kisi">
                    <b>${doktor.doktor_isim}</b>
                </div>
            `;
                        kart.setAttribute('data-tc', doktor.doktor_tc);
                        kart.addEventListener("click", (event) => sohbetAc(doktor, event));
                        sohbetContainer.appendChild(kart);
                    });

                    // İletişime açık doktorları ekle
                    data.iletisime_aciklar.forEach(doktor => {
                        const fotoYolu = doktor.fotograf ? `img/${doktor.fotograf}` : 'img/defaultdoc.png';
                        const kart = document.createElement("div");
                        kart.classList.add("sohbet-kart");
                        kart.innerHTML = `
                <div class="s_kart_img">
                    <img src="${fotoYolu}" alt="">
                </div>
                <div class="s_kart_kisi">
                    <b>${doktor.doktor_isim}</b>
                </div>
            `;
                        kart.setAttribute('data-tc', doktor.doktor_tc);
                        kart.addEventListener("click", (event) => sohbetAc(doktor, event));
                        iletisimContainer.appendChild(kart);
                    });
                })
                .catch(err => console.error("Hata:", err));



            function sohbetAc(kisi, event) {
                document.querySelectorAll('.sohbet-kart').forEach(el => el.classList.remove('active'));
                event.currentTarget.classList.add('active');


                secilenDoktorTc = kisi.type === 'bot' ? 'YETTIBOT' : kisi.doktor_tc;
                secilenDoktorIsim = kisi.doktor_isim;
                secilenDoktorFoto = kisi.fotograf ? `img/${kisi.fotograf}` : 'img/defaultdoc.png';


                mesajBasliginiGuncelle(kisi);

                if (kisi.type !== 'bot') {
                    doktorBilgileriniYukle(kisi.doktor_id);
                }

                // Seçimi localStorage'a kaydet
                localStorage.setItem('seciliDoktorTc', secilenDoktorTc);

                fetchMesajlar(secilenDoktorTc);
            }


            const mesajListesi = document.getElementById('mesajListesi');
            const user_id = "<?php echo $_SESSION['user_id']; ?>";

            function fetchMesajlar(secilenDoktorTc) {
                fetch(`mesajlari_cek.php?karsi_tc=${encodeURIComponent(secilenDoktorTc)}`)
                    .then(res => res.text())  // önce text olarak al, JSON parse hatasını kolay yakalamak için
                    .then(text => {
                        console.log('Sunucudan gelen ham mesajlar cevabı:', text);
                        try {
                            const data = JSON.parse(text);  // JSON parse yap
                            mesajListesi.innerHTML = '';   // temizle

                            data.forEach(mesaj => {
                                const div = document.createElement('div');
                                div.style.padding = '10px';
                                div.style.margin = '5px 10px';
                                div.style.maxWidth = '70%';
                                div.style.borderRadius = '10px';
                                div.style.position = 'relative'; // alt bilgi için

                                // Mesaj metni
                                const mesajMetni = document.createElement('div');
                                mesajMetni.textContent = mesaj.mesaj_text;

                                // Alt bilgi div'i (tarih ve okundu)
                                const altBilgi = document.createElement('div');
                                altBilgi.style.fontSize = '10px';
                                altBilgi.style.color = '#666';
                                altBilgi.style.marginTop = '5px';
                                altBilgi.style.textAlign = 'right';

                                // Tarih ve saat ayrımı
                                const tarih = new Date(mesaj.gonderme_tarihi);
                                // Gün.Ay.Yıl (örn: 19.05.2025)
                                const tarihStr = tarih.toLocaleDateString('tr-TR');
                                // Saat:dakika (örn: 22:27)
                                const saatDakika = tarih.toLocaleTimeString('tr-TR', { hour: '2-digit', minute: '2-digit' });

                                // Okundu bilgisi
                                const okunduYazisi = mesaj.goruldu_mu == 1 ? '✓✓' : '✓';

                                altBilgi.innerHTML = `
        <div>${tarihStr} - ${saatDakika}</div>
    `;

                                if (mesaj.gonderen_tc_no === user_id) {
                                    div.style.backgroundColor = '#2c3e50';
                                    div.style.color = 'white';
                                    div.style.marginLeft = 'auto';
                                    div.style.textAlign = 'right';
                                } else {
                                    div.style.backgroundColor = '#aaa';
                                    div.style.color = '#000';
                                    div.style.marginRight = 'auto';
                                    div.style.textAlign = 'left';
                                }

                                div.appendChild(mesajMetni);
                                div.appendChild(altBilgi);
                                mesajListesi.appendChild(div);
                                scrollMesajListesi();
                            });

                        } catch (e) {
                            console.error('JSON parse hatası:', e);
                            mesajListesi.innerHTML = '<div style="color:red">Mesajlar yüklenemedi!</div>';
                        }
                    })
                    .catch(err => console.error('Mesaj çekme hatası:', err));
            }






            function mesajBasliginiGuncelle(kisi) {
                const baslik = document.getElementById("mesajBaslik");

                if (kisi.type === "bot") {
                    baslik.innerHTML = `
            <img src="${kisi.img}" alt="${kisi.name}" style="width:40px; height:40px; border-radius:50%; margin-left: 20px; vertical-align:middle; margin-right:10px;">
            <span>${kisi.name}</span>
        `;
                } else {
                    const fotoYolu = kisi.fotograf ? `img/${kisi.fotograf}` : 'img/defaultdoc.png';
                    baslik.innerHTML = `
            <img src="${fotoYolu}" alt="${kisi.doktor_isim}" style="width:40px; height:40px; border-radius:50%; margin-left: 20px; vertical-align:middle; margin-right:10px;">
            <span>${kisi.doktor_isim}</span>
        `;
                }
            }

            window.onload = () => {
                document.getElementById('gonderBtn').addEventListener('click', function (e) {
                    e.preventDefault();

                    const mesajInput = document.getElementById('mesajInput');
                    const mesaj = mesajInput.value.trim();

                    if (!mesaj) return alert('Mesaj boş olamaz!');

                    if (!secilenDoktorTc) {
                        return alert('Lütfen önce bir doktor seçin!');
                    }

                    // YETTIBOT kontrolü
                    if (secilenDoktorTc === 'YETTIBOT') {
                        kullaniciMesajiYaz(mesaj);
                        mesajInput.value = '';
                        setTimeout(() => {
                            yettiBotCevapVer(mesaj);
                        }, 500);
                        return; // sunucuya gönderme
                    }

                    // Normal doktor için mesaj gönderme
                    fetch('mesajgonder.php', {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                        body: new URLSearchParams({
                            alici_tc_no: secilenDoktorTc,
                            mesaj_text: mesaj
                        })
                    })
                        .then(res => res.text())
                        .then(text => {
                            console.log("Sunucudan gelen ham veri:", text);
                            return JSON.parse(text);
                        })
                        .then(data => {
                            if (data.success) {
                                mesajInput.value = '';
                                sohbetKartiniGuncelle(secilenDoktorTc, secilenDoktorIsim, secilenDoktorFoto);
                                fetchMesajlar(secilenDoktorTc);
                            } else {
                                alert(data.error || 'Mesaj gönderilemedi!');
                            }
                        })
                        .catch(err => {
                            alert('Sunucu ile bağlantı kurulamadı! ' + err.message);
                            console.error(err);
                        });

                });
            };





            let doktorBilgileriCache = {};

            function doktorBilgileriniYukle(doktorId) {
                if (doktorBilgileriCache[doktorId]) {
                    // Eğer önceden çekildiyse direkt kullan
                    console.log("Cache’den çekilen doktor bilgileri:", doktorBilgileriCache[doktorId]);
                    return Promise.resolve(doktorBilgileriCache[doktorId]);
                }
                return fetch('doktor_bilgi.php?doktor_id=' + encodeURIComponent(doktorId))
                    .then(res => res.json())
                    .then(data => {
                        if (data.error) {
                            console.error('Doktor bilgisi alınamadı:', data.error);
                            throw new Error(data.error);
                        }
                        doktorBilgileriCache[doktorId] = data; // Cache’le
                        console.log("Sunucudan çekilen doktor bilgileri:", data);
                        return data;
                    })
                    .catch(err => {
                        console.error('Sunucu bağlantı hatası:', err);
                        throw err;
                    });
            }





            function scrollMesajListesi() {
                const mesajListesi = document.getElementById('mesajListesi');
                if (mesajListesi) {
                    mesajListesi.scrollTop = mesajListesi.scrollHeight;
                }
            }

            function sohbetKartiniGuncelle(tcNo, isim, imgSrc) {
                const sohbetlerIcerik = document.querySelector('.konusmalarlistesi .m_icerik');
                if (!sohbetlerIcerik) return;

                // Var mı diye bak (data-tc attribute ekleyelim)
                let kart = sohbetlerIcerik.querySelector(`[data-tc="${tcNo}"]`);

                if (kart) {
                    // Varsa en üste taşı
                    sohbetlerIcerik.prepend(kart);
                } else {
                    // Yoksa yeni kart yarat
                    kart = document.createElement('div');
                    kart.className = 'sohbet-kart';
                    kart.setAttribute('data-tc', tcNo);

                    // onclick olayını dinamik olarak ayarlayalım
                    kart.onclick = function (event) {
                        sohbetAc({ name: isim, type: "doktor", img: imgSrc }, event);
                    };

                    kart.innerHTML = `
            <div class="s_kart_img">
                <img src="${imgSrc}" alt="${isim}">
            </div>
            <div class="s_kart_kisi">
                <b>${isim}</b>
            </div>
        `;

                    sohbetlerIcerik.prepend(kart);
                }
            }

            function kullaniciMesajiYaz(mesajText) {
                const mesajListesi = document.getElementById('mesajListesi');

                const div = document.createElement('div');
                div.style.padding = '10px';
                div.style.margin = '5px 10px';
                div.style.maxWidth = '70%';
                div.style.borderRadius = '10px';
                div.style.backgroundColor = '#2c3e50';
                div.style.color = 'white';
                div.style.marginLeft = 'auto';
                div.style.textAlign = 'right';

                const mesajMetni = document.createElement('div');
                mesajMetni.textContent = mesajText;

                const altBilgi = document.createElement('div');
                altBilgi.style.fontSize = '10px';
                altBilgi.style.color = '#ccc';
                altBilgi.style.marginTop = '5px';
                altBilgi.style.textAlign = 'right';

                const now = new Date();
                const tarihStr = now.toLocaleDateString('tr-TR');
                const saatStr = now.toLocaleTimeString('tr-TR', { hour: '2-digit', minute: '2-digit' });

                altBilgi.innerHTML = `<div>${tarihStr} - ${saatStr}</div>`;

                div.appendChild(mesajMetni);
                div.appendChild(altBilgi);
                mesajListesi.appendChild(div);
                mesajListesi.scrollTop = mesajListesi.scrollHeight;
            }



            function yettiBotCevapVer(gelenMesaj) {
                const mesajListesi = document.getElementById('mesajListesi');

                fetch('yettibotcevap.php', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    body: new URLSearchParams({
                        mesaj: gelenMesaj,
                        tc_no: user_id
                    })
                })
                    .then(res => res.text())
                    .then(cevap => {
                        const div = document.createElement('div');
                        div.style.padding = '10px';
                        div.style.margin = '5px 10px';
                        div.style.maxWidth = '70%';
                        div.style.borderRadius = '10px';
                        div.style.backgroundColor = '#aaa';
                        div.style.color = '#000';
                        div.style.marginRight = 'auto';
                        div.style.textAlign = 'left';

                        const mesajMetni = document.createElement('div');
                        mesajMetni.innerHTML = cevap;

                        const altBilgi = document.createElement('div');
                        altBilgi.style.fontSize = '10px';
                        altBilgi.style.color = '#666';
                        altBilgi.style.marginTop = '5px';
                        altBilgi.style.textAlign = 'right';

                        const now = new Date();
                        const tarihStr = now.toLocaleDateString('tr-TR');
                        const saatStr = now.toLocaleTimeString('tr-TR', { hour: '2-digit', minute: '2-digit' });

                        altBilgi.innerHTML = `<div>${tarihStr} - ${saatStr}</div>`;

                        div.appendChild(mesajMetni);
                        div.appendChild(altBilgi);
                        mesajListesi.appendChild(div);
                        mesajListesi.scrollTop = mesajListesi.scrollHeight;
                    })
                    .catch(err => {
                        console.error("YettiBot cevap verirken hata:", err);
                    });
            }







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