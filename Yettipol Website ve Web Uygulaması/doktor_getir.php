<?php
include('baglanti.php');

$bolumID = $_GET['bolum_id'];

$query = "
    SELECT doktorlar.doktor_id, doktorlar.doktor_isim, fotograflar.fotograf
    FROM doktorlar
    LEFT JOIN fotograflar ON doktorlar.doktor_id = fotograflar.doktor_id
    WHERE doktorlar.bolum_id = '$bolumID'
";
$result = $conn->query($query);

if ($result) {
    while ($row = $result->fetch_assoc()) {
        $foto = !empty($row['fotograf']) ? $row['fotograf'] : 'default.jpg';

        echo "<div class='doctor-card'>
                <img src='img/$foto' alt='{$row['doktor_isim']}' class='doctor-photo'>
                <div class='doctor-name'>{$row['doktor_isim']}</div>
                <input type='radio' name='secili_doktor' value='{$row['doktor_id']}' id='doktor2' class='radio-btn radio-visible'>
            </div>";
    }
} else {
    echo "Sorgu hatası: " . $conn->error;
}
?>

