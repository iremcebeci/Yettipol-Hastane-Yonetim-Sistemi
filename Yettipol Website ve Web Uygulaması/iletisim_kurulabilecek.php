<?php
session_start();
header("Content-Type: application/json");

if (!isset($_SESSION['user_id'])) {
    echo json_encode(["error" => "Giriş yapılmamış."]);
    exit;
}

$tc = $_SESSION['user_id'];
require_once 'baglanti.php';

try {
    // Kullanıcının rolünü al
    $rolSorgu = $conn->prepare("SELECT rol FROM kullanicilar WHERE tc_no = ?");
    $rolSorgu->bind_param("s", $tc);
    $rolSorgu->execute();
    $rolSonuc = $rolSorgu->get_result();
    $kullanici = $rolSonuc->fetch_assoc();

    if (!$kullanici) {
        echo json_encode(["error" => "Kullanıcı bulunamadı."]);
        exit;
    }

    $rol = $kullanici['rol'];
    $sohbetler = [];
    $iletisime_aciklar = [];

    if ($rol === 'Hasta') {
        // Hasta ise: randevu aldığı doktorları getir
        $sorgu = $conn->prepare("
            SELECT 
                d.doktor_id,
                d.doktor_isim,
                d.tc_no as doktor_tc,
                f.fotograf,
                b.bolum_isim,
                h.hastane_isim,
                MAX(r.randevu_id) as son_randevu_id
            FROM randevular r
            JOIN doktorlar d ON r.doktor_id = d.doktor_id
            LEFT JOIN fotograflar f ON d.doktor_id = f.doktor_id
            LEFT JOIN bolumler b ON d.bolum_id = b.bolum_id
            LEFT JOIN hastaneler h ON d.hastane_id = h.hastane_id
            WHERE r.tc_no = ?
            GROUP BY d.doktor_id
        ");
        $sorgu->bind_param("s", $tc);
    } else if ($rol === 'Doktor') {
        // Doktor ise: kendisine randevu alan hastaları getir
        $sorgu = $conn->prepare("
            SELECT 
                h.tc_no,
                h.hasta_isimsoyisim as doktor_isim, -- Aynı alan ismi olması için
                h.tc_no as doktor_tc,
                NULL as fotograf,
                '' as bolum_isim,
                '' as hastane_isim,
                MAX(r.randevu_id) as son_randevu_id
            FROM randevular r
            JOIN hastalar h ON r.tc_no = h.tc_no
            WHERE r.doktor_id = (SELECT doktor_id FROM doktorlar WHERE tc_no = ?)
            GROUP BY h.tc_no
        ");
        $sorgu->bind_param("s", $tc);
    } else {
        echo json_encode(["error" => "Bu kullanıcı rolü için sohbetler tanımlı değil."]);
        exit;
    }

    $sorgu->execute();
    $sorgu->store_result();
    $sorgu->bind_result($id, $isim, $tc_no, $fotograf, $bolum_isim, $hastane_isim, $son_randevu_id);

    while ($sorgu->fetch()) {
        // Mesaj var mı kontrolü
        $kontrol = $conn->prepare("
            SELECT COUNT(*) as adet FROM mesajlar
            WHERE (gonderen_tc_no = ? AND alici_tc_no = ?) OR (gonderen_tc_no = ? AND alici_tc_no = ?)
        ");
        $kontrol->bind_param("ssss", $tc, $tc_no, $tc_no, $tc);
        $kontrol->execute();
        $sonuc = $kontrol->get_result()->fetch_assoc();

        $kisi = [
            'doktor_id' => $id,
            'doktor_isim' => $isim,
            'doktor_tc' => $tc_no,
            'fotograf' => $fotograf,
            'bolum_isim' => $bolum_isim,
            'hastane_isim' => $hastane_isim,
            'son_randevu_id' => $son_randevu_id
        ];

        if ($sonuc["adet"] > 0) {
            $sohbetler[] = $kisi;
        } else {
            $iletisime_aciklar[] = $kisi;
        }
    }

    echo json_encode([
        "sohbetler" => $sohbetler,
        "iletisime_aciklar" => $iletisime_aciklar
    ]);

} catch (Exception $e) {
    echo json_encode(["error" => "Veritabanı hatası: " . $e->getMessage()]);
}
?>
