<!DOCTYPE html>
<html lang="tr">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>YETTİPOL HASTANESİ | Giriş Yap</title>
    <link rel="icon" type="image/x-icon" href="img/logo.jpg">
    <link rel="stylesheet" href="styleonline.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
</head>

<body>
    <div class="container">

        <header>
            <div class="baslikIsim">
                <img src="img/logo.jpg" alt="logo">
                <h2>YETTİPOL ONLINE</h2>
            </div>
        </header>

        <div class="girisvekayit">


            <section class="girisyapsayfasi3">
                <div class="girisbaslik">Şifre Değiştir</div>

                <form id="kayitform" action="sifre_degistir_giriste.php" method="POST">
                    <label for="mail">E-Posta:</label>
                    <input type="email" name="email" required><br><br>

                    <button type="submit">E-posta Gönder</button>
                </form>



                <div class="girisyapformalt">
                    <p>Hesabınız yok mu? <a href="kayit.html">Kayıt Olun</a></p>
                    <p><a href="girisyap.html">Giriş Yap</a></p>
                    <p><a href="girissizrandevu.php" style="color: white;">Giriş Yapmadan Devam Et</a></p>
                </div>
            </section>
        </div>

    </div>
</body>

</html>