INSERT INTO hastaneler(hastane_id, hastane_isim, hastane_sehir, hastane_ilce, hastane_telefon) VALUES
('BAY', 'Bayrampaşa Yettipol Mega Hastanesi', 'İstanbul', 'Bayrampaşa', '02125551234'),
('TUZ', 'Tuzla Yettipol Hastanesi', 'İstanbul', 'Tuzla', '02165559876'),
('SAR', 'Sarıyer Yettipol Hastanesi', 'İstanbul', 'Sarıyer', '02122224567');

INSERT INTO bolumler( bolum_id, bolum_isim, hastane_id ) VALUES
("BAY_DAH", "Dahiliye (İç Hastalıkları)", "BAY"),
("BAY_GEN", "Genel Cerrahi", "BAY"),
("BAY_DOG", "Kadın Hastalıkları ve Doğum", "BAY"),
("BAY_KAR", "Kardiyoloji", "BAY"),
("BAY_KBB", "Kulak Burun Boğaz", "BAY"),
("BAY_NEF", "Nefroloji", "BAY"),
("BAY_NOR", "Nöroloji", "BAY"),
("BAY_ORT", "Ortopedi ve Travmatoloji", "BAY"),
("BAY_PED", "Pediatri", "BAY"),
("BAY_PLS", "Plastik, Rekonstrüktif ve Estetik Cerrahi", "BAY"),
("BAY_PSY", "Psikiyatri", "BAY"),
("SAR_DAH", "Dahiliye (İç Hastalıkları)", "SAR"),
("SAR_NOR", "Nöroloji", "SAR"),
("SAR_ORT", "Ortopedi ve Travmatoloji", "SAR"),
("SAR_PED", "Pediatri", "SAR"),
("SAR_PLS", "Plastik, Rekonstrüktif ve Estetik Cerrahi", "SAR"),
("SAR_PSY", "Psikiyatri", "SAR"),
("TUZ_DAH", "Dahiliye (İç Hastalıkları)", "TUZ"),
("TUZ_GEN", "Genel Cerrahi", "TUZ"),
("TUZ_DOG", "Kadın Hastalıkları ve Doğum", "TUZ"),
("TUZ_KAR", "Kardiyoloji", "TUZ"),
("TUZ_KBB", "Kulak Burun Boğaz", "TUZ"),
("TUZ_NEF", "Nefroloji", "TUZ");
INSERT INTO kullanicilar (tc_no, email, sifre, hasta_isimsoyisim, hasta_cinsiyet, hasta_dog_tar, hasta_telefon, rol) VALUES
('12345678901', 'ayse.yilmaz@example.com', 'sifre123', 'Ayşe Yılmaz', 'Kadın', '1990-04-12', '0532 123 45 67', 'Hasta'),
('98765432100', 'mehmet.kaya@example.com', 'sifre456', 'Mehmet Kaya', 'Erkek', '1985-09-25', '0542 123 45 67', 'Hasta'),
('11223344556', 'fatma.arslan@example.com', 'sifre789', 'Fatma Arslan', 'Kadın', '1995-11-03', '0533 567 89 01', 'Hasta');

INSERT INTO kullanicilar (tc_no, email, sifre, hasta_isimsoyisim, hasta_cinsiyet, hasta_dog_tar, hasta_telefon, rol) VALUES
('55550000001', 'ellisgrey@yettipol.com', 'doktor123', 'Ellis GREY', 'Erkek', '1973-04-29', '0599 420 36 49', 'Doktor'),
('55550000002', 'richardwebber@yettipol.com', 'doktor123', 'Richard WEBBER', 'Erkek', '1973-02-12', '0599 186 21 23', 'Doktor'),
('55550000003', 'alivefa@yettipol.com', 'doktor123', 'Ali VEFA', 'Erkek', '1971-10-08', '0599 842 45 38', 'Doktor'),
('55550000004', 'nazligulengul@yettipol.com', 'doktor123', 'Nazlı GÜLENGÜL', 'Kadın', '1980-08-24', '0599 129 13 46', 'Doktor'),
('55550000005', 'eylemyucel@yettipol.com', 'doktor123', 'Eylem YÜCEL', 'Kadın', '1964-10-19', '0599 378 98 74', 'Doktor'),
('55550000006', 'rehakaraelmas@yettipol.com', 'doktor123', 'Reha KARAELMAS', 'Erkek', '1969-05-19', '0599 819 33 42', 'Doktor'),
('55550000007', 'elaaltindag@yettipol.com', 'doktor123', 'Ela ALTINDAĞ', 'Kadın', '1979-06-12', '0599 640 83 82', 'Doktor'),
('55550000008', 'mirandabailey@yettipol.com', 'doktor123', 'Miranda BAILEY', 'Kadın', '1988-05-11', '0599 906 65 95', 'Doktor'),
('55550000009', 'haldungoksun@yettipol.com', 'doktor123', 'Haldun GÖKSUN', 'Erkek', '1974-08-17', '0599 536 69 86', 'Doktor'),
('55550000010', 'baharozden@yettipol.com', 'doktor123', 'Bahar ÖZDEN', 'Kadın', '1971-02-21', '0599 759 38 85', 'Doktor'),
('55550000011', 'evrenyalkin@yettipol.com', 'doktor123', 'Evren YALKIN', 'Erkek', '1982-10-08', '0599 495 85 86', 'Doktor'),
('55550000012', 'addisonmontgomery@yettipol.com', 'doktor123', 'Addison MONTGOMERY', 'Kadın', '1973-07-29', '0599 862 49 96', 'Doktor'),
('55550000013', 'georgeomalley@yettipol.com', 'doktor123', "George O'MALLEY", 'Erkek', '1987-12-03', '0599 183 64 42', 'Doktor'),
('55550000014', 'izziestevens@yettipol.com', 'doktor123', 'Izzie STEVENS', 'Kadın', '1967-03-17', '0599 729 77 82', 'Doktor'),
('55550000015', 'azizurasyavuzoglu@yettipol.com', 'doktor123', 'Aziz Uras YAVUZOĞLU', 'Erkek', '1976-05-18', '0599 908 23 70', 'Doktor'),
('55550000016', 'serenteki̇n@yettipol.com', 'doktor123', 'Seren TEKİN', 'Kadın', '1976-06-12', '0599 214 93 98', 'Doktor'),
('55550000017', 'cristinayang@yettipol.com', 'doktor123', 'Cristina YANG', 'Kadın', '1979-12-13', '0599 251 83 39', 'Doktor'),
('55550000018', 'ericahanh@yettipol.com', 'doktor123', 'Erica HANH', 'Kadın', '1979-03-16', '0599 700 56 19', 'Doktor'),
('55550000019', 'prestonburke@yettipol.com', 'doktor123', 'Preston BURKE', 'Erkek', '1964-10-20', '0599 381 69 52', 'Doktor'),
('55550000020', 'teddyaltman@yettipol.com', 'doktor123', 'Teddy ALTMAN', 'Kadın', '1992-08-18', '0599 371 76 99', 'Doktor'),
('55550000021', 'rengincevi̇k@yettipol.com', 'doktor123', 'Rengin ÇEVİK', 'Kadın', '1963-08-18', '0599 754 98 17', 'Doktor'),
('55550000022', 'timuryavuzoglu@yettipol.com', 'doktor123', 'Timur YAVUZOĞLU', 'Erkek', '1982-12-05', '0599 471 91 71', 'Doktor'),
('55550000023', 'lexiegrey@yettipol.com', 'doktor123', 'Lexie GREY', 'Kadın', '1974-06-22', '0599 947 75 23', 'Doktor'),
('55550000024', 'marksloan@yettipol.com', 'doktor123', 'Mark SLOAN', 'Erkek', '1971-07-24', '0599 707 49 67', 'Doktor'),
('55550000025', 'caglasert@yettipol.com', 'doktor123', 'Çağla SERT', 'Kadın', '1965-01-07', '0599 403 98 89', 'Doktor'),
('55550000026', 'tolgaokaner@yettipol.com', 'doktor123', 'Tolga OKANER', 'Erkek', '1978-04-21', '0599 654 80 77', 'Doktor'),
('55550000027', 'charlespercy@yettipol.com', 'doktor123', 'Charles PERCY', 'Erkek', '1989-08-21', '0599 820 26 57', 'Doktor'),
('55550000028', 'reedadamson@yettipol.com', 'doktor123', 'Reed ADAMSON', 'Kadın', '1968-03-19', '0599 394 87 83', 'Doktor'),
('55550000029', 'alpsungur@yettipol.com', 'doktor123', 'Alp SUNGUR', 'Erkek', '1986-07-13', '0599 435 70 38', 'Doktor'),
('55550000030', 'dorukergun@yettipol.com', 'doktor123', 'Doruk ERGÜN', 'Erkek', '1967-07-23', '0599 862 10 53', 'Doktor'),
('55550000031', 'uguraydin@yettipol.com', 'doktor123', 'Uğur AYDIN', 'Erkek', '1983-07-26', '0599 826 87 72', 'Doktor'),
('55550000032', 'derekshepherd@yettipol.com', 'doktor123', 'Derek SHEPHERD', 'Erkek', '1976-08-09', '0599 319 93 35', 'Doktor'),
('55550000033', 'leventatahanli@yettipol.com', 'doktor123', 'Levent ATAHANLI', 'Erkek', '1989-08-22', '0599 571 79 97', 'Doktor'),
('55550000034', 'meredithgrey@yettipol.com', 'doktor123', 'Meredith GREY', 'Kadın', '1981-08-09', '0599 630 15 59', 'Doktor'),
('55550000035', 'aliasafdeni̇zoglu@yettipol.com', 'doktor123', 'Ali Asaf DENİZOĞLU', 'Erkek', '1962-04-09', '0599 257 99 10', 'Doktor'),
('55550000036', 'fermaneryi̇gi̇t@yettipol.com', 'doktor123', 'Ferman ERYİĞİT', 'Erkek', '1964-12-03', '0599 905 76 63', 'Doktor'),
('55550000037', 'callietorres@yettipol.com', 'doktor123', 'Callie TORRES', 'Kadın', '1968-07-15', '0599 377 77 67', 'Doktor'),
('55550000038', 'owenhunt@yettipol.com', 'doktor123', 'Owen HUNT', 'Erkek', '1990-01-06', '0599 830 54 95', 'Doktor'),
('55550000039', 'bahartunc@yettipol.com', 'doktor123', 'Bahar TUNÇ', 'Kadın', '1986-08-28', '0599 651 38 99', 'Doktor'),
('55550000040', 'eyluldi̇ncer@yettipol.com', 'doktor123', 'Eylül DİNÇER', 'Kadın', '1995-07-03', '0599 611 64 92', 'Doktor'),
('55550000041', 'alexkartev@yettipol.com', 'doktor123', 'Alex KARTEV', 'Erkek', '1964-01-14', '0599 188 41 76', 'Doktor'),
('55550000042', 'arizonarobbins@yettipol.com', 'doktor123', 'Arizona ROBBINS', 'Kadın', '1975-07-28', '0599 307 73 97', 'Doktor'),
('55550000043', 'nisandeni̇z@yettipol.com', 'doktor123', 'Nisan DENİZ', 'Kadın', '1989-07-05', '0599 452 98 53', 'Doktor'),
('55550000044', 'sinansoy@yettipol.com', 'doktor123', 'Sinan SOY', 'Erkek', '1966-07-22', '0599 426 69 57', 'Doktor'),
('55550000045', 'arslani̇brahi̇moglu@yettipol.com', 'doktor123', 'Arslan İBRAHİMOĞLU', 'Erkek', '1970-07-31', '0599 777 70 69', 'Doktor'),
('55550000046', 'dorukkurt@yettipol.com', 'doktor123', 'Doruk KURT', 'Erkek', '1961-11-13', '0599 338 54 70', 'Doktor'),
('55550000047', 'emirdemi̇rhan@yettipol.com', 'doktor123', 'Emir DEMİRHAN', 'Erkek', '1995-01-05', '0599 339 17 51', 'Doktor'),
('55550000048', 'oguzaydin@yettipol.com', 'doktor123', 'Oğuz AYDIN', 'Erkek', '1993-07-27', '0599 374 70 44', 'Doktor'),
('55550000049', 'aprilkepner@yettipol.com', 'doktor123', 'April KEPNER', 'Kadın', '1981-04-11', '0599 477 63 58', 'Doktor'),
('55550000050', 'jacksonavery@yettipol.com', 'doktor123', 'Jackson AVERY', 'Erkek', '1973-08-21', '0599 519 28 97', 'Doktor'),
('55550000051', 'efsunarmagan@yettipol.com', 'doktor123', 'Efsun ARMAĞAN', 'Kadın', '1981-07-12', '0599 997 53 25', 'Doktor'),
('55550000052', 'ferdaaksoy@yettipol.com', 'doktor123', 'Ferda AKSOY', 'Kadın', '1990-09-09', '0599 335 72 47', 'Doktor');


INSERT INTO doktorlar (doktor_isim, bolum_id, hastane_id, tc_no) VALUES
("Dr. Ellis GREY", "BAY_DAH", "BAY", "55550000001"),
("Dr. Richard WEBBER", "BAY_DAH", "BAY", "55550000002"),
("Dr. Ali VEFA", "SAR_DAH", "SAR", "55550000003"),
("Dr. Nazlı GÜLENGÜL", "SAR_DAH", "SAR", "55550000004"),
("Dr. Eylem YÜCEL", "TUZ_DAH", "TUZ", "55550000005"),
("Dr. Reha KARAELMAS", "TUZ_DAH", "TUZ", "55550000006"),
("Dr. Ela ALTINDAĞ", "BAY_GEN", "BAY", "55550000007"),
("Dr. Miranda BAILEY", "BAY_GEN", "BAY", "55550000008"),
("Dr. Haldun GÖKSUN", "TUZ_GEN", "TUZ", "55550000009"),
("Dr. Bahar ÖZDEN", "TUZ_GEN", "TUZ", "55550000010"),
("Dr. Evren YALKIN", "TUZ_GEN", "TUZ", "55550000011"),
("Dr. Addison MONTGOMERY", "BAY_DOG", "BAY", "55550000012"),
("Dr. George O'MALLEY", "BAY_DOG", "BAY", "55550000013"),
("Dr. Izzie STEVENS", "BAY_DOG", "BAY", "55550000014"),
("Dr. Uras YAVUZOĞLU", "TUZ_DOG", "TUZ", "55550000015"),
("Dr. Seren TEKİN", "TUZ_DOG", "TUZ", "55550000016"),
("Dr. Cristina YANG", "BAY_KAR", "BAY", "55550000017"),
("Dr. Erica HANH", "BAY_KAR", "BAY", "55550000018"),
("Dr. Preston BURKE", "BAY_KAR", "BAY", "55550000019"),
("Dr. Teddy ALTMAN", "BAY_KAR", "BAY", "55550000020"),
("Dr. Rengin ÇEVİK", "TUZ_KAR", "TUZ", "55550000021"),
("Dr. Timur YAVUZOĞLU", "TUZ_KAR", "TUZ", "55550000022"),
("Dr. Lexie GREY", "BAY_KBB", "BAY", "55550000023"),
("Dr. Mark SLOAN", "BAY_KBB", "BAY", "55550000024"),
("Dr. Çağla SERT", "TUZ_KBB", "TUZ", "55550000025"),
("Dr. Tolga OKANER", "TUZ_KBB", "TUZ", "55550000026"),
("Dr. Charles PERCY", "BAY_NEF", "BAY", "55550000027"),
("Dr. Reed ADAMSON", "BAY_NEF", "BAY", "55550000028"),
("Dr. Alp SUNGUR", "TUZ_NEF", "TUZ", "55550000029"),
("Dr. Doruk ERGÜN", "TUZ_NEF", "TUZ", "55550000030"),
("Dr. Uğur AYDIN", "TUZ_NEF", "TUZ", "55550000031"),
("Dr. Derek SHEPHERD", "BAY_NOR", "BAY", "55550000032"),
("Dr. Levent ATAHANLI", "BAY_NOR", "BAY", "55550000033"),
("Dr. Meredith GREY", "BAY_NOR", "BAY", "55550000034"),
("Dr. Ali Asaf DENİZOĞLU", "SAR_NOR", "SAR", "55550000035"),
("Dr. Ferman ERYİĞİT", "SAR_NOR", "SAR", "55550000036"),
("Dr. Callie TORRES", "BAY_ORT", "BAY", "55550000037"),
("Dr. Owen HUNT", "BAY_ORT", "BAY", "55550000038"),
("Dr. Bahar TUNÇ", "SAR_ORT", "SAR", "55550000039"),
("Dr. Eylül DİNÇER", "SAR_ORT", "SAR", "55550000040"),
("Dr. Alex KARTEV", "BAY_PED", "BAY", "55550000041"),
("Dr. Arizona ROBBINS", "BAY_PED", "BAY", "55550000042"),
("Dr. Nisan DENİZ", "SAR_PED", "SAR", "55550000043"),
("Dr. Sinan SOY", "SAR_PED", "SAR", "55550000044"),
("Dr. Arslan İBRAHİMOĞLU", "BAY_PLS", "BAY", "55550000045"),
("Dr. Doruk KURT", "SAR_PLS", "SAR", "55550000046"),
("Dr. Emir DEMİRHAN", "SAR_PLS", "SAR", "55550000047"),
("Dr. Oğuz AYDIN", "SAR_PLS", "SAR", "55550000048"),
("Dr. April KEPNER", "BAY_PSY", "BAY", "55550000049"),
("Dr. Jackson AVERY", "BAY_PSY", "BAY", "55550000050"),
("Dr. Efsun ARMAĞAN", "SAR_PSY", "SAR", "55550000051"),
("Dr. Ferda AKSOY", "SAR_PSY", "SAR", "55550000052");



INSERT INTO hastalar (tc_no, hasta_isimsoyisim, hasta_cinsiyet, hasta_dog_tar, hasta_telefon) VALUES
('12345678901', 'Ayşe Yılmaz', 'Kadın', '1990-04-12', '0532 123 45 67'),
('98765432100', 'Mehmet Kaya', 'Erkek', '1985-09-25', '0542 123 45 67'),
('11223344556', 'Fatma Arslan', 'Kadın', '1995-11-03', '0533 567 89 01');

INSERT INTO tatil_gunleri (tarih, ad) VALUES
('2025-01-01', 'Yılbaşı'),
('2025-04-21', 'Ramazan Bayramı Arifesi'),
('2025-04-22', 'Ramazan Bayramı 1. Gün'),
('2025-04-23', 'Ramazan Bayramı 2. Gün ve 23 Nisan'),
('2025-04-24', 'Ramazan Bayramı 3. Gün'),
('2025-05-01', 'Emek ve Dayanışma Günü'),
('2025-05-19', 'Atatürk’ü Anma, Gençlik ve Spor Bayramı'),
('2025-06-07', 'Kurban Bayramı Arifesi'),
('2025-06-08', 'Kurban Bayramı 1. Gün'),
('2025-06-09', 'Kurban Bayramı 2. Gün'),
('2025-06-10', 'Kurban Bayramı 3. Gün'),
('2025-06-11', 'Kurban Bayramı 4. Gün'),
('2025-07-15', 'Demokrasi ve Millî Birlik Günü'),
('2025-08-30', 'Zafer Bayramı'),
('2025-10-29', 'Cumhuriyet Bayramı');


SET SQL_SAFE_UPDATES = 0;


UPDATE doktorlar SET izingunu = 'Pazartesi' 
WHERE doktor_isim IN ('Dr. Ellis GREY', 'Dr. Reha KARAELMAS', 'Dr. Evren YALKIN', 'Dr. Teddy ALTMAN',
                      'Dr. Rengin ÇEVİK', 'Dr. Alex KARTEV', 'Dr. Emir DEMİRHAN', 'Dr. Doruk ERGÜN',
                      'Dr. Meredith GREY', 'Dr. Seren TEKİN', 'Dr. Doruk KURT');

-- Salı izinliler (11 kişi)
UPDATE doktorlar SET izingunu = 'Salı' 
WHERE doktor_isim IN ('Dr. Miranda BAILEY', 'Dr. Richard WEBBER', 'Dr. Addison MONTGOMERY', 'Dr. Izzie STEVENS',
                      'Dr. Haldun GÖKSUN', 'Dr. Lexie GREY', 'Dr. Efsun ARMAĞAN', 'Dr. Sinan SOY',
                      'Dr. Timur YAVUZOĞLU', 'Dr. Alp SUNGUR', 'Dr. Ferman ERYİĞİT');

-- Çarşamba izinliler (10 kişi)
UPDATE doktorlar SET izingunu = 'Çarşamba' 
WHERE doktor_isim IN ('Dr. Cristina YANG', 'Dr. Erica HANH', 'Dr. Reed ADAMSON', 'Dr. Eylem YÜCEL',
                      'Dr. Jackson AVERY', 'Dr. April KEPNER', 'Dr. Nazlı GÜLENGÜL', 'Dr. Nisan DENİZ',
                      'Dr. Owen HUNT', 'Dr. Tolga OKANER');

-- Perşembe izinliler (10 kişi)
UPDATE doktorlar SET izingunu = 'Perşembe' 
WHERE doktor_isim IN ('Dr. Charles PERCY', 'Dr. George O\'MALLEY', 'Dr. Ela ALTINDAĞ', 'Dr. Uras YAVUZOĞLU',
                      'Dr. Levent ATAHANLI', 'Dr. Ferda AKSOY', 'Dr. Ali VEFA', 'Dr. Arslan İBRAHİMOĞLU',
                      'Dr. Callie TORRES', 'Dr. Bahar TUNÇ');

-- Cuma izinliler (10 kişi)
UPDATE doktorlar SET izingunu = 'Cuma' 
WHERE doktor_isim IN ('Dr. Preston BURKE', 'Dr. Bahar ÖZDEN', 'Dr. Bahar TUNÇ', 'Dr. Oğuz AYDIN',
                      'Dr. Mark SLOAN', 'Dr. Uğur AYDIN', 'Dr. Ferman ERYİĞİT', 'Dr. Alex KARTEV',
                      'Dr. Eylül DİNÇER', 'Dr. Levent ATAHANLI');

-- Pazartesi akademik izin (10 kişi)
UPDATE doktorlar SET akademik_izin = 'Pazartesi' 
WHERE doktor_isim IN ('Dr. Miranda BAILEY', 'Dr. Charles PERCY', 'Dr. Reed ADAMSON', 'Dr. Tolga OKANER',
                      'Dr. Uğur AYDIN', 'Dr. Ela ALTINDAĞ', 'Dr. Eylül DİNÇER', 'Dr. Erica HANH',
                      'Dr. Sinan SOY', 'Dr. Ferda AKSOY');

-- Salı akademik izin (10 kişi)
UPDATE doktorlar SET akademik_izin = 'Salı' 
WHERE doktor_isim IN ('Dr. Ellis GREY', 'Dr. Cristina YANG', 'Dr. George O\'MALLEY', 'Dr. Callie TORRES',
                      'Dr. Emir DEMİRHAN', 'Dr. Mark SLOAN', 'Dr. Richard WEBBER', 'Dr. Alp SUNGUR',
                      'Dr. Doruk KURT', 'Dr. Jackson AVERY');

-- Çarşamba akademik izin (10 kişi)
UPDATE doktorlar SET akademik_izin = 'Çarşamba' 
WHERE doktor_isim IN ('Dr. Meredith GREY', 'Dr. Reha KARAELMAS', 'Dr. Izzie STEVENS', 'Dr. Levent ATAHANLI',
                      'Dr. Oğuz AYDIN', 'Dr. Rengin ÇEVİK', 'Dr. Miranda BAILEY', 'Dr. Nisan DENİZ',
                      'Dr. Ferman ERYİĞİT', 'Dr. Arslan İBRAHİMOĞLU');

-- Perşembe akademik izin (11 kişi)
UPDATE doktorlar SET akademik_izin = 'Perşembe' 
WHERE doktor_isim IN ('Dr. Addison MONTGOMERY', 'Dr. Uras YAVUZOĞLU', 'Dr. Bahar ÖZDEN', 'Dr. Teddy ALTMAN',
                      'Dr. Timur YAVUZOĞLU', 'Dr. Bahar TUNÇ', 'Dr. Nazlı GÜLENGÜL', 'Dr. Doruk ERGÜN',
                      'Dr. Alex KARTEV', 'Dr. Efsun ARMAĞAN', 'Dr. Haldun GÖKSUN');

-- Cuma akademik izin (11 kişi)
UPDATE doktorlar SET akademik_izin = 'Cuma' 
WHERE doktor_isim IN ('Dr. Erica HANH', 'Dr. Preston BURKE', 'Dr. April KEPNER', 'Dr. Evren YALKIN',
                      'Dr. Ali VEFA', 'Dr. Jackson AVERY', 'Dr. Ferman ERYİĞİT', 'Dr. George O\'MALLEY',
                      'Dr. Izzie STEVENS', 'Dr. Uğur AYDIN', 'Dr. Seren TEKİN');
SET SQL_SAFE_UPDATES = 1;

UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'DR. Reha Karaelmas';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Eylem Yücel';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Richard Webber';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Ellis Grey';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Salı' WHERE doktor_isim = 'Dr. Ali Vefa';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Nazlı Gülengül';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Evren Yalkın';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Bahar Özden';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Haldun Göksun';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Miranda Bailey';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Ela Altındağ';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Seren Tekin';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Aziz Uras Yavuzoğlu';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. George O\'Malley';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Izzie Stevens';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Addison Montgomery';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Timur Yavuzoğlu';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Rengin Çevik';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Preston Burke';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Teddy Altman';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Salı' WHERE doktor_isim = 'Dr. Cristina Yang';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Erica Hanh';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Tolga Okaner';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Çağla Sert';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Mark Sloan';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Salı' WHERE doktor_isim = 'Dr. Lexie Grey';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Doruk Ergün';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Uğur Aydın';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Alp Sungur';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Salı' WHERE doktor_isim = 'Dr. Reed Adamson';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Charles Percy';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Ali Asaf Denizoğlu';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Ferman Eryiğit';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Derek Shepherd';
UPDATE doktorlar SET izingunu = 'Cuma', akademik_izin = 'Salı' WHERE doktor_isim = 'Dr. Meredith Grey';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Levent Atahanlı';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Eylül Dinçer';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Bahar Tunç';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Owen Hunt';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Callie Torres';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Nisan Deniz';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Sinan Soy';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Alex Karev';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Arizona Robbins';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Ferda Aksoy';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Efsun Armağan';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Jackson Avery';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. April Kepner';
UPDATE doktorlar SET izingunu = 'Pazartesi', akademik_izin = 'Cuma' WHERE doktor_isim = 'Dr. Emir Demirhan';
UPDATE doktorlar SET izingunu = 'Salı', akademik_izin = 'Perşembe' WHERE doktor_isim = 'Dr. Doruk Kurt';
UPDATE doktorlar SET izingunu = 'Çarşamba', akademik_izin = 'Pazartesi' WHERE doktor_isim = 'Dr. Oğuz Aydın';
UPDATE doktorlar SET izingunu = 'Perşembe', akademik_izin = 'Çarşamba' WHERE doktor_isim = 'Dr. Arslan İbrahimoğlu';


INSERT INTO fotograflar (fotograf, doktor_id) VALUES
('sarıyer hastane/ali asaf denizoğlu.png', 35),
('bayrampaşa hastane/ellis grey.jpg', 1),
('tuzla hastane/haldun göksun.jpg', 9),
('bayrampaşa hastane/addison montgomery.jpg', 12),
('bayrampaşa hastane/Alex Karev.jpg', 41),
('sarıyer hastane/ali vefa.jpg', 3),
('tuzla hastane/alp sungur.png', 29),
('bayrampaşa hastane/april kepner.png', 49),
('bayrampaşa hastane/arizona robbins.jpg', 42),
('bayrampaşa hastane/arslan ibrahimoğlu.jpg', 45),
('tuzla hastane/aziz uras yavuzoglu.jpg', 15),
('tuzla hastane/bahar özden.jpg', 10),
('sarıyer hastane/bahar tunç.jpg', 39),
('bayrampaşa hastane/Callie Torres.jpg', 37),
('bayrampaşa hastane/charles percy.jpg', 27),
('bayrampaşa hastane/Cristina Yang.jpg', 17),
('tuzla hastane/çağla sert.jpg', 25),
('bayrampaşa hastane/Derek Shepherd.jpg', 32),
('tuzla hastane/doruk ergün.png', 30),
('sarıyer hastane/doruk kurt.jpg', 46),
('sarıyer hastane/efsun armağan.jpg', 51),
('bayrampaşa hastane/ela altındağ.jpg', 7),
('sarıyer hastane/emir demirhan.jpg', 47),
('bayrampaşa hastane/erica hanh.jpg', 18),
('tuzla hastane/evren yalkın.jpg', 11),
('tuzla hastane/eylem yücel.jpg', 5),
('sarıyer hastane/eylül dinçer.jpg', 40),
('sarıyer hastane/ferda aksoy.jpg', 52),
('sarıyer hastane/ferman eryiğit.jpg', 36),
('bayrampaşa hastane/george o\'malley.jpg', 13),
('bayrampaşa hastane/izzie stevens.jpg', 14),
('bayrampaşa hastane/jackson avery.jpg', 50),
('bayrampaşa hastane/levent atahanlı.jpg', 33),
('bayrampaşa hastane/lexie grey.jpg', 23),
('bayrampaşa hastane/Mark Sloan.jpg', 24),
('bayrampaşa hastane/meredith grey.jpg', 34),
('bayrampaşa hastane/miranda bailey.jpg', 8),
('sarıyer hastane/nazlı gülengül.jpg', 4),
('sarıyer hastane/nisan deniz.jpg', 43),
('sarıyer hastane/oğuz aydın.jpg', 48),
('bayrampaşa hastane/owen hunt.jpg', 38),
('bayrampaşa hastane/Preston Burke.jpg', 19),
('bayrampaşa hastane/reed adamson.jpg', 28),
('tuzla hastane/reha karaelmas.jpg', 6),
('tuzla hastane/rengin çevik.jpg', 21),
('bayrampaşa hastane/richard webber.jpg', 2),
('tuzla hastane/seren tekin.jpg', 16),
('sarıyer hastane/sinan soy.jpg', 44),
('bayrampaşa hastane/Teddy Altman.jpg', 20),
('tuzla hastane/timur yavuzoglu.jpg', 22),
('tuzla hastane/tolga okaner.jpg', 26),
('tuzla hastane/uğur aydın.jpg', 31);

INSERT INTO kullanicilar (tc_no, email, sifre, hasta_isimsoyisim, hasta_cinsiyet, hasta_dog_tar, hasta_telefon, rol) VALUES
('66660000001', 'ahmetyilmaz@yettipol.com', 'tek123', 'Ahmet Yılmaz', 'Erkek', '1990-01-01', '0566 000 00 01', 'Teknisyen'),
('66660000002', 'elifdemir@yettipol.com', 'tek123', 'Elif Demir', 'Kadın', '1992-02-02', '0566 000 00 02', 'Teknisyen'),
('66660000003', 'mehmetkaya@yettipol.com', 'tek123', 'Mehmet Kaya', 'Erkek', '1989-03-03', '0566 000 00 03', 'Teknisyen'),
('66660000004', 'zeynepsahin@yettipol.com', 'tek123', 'Zeynep Şahin', 'Kadın', '1993-04-04', '05660000004', 'Teknisyen'),
('66660000005', 'burakcelik@yettipol.com', 'tek123', 'Burak Çelik', 'Erkek', '1991-05-05', '05660000005', 'Teknisyen'),
('66660000006', 'aylinaydin@yettipol.com', 'tek123', 'Aylin Aydın', 'Kadın', '1990-06-06', '05660000006', 'Teknisyen'),
('66660000007', 'emrekoc@yettipol.com', 'tek123', 'Emre Koç', 'Erkek', '1992-07-07', '05660000007', 'Teknisyen'),
('66660000008', 'deryayildiz@yettipol.com', 'tek123', 'Derya Yıldız', 'Kadın', '1991-08-08', '05660000008', 'Teknisyen'),
('66660000009', 'serkanpolat@yettipol.com', 'tek123', 'Serkan Polat', 'Erkek', '1988-09-09', '05660000009', 'Teknisyen'),
('66660000010', 'muratarslan@yettipol.com', 'tek123', 'Murat Arslan', 'Erkek', '1987-01-10', '05660000010', 'Teknisyen'),
('66660000011', 'aslicetin@yettipol.com', 'tek123', 'Aslı Çetin', 'Kadın', '1990-02-11', '05660000011', 'Teknisyen'),
('66660000012', 'okandemirtas@yettipol.com', 'tek123', 'Okan Demirtaş', 'Erkek', '1994-03-12', '05660000012', 'Teknisyen'),
('66660000013', 'sedayilmaz@yettipol.com', 'tek123', 'Seda Yılmaz', 'Kadın', '1995-04-13', '05660000013', 'Teknisyen'),
('66660000014', 'canerdem@yettipol.com', 'tek123', 'Can Erdem', 'Erkek', '1989-05-14', '05660000014', 'Teknisyen'),
('66660000015', 'fundagunus@yettipol.com', 'tek123', 'Funda Güneş', 'Kadın', '1992-06-15', '05660000015', 'Teknisyen'),
('66660000016', 'tunaacar@yettipol.com', 'tek123', 'Tuna Acar', 'Erkek', '1993-07-16', '05660000016', 'Teknisyen'),
('66660000017', 'haledogan@yettipol.com', 'tek123', 'Hale Doğan', 'Kadın', '1990-08-17', '05660000017', 'Teknisyen'),
('66660000018', 'barissen@yettipol.com', 'tek123', 'Barış Şen', 'Erkek', '1991-09-18', '05660000018', 'Teknisyen'),
('66660000019', 'erenkurt@yettipol.com', 'tek123', 'Eren Kurt', 'Erkek', '1987-10-19', '05660000019', 'Teknisyen'),
('66660000020', 'ipekyildirim@yettipol.com', 'tek123', 'İpek Yıldırım', 'Kadın', '1994-11-20', '05660000020', 'Teknisyen'),
('66660000021', 'selimkoc@yettipol.com', 'tek123', 'Selim Koç', 'Erkek', '1989-12-21', '05660000021', 'Teknisyen'),
('66660000022', 'melisari@yettipol.com', 'tek123', 'Melis Arı', 'Kadın', '1993-01-22', '05660000022', 'Teknisyen'),
('66660000023', 'onurtopal@yettipol.com', 'tek123', 'Onur Topal', 'Erkek', '1990-02-23', '05660000023', 'Teknisyen'),
('66660000024', 'busekilic@yettipol.com', 'tek123', 'Buse Kılıç', 'Kadın', '1995-03-24', '05660000024', 'Teknisyen'),
('66660000025', 'kaancakir@yettipol.com', 'tek123', 'Kaan Çakır', 'Erkek', '1988-04-25', '05660000025', 'Teknisyen'),
('66660000026', 'denizyilmaz@yettipol.com', 'tek123', 'Deniz Yılmaz', 'Kadın', '1991-05-26', '05660000026', 'Teknisyen'),
('66660000027', 'mervedogan@yettipol.com', 'tek123', 'Merve Doğan', 'Kadın', '1992-06-27', '05660000027', 'Teknisyen');

INSERT INTO teknisyenler (tc_no, isimsoyisim, hastane_id, izin_gunu, tek_tur) VALUES
('66660000001', 'Ahmet Yılmaz', 'BAY', 'Pazartesi', 'Kan'),
('66660000002', 'Elif Demir', 'BAY', 'Salı', 'Kan'),
('66660000003', 'Mehmet Kaya', 'BAY', 'Çarşamba', 'Kan'),
('66660000004', 'Zeynep Şahin', 'SAR', 'Perşembe', 'Kan'),
('66660000005', 'Burak Çelik', 'SAR', 'Cuma', 'Kan'),
('66660000006', 'Aylin Aydın', 'SAR', 'Pazartesi', 'Kan'),
('66660000007', 'Emre Koç', 'TUZ', 'Salı', 'Kan'),
('66660000008', 'Derya Yıldız', 'TUZ', 'Çarşamba', 'Kan'),
('66660000009', 'Serkan Polat', 'TUZ', 'Perşembe', 'Kan'),
('66660000010', 'Murat Arslan', 'TUZ', 'Pazartesi', 'İdrar'),
('66660000011', 'Aslı Çetin', 'TUZ', 'Salı', 'İdrar'),
('66660000012', 'Okan Demirtaş', 'TUZ', 'Çarşamba', 'İdrar'),
('66660000013', 'Seda Yılmaz', 'BAY', 'Perşembe', 'İdrar'),
('66660000014', 'Can Erdem', 'BAY', 'Cuma', 'İdrar'),
('66660000015', 'Funda Güneş', 'BAY', 'Pazartesi', 'İdrar'),
('66660000016', 'Tuna Acar', 'SAR', 'Salı', 'İdrar'),
('66660000017', 'Hale Doğan', 'SAR', 'Çarşamba', 'İdrar'),
('66660000018', 'Barış Şen', 'SAR', 'Perşembe', 'İdrar'),
('66660000019', 'Eren Kurt', 'SAR', 'Pazartesi', 'Görüntüleme'),
('66660000020', 'İpek Yıldırım', 'SAR', 'Salı', 'Görüntüleme'),
('66660000021', 'Selim Koç', 'SAR', 'Çarşamba', 'Görüntüleme'),
('66660000022', 'Melis Arı', 'TUZ', 'Perşembe', 'Görüntüleme'),
('66660000023', 'Onur Topal', 'TUZ', 'Cuma', 'Görüntüleme'),
('66660000024', 'Buse Kılıç', 'TUZ', 'Pazartesi', 'Görüntüleme'),
('66660000025', 'Kaan Çakır', 'BAY', 'Salı', 'Görüntüleme'),
('66660000026', 'Deniz Yılmaz', 'BAY', 'Çarşamba', 'Görüntüleme'),
('66660000027', 'Merve Doğan', 'BAY', 'Perşembe', 'Görüntüleme');

INSERT INTO tahlil_turleri (ad) VALUES 
('Hemogram (Tam Kan Sayımı)'),
('Biyokimya'),
('Vitamin Testi'),
('Hormon Testi'),
('Kan Şekeri'),
('Tam İdrar Tahlili'),
('İdrar Kültürü'),
('24 Saatlik İdrar'),
('Akciğer Röntgeni'),
('MR'),
('BT'),
('Ultrason');

-- hemogram

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max) VALUES
(1, 'WBC', 'x10³/µL', 4.0, 10.0),
(1, 'RBC', 'x10⁶/µL', 4.2, 5.9),
(1, 'HGB', 'g/dL', 12.0, 16.0),
(1, 'HCT', '%', 36.0, 50.0),
(1, 'MCV', 'fL', 80.0, 100.0),
(1, 'MCH', 'pg', 27.0, 33.0),
(1, 'MCHC', 'g/dL', 32.0, 36.0),
(1, 'PLT', 'x10³/µL', 150.0, 400.0),
(1, 'RDW', '%', 11.5, 14.5),
(1, 'MPV', 'fL', 7.5, 11.5),
(1, 'PDW', '%', 9.0, 17.0),
(1, 'NEU', '%', 40.0, 70.0),
(1, 'LYM', '%', 20.0, 40.0),
(1, 'MON', '%', 2.0, 10.0),
(1, 'EOS', '%', 1.0, 6.0),
(1, 'BAS', '%', 0.0, 2.0);

-- biyokimya

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max, kategorik_mi)
VALUES
(2, 'Glukoz (Açlık)', 'mg/dL', 70, 100, FALSE),
(2, 'BUN (Üre)', 'mg/dL', 7, 20, FALSE),
(2, 'Kreatinin', 'mg/dL', 0.6, 1.3, FALSE),
(2, 'Total Protein', 'g/dL', 6.4, 8.3, FALSE),
(2, 'Albumin', 'g/dL', 3.5, 5.0, FALSE),
(2, 'ALT (SGPT)', 'U/L', 7, 56, FALSE),
(2, 'AST (SGOT)', 'U/L', 10, 40, FALSE),
(2, 'ALP', 'U/L', 44, 147, FALSE),
(2, 'GGT', 'U/L', 9, 48, FALSE),
(2, 'Total Bilirubin', 'mg/dL', 0.1, 1.2, FALSE),
(2, 'Direct Bilirubin', 'mg/dL', 0, 0.3, FALSE),
(2, 'Sodium (Na)', 'mmol/L', 135, 145, FALSE),
(2, 'Potassium (K)', 'mmol/L', 3.5, 5.1, FALSE),
(2, 'Chloride (Cl)', 'mmol/L', 98, 107, FALSE),
(2, 'Calcium (Ca)', 'mg/dL', 8.5, 10.5, FALSE),
(2, 'Magnesium (Mg)', 'mg/dL', 1.7, 2.2, FALSE),
(2, 'Phosphorus (P)', 'mg/dL', 2.5, 4.5, FALSE);

-- vitamin testi

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max) VALUES
(3, 'B12 Vitamini', 'pg/mL', 200, 900),
(3, 'D Vitamini (25-OH)', 'ng/mL', 20, 50),
(3, 'Folik Asit (B9)', 'ng/mL', 3, 20),
(3, 'Ferritin (Ortalama)', 'ng/mL', 10, 250),
(3, 'Demir (Fe)', 'µg/dL', 60, 170);

-- hormon testi

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max) VALUES
(4, 'TSH', 'µIU/mL', 0.4, 4.0),
(4, 'Serbest T4', 'ng/dL', 0.8, 1.8),
(4, 'Serbest T3', 'pg/mL', 2.3, 4.2),
(4, 'FSH', 'mIU/mL', 1.5, 12.4),
(4, 'LH', 'mIU/mL', 1.7, 8.6),
(4, 'Prolaktin', 'ng/mL', 4.0, 23.0),
(4, 'Östrojen (E2)', 'pg/mL', 30.0, 400.0),
(4, 'Testosteron', 'ng/mL', 0.06, 0.86),
(4, 'Kortizol (sabah)', 'µg/dL', 6.0, 23.0),
(4, 'İnsülin', 'µIU/mL', 2.0, 25.0);

-- kan şekeri testi

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max) VALUES
(5, 'Açlık Kan Şekeri', 'mg/dL', 70, 100),
(5, 'Tokluk Kan Şekeri', 'mg/dL', 0, 139.99),
(5, 'HbA1c (Glikozile Hemoglobin)', '%', 4.0, 5.6),
(5, 'Oral Glukoz Tolerans Testi (OGTT)', 'mg/dL', 0, 139.99);

-- tam idrar

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max, kategorik_mi, referans_deger_metni) VALUES
(6, 'Renk', NULL, NULL, NULL, TRUE, 'Açık sarı – Koyu sarı'),
(6, 'Şeffaflık', NULL, NULL, NULL, TRUE, 'Temiz - Bulanık'),
(6, 'Spesifik Gravity (Yoğunluk)', NULL, 1.005, 1.030, FALSE, NULL),
(6, 'pH', NULL, 4.5, 8.0, FALSE, NULL),
(6, 'Protein', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Glukoz', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Ketone', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Bilirubin', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Ürobilinojen', 'mg/dL', 0.1, 1.0, FALSE, NULL),
(6, 'Nitrit', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Eritrosit (Kan)', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Lökosit (WBC)', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Epitel Hücre', NULL, NULL, NULL, TRUE, 'Az - Yok'),
(6, 'Silika/Kristaller', NULL, NULL, NULL, TRUE, 'Negatif'),
(6, 'Bakteri', NULL, NULL, NULL, TRUE, 'Negatif');

-- kültür

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max, kategorik_mi, referans_deger_metni) VALUES
(7, 'Numune Türü', NULL, NULL, NULL, TRUE, 'Midstream İdrar'),
(7, 'Toplama Tarihi', NULL, NULL, NULL, TRUE, '2025-05-18'),
(7, 'İnkübasyon Süresi', NULL, NULL, NULL, TRUE, '24-48 saat'),
(7, 'Bakteri Sayısı (CFU/mL)', NULL, NULL, NULL, TRUE, '>100,000'),
(7, 'İzole Edilen Mikroorganizmalar', NULL, NULL, NULL, TRUE, 'Escherichia coli'),
(7, 'Mikroskobik İnceleme', NULL, NULL, NULL, TRUE, 'Lökosit (+), Eritrosit (-)'),
(7, 'Antibiyogram Sonuçları - Amoksisilin', NULL, NULL, NULL, TRUE, 'Dirençli'),
(7, 'Antibiyogram Sonuçları - Siprofloksasin', NULL, NULL, NULL, TRUE, 'Duyarlı'),
(7, 'Antibiyogram Sonuçları - Nitrofurantoin', NULL, NULL, NULL, TRUE, 'Duyarlı'),
(7, 'Sonuç', NULL, NULL, NULL, TRUE, 'Pozitif - Negatif');

-- 24 saatlik idrar

INSERT INTO parametreler (tahlil_turu_id, isim, birim, referans_min, referans_max, kategorik_mi) VALUES
(8, 'Toplam İdrar Hacmi', 'mL', 800, 2000, FALSE),
(8, 'Protein', 'mg/24 saat', NULL, 150, FALSE),
(8, 'Kreatinin', 'mg/24 saat', 800, 2000, FALSE),
(8, 'Sodyum', 'mmol/24 saat', 40, 220, FALSE),
(8, 'Potasyum', 'mmol/24 saat', 25, 125, FALSE),
(8, 'Kalsiyum', 'mg/24 saat', 100, 300, FALSE),
(8, 'Üre', 'g/24 saat', 12, 20, FALSE),
(8, 'Mikroalbumin', 'mg/24 saat', NULL, 30, FALSE);

