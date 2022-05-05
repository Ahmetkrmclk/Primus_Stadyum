-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 05 May 2022, 16:46:10
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
-- Veritabanı: `prime`
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
  `k_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `biletler`
--

INSERT INTO `biletler` (`biletId`, `ad`, `soyad`, `durum`, `fiyat`, `koltukno`, `k_ID`) VALUES
(1, 'Meltem', 'Soyoğlu', 'Çocuk', 40, 'TB1', 1),
(2, 'Asuman', 'Erginoğlu', 'Kadın', 50, 'TB2', 1),
(3, 'Asuman', 'Erginoğlu', 'Kadın', 50, 'KB1', 1),
(4, 'Asuman', 'oğlu', 'Kadın', 50, 'KB2', 2),
(5, 'Ayşe Nur', 'Ak', 'Engelli', 30, 'KD10', 2),
(6, 'Ayfer', 'Yılmaz', 'Çocuk', 40, 'TB3', 1),
(7, 'Nurten', 'Gürgen', 'Engelli', 30, 'TD14', 1),
(8, 'Hanife', 'Çelikoğlu', 'Çocuk', 40, 'TD15', 1),
(9, 'Ayşe', 'Akbaba', 'Engelli', 30, 'KKK3', 2),
(10, 'Ayşe Fatma', 'Akbaba', 'Çocuk', 40, 'KKK4', 2),
(11, 'Mine', 'Yoldas', 'Engelli', 30, 'TD9', 1),
(12, 'Zeynep', 'Paroglu', 'Engelli', 30, 'TD2', 1),
(13, 'Canan', 'Yıldırım', 'Kadın', 50, 'TD3', 1),
(14, 'Ayşe', 'Yıldırım', 'Çocuk', 40, 'TD4', 1),
(15, 'Deniz', 'Yılmaz', 'Engelli', 30, 'TK1', 1),
(16, 'Pelin', 'Yumusak', 'Engelli', 30, 'KD3', 2),
(17, 'Ayşe', 'Akdoğanoğlu', 'Çocuk', 40, 'TB4', 1),
(19, 'Pelin', 'Akpınar', 'Kadın', 50, 'TD1', 1),
(20, 'Yasemin', 'Yılmaz', 'Engelli', 30, 'KD2', 2),
(21, 'Sema', 'Pamuk', 'Çocuk', 40, 'KB3', 2),
(23, 'ss', 's', 'Engelli', 30, 'TD5', 1),
(24, 'Melek', 'Özbey', 'Çocuk', 40, 'TB5', 1),
(25, 'Berfin', 'Çakır', 'Çocuk', 40, 'TKK5', 1),
(26, 'Melissa', 'Çakır', 'Çocuk', 40, 'TKK4', 1),
(27, 'Melis', 'Pamuk', 'Çocuk', 40, 'TD20', 1),
(28, 'Ayşe', 'Pamuk', 'Çocuk', 40, 'TD19', 1),
(29, 'Sinem', 'Güler', 'Kadın', 50, 'TB6', 1),
(30, 'Meltem', 'Özoğlu', 'Engelli', 30, 'TD8', 1),
(31, 'Derya', 'Damoğlu', 'Engelli', 30, 'TB8', 1),
(32, 'Derya Deniz', 'Hatmanoğlu', 'Engelli', 30, 'KB6', 2),
(33, 'Fatma Ayşe', 'Erdoğdu', 'Kadın', 50, 'TB7', 1),
(34, 'Cüneyt', 'Oral', 'Engelli', 30, 'TKK6', 1),
(35, 'Deneme', 'dn', 'Çocuk', 40, 'KB7', 2),
(36, 'ad', 'soyad', 'Kadın', 50, 'KK4', 2);

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
  `fiyat` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `koltukfiyatları`
--

INSERT INTO `koltukfiyatları` (`koltukfiyatID`, `koltukkategori`, `fiyat`) VALUES
(1, 'Engelli', 30),
(2, 'Çocuk', 40),
(3, 'Kadın', 50);

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
  `telefon` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `kullanici_verileri`
--

INSERT INTO `kullanici_verileri` (`kullaniciID`, `kullaniciAdi`, `KullaniciSoyadi`, `yas`, `eposta`, `sifre`, `durum`, `telefon`) VALUES
(1, 'Meltem', 'Soyoğlu', 25, 'Meltem@gmail.com', 'meltem123', 'Kadın', '(531) 858-9589'),
(2, 'Deniz', 'Yılmaz', 55, 'Dyilmaz@gmail.com', 'd_yilmaz1221', 'Engelli', '(564) 852-2888'),
(3, 'Semra nur', 'Deliloğlu', 5, 's.n_d@gmail.com', 'semra_.', 'Çocuk', '(589) 888-8888'),
(5, 'Ayşe', 'Akdoğanoğlu', 15, 'a.oğlu_@gmail.com', 'ayse_.123321', 'Çocuk', '(539) 695-5555'),
(6, 'Emine', 'Taylan', 2, 'Taylan.Emine@gmail.com', 'taylan_,.', 'Engelli', '(555) 555-5555'),
(7, 'Fatıma', 'Taylan', 6, 'Taylan.Fatıma@gmail.com', 'fatıma_,.', 'Çocuk', '(555) 524-9666');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `stadyumbm`
--

CREATE TABLE `stadyumbm` (
  `stadyumBMID` int(11) NOT NULL,
  `stadyumBM` int(11) DEFAULT NULL,
  `bolumadi` varchar(45) DEFAULT NULL,
  `kapasite` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `stadyumbm`
--

INSERT INTO `stadyumbm` (`stadyumBMID`, `stadyumBM`, `bolumadi`, `kapasite`) VALUES
(1, 1, 'Doğu Tribünü', 20),
(2, 1, 'Batı Tribünü', 20),
(3, 1, 'Kale Arkası Tribünü', 10),
(4, 1, 'Kale Arkası Tribünü2', 10),
(5, 2, 'Doğu Tribünü', 15),
(6, 2, 'Batı Tribünü', 15),
(7, 2, 'Kale Arkası Tribünü', 8),
(8, 2, 'Kale Arkası Tribünü2', 8),
(9, 2, 'Bölüm Kapanmıştır', 0);

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
  ADD PRIMARY KEY (`biletId`),
  ADD KEY `biiletten_Karsılasmaya_idx` (`k_ID`);

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
  ADD PRIMARY KEY (`koltukfiyatID`);

--
-- Tablo için indeksler `kullanici_verileri`
--
ALTER TABLE `kullanici_verileri`
  ADD PRIMARY KEY (`kullaniciID`);

--
-- Tablo için indeksler `stadyumbm`
--
ALTER TABLE `stadyumbm`
  ADD PRIMARY KEY (`stadyumBMID`),
  ADD KEY `sb_s` (`stadyumBM`);

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
  MODIFY `biletId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

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
  MODIFY `kullaniciID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Tablo için AUTO_INCREMENT değeri `stadyumbm`
--
ALTER TABLE `stadyumbm`
  MODIFY `stadyumBMID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

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
-- Tablo kısıtlamaları `biletler`
--
ALTER TABLE `biletler`
  ADD CONSTRAINT `biiletten_Karsılasmaya` FOREIGN KEY (`k_ID`) REFERENCES `karsilasmalar` (`karsilasmaID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `karsilasmalar`
--
ALTER TABLE `karsilasmalar`
  ADD CONSTRAINT `K_Stadyum` FOREIGN KEY (`StadyumID`) REFERENCES `stadyumlar` (`stadyumID`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `stadyumbm`
--
ALTER TABLE `stadyumbm`
  ADD CONSTRAINT `sb_s` FOREIGN KEY (`stadyumBM`) REFERENCES `stadyumlar` (`stadyumID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `stadyumlar`
--
ALTER TABLE `stadyumlar`
  ADD CONSTRAINT `s_t` FOREIGN KEY (`takimID`) REFERENCES `takimlar` (`takimID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
