CREATE DATABASE IF NOT EXISTS `win_form_sample` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `win_form_sample`;

SET NAMES utf8 ;

--
-- Table structure for table `enemy`
--
CREATE TABLE IF NOT EXISTS `enemy` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `hp` int(11) NOT NULL,
  `boss_flag` bit(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
