<?php
session_start();  // Oturumu başlat
session_unset();  // Tüm oturum değişkenlerini temizle
session_destroy();  // Oturumu sonlandır

// Kullanıcıyı giriş sayfasına yönlendir
header("Location: girisyap.html");  // login.html'e yönlendir. Bu sayfayı değiştirin ihtiyaca göre.
exit();
?>
