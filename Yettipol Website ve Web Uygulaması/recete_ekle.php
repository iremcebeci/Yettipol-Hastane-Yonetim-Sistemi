<?php
session_start();
include('baglanti.php');

echo "<pre>";
print_r($_POST);
echo "</pre>";

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

$ilaclar  = $_POST['ilac'];
$dozajlar = $_POST['dozaj'];
$sikliklar = $_POST['siklik'];
$aciklamalar = $_POST['receteAciklama'];

// Hastanın TC numarasını kontrol et (var mı diye)
$check_query = "SELECT COUNT(*) AS count FROM hastalar WHERE tc_no = '$hastatc'";
$check_result = $conn->query($check_query);
$row = $check_result->fetch_assoc();
if ($row['count'] == 0) {
    echo "Hastanın TC numarası bulunamadı!";
    exit;
}

// Tüm ilaçları teker teker ekle
for ($i = 0; $i < count($ilaclar); $i++) {
    $ilac = $ilaclar[$i];
    $doz = $dozajlar[$i];
    $siklik = $sikliklar[$i];
    $aciklama = is_array($aciklamalar) ? $aciklamalar[$i] : $aciklamalar; // Tek açıklama geldiyse

    // Veritabanına veri ekle
    $stmt = $conn->prepare("INSERT INTO receteler (tc_no, doktor_id, ilac_adi, dozaj, kullanim_sikligi, aciklama) VALUES (?, ?, ?, ?, ?, ?)");
    $stmt->bind_param("sissss", $hastatc, $doktorid, $ilac, $doz, $siklik, $aciklama);
    $stmt->execute();
}

$conn->close();
?>
