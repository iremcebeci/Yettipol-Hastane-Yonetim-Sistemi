<?php
// Veritabanı bağlantısı
include('baglanti.php');
session_start();

// Kullanıcı ID'sini al
$user_id = $_SESSION['user_id'];  

// Kullanıcı bilgilerini almak için sorgu
$sql = "SELECT * FROM kullanicilar WHERE tc_no = '$user_id'";
$result = $conn->query($sql);
$user = $result->fetch_assoc(); 

// Form gönderildiyse şifreyi değiştir
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $eski_sifre = $_POST['eski_sifre'];
    $yeni_sifre = $_POST['yeni_sifre'];
    $yeni_sifre_tekrar = $_POST['yeni_sifre_tekrar'];

    // Eski şifreyi kontrol et (hashleme yapılmadan doğrudan karşılaştırma)
    if ($eski_sifre == $user['sifre']) {
        if ($yeni_sifre == $yeni_sifre_tekrar) {
            // Yeni şifreyi veritabanına güncelle
            $update_sql = "UPDATE kullanicilar SET sifre = '$yeni_sifre' WHERE tc_no = '$user_id'";
            if ($conn->query($update_sql) === TRUE) {
                // Şifre değiştirildiyse yönlendirme
                echo "<script>alert('Şifre başarıyla değiştirildi!'); window.location.href = 'yettipolonline.php';</script>";
            } else {
                echo "<script>alert('Hata: " . $conn->error . "');</script>";
            }
        } else {
            echo "<script>alert('Yeni şifreler uyuşmuyor!');</script>";
        }
    } else {
        echo "<script>alert('Eski şifre yanlış!');</script>";
    }
}

// Veritabanı bağlantısını kapat
$conn->close();
?>
