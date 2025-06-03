CREATE DATABASE yettipol;
USE yettipol;

CREATE TABLE IF NOT EXISTS hastaneler(
	hastane_id varchar(3) primary key,
    hastane_isim varchar(50) not null,
    hastane_sehir varchar(50),
    hastane_ilce varchar(50),
    hastane_telefon varchar(11)
);

CREATE TABLE IF NOT EXISTS bolumler(
	bolum_id varchar(7) primary key,
    bolum_isim varchar(50),
    hastane_id varchar(3),
    foreign key (hastane_id) references hastaneler(hastane_id)
);

CREATE TABLE IF NOT EXISTS kullanicilar(
	tc_no char(11) primary key,
    email varchar(100),
    sifre varchar(20),
	hasta_isimsoyisim varchar(100),
    hasta_cinsiyet ENUM('kadın','erkek'),
    hasta_dog_tar date,
    hasta_telefon varchar(14),
    rol enum('Hasta','Doktor') default 'Hasta'
);


alter table kullanicilar MODIFY column rol enum('Hasta','Doktor','Yönetici','Teknisyen') default 'Hasta';
CREATE TABLE IF NOT EXISTS doktorlar(
	doktor_id int auto_increment primary key,
    tc_no char(11),
    doktor_isim varchar(50),
    bolum_id varchar(7),
    hastane_id varchar(3),
    foreign key (bolum_id) references bolumler(bolum_id),
    foreign key (hastane_id) references hastaneler(hastane_id),
    foreign key (tc_no) references kullanicilar(tc_no)
);
alter table doktorlar 
add column izingunu varchar(50),
add column akademik_izin varchar(50);

CREATE TABLE IF NOT EXISTS hastalar(
	tc_no char(11) primary key,
    hasta_isimsoyisim varchar(100),
    hasta_cinsiyet ENUM('kadın','erkek'),
    hasta_dog_tar date,
    hasta_telefon varchar(14)
);

CREATE TABLE IF NOT EXISTS randevular (
    randevu_id INT AUTO_INCREMENT PRIMARY KEY,
    tc_no CHAR(11) not null,
    doktor_id int,
    hastane_id char(3),
    bolum_id char(7),
    randevu_tarih DATE,
    randevu_saat TIME,
    randevu_turu ENUM('Online', 'Hastane'),
    randevu_durumu ENUM('iptal','geçmiş', 'aktif') default 'aktif',
    UNIQUE (doktor_id, randevu_tarih, randevu_saat),
    FOREIGN KEY (tc_no) REFERENCES hastalar(tc_no),
    FOREIGN KEY (doktor_id) REFERENCES doktorlar(doktor_id),
    foreign key (hastane_id) references hastaneler(hastane_id),
    foreign key (bolum_id) references bolumler(bolum_id)
);

CREATE TABLE IF NOT EXISTS receteler (
    recete_id INT AUTO_INCREMENT PRIMARY KEY,
    tc_no VARCHAR(11),
    doktor_id INT,
    ilac_adi VARCHAR(100),
    dozaj VARCHAR(100),
    kullanım_sıklığı VARCHAR(100),
    aciklama TEXT,
    FOREIGN KEY (tc_no) REFERENCES kullanicilar(tc_no),
    FOREIGN KEY (doktor_id) REFERENCES doktorlar(doktor_id)
);

CREATE TABLE IF NOT EXISTS hastaliklar (
    hastalik_id INT AUTO_INCREMENT PRIMARY KEY,
    tc_no VARCHAR(11) NOT NULL,
    doktor_id INT,
    hastalik_adi VARCHAR(100),
    hastalik_aciklama TEXT,
    teshis_tarihi DATE,
    FOREIGN KEY (tc_no) REFERENCES hastalar(tc_no),
    FOREIGN KEY (doktor_id) REFERENCES doktorlar(doktor_id)
);
CREATE TABLE tatil_gunleri (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tarih DATE NOT NULL,
    ad VARCHAR(100) NOT NULL,
    resmi_tatil BOOLEAN DEFAULT TRUE
);

CREATE TABLE kisiselbilgiler (
	id INT AUTO_INCREMENT PRIMARY KEY,
    tc_no char(11),
    kan_grubu varchar(5),
    boy int,
    kilo int,
    alerji text,
    FOREIGN KEY (tc_no) REFERENCES kullanicilar(tc_no)
);

CREATE TABLE teknisyenler ( 	
	teknisyen_id INT AUTO_INCREMENT PRIMARY KEY,     
    tc_no char(11),     
    isimsoyisim VARCHAR(100),     
    hastane_id varchar(3),     
    izin_gunu ENUM('Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma'),     
    tek_tur ENUM ('Kan', 'İdrar', 'Görüntüleme'),     
    FOREIGN key (hastane_id) REFERENCES hastaneler(hastane_id),     
    FOREIGN key (tc_no) REFERENCES kullanicilar(tc_no) 
);

CREATE TABLE tahliller (
	id INT AUTO_INCREMENT PRIMARY KEY,
    isteyen_doktor INT,
    tc_no VARCHAR(11) NOT NULL,  
    teknisyen_id INT NOT NULL,   
    tahlil_kategori ENUM('kan', 'idrar', 'görüntüleme') NOT NULL,     
    tahlil_turu VARCHAR(100) NOT NULL,     
    istek_tarihi DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,     
    FOREIGN KEY (isteyen_doktor) REFERENCES doktorlar(doktor_id),     
    FOREIGN KEY (tc_no) REFERENCES hastalar(tc_no), 
    FOREIGN KEY (teknisyen_id) REFERENCES teknisyenler(teknisyen_id)
);

CREATE TABLE tahlil_turleri (
    id INT PRIMARY KEY AUTO_INCREMENT,
    ad VARCHAR(100)
);

CREATE TABLE parametreler (
    id INT PRIMARY KEY AUTO_INCREMENT,
    tahlil_turu_id INT,
    isim VARCHAR(100),
    birim VARCHAR(20),
    referans_min DECIMAL(6,2) DEFAULT NULL,
    referans_max DECIMAL(6,2) DEFAULT NULL,
    kategorik_mi BOOLEAN DEFAULT FALSE,
    referans_deger_metni VARCHAR(100) DEFAULT NULL,
    FOREIGN KEY (tahlil_turu_id) REFERENCES tahlil_turleri(id)
);

CREATE TABLE goruntuleme_raporlari (
    id INT PRIMARY KEY AUTO_INCREMENT,
    hasta_tc char(11),
    cekim_tarihi DATE,
    cekim_turu ENUM('Röntgen', 'MR', 'BT', 'Ultrason'),
    teknik_bilgi TEXT,
    bulgular TEXT,
    sonuc_degerlendirme TEXT,
    oneriler TEXT,
    imza VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (hasta_tc) REFERENCES hastalar(tc_no)
);

CREATE TABLE IF NOT EXISTS fotograflar (
	fotograf_id int auto_increment primary key,
    fotograf varchar(100),
    doktor_id int,
    foreign key (doktor_id) references doktorlar(doktor_id)
);

CREATE TABLE tahlil_sonuclari (
    id INT PRIMARY KEY AUTO_INCREMENT,
    hasta_id INT,
    tahlil_turu_id INT,
    parametre_id INT,
    deger DECIMAL(6,2),
    tarih DATE,
    FOREIGN KEY (tahlil_turu_id) REFERENCES tahlil_turleri(id),
    FOREIGN KEY (parametre_id) REFERENCES parametreler(id)
);


CREATE TABLE sifre_sifirlama_kodlari (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255),
    kod VARCHAR(10),
    zaman DATETIME
);

CREATE TABLE IF NOT EXISTS mesajlar ( 
	mesaj_id INT AUTO_INCREMENT PRIMARY KEY, 
	gonderen_tc_no CHAR(11) NOT NULL, 
	alici_tc_no CHAR(11) NOT NULL, 
	mesaj_text TEXT NOT NULL, 
	gonderme_tarihi DATETIME DEFAULT CURRENT_TIMESTAMP, 
	goruldu_mu BOOLEAN DEFAULT FALSE, 
	FOREIGN KEY (gonderen_tc_no) REFERENCES kullanicilar(tc_no), 
	FOREIGN KEY (alici_tc_no) REFERENCES kullanicilar(tc_no)
);



select * from hastaneler;
select * from bolumler;
select * from doktorlar;
select * from hastalar;
select * from kullanicilar;
select * from randevular;
select * from tahliller;
select * from teknisyenler;