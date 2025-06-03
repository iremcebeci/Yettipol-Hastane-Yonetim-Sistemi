<?php
session_start();
include('baglanti.php');
require_once('tcpdf/tcpdf.php');

ob_clean(); // varsa önceki çıktıyı temizle


$user_id = $_SESSION['user_id'];

// Kullanıcı bilgilerini almak için veritabanı sorgusu
$sql = "SELECT 
            teknisyenler.teknisyen_id,
            teknisyenler.isimsoyisim,
            teknisyenler.tc_no,
            teknisyenler.hastane_id,
            teknisyenler.izin_gunu,
            teknisyenler.tek_tur,
            hastaneler.hastane_isim,
            kullanicilar.hasta_isimsoyisim,
            kullanicilar.hasta_cinsiyet,
            kullanicilar.hasta_dog_tar,
            kullanicilar.hasta_telefon,
            kullanicilar.email
        FROM teknisyenler
        JOIN hastaneler ON teknisyenler.hastane_id = hastaneler.hastane_id
        JOIN kullanicilar ON teknisyenler.tc_no = kullanicilar.tc_no
        WHERE teknisyenler.tc_no = '$user_id'";

$result = $conn->query($sql);
$user = $result->fetch_assoc();  // Veriyi al

$hasta_tc = $_GET['hasta_tc'];
$tahlil_id = $_GET['tahlil_id'];
$tahlil_turu_id = $_GET['tahlil_turu_id'];

$sql2 = "SELECT hasta_isimsoyisim, hasta_dog_tar, hasta_cinsiyet
                FROM hastalar
                WHERE tc_no = '$hasta_tc'";
$result2 = $conn->query($sql2);
$hasta = $result2->fetch_assoc();

$sql3 = "SELECT tahlil_turu, istek_tarihi, isteyen_doktor
                FROM tahliller
                WHERE id = '$tahlil_id'";
$result3 = $conn->query($sql3);
$tahlil = $result3->fetch_assoc();

$sql4 = "SELECT doktor_isim, bolum_id, hastane_id
                FROM doktorlar
                WHERE doktor_id = '{$tahlil['isteyen_doktor']}'";
$result4 = $conn->query($sql4);
$doktor = $result4->fetch_assoc();

$sql5 = "SELECT bolum_isim
                FROM bolumler
                WHERE bolum_id = '{$doktor['bolum_id']}'";
$result5 = $conn->query($sql5);
$bolum = $result5->fetch_assoc();

$sql6 = "SELECT hastane_isim
                FROM hastaneler
                WHERE hastane_id = '{$doktor['hastane_id']}'";
$result6 = $conn->query($sql6);
$hastane = $result6->fetch_assoc();

// tahlil parametreleri ve değerlerini çek
$sql8 = "SELECT 
            p.isim AS parametre,
            ts.deger,
            p.birim,
            CASE 
                WHEN p.kategorik_mi = 1 THEN p.referans_deger_metni
                ELSE CONCAT(p.referans_min, ' - ', p.referans_max)
            END AS referans
        FROM tahlil_sonuclari ts
        JOIN parametreler p ON ts.parametre_id = p.id
        WHERE ts.tahlil_id = ?";
$stmt2 = $conn->prepare($sql8);
$stmt2->bind_param("i", $tahlil_id);
$stmt2->execute();
$result8 = $stmt2->get_result();

$sonuclar = [];

while ($row = $result8->fetch_assoc()) {
    $sonuclar[] = $row;
}



// TCPDF başlat
$pdf = new TCPDF();
$pdf->setPrintHeader(false);
$pdf->setPrintFooter(false);
$pdf->AddPage();

// Logo ekle


// Sayfa genişliğini al
$pageWidth = $pdf->getPageWidth();

// Logonun genişliği (örnek 40 mm)
$logoWidth = 30;

// Logonun X pozisyonu (sayfa ortası - yarısı kadar kaydır)
$x = ($pageWidth - $logoWidth) / 2;

// Logoyu orta üstte yerleştir (y = 10 mm kadar boşluk üstten)
$pdf->Image(__DIR__ . '/img/logo2.jpg', $x, 10, $logoWidth);

// Logo altına boşluk bırak, yazılar buradan başlasın
$pdf->Ln(30);


$pdf->SetFont('dejavusans', 'B', 12);



$pdf->SetFont('dejavusans', '', 8);
$pdf->Ln(5);

// İlk sütun X pozisyonu
$x1 = 15;
// İkinci sütun X pozisyonu
$x2 = 110;

$h = 7; // hücre yüksekliği

// 1. satır
$pdf->SetX($x1);
$pdf->Cell(40, $h, "Hasta Adı:");
$pdf->Cell(50, $h, $hasta['hasta_isimsoyisim']);

$pdf->SetX($x2);
$pdf->Cell(40, $h, "TC No:");
$pdf->Cell(50, $h, $hasta_tc);

$pdf->Ln($h);

// 2. satır
$pdf->SetX($x1);
$pdf->Cell(40, $h, "Doğum Tarihi:");
$pdf->Cell(50, $h, $hasta['hasta_dog_tar']);

$pdf->SetX($x2);
$pdf->Cell(40, $h, "Cinsiyet:");
$pdf->Cell(50, $h, $hasta['hasta_cinsiyet']);

$pdf->Ln($h);

// 3. satır
$pdf->SetX($x1);
$pdf->Cell(40, $h, "Tahlil Tarihi:");
$pdf->Cell(50, $h, $tahlil['istek_tarihi']);

$pdf->SetX($x2);
$pdf->Cell(40, $h, "Hastane Adı:");
$pdf->Cell(50, $h, $hastane['hastane_isim']);

$pdf->Ln($h);

// 4. satır
$pdf->SetX($x1);
$pdf->Cell(40, $h, "Bölüm Adı:");
$pdf->Cell(50, $h, $bolum['bolum_isim']);

$pdf->SetX($x2);
$pdf->Cell(40, $h, "Doktor Adı:");
$pdf->Cell(50, $h, $doktor['doktor_isim']);

$pdf->Ln($h);

// Sayfanın genişliği
$width = $pdf->getPageWidth();

// Sol ve sağdan boşluklar (örnek: 15 mm)
$margin = 15;

// Y pozisyonu (şu anki cursor yüksekliğini alalım)
$y = $pdf->GetY();

// Çizgiyi çiz
$pdf->Line($margin, $y, $width - $margin, $y);

// İstersen altına biraz boşluk bırak
$pdf->Ln(2);


// Başlık
$pdf->SetFont('dejavusans', 'B', 12);
$pdf->Cell(0, 10, $tahlil['tahlil_turu'] . ' Sonuç Raporu', 0, 1, 'C');




$pdf->Ln(10);

// Sayfa içi genişlik (sol ve sağ marginler hariç)
$pageWidth = $pdf->getPageWidth() - $pdf->getMargins()['left'] - $pdf->getMargins()['right'];

// Sütun oranlarını belirle (örnek: %40, %20, %20, %20)
$col1 = $pageWidth * 0.40;
$col2 = $pageWidth * 0.20;
$col3 = $pageWidth * 0.20;
$col4 = $pageWidth * 0.20;

// Başlıklar
$pdf->SetFillColor(200, 200, 200);
$pdf->SetFont('dejavusans', 'B', 10);
$pdf->Cell($col1, 7, 'Parametre', 1, 0, 'C', 1);
$pdf->Cell($col2, 7, 'Değer', 1, 0, 'C', 1);
$pdf->Cell($col3, 7, 'Birim', 1, 0, 'C', 1);
$pdf->Cell($col4, 7, 'Referans Aralığı', 1, 1, 'C', 1);

// Veriler
$pdf->SetFont('dejavusans', '', 9);
foreach ($sonuclar as $sonuc) {
    $pdf->Cell($col1, 7, $sonuc['parametre'], 1, 0, 'C');
    $pdf->Cell($col2, 7, $sonuc['deger'], 1, 0, 'C');
    $pdf->Cell($col3, 7, $sonuc['birim'], 1, 0, 'C');
    $pdf->Cell($col4, 7, $sonuc['referans'], 1, 1, 'C');
}


// Sayfanın altından yukarı 15mm mesafeye git
$pdf->SetY(-30);

// Sayfanın sol ve sağ kenar boşluklarını al
$startX = $pdf->getMargins()['left'];
$endX = $pdf->getPageWidth() - $pdf->getMargins()['right'];

// Çizgiyi çiz (sayfanın sonuna yakın)
$pdf->Line($startX, $pdf->GetY(), $endX, $pdf->GetY());

// Biraz aşağı in ve tarihi yaz
$pdf->Ln(1);
$pdf->SetFont('dejavusans', '', 8);
$pdf->Cell(0, 5, 'Oluşturulma Tarihi: ' . date('d.m.Y H:i'), 0, 0, 'R');



// PDF'i tarayıcıda aç (indir diye 'D' yapabilirsin)
$pdf->Output('tahlil_raporu.pdf', 'I');
exit; 
?>