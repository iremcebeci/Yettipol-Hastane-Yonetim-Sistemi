<?php
include('baglanti.php'); // Veritabanı bağlantısı

// Seçilen hastane, bölüm ve doktor bilgilerini al
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Form verilerini al
    $hastane_id = isset($_GET['hastane_id']) ? $_GET['hastane_id'] : '';
    $bolum_id = isset($_GET['bolum_id']) ? $_GET['bolum_id'] : '';
    $doktor_id = isset($_GET['doktor_id']) ? $_GET['doktor_id'] : '';

    // Seçim yapılmadıysa hata mesajı göster
    if (empty($hastane) || empty($bolum) || empty($doktor)) {
        echo "<p style='color: red;'>Lütfen tüm alanları doldurun!</p>";
    } else {
        // Veritabanı işlemleri veya başka işlemler...
    }
}

// Veritabanı işlemleri: Hangi günlerin dolduğunu al
$sql_tarihler = "
    SELECT DISTINCT randevu_tarih 
    FROM randevular 
    WHERE hastane_id = ? AND bolum_id = ? AND doktor_id = ? AND randevu_durumu = 'aktif'
";
$stmt = $conn->prepare($sql_tarihler);
$stmt->bind_param("iis", $hastane_id, $bolum_id, $doktor_id);
$stmt->execute();
$result_tarih = $stmt->get_result();
$dolmuş_gunler = [];

while ($row = $result_tarih->fetch_assoc()) {
    $dolmuş_gunler[] = $row['randevu_tarih']; // O gün dolmuş
}
$stmt->close();

// JSON olarak dolmuş günleri geri gönder
echo json_encode($dolmuş_gunler);

if (isset($_POST['tarih'])) {
    $secilen_tarih = $_POST['tarih'];

    // O günün saatlerini al
    $sql_saatler = "
        SELECT randevu_saat 
        FROM randevular 
        WHERE hastane_id = ? AND bolum_id = ? AND doktor_id = ? AND randevu_tarih = ? AND randevu_durumu = 'aktif'
    ";
    $stmt = $conn->prepare($sql_saatler);
    $stmt->bind_param("iiss", $hastane_id, $bolum_id, $doktor_id, $secilen_tarih);
    $stmt->execute();
    $result_saat = $stmt->get_result();
    $dolmuş_saatler = [];
    $_SESSION['dolmuş_saatler'] = $dolmuş_saatler;

    while ($row = $result_saat->fetch_assoc()) {
        $dolmuş_saatler[] = $row['randevu_saat']; // O saat dolmuş
    }
    $stmt->close();

    // Kullanıcı seçtiği tarihteki dolu saatleri döndür
    echo json_encode(['status' => 'success', 'dolmuş_saatler' => $dolmuş_saatler]);
}
?>
