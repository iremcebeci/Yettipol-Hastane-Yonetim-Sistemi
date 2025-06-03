<?php
session_start();
include('baglanti.php');

if (isset($_SESSION['user_id'])) {
    $user_id = $_SESSION['user_id'];

    $sql = "SELECT * FROM kullanicilar WHERE tc_no = '$user_id'";
    $result = $conn->query($sql);
    $user = $result->fetch_assoc();

    $tc_no = $user['tc_no'];
} else {
    echo "Lütfen giriş yapın.";
    exit;
}

$doktor_id = $_POST['secili_doktor'];
$hastane_id = $_POST['hastane'];
$bolum_id = $_POST['bolum'];
$gun = $_POST['gun'];
$saat = $_POST['saat'];

if (isset($_POST['saat'])) {
    $saat = $_POST['saat'];
} else {
    echo "Lütfen bir saat seçin.";
    exit;
}

$sql = "INSERT INTO randevular (tc_no, doktor_id, hastane_id, bolum_id, randevu_tarih, randevu_saat, randevu_turu, randevu_durumu) 
        VALUES ('$tc_no', '$doktor_id', '$hastane_id', '$bolum_id', '$gun', '$saat', 'hastane', 'aktif')";

if ($conn->query($sql) === TRUE) {
    echo "
    <script type='text/javascript'>
        alert('Randevu başarıyla kaydedildi!');
        window.location.href = 'randevu.php';  // Yönlendirmek istediğiniz sayfa
    </script>";
} else {
    echo "
    <script type='text/javascript'>
        alert('Hata: " . $conn->error . "');
        window.location.href = 'randevu.php';  // Yönlendirmek istediğiniz sayfa
    </script>";
}

$conn->close();
?>
