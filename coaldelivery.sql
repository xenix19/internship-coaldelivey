-- --------------------------------------------------------
-- Хост:                         127.0.0.1
-- Версия сервера:               10.1.38-MariaDB - mariadb.org binary distribution
-- Операционная система:         Win32
-- HeidiSQL Версия:              12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Дамп структуры базы данных coaldelivery
DROP DATABASE IF EXISTS `coaldelivery`;
CREATE DATABASE IF NOT EXISTS `coaldelivery` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `coaldelivery`;

-- Дамп структуры для таблица coaldelivery.coal
DROP TABLE IF EXISTS `coal`;
CREATE TABLE IF NOT EXISTS `coal` (
  `ID` int(11) NOT NULL,
  `name` int(11) DEFAULT NULL,
  `class` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.coal: ~11 rows (приблизительно)
DELETE FROM `coal`;
INSERT INTO `coal` (`ID`, `name`, `class`) VALUES
	(0, 0, '0-300'),
	(1, 1, '70-200'),
	(2, 1, '60-130'),
	(3, 1, '50-200'),
	(4, 2, '13-200'),
	(5, 3, '25-70'),
	(6, 3, '25-50'),
	(7, 4, '13-70'),
	(8, 5, '0-25'),
	(9, 6, '0-50'),
	(10, 7, '6-25');

-- Дамп структуры для таблица coaldelivery.coals
DROP TABLE IF EXISTS `coals`;
CREATE TABLE IF NOT EXISTS `coals` (
  `ID` int(11) NOT NULL,
  `coal` int(11) DEFAULT NULL,
  `supplier` int(11) DEFAULT NULL,
  `coast` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.coals: ~19 rows (приблизительно)
DELETE FROM `coals`;
INSERT INTO `coals` (`ID`, `coal`, `supplier`, `coast`) VALUES
	(0, 0, 0, 135.12),
	(1, 0, 1, 233.35),
	(2, 0, 2, 634.64),
	(3, 0, 3, 234.12),
	(4, 1, 0, 547.34),
	(5, 2, 2, 679.46),
	(6, 3, 1, 123.67),
	(7, 4, 0, 374.78),
	(8, 5, 0, 163.34),
	(9, 5, 2, 1233.23),
	(10, 5, 3, 234.12),
	(11, 6, 1, 477.15),
	(12, 7, 0, 452.16),
	(13, 8, 0, 123.26),
	(14, 8, 1, 111.34),
	(15, 8, 2, 222.37),
	(16, 8, 3, 750),
	(17, 9, 1, 324),
	(18, 10, 2, 123);

-- Дамп структуры для таблица coaldelivery.coal_names
DROP TABLE IF EXISTS `coal_names`;
CREATE TABLE IF NOT EXISTS `coal_names` (
  `ID` int(11) NOT NULL,
  `name` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.coal_names: ~8 rows (приблизительно)
DELETE FROM `coal_names`;
INSERT INTO `coal_names` (`ID`, `name`) VALUES
	(0, 'ДР'),
	(1, 'ДПК'),
	(2, 'ДПКОМ'),
	(3, 'ДО'),
	(4, 'ДОМ'),
	(5, 'ДМСШ'),
	(6, 'ДОМСШ'),
	(7, 'ДМС');

-- Дамп структуры для таблица coaldelivery.orders
DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `ID` int(11) NOT NULL,
  `user` int(11) DEFAULT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.orders: ~0 rows (приблизительно)
DELETE FROM `orders`;

-- Дамп структуры для таблица coaldelivery.positions
DROP TABLE IF EXISTS `positions`;
CREATE TABLE IF NOT EXISTS `positions` (
  `ID` int(11) NOT NULL,
  `weight` decimal(10,0) DEFAULT NULL,
  `coal` int(11) DEFAULT NULL,
  `order` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.positions: ~0 rows (приблизительно)
DELETE FROM `positions`;

-- Дамп структуры для таблица coaldelivery.suppliers
DROP TABLE IF EXISTS `suppliers`;
CREATE TABLE IF NOT EXISTS `suppliers` (
  `ID` int(11) NOT NULL,
  `Name` text COLLATE utf8mb4_unicode_ci,
  `ByKilometr` double DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.suppliers: ~4 rows (приблизительно)
DELETE FROM `suppliers`;
INSERT INTO `suppliers` (`ID`, `Name`, `ByKilometr`) VALUES
	(0, 'Аршановский разрез', 1.2),
	(1, 'Кирбинский разрез', 1.2),
	(2, 'Черногорский разрез', 1.2),
	(3, 'Изыхский разрез', 1.2);

-- Дамп структуры для таблица coaldelivery.users
DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL,
  `token` text COLLATE utf8mb4_unicode_ci,
  `surname` text COLLATE utf8mb4_unicode_ci,
  `firstName` text COLLATE utf8mb4_unicode_ci,
  `patronomic` text COLLATE utf8mb4_unicode_ci,
  `email` text COLLATE utf8mb4_unicode_ci,
  `login` text COLLATE utf8mb4_unicode_ci,
  `password` text COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.users: ~1 rows (приблизительно)
DELETE FROM `users`;
	(0, 'z6QD75fouCHTJLK41oCN3SBs3', 'Ремнев', 'Павел', 'Павлович', 'me@xenix19.ru', 'xenix19', '321670AB76C1F935855739AF7092913C');

-- Дамп структуры для таблица coaldelivery.verifications
DROP TABLE IF EXISTS `verifications`;
CREATE TABLE IF NOT EXISTS `verifications` (
  `ID` int(11) NOT NULL,
  `email` text COLLATE utf8mb4_unicode_ci,
  `code` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Дамп данных таблицы coaldelivery.verifications: ~1 rows (приблизительно)
DELETE FROM `verifications`;
INSERT INTO `verifications` (`ID`, `email`, `code`) VALUES
	(0, 'me@xenix.ru', 829427);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
