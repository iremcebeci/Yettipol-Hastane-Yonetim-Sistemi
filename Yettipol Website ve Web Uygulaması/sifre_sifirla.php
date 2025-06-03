<?php
include("baglanti.php");

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $email = $_POST['email'];
    $kod = $_POST['kod'];
    $yeniSifre = $_POST['yeni_sifre'];

    // Kodun veritabanında var olup olmadığını kontrol et
    $sorgu = $conn->prepare("SELECT * FROM sifre_sifirlama_kodlari WHERE email = ? AND kod = ? ORDER BY zaman DESC LIMIT 1");
    $sorgu->execute([$email, $kod]);
    $sorgu->store_result();

    if ($sorgu->num_rows > 0) {
        // Şifreyi hashlemeden doğrudan kaydet (güvenli değil ama sen öyle istedin)
        $guncelle = $conn->prepare("UPDATE kullanicilar SET sifre = ? WHERE email = ?");
        $guncelle->execute([$yeniSifre, $email]);

        // Kullanılan kodu temizle (opsiyonel ama iyi bir uygulamadır)
        $conn->prepare("DELETE FROM sifre_sifirlama_kodlari WHERE email = ?")->execute([$email]);

        echo "✅ Şifren başarıyla değiştirildi. <a href='girisyap.html'>Giriş yap</a>";
    } else {
        echo "❌ Hatalı kod girdin. Lütfen kontrol et ve tekrar dene.";
    }
}
?>
