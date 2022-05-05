-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 30 Ara 2021, 18:06:04
-- Sunucu sürümü: 10.4.14-MariaDB
-- PHP Sürümü: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `primus_projesi`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `adminID` int(11) NOT NULL,
  `e_posta` varchar(50) DEFAULT NULL,
  `sifre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`adminID`, `e_posta`, `sifre`) VALUES
(1, 'ahmetkerim_colak@gmail.com', 'gürgendalları_.');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `biletler`
--

CREATE TABLE `biletler` (
  `biletId` int(11) NOT NULL,
  `ad` varchar(50) DEFAULT NULL,
  `soyad` varchar(50) DEFAULT NULL,
  `durum` varchar(45) DEFAULT NULL,
  `fiyat` int(11) DEFAULT NULL,
  `koltukno` varchar(10) DEFAULT NULL,
  `para_üstü` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `biletler`
--

INSERT INTO `biletler` (`biletId`, `ad`, `soyad`, `durum`, `fiyat`, `koltukno`, `para_üstü`) VALUES
(1, 'Ahmet', 'ÇOLAK', 'Engelli', 40, 'B2', 10);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `karsilasmalar`
--

CREATE TABLE `karsilasmalar` (
  `karsilasmaID` int(11) NOT NULL,
  `Tarih` varchar(45) DEFAULT NULL,
  `Ev_Sahibi_Takimi` varchar(1000) DEFAULT NULL,
  `Saat` time DEFAULT NULL,
  `Deplasman_Takimi` varchar(1000) DEFAULT NULL,
  `StadyumID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `karsilasmalar`
--

INSERT INTO `karsilasmalar` (`karsilasmaID`, `Tarih`, `Ev_Sahibi_Takimi`, `Saat`, `Deplasman_Takimi`, `StadyumID`) VALUES
(1, '18.12.2021', 'TRABZONSPOR A.Ş.', '20:00:00', 'ATAKAŞ HATAYSPOR', 1),
(2, '19.12.2021', 'İTTİFAK HOLDİNG KONYASPOR', '18:00:00', 'MEDİPOL BAŞAKŞEHİR FK', 2);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `koltukfiyatları`
--

CREATE TABLE `koltukfiyatları` (
  `koltukfiyatID` int(11) NOT NULL,
  `koltukkategori` varchar(45) DEFAULT NULL,
  `fiyat` int(11) DEFAULT NULL,
  `takimID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `koltukfiyatları`
--

INSERT INTO `koltukfiyatları` (`koltukfiyatID`, `koltukkategori`, `fiyat`, `takimID`) VALUES
(1, 'Engelli', 30, NULL),
(2, 'Çocuk', 40, NULL),
(3, 'Kadın', 50, NULL);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici_verileri`
--

CREATE TABLE `kullanici_verileri` (
  `kullaniciID` int(11) NOT NULL,
  `kullaniciAdi` varchar(45) DEFAULT NULL,
  `KullaniciSoyadi` varchar(45) DEFAULT NULL,
  `yas` int(11) DEFAULT NULL,
  `eposta` varchar(45) DEFAULT NULL,
  `sifre` varchar(45) DEFAULT NULL,
  `durum` varchar(45) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kullanici_verileri`
--

INSERT INTO `kullanici_verileri` (`kullaniciID`, `kullaniciAdi`, `KullaniciSoyadi`, `yas`, `eposta`, `sifre`, `durum`, `telefon`) VALUES
(1, 'Ertuğrul', 'Sağlam', 15, 'Ertuğrul@gmail.com', 'sağlam1243', 'Çocuk', '5555555555'),
(2, 'Mahmet', 'Sağlam', 15, 'Mahmet@gmail.com', 'sağlam1243', 'Çocuk', '(555) 111-5'),
(3, 'Can', 'Sağlam', 13, 'can@gmail.com', 'sağlam1243', 'Çocuk', '(555) 111-5544');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satislar`
--

CREATE TABLE `satislar` (
  `satisID` int(11) NOT NULL,
  `karsilasmaID` int(11) DEFAULT NULL,
  `biletID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `satislar`
--

INSERT INTO `satislar` (`satisID`, `karsilasmaID`, `biletID`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stadyumbm`
--

CREATE TABLE `stadyumbm` (
  `idstadyumBM` int(11) NOT NULL,
  `bolumadi` varchar(45) DEFAULT NULL,
  `kapasite` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `stadyumbm`
--

INSERT INTO `stadyumbm` (`idstadyumBM`, `bolumadi`, `kapasite`) VALUES
(1, 'Doğu Tribünü', 20),
(1, 'Batı Tribünü', 20),
(1, 'Kale Arkası Tribünü', 10),
(1, 'Kale Arkası Tribünü2', 10),
(2, 'Doğu Tribünü', 15),
(2, 'Batı Tribünü', 15),
(2, 'Kale Arkası Tribünü', 8),
(2, 'Kale Arkası Tribünü2', 8);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stadyumlar`
--

CREATE TABLE `stadyumlar` (
  `stadyumID` int(11) NOT NULL,
  `Stadyum` varchar(100) DEFAULT NULL,
  `takimID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `stadyumlar`
--

INSERT INTO `stadyumlar` (`stadyumID`, `Stadyum`, `takimID`) VALUES
(1, 'Şenol Güneş Spor Kompleksi Medical Park Stadyumu', 1),
(2, 'Medaş Konya Büyükşehir Stadyumu', 3);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `takimlar`
--

CREATE TABLE `takimlar` (
  `takimID` int(11) NOT NULL,
  `takimAdi` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `takimlar`
--

INSERT INTO `takimlar` (`takimID`, `takimAdi`) VALUES
(1, 'TRABZONSPOR A.Ş.'),
(2, 'ATAKAŞ HATAYSPOR'),
(3, 'İTTİFAK HOLDİNG KONYASPOR'),
(4, 'MEDİPOL BAŞAKŞEHİR FK');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`adminID`);

--
-- Tablo için indeksler `biletler`
--
ALTER TABLE `biletler`
  ADD PRIMARY KEY (`biletId`);

--
-- Tablo için indeksler `karsilasmalar`
--
ALTER TABLE `karsilasmalar`
  ADD PRIMARY KEY (`karsilasmaID`),
  ADD KEY `K_Stadyum_idx` (`StadyumID`);

--
-- Tablo için indeksler `koltukfiyatları`
--
ALTER TABLE `koltukfiyatları`
  ADD PRIMARY KEY (`koltukfiyatID`),
  ADD KEY `k_t_idx` (`takimID`);

--
-- Tablo için indeksler `kullanici_verileri`
--
ALTER TABLE `kullanici_verileri`
  ADD PRIMARY KEY (`kullaniciID`);

--
-- Tablo için indeksler `satislar`
--
ALTER TABLE `satislar`
  ADD PRIMARY KEY (`satisID`),
  ADD KEY `s_b_idx` (`biletID`),
  ADD KEY `s_k_idx` (`karsilasmaID`);

--
-- Tablo için indeksler `stadyumbm`
--
ALTER TABLE `stadyumbm`
  ADD KEY `sb_s_idx` (`idstadyumBM`);

--
-- Tablo için indeksler `stadyumlar`
--
ALTER TABLE `stadyumlar`
  ADD PRIMARY KEY (`stadyumID`),
  ADD KEY `s_t_idx` (`takimID`);

--
-- Tablo için indeksler `takimlar`
--
ALTER TABLE `takimlar`
  ADD PRIMARY KEY (`takimID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin`
--
ALTER TABLE `admin`
  MODIFY `adminID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `biletler`
--
ALTER TABLE `biletler`
  MODIFY `biletId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `karsilasmalar`
--
ALTER TABLE `karsilasmalar`
  MODIFY `karsilasmaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `koltukfiyatları`
--
ALTER TABLE `koltukfiyatları`
  MODIFY `koltukfiyatID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici_verileri`
--
ALTER TABLE `kullanici_verileri`
  MODIFY `kullaniciID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `satislar`
--
ALTER TABLE `satislar`
  MODIFY `satisID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `stadyumlar`
--
ALTER TABLE `stadyumlar`
  MODIFY `stadyumID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `takimlar`
--
ALTER TABLE `takimlar`
  MODIFY `takimID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `karsilasmalar`
--
ALTER TABLE `karsilasmalar`
  ADD CONSTRAINT `K_Stadyum` FOREIGN KEY (`StadyumID`) REFERENCES `stadyumlar` (`stadyumID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `koltukfiyatları`
--
ALTER TABLE `koltukfiyatları`
  ADD CONSTRAINT `k_t` FOREIGN KEY (`takimID`) REFERENCES `takimlar` (`takimID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `satislar`
--
ALTER TABLE `satislar`
  ADD CONSTRAINT `s_b` FOREIGN KEY (`biletID`) REFERENCES `biletler` (`biletId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `s_k` FOREIGN KEY (`karsilasmaID`) REFERENCES `karsilasmalar` (`karsilasmaID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `stadyumbm`
--
ALTER TABLE `stadyumbm`
  ADD CONSTRAINT `sb_s` FOREIGN KEY (`idstadyumBM`) REFERENCES `stadyumlar` (`stadyumID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `stadyumlar`
--
ALTER TABLE `stadyumlar`
  ADD CONSTRAINT `s_t` FOREIGN KEY (`takimID`) REFERENCES `takimlar` (`takimID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
