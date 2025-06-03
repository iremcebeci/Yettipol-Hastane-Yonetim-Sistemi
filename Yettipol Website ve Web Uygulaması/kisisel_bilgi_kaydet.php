<?php
session_start();
include("baglanti.php");

// Giriş yapan kullanıcının TC no'sunu al
$tc_no = $_SESSION['user_id']; 

$kan_grubu = $_POST['kan_grubu'];
$boy = $_POST['boy'];
$kilo = $_POST['kilo'];
$alerji = $_POST['alerji'];

// Veritabanına ekle
$sql = "INSERT INTO kisiselbilgiler (tc_no, kan_grubu, boy, kilo, alerji) 
        VALUES ('$tc_no', '$kan_grubu', '$boy', '$kilo', '$alerji')";

if ($conn->query($sql) === TRUE) {
    echo "<script>alert('Kişisel bilgiler başarıyla kaydedildi.'); window.location.href='yettipolonline.php';</script>";
} else {
    echo "Hata: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>
