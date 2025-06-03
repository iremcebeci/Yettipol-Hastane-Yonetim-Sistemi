<?php
session_start();
include('baglanti.php');

$user_id = $_SESSION['user_id'];

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

$hasta_tc = $_POST['hasta_tc'];
$tahlil_id = $_POST['tahlil_id'];
$tahlil_turu_id = $_POST['tahlil_turu_id'];


// Görüntüleme testleri için ID'ler (9-10-11-12)
$goruntuleme_idler = [9, 10, 11, 12];

if (in_array($tahlil_turu_id, $goruntuleme_idler)) {
    // 📸 Görüntüleme testi kaydetme
    $cekim_turu_map = [
        9 => 'Röntgen',
        10 => 'MR',
        11 => 'BT',
        12 => 'Ultrason'
    ];

    $cekim_turu = $cekim_turu_map[$tahlil_turu_id];
    $cekim_tarihi = date('Y-m-d'); // Bugünün tarihi
    $teknik_bilgi = $_POST['teknik_bilgi'] ?? '';
    $bulgular = $_POST['bulgular'] ?? '';
    $sonuc_degerlendirme = $_POST['sonuc_degerlendirme'] ?? '';
    $oneriler = $_POST['oneriler'] ?? '';
    $imza = "Uzm. " . $_POST['imza']; // veya ayrı sütun

    $stmt = $conn->prepare("INSERT INTO goruntuleme_raporlari 
        (tahlil_id, hasta_tc, cekim_tarihi, cekim_turu, teknik_bilgi, bulgular, sonuc_degerlendirme, oneriler, imza) 
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)");
    $stmt->bind_param("issssssss", $tahlil_id,$hasta_tc, $cekim_tarihi, $cekim_turu, $teknik_bilgi, $bulgular, $sonuc_degerlendirme, $oneriler, $imza);
    $stmt->execute();

    exit;
}

// 📊 Parametreli test sonucu kaydetme
foreach ($_POST['deger'] ?? [] as $parametre_id => $deger) {
    $stmt = $conn->prepare("INSERT INTO tahlil_sonuclari (tahlil_id, hasta_id, tahlil_turu_id, parametre_id, deger, tarih) VALUES (?, ?, ?, ?, ?, NOW())");
    $stmt->bind_param("isisd", $tahlil_id, $hasta_tc, $tahlil_turu_id, $parametre_id, $deger);
    $stmt->execute();
}

// Kategorik değerler (metin olarak girilenler)
foreach ($_POST['deger_metni'] ?? [] as $parametre_id => $deger_metni) {
    $stmt = $conn->prepare("INSERT INTO tahlil_sonuclari (tahlil_id, hasta_id, tahlil_turu_id, parametre_id, deger, tarih) VALUES (?, ?, ?, ?, ?, NOW())");
    $stmt->bind_param("isiss", $hasta_tc, $tahlil_id, $tahlil_turu_id, $parametre_id, $deger_metni);
    $stmt->execute();
}

exit;


?>