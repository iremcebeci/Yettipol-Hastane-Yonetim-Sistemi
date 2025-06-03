<?php
include('baglanti.php');

$hastaneID = $_GET['hastane_id'];

// hastane_id'nin VARCHAR türünde olduğunu göz önünde bulundurup sorguyu güncelle
$sonuc = $conn->query("SELECT * FROM bolumler WHERE hastane_id = '$hastaneID'");

if ($sonuc) {
    while ($satir = $sonuc->fetch_assoc()) {
        echo "<option value='{$satir['bolum_id']}'>{$satir['bolum_isim']}</option>";
    }
} else {
    echo "Sorgu hatası: " . $conn->error;
}
?>
