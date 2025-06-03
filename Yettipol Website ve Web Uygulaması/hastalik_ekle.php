<?php
session_start();
include('baglanti.php');

// Oturumdan doktor bilgisi
$doktortc = $_SESSION['user_id'] ?? null; // Doktorun TC'si

// Kullanıcı bilgilerini almak için veritabanı sorgusu
$sql = "SELECT doktor_id FROM doktorlar WHERE tc_no = '$doktortc'";
$result = $conn->query($sql);
$doktor = $result->fetch_assoc();  // Veriyi al
$doktorid = $doktor['doktor_id']; // Doktor ID'si

// Formdan gelen veriler
$hastatc   = $_POST['tc_no'];  // Hastanın TC'si
$tarih    = $_POST['tarih'];
$saat     = $_POST['saat'];

$hastaliklar = $_POST['hastalik'];
$aciklamalar = $_POST['hastalikAciklama'];

// Hastanın TC numarasını kontrol et (var mı diye)
$check_query = "SELECT COUNT(*) AS count FROM hastalar WHERE tc_no = '$hastatc'";
$check_result = $conn->query($check_query);
$row = $check_result->fetch_assoc();
if ($row['count'] == 0) {
    echo "Hastanın TC numarası bulunamadı!";
    exit;
}

// Tüm ilaçları teker teker ekle
for ($i = 0; $i < count($hastaliklar); $i++) {
    $hastalik = $hastaliklar[$i];
    $aciklama = is_array($aciklamalar) ? $aciklamalar[$i] : $aciklamalar; // Tek açıklama geldiyse

    // Veritabanına veri ekle
    $stmt = $conn->prepare("INSERT INTO hastaliklar (tc_no, doktor_id, hastalik_adi, hastalik_aciklama, teshis_tarihi) VALUES (?, ?, ?, ?, ?)");
    $stmt->bind_param("sisss", $hastatc, $doktorid, $hastalik, $aciklama, $tarih);
    $stmt->execute();
}

echo "Hastalık başarıyla kaydedildi.";

$conn->close();
?>