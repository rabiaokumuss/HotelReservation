/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : otel-otomasyonu

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2016-05-31 12:19:09
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for musteriler
-- ----------------------------
DROP TABLE IF EXISTS `musteriler`;
CREATE TABLE `musteriler` (
  `oda_numarasi` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `musteri_adi_soyadi` varchar(70) COLLATE utf8_unicode_ci NOT NULL,
  `musteri_tel` varchar(11) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`oda_numarasi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of musteriler
-- ----------------------------
INSERT INTO `musteriler` VALUES ('0', 'Yok', '0');
INSERT INTO `musteriler` VALUES ('103', 'Orhan Saglam', '123456789');
INSERT INTO `musteriler` VALUES ('305', 'Kemal Uzun', '123123');
INSERT INTO `musteriler` VALUES ('401', 'Mehmet Dogru', '1234567890');

-- ----------------------------
-- Table structure for odalar
-- ----------------------------
DROP TABLE IF EXISTS `odalar`;
CREATE TABLE `odalar` (
  `oda_no` varchar(5) COLLATE utf8_unicode_ci NOT NULL,
  `oda_sayisi` int(4) NOT NULL,
  `oda_cift_kisilik_yatak` varchar(4) COLLATE utf8_unicode_ci NOT NULL,
  `oda_yatak_sayisi` int(5) NOT NULL,
  PRIMARY KEY (`oda_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of odalar
-- ----------------------------
INSERT INTO `odalar` VALUES ('101', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('102', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('103', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('104', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('105', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('200', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('201', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('202', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('203', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('204', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('205', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('300', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('301', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('302', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('303', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('304', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('305', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('400', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('401', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('402', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('403', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('404', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('405', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('500', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('501', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('502', '1', 'Yok', '1');
INSERT INTO `odalar` VALUES ('503', '2', 'Var', '2');
INSERT INTO `odalar` VALUES ('504', '1', 'Var', '1');
INSERT INTO `odalar` VALUES ('505', '1', 'Yok', '1');
