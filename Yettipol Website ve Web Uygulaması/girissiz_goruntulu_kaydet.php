<?php
session_start();
include('baglanti.php');

// Formdan gelen verileri al
$ktcno = $_POST['tc_no'];
$kisimsoyisim = $_POST['isimsoyisim'];
$kcinsiyet = $_POST['cinsiyet'];
$ktelefon_no = $_POST['telefon_no'];
$kdogtar = $_POST['dogtar'];
$doktor_id = $_POST['doktor'];
$hastane_id = $_POST['hastane'];
$bolum_id = $_POST['bolum'];
$gun = $_POST['gun'];

// Saat kontrolü
if (!isset($_POST['saat'])) {
    echo "<script>alert('Lütfen bir saat seçin.'); window.location.href = 'girissizgoruntulu.php';</script>";
    exit;
}
$saat = $_POST['saat'];

// Önce hastanın zaten var olup olmadığını kontrol et
$kontrol = $conn->query("SELECT * FROM hastalar WHERE tc_no = '$ktcno'");

if ($kontrol->num_rows == 0) {
    // Hasta yoksa ekle
    $sqlHasta = "INSERT INTO hastalar (tc_no, hasta_isimsoyisim, hasta_cinsiyet, hasta_telefon, hasta_dog_tar) 
                 VALUES ('$ktcno', '$kisimsoyisim', '$kcinsiyet', '$ktelefon_no', '$kdogtar')";
    
    if (!$conn->query($sqlHasta)) {
        echo "<script>alert('Hasta eklenirken hata oluştu: " . $conn->error . "'); window.location.href = 'girisyap.php';</script>";
        exit;
    }
}

// Randevuyu ekle
$sqlRandevu = "INSERT INTO randevular (tc_no, doktor_id, hastane_id, bolum_id, randevu_tarih, randevu_saat, randevu_turu, randevu_durumu) 
               VALUES ('$ktcno', '$doktor_id', '$hastane_id', '$bolum_id', '$gun', '$saat', 'online', 'aktif')";

if ($conn->query($sqlRandevu) === TRUE) {
    echo "<script>alert('Randevu başarıyla kaydedildi!'); window.location.href = 'girisyap.php';</script>";
} else {
    echo "<script>alert('Randevu eklenirken hata oluştu: " . $conn->error . "'); window.location.href = 'girisyap.php';</script>";
}

$conn->close();
?>