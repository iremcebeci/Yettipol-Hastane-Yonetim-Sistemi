<?php
include('baglanti.php');

if (isset($_POST['doktor']) && isset($_POST['tarih'])) {
    $doktor = $_POST['doktor'];
    $tarih = $_POST['tarih'];

    $sql = "SELECT saat FROM randevular WHERE doktor_adi = ? AND tarih = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ss", $doktor, $tarih);
    $stmt->execute();
    $result = $stmt->get_result();

    $doluSaatler = [];
    while ($row = $result->fetch_assoc()) {
        $doluSaatler[] = $row['saat'];
    }

    echo json_encode($doluSaatler);
}
?>
