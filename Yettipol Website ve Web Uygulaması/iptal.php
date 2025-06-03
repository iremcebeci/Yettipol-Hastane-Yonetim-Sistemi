<?php
include('baglanti.php');
session_start();

$user_id = $_SESSION['user_id'];

if (isset($_GET['randevu_id'])) {
    $randevu_id = $_GET['randevu_id'];

    // Randevu durumunu 'iptal' olarak güncelle
    $sql = "UPDATE randevular SET randevu_durumu = 'iptal' 
            WHERE randevu_id = '$randevu_id' AND tc_no = '$user_id'";

    if ($conn->query($sql) === TRUE) {
        header("Location: yettipolonline.php?message=Randevunuz başarıyla iptal edilmiştir.");
    } else {
        header("Location: yettipolonline.php?message=Bir hata oluştu. Lütfen tekrar deneyin.");
    }
} else {
    header("Location: yettipolonline.php?message=Geçersiz işlem.");
}

$conn->close();
?>
