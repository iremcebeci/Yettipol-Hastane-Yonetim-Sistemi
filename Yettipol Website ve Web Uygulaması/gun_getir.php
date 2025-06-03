<?php
include('baglanti.php');

header('Content-Type: application/json; charset=utf-8'); // JSON header

if (!isset($_GET['doktor_id'])) {
    echo json_encode(['error' => 'doktor_id parametresi eksik']);
    exit;
}

$doktorID = (int) $_GET['doktor_id']; // Güvenlik için cast

$sonuc = $conn->query("SELECT * FROM randevular WHERE doktor_id = $doktorID");

$randevular = [];

if ($sonuc) {
    while ($satir = $sonuc->fetch_assoc()) {
        $randevular[] = [
            'randevu_id' => $satir['randevu_id'],
            'randevu_tarih' => $satir['randevu_tarih'],
            'randevu_saat' => $satir['randevu_saat'],
            'bolum_id' => $satir['bolum_id'],
            'hastane_id' => $satir['hastane_id'],
            'doktor_id' => $satir['doktor_id'],
            'randevu_durumu' => $satir['randevu_durumu']
        ];
    }
    echo json_encode($randevular);
} else {
    echo json_encode(['error' => 'Sorgu hatası: ' . $conn->error]);
}
?>
