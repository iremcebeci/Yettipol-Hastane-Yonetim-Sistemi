<?php
include('baglanti.php');

$tcno = $_POST['tcno'];
$sifre = $_POST['sifre'];

// TC no ile kullanıcıyı sorgula
$sql = "SELECT * FROM kullanicilar WHERE tc_no = '$tcno'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    $user = $result->fetch_assoc();

    if ($sifre === $user['sifre']) {
        session_start();
        $_SESSION['user_id'] = $user['tc_no'];
        $_SESSION['rol'] = $user['rol'];

        if ($user['rol'] === 'Doktor') {
            header("Location: doktoranasayfa.php");
        } else if ($user['rol'] === 'Teknisyen'){
            header("Location: teknisyenanasayfa.php");
        } else {
            header("Location: yettipolonline.php");
        }
        exit();
    } else {
        echo "<script>alert('Yanlış şifre!'); window.history.back();</script>";
    }
} else {
    echo "<script>alert('Bu TC numarasıyla kayıtlı bir kullanıcı bulunamadı!'); window.history.back();</script>";
}

$conn->close();
?>
