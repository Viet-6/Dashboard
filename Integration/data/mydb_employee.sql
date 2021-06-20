-- MySQL dump 10.13  Distrib 8.0.25, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `idEmployee` int NOT NULL,
  `Employee Number` int unsigned NOT NULL,
  `Last Name` varchar(45) NOT NULL,
  `First Name` varchar(45) NOT NULL,
  `SSN` decimal(10,0) NOT NULL,
  `Pay Rate` varchar(40) DEFAULT NULL,
  `Pay Rates_idPay Rates` int NOT NULL,
  `Vacation Days` int DEFAULT NULL,
  `Paid To Date` decimal(2,0) DEFAULT NULL,
  `Paid Last Year` decimal(2,0) DEFAULT NULL,
  PRIMARY KEY (`Employee Number`,`Pay Rates_idPay Rates`),
  UNIQUE KEY `Employee Number_UNIQUE` (`Employee Number`),
  KEY `fk_Employee_Pay Rates` (`Pay Rates_idPay Rates`),
  CONSTRAINT `fk_Employee_Pay Rates` FOREIGN KEY (`Pay Rates_idPay Rates`) REFERENCES `pay rates` (`idPay Rates`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,111,'Chau','Pham Thi',379961234,'100',10000123,5,20,85),(2,112,'Viet','Le Hoang Quoc',564602433,'100',10000346,40,10,65),(3,113,'Han','Pham Thi',391174354,'50',10004530,10,45,80),(4,114,'Viet','Huynh Van',593032352,'80',10000211,23,20,75),(6,116,'Khan','Nguyen Tan',223331234,'100',10002134,57,56,65),(7,117,'Thai','Doan',183334562,'100',10000045,55,45,79),(8,118,'Anh','Thai Ba',493424367,'100',10000435,30,77,85),(9,119,'My','Le Huyen',287172346,'100',10002034,14,45,50),(10,120,'Long','Mai Ba',488416753,'100',10000094,35,80,85),(11,121,'Minh','Nguyen Huu',510787864,'90',10000523,29,90,95),(12,122,'Danh','Huynh Nien',290596543,'100',10000349,12,75,98),(13,123,'Kin','Le Thi',552518674,'50',10000035,23,43,65),(14,124,'Vy','Nguyen Ngoc',648533457,'100',10000411,45,60,75),(15,125,'Rin','Huynh Van',431292346,'80',10000200,43,23,45),(16,126,'Thoai','Van Sy',472368764,'100',10000350,13,45,55),(17,127,'Loc','Doan Thi',398495673,'100',10004434,34,65,70),(18,128,'Linh','Nguyen ',379837564,'100',10003340,6,50,76),(19,129,'Long','Pham Huu',301954563,'90',10000098,10,80,90),(20,130,'Ha','Pham Thi',485426758,'100',10000379,18,65,80),(21,131,'Hai','Cao Thai',329572341,'100',10000235,6,75,80);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-20 23:34:40
