<?php 
// Veritabanı bağlantısını dahil et
include('baglanti.php');

// Formdan gelen verileri al
$tc_no = $_POST['tc_no'];
$isimsoyisim = $_POST['isimsoyisim'];
$cinsiyet = $_POST['cinsiyet'];
$telefon_no = $_POST['telefon_no'];
$email = $_POST['email'];
$dogtar = $_POST['dogtar'];
$sifre = $_POST['sifre'];

// Telefon numarasını formatla: 05553332244 -> 0555 333 22 44
$telefon_no = preg_replace('/(\d{4})(\d{3})(\d{2})(\d{2})/', '$1 $2 $3 $4', $telefon_no);

// Kullanıcılar tablosuna veri ekle
$sql_kullanici = "INSERT INTO kullanicilar (tc_no, email, sifre, hasta_isimsoyisim, hasta_cinsiyet, hasta_telefon, hasta_dog_tar) 
                  VALUES ('$tc_no', '$email', '$sifre', '$isimsoyisim', '$cinsiyet', '$telefon_no', '$dogtar')";  

// Hastalar tablosuna veri ekle
$sql_hasta = "INSERT INTO hastalar (tc_no, hasta_isimsoyisim, hasta_cinsiyet, hasta_telefon, hasta_dog_tar) 
              VALUES ('$tc_no', '$isimsoyisim', '$cinsiyet', '$telefon_no', '$dogtar')";

// İlk olarak `kullanicilar` tablosuna veri ekle
if ($conn->query($sql_kullanici) === TRUE) {
    // Eğer kullanıcılar tablosuna veri başarılı şekilde eklendiyse, şimdi hastalar tablosuna veri ekle
    if ($conn->query($sql_hasta) === TRUE) {
        // Başarıyla eklenmişse, kullanıcıyı giriş sayfasına yönlendir
        header("Location: girisyap.html");
        exit;
    } else {
        echo "<script>
                alert('Hastalar tablosuna veri eklenirken bir hata oluştu: " . $conn->error . "');
              </script>";
    }
} else {
    echo "<script>
            alert('Kullanıcılar tablosuna veri eklenirken bir hata oluştu: " . $conn->error . "');
          </script>";
}

// Bağlantıyı kapat
$conn->close();
?>
