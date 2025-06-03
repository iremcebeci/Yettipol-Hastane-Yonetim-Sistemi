<?php
session_start();
include('baglanti.php');

// Oturumdan doktor bilgisi
$doktortc = $_SESSION['user_id'] ?? null; // Doktorun TC'si

// Doktor ID'sini al
$sql = "SELECT doktor_id, hastane_id FROM doktorlar WHERE tc_no = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $doktortc);
$stmt->execute();
$result = $stmt->get_result();
$doktor = $result->fetch_assoc();

$doktorid = $doktor['doktor_id'];
$hastane_id = $doktor['hastane_id'];

// Formdan gelen veriler
$hastatc = $_POST['tc_no'];
$tahlil_kategori = $_POST['tahlil_kategori'];
$tahliller = $_POST['tahliller'];

// Bugünün Türkçe karşılığı
$bugun = date('l'); // Monday vs.
$gunMap = [
    'Monday' => 'Pazartesi',
    'Tuesday' => 'Salı',
    'Wednesday' => 'Çarşamba',
    'Thursday' => 'Perşembe',
    'Friday' => 'Cuma'
];
$bugun_tr = $gunMap[$bugun] ?? '';

// Her kategori ve altındaki tahliller için dön
foreach ($tahlil_kategori as $index => $kategori) {
    if (!isset($tahliller[$index])) continue;

    foreach ($tahliller[$index] as $tahlil) {
        // Uygun teknisyeni bul
        $teknisyen_stmt = $conn->prepare("
            SELECT teknisyen_id FROM teknisyenler
            WHERE hastane_id = ? AND tek_tur = ? AND izin_gunu != ?
            ORDER BY RAND()
            LIMIT 1
        ");
        $teknisyen_stmt->bind_param("sss", $hastane_id, $kategori, $bugun_tr);
        $teknisyen_stmt->execute();
        $teknisyen_result = $teknisyen_stmt->get_result();
        $teknisyen = $teknisyen_result->fetch_assoc();
        $teknisyen_id = $teknisyen['teknisyen_id'] ?? null;

        // Tahlili kaydet (teknisyen varsa)
        $insert_stmt = $conn->prepare("
            INSERT INTO tahliller (isteyen_doktor, tc_no, tahlil_kategori, tahlil_turu, teknisyen_id)
            VALUES (?, ?, ?, ?, ?)
        ");
        $insert_stmt->bind_param("isssi", $doktorid, $hastatc, $kategori, $tahlil, $teknisyen_id);
        $insert_stmt->execute();
    }
}

$conn->close();
exit;
?>
