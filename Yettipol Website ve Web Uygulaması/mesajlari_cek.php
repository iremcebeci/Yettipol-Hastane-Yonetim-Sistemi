<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
header('Content-Type: application/json; charset=utf-8');

session_start();
header('Content-Type: application/json');
include('baglanti.php');

$oturumTc = $_SESSION['user_id'];  // Oturumdaki kullanıcı TC
$karsiTc = $_GET['karsi_tc'] ?? '';  // GET ile karşı taraf TC'si geliyor

if (!$karsiTc) {
    echo json_encode(["error" => "Karşı taraf TC gönderilmedi"]);
    exit;
}

$stmt = $conn->prepare("
    SELECT * FROM mesajlar 
    WHERE (gonderen_tc_no = ? AND alici_tc_no = ?) 
       OR (gonderen_tc_no = ? AND alici_tc_no = ?)
    ORDER BY gonderme_tarihi ASC
");

$stmt->bind_param("ssss", $oturumTc, $karsiTc, $karsiTc, $oturumTc);
$stmt->execute();

$result = $stmt->get_result();
$mesajlar = [];
while ($row = $result->fetch_assoc()) {
    $mesajlar[] = $row;
}

echo json_encode($mesajlar);
