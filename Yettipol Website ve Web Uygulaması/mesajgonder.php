<?php
session_start();
header('Content-Type: application/json');

if (!isset($_SESSION['user_id'])) {
    echo json_encode(['error' => 'Giriş yapılmamış.']);
    exit;
}

require_once 'baglanti.php'; // $conn = new mysqli(...)

$gonderen_tc = $_SESSION['user_id'];
$alici_tc = $_POST['alici_tc_no'] ?? null;
$mesaj_text = $_POST['mesaj_text'] ?? null;

// Randevu_id kontrolü (gerekliyse sorguya eklenmeli)
if (!$alici_tc || !$mesaj_text) {
    echo json_encode(['error' => 'Eksik veri gönderildi.']);
    exit;
}

$stmt = $conn->prepare("INSERT INTO mesajlar
    (gonderen_tc_no, alici_tc_no, mesaj_text, gonderme_tarihi) 
    VALUES (?, ?, ?, NOW())");

$stmt->bind_param("sss", $gonderen_tc, $alici_tc, $mesaj_text);

if ($stmt->execute()) {
    echo json_encode(['success' => true]);
} else {
    echo json_encode(['error' => 'Mesaj gönderme hatası: ' . $stmt->error]);
}

file_put_contents("debug.txt", "buraya geldi\n", FILE_APPEND);


$stmt->close();
$conn->close();
?>
