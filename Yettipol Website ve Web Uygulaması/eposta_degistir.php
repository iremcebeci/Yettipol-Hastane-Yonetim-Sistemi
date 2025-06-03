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

// Form gönderildiyse e-posta güncelle
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $eski_email = $_POST['eski_email'];
    $yeni_email = $_POST['yeni_email'];

    // Eski e-postayı kontrol et
    if ($eski_email == $user['email']) {
        // Yeni e-posta veritabanına güncelle
        $update_sql = "UPDATE kullanicilar SET email = '$yeni_email' WHERE tc_no = '$user_id'";
        if ($conn->query($update_sql) === TRUE) {
            // Yönlendirme işlemi
            echo "<script>alert('E-posta başarıyla değiştirildi!'); window.location.href='yettipolonline.php';</script>";
        } else {
            echo "Hata: " . $conn->error;
        }
    } else {
        // Eski e-posta yanlışsa hata mesajı
        echo "<script>alert('Eski e-posta yanlış!');</script>";
    }
}

// Veritabanı bağlantısını kapat
$conn->close();
?>
