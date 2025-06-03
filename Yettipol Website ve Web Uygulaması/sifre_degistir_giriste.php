<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'PHPMailer/PHPMailer.php';
require 'PHPMailer/SMTP.php';
require 'PHPMailer/Exception.php';
include('baglanti.php');

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $email = $_POST['email'];
    $kod = rand(100000, 999999);

    $sorgu = $conn->prepare("SELECT * FROM kullanicilar WHERE email = ?");
    $sorgu->execute([$email]);
    $sorgu->store_result();

    if ($sorgu->num_rows > 0) {
        // Kod veritabanına kaydedilsin
        $conn->prepare("INSERT INTO sifre_sifirlama_kodlari (email, kod, zaman) VALUES (?, ?, NOW())")
                 ->execute([$email, $kod]);

        $mail = new PHPMailer(true);

        try {
            $mail->isSMTP();
            $mail->Host       = 'smtp.gmail.com';
            $mail->SMTPAuth   = true;
            $mail->Username   = 'yettipolhastanesi@gmail.com';
            $mail->Password   = 'ifpe nnxo gdrx zdcc'; // uygulama şifresi
            $mail->SMTPSecure = 'tls';
            $mail->Port       = 587;

            $mail->setFrom('yettipolhastanesi@gmail.com', 'Yettipol Hastanesi');
            $mail->addAddress($email);

            $mail->isHTML(true);
            $mail->Subject = 'Sifre Yenileme Kodu';
            $mail->Body    = "<p>Sifre Yenileme kodunuz: <strong>$kod</strong></p>";

            if ($mail->send()) {
                header("Location: kod_dogrula.php?email=$email");
                exit;
            } else {
                echo "Mail gönderilemedi. Lütfen tekrar deneyin.";
            }
        } catch (Exception $e) {
            echo "Mail gönderilemedi. Hata: {$mail->ErrorInfo}";
        }

    } else {
        echo "Bu e-posta sistemde kayıtlı değil.";
    }
}
?>
