<?php
session_start();
include('baglanti.php');
require_once('tcpdf/tcpdf.php');

ob_clean();

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
$tahlil_id = $_GET['tahlil_id']; // log tutmak istersen kullanılabilir
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

// görüntüleme bilgisi
$sql2 = "SELECT cekim_tarihi, cekim_turu, teknik_bilgi, bulgular, sonuc_degerlendirme, oneriler, imza
         FROM goruntuleme_raporlari
         WHERE hasta_tc = ?
         ORDER BY id DESC LIMIT 1";
$stmt2 = $conn->prepare($sql2);
$stmt2->bind_param("s", $hasta_tc);
$stmt2->execute();
$rapor = $stmt2->get_result()->fetch_assoc();

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

// Sütun oranlarını belirle
$col1 = $pageWidth * 0.20;
$col2 = $pageWidth * 0.80;

// Başlıklar
$pdf->SetFillColor(200, 200, 200);
$pdf->SetFont('dejavusans', 'B', 10);
$pdf->Cell($col1, 7, 'Başlık', 1, 0, 'C', 1);
$pdf->Cell($col2, 7, 'Açıklama', 1, 1, 'C', 1);

$sutunbaslik = [
    ["baslik" => "Çekim Tarihi:", "deger" => $rapor['cekim_tarihi']],
    ["baslik" => "Teknik Bilgi:", "deger" => $rapor['teknik_bilgi']],
    ["baslik" => "Bulgular:", "deger" => $rapor['bulgular']],
    ["baslik" => "Değerlendirme:", "deger" => $rapor['sonuc_degerlendirme']],
    ["baslik" => "Öneriler:", "deger" => $rapor['oneriler']],
    ["baslik" => "İmza:", "deger" => $rapor['imza']]
];
$pdf->Ln(10);


// Veriler
$pdf->SetFont('dejavusans', '', 9);
foreach ($sutunbaslik as $satir) {
    $x = $pdf->GetX();
    $y = $pdf->GetY();

    // Başlık hücresi (sabit genişlik)
    $pdf->Cell($col1, 7, $satir['baslik'], 0, 0, 'C');

    // Değer hücresi (MultiCell)
    $pdf->MultiCell($col2, 7, $satir['deger'], 0, 'L');

    $pdf->Ln(5);
    // MultiCell alt satıra indiği için X koordinatını başa alıyor, onu düzeltiyoruz:
    $pdf->SetXY($x, $pdf->GetY());  // Yeni satır başına döner.
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


// PDF indir
$pdf->Output('goruntuleme_raporu.pdf', 'I');
exit;
?>
