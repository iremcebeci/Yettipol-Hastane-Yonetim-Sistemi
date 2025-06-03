<?php
session_start();
include 'baglanti.php';

$mesaj = isset($_POST['mesaj']) ? mb_strtolower(trim($_POST['mesaj']), 'UTF-8') : '';
$hastaTc = isset($_POST['tc_no']) ? $_POST['tc_no'] : '';

if (!$mesaj || !$hastaTc) {
    echo 'Mesaj veya kullanıcı bilgisi eksik.';
    exit;
}

if (!isset($_SESSION['son_mesaj'])) {
    $_SESSION['son_mesaj'] = '';
}

// 🔍 Küçük yardımcı fonksiyon
function kelimeVarMi($kelime, $cumle)
{
    return strpos($cumle, $kelime) !== false;
}

// 📅 1. Bugünkü randevu saatini söyle
if (kelimeVarMi('randevu', $mesaj) && kelimeVarMi('kaçta', $mesaj)) {
    $sql = "SELECT d.doktor_isim, r.randevu_saat 
            FROM randevular r 
            JOIN doktorlar d ON r.doktor_id = d.doktor_id 
            WHERE r.tc_no = ? AND r.randevu_tarih = CURDATE() AND r.randevu_durumu = 'aktif' LIMIT 1";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('s', $hastaTc);
    $stmt->execute();
    $result = $stmt->get_result();
    $randevu = $result->fetch_assoc();

    if ($randevu) {
        echo 'Saat ' . date('H:i', strtotime($randevu['randevu_saat'])) . '’te Dr. ' . htmlspecialchars($randevu['doktor_isim']) . ' ile randevunuz var.';
    } else {
        echo 'Bugün için aktif randevunuz bulunmamaktadır.';
    }
    $stmt->close();
}

// ❌ 3. Gerçek iptal talebi
elseif (kelimeVarMi('iptal', $mesaj)) {
    echo 'Randevunuzu iptal etmek için <a href="randevuiptal.php">buraya tıklayabilirsiniz</a>.';
}

// 💊 4. Reçetelerimi Göster
elseif (kelimeVarMi('reçete', $mesaj) || kelimeVarMi('ilaçlarım', $mesaj)) {
    $sql = "SELECT ilac_adi, dozaj, kullanım_sıklığı FROM receteler WHERE tc_no = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('s', $hastaTc);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        echo "Reçeteleriniz:<br>";
        while ($row = $result->fetch_assoc()) {
            echo "- " . htmlspecialchars($row['ilac_adi']) . " / " . $row['dozaj'] . " (" . $row['kullanım_sıklığı'] . ")<br>";
        }
    } else {
        echo "Kayıtlı reçeteniz bulunmamaktadır.";
    }
    $stmt->close();
}

// 🦠 5. Hastalık Geçmişi
elseif (kelimeVarMi('geçmiş', $mesaj) && kelimeVarMi('hastalık', $mesaj)) {
    $sql = "SELECT hastalik_adi, teshis_tarihi FROM hastaliklar WHERE tc_no = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('s', $hastaTc);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        echo "Hastalık geçmişiniz:<br>";
        while ($row = $result->fetch_assoc()) {
            echo "- " . htmlspecialchars($row['hastalik_adi']) . " (" . $row['teshis_tarihi'] . ")<br>";
        }
    } else {
        echo "Hastalık geçmişiniz bulunmuyor.";
    }
    $stmt->close();
}

// 🧪 6. Tahlil istenmiş mi?
elseif (kelimeVarMi('tahlil', $mesaj) && kelimeVarMi('yapıldı', $mesaj)) {
    $sql = "SELECT tahlil_turu, istek_tarihi FROM tahliller WHERE tc_no = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('s', $hastaTc);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows > 0) {
        echo "Yapılan tahliller:<br>";
        while ($row = $result->fetch_assoc()) {
            echo "- " . htmlspecialchars($row['tahlil_turu']) . " (" . $row['istek_tarihi'] . ")<br>";
        }
    } else {
        echo "Herhangi bir tahlil isteği bulunmuyor.";
    }
    $stmt->close();
}

// 🏥 7. Hangi hastanedeyim? 
elseif (kelimeVarMi('hangi hastane', $mesaj) || kelimeVarMi('nereye', $mesaj)) {
    $sql = "SELECT h.hastane_isim, h.hastane_ilce FROM randevular r 
            JOIN hastaneler h ON r.hastane_id = h.hastane_id 
            WHERE r.tc_no = ? ORDER BY r.randevu_tarih DESC LIMIT 1";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('s', $hastaTc);
    $stmt->execute();
    $result = $stmt->get_result();
    $row = $result->fetch_assoc();

    if ($row) {
        echo "Son randevunuz: " . htmlspecialchars($row['hastane_isim']) . " (" . $row['hastane_ilce'] . ")";
    } else {
        echo "Daha önce herhangi bir hastaneye randevunuz olmamış.";
    }
    $stmt->close();
}

// 👋 Selam
elseif (kelimeVarMi('merhaba', $mesaj) || kelimeVarMi('selam', $mesaj)) {
    echo 'Merhaba! Sana nasıl yardımcı olabilirim? 👩‍⚕️ Yazabileceğin şeylerden bazıları: reçetelerim, randevu kaçta, hastalık geçmişi, tahlil yapıldı mı...';
}

// 🔍 Ne yapabilirim?
elseif (kelimeVarMi('neler yapabilirsin', $mesaj)) {
    echo "Ben Yettibot! Yapabileceklerim:<br>
    🕒 Randevu saatlerini söyleyebilirim<br>
    ❌ Randevu iptal işlemini başlatabilirim<br>
    💊 Reçetelerini gösterebilirim<br>
    🦠 Hastalık geçmişini listelerim<br>
    🧪 Tahlil bilgilerini sunabilirim<br>
    🏥 Randevulu hastaneyi söyleyebilirim<br>
    🔜 Daha fazlası yolda! :)";
}

else {
    if (!isset($_SESSION['yettibot_adim'])) {
        $_SESSION['yettibot_adim'] = 0;
        $_SESSION['randevu_verisi'] = [];
    }

    // ADIM 0 – Kullanıcı "randevu" ve "almak" diyorsa başlat
    if ($_SESSION['yettibot_adim'] == 0 && kelimeVarMi('randevu', $mesaj) && kelimeVarMi('almak', $mesaj)) {
        $_SESSION['yettibot_adim'] = 1;
        echo "🩺 Hangi branş için randevu almak istersin? (örn: Kardiyoloji, Genel Cerrahi, Dahiliye)";
    }

    // ADIM 1 – Branş
    elseif ($_SESSION['yettibot_adim'] == 1) {
        $_SESSION['randevu_verisi']['brans'] = ucfirst($mesaj);
        $_SESSION['yettibot_adim'] = 2;
        echo "🏥 Hangi ilçedeki hastaneyi tercih edersin? (örn: Bayrampaşa, Sarıyer, Tuzla)";
    }

    // Randevu türü seçimi (ADIM 2)
    elseif ($_SESSION['yettibot_adim'] == 2) {
        $tur = strtolower(trim($mesaj));
        if ($tur !== 'online' && $tur !== 'hastane') {
            echo "Lütfen sadece 'Online' ya da 'Hastane' yaz.";
        } else {
            $_SESSION['randevu_verisi']['tur'] = ucfirst($tur);
            $_SESSION['yettibot_adim'] = 3;
            echo "📅 Randevu almak istediğin tarihi yaz (örn: 2025-06-05)";
        }
    }

    // Tarih seçimi (ADIM 3)
    elseif ($_SESSION['yettibot_adim'] == 3) {
        $tarih = trim($mesaj);
        $tarihZaman = strtotime($tarih);
        if (!$tarihZaman) {
            echo "Lütfen geçerli bir tarih yaz (örn: 2025-06-05).";
        } else {
            $gun = date('N', $tarihZaman); // 1=Pazartesi ... 7=Pazar
            $tur = strtolower($_SESSION['randevu_verisi']['tur']);

            if ($tur == 'hastane' && ($gun < 1 || $gun > 5)) {
                echo "Hastane randevuları sadece hafta içi Pazartesi-Cuma arasında alınabilir. Başka tarih gir.";
            } elseif ($tur == 'online' && $gun != 6) {
                echo "Online randevular sadece Cumartesi alınabilir. Başka tarih gir.";
            } else {
                $_SESSION['randevu_verisi']['tarih'] = $tarih;
                $_SESSION['yettibot_adim'] = 4;
                echo "⏰ Saat kaçta randevu almak istersin? (09:00, 10:00, 11:00, 13:00, 14:00, 15:00, 16:00, 17:00)";
            }
        }
    }

    // Saat seçimi (ADIM 4)
    elseif ($_SESSION['yettibot_adim'] == 4) {
        $saat = trim($mesaj);
        $izinliSaatler = ['09:00', '10:00', '11:00', '13:00', '14:00', '15:00', '16:00', '17:00'];
        if (!in_array($saat, $izinliSaatler)) {
            echo "Lütfen aşağıdaki saatlerden birini seç: " . implode(', ', $izinliSaatler);
        } else {
            $_SESSION['randevu_verisi']['saat'] = $saat;
            $_SESSION['yettibot_adim'] = 5;
            echo "🏥 Hangi ilçedeki hastaneyi tercih edersin? (örn: Kadıköy, Üsküdar, Beşiktaş)";
        }
    }


    // ADIM 5 – Randevu Türü
    elseif ($_SESSION['yettibot_adim'] == 5) {
        $tur = ucfirst(strtolower($mesaj));
        if ($tur !== 'Online' && $tur !== 'Hastane') {
            echo "Lütfen sadece 'Online' ya da 'Hastane' yaz.";
        } else {
            $_SESSION['randevu_verisi']['tur'] = $tur;

            // Randevu verilerini toplayalım
            $veri = $_SESSION['randevu_verisi'];

            // Doktoru, hastaneyi ve bölümü bul
            $sql = "SELECT d.doktor_id, d.doktor_isim, d.bolum_id, h.hastane_id
                    FROM doktorlar d
                    JOIN hastaneler h ON d.hastane_id = h.hastane_id
                    JOIN bolumler b ON d.bolum_id = b.bolum_id
                    WHERE b.bolum_isim = ? AND h.hastane_ilce = ? LIMIT 1";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param('ss', $veri['brans'], $veri['ilce']);
            $stmt->execute();
            $result = $stmt->get_result();

            if ($doktor = $result->fetch_assoc()) {
                $ekle = $conn->prepare("INSERT INTO randevular 
                    (tc_no, doktor_id, hastane_id, bolum_id, randevu_tarih, randevu_saat, randevu_turu, randevu_durumu) 
                    VALUES (?, ?, ?, ?, ?, ?, ?, 'aktif')");
                $ekle->bind_param(
                    "siissss",
                    $hastaTc,
                    $doktor['doktor_id'],
                    $doktor['hastane_id'],
                    $doktor['bolum_id'],
                    $veri['tarih'],
                    $veri['saat'],
                    $veri['tur']
                );
                $ekle->execute();

                echo "✅ Randevun oluşturuldu!<br>
                🧑‍⚕️ Dr. " . $doktor['doktor_isim'] . "<br>
                📍 İlçe: " . $veri['ilce'] . "<br>
                📅 Tarih: " . $veri['tarih'] . " ⏰ Saat: " . $veri['saat'] . "<br>
                Tür: " . $veri['tur'];

            } else {
                echo "❌ Uygun doktor veya hastane bulunamadı.";
            }

            $_SESSION['yettibot_adim'] = 0;
            $_SESSION['randevu_verisi'] = [];
            $stmt->close();
        }
    }

    // Anlamadığı mesajlara default cevap
    else {
        echo 'Üzgünüm, bu mesajı anlayamadım. 🧠 Bana "neler yapabilirsin" yazarak komutları görebilirsin.';
    }
}




$_SESSION['son_mesaj'] = $mesaj;
?>