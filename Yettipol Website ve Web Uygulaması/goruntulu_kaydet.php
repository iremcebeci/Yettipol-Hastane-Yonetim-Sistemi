<?php
session_start();
include('baglanti.php');

// Kullanıcı bilgilerini almak
if (isset($_SESSION['user_id'])) {
    $user_id = $_SESSION['user_id'];  // Oturumdaki user_id'yi alıyoruz

    $sql = "SELECT * FROM kullanicilar WHERE tc_no = '$user_id'";
    $result = $conn->query($sql);
    $user = $result->fetch_assoc();

    $tc_no = $user['tc_no'];
} else {
    echo "Lütfen giriş yapın.";
    exit;
}

// Formdan gelen verileri al
$doktor_id = $_POST['secili_doktor'];
$hastane_id = $_POST['hastane'];
$bolum_id = $_POST['bolum'];
$gun = $_POST['gun'];
$saat = $_POST['saat'];

// Saat değerinin var olup olmadığını kontrol et
if (isset($_POST['saat'])) {
    $saat = $_POST['saat'];
} else {
    echo "Lütfen bir saat seçin.";
    exit;
}

// SQL sorgusu
$sql = "INSERT INTO randevular (tc_no, doktor_id, hastane_id, bolum_id, randevu_tarih, randevu_saat, randevu_turu, randevu_durumu) 
        VALUES ('$tc_no', '$doktor_id', '$hastane_id', '$bolum_id', '$gun', '$saat', 'Online', 'aktif')";

if ($conn->query($sql) === TRUE) {
    // Başarıyla kaydedildiyse, alert gösterip yönlendirelim
    echo "
    <script type='text/javascript'>
        alert('Randevu başarıyla kaydedildi!');
        window.location.href = 'goruntulu.php';  // Yönlendirmek istediğiniz sayfa
    </script>";
} else {
    // Hata durumunda alert gösterip yönlendirelim
    echo "
    <script type='text/javascript'>
        alert('Hata: " . $conn->error . "');
        window.location.href = 'goruntulu.php';  // Yönlendirmek istediğiniz sayfa
    </script>";
}

$conn->close();
?>
