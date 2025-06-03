<?php
session_start();
include('baglanti.php');

$tahlilTuruId = $_POST['tahlil_turu_id'];

$stmt = $conn->prepare("
    SELECT id, isim, birim, referans_min, referans_max, kategorik_mi, referans_deger_metni 
    FROM parametreler 
    WHERE tahlil_turu_id = ?
");
$stmt->bind_param("i", $tahlilTuruId);
$stmt->execute();
$result = $stmt->get_result();

$parametreler = [];

while ($row = $result->fetch_assoc()) {
    $parametreler[] = $row;
}

echo json_encode($parametreler);

?>