<?php
include('baglanti.php');

$sonuc = $conn->query("SELECT * FROM hastaneler");

while ($satir = $sonuc->fetch_assoc()) {
    echo "<option name='hastane' value='{$satir['hastane_id']}'>{$satir['hastane_isim']}</option>";
}
?>
