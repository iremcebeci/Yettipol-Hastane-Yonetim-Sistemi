<?php
session_start();
header("Content-Type: application/json");

if (!isset($_SESSION['user_id'])) {
    echo json_encode(['error' => 'Giriş yapılmamış']);
    exit;
}

require_once 'baglanti.php';

if (!isset($_GET['doktor_id'])) {
    echo json_encode(['error' => 'Doktor ID belirtilmedi']);
    exit;
}

$doktor_id = intval($_GET['doktor_id']);

try {
    $stmt = $conn->prepare("
        SELECT d.doktor_id, d.doktor_isim, d.tc_no, f.fotograf, b.bolum_isim, h.hastane_isim
        FROM doktorlar d
        LEFT JOIN fotograflar f ON d.doktor_id = f.doktor_id
        LEFT JOIN bolumler b ON d.bolum_id = b.bolum_id
        LEFT JOIN hastaneler h ON d.hastane_id = h.hastane_id
        WHERE d.doktor_id = ?
        LIMIT 1
    ");
    $stmt->bind_param("i", $doktor_id);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($result->num_rows === 0) {
        echo json_encode(['error' => 'Doktor bulunamadı']);
        exit;
    }

    $doktor = $result->fetch_assoc();
    echo json_encode($doktor);

} catch (Exception $e) {
    echo json_encode(['error' => 'Veritabanı hatası: ' . $e->getMessage()]);
}
?>
