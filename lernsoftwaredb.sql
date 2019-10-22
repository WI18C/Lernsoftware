-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 15, 2019 at 07:19 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lernsoftwaredb`
--

-- --------------------------------------------------------

--
-- Table structure for table `cardbox`
--

CREATE TABLE `cardbox` (
  `cardbox_ID` int(11) NOT NULL,
  `cardbox_name` varchar(30) NOT NULL,
  `user_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cardbox`
--

INSERT INTO `cardbox` (`cardbox_ID`, `cardbox_name`, `user_ID`) VALUES
(1, 'Algebra', 1),
(2, 'Logik und Algebra', 2),
(3, 'Spanisch', 1),
(4, 'Latein', 1),
(5, 'YU-GI-OH', 3);

-- --------------------------------------------------------

--
-- Table structure for table `filecard`
--

CREATE TABLE `filecard` (
  `fc_ID` int(11) NOT NULL,
  `register_ID` int(11) NOT NULL,
  `fc_question` varchar(200) NOT NULL,
  `fc_answer` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `filecard`
--

INSERT INTO `filecard` (`fc_ID`, `register_ID`, `fc_question`, `fc_answer`) VALUES
(1, 1, 'Wie heißen die Konjunktionen? ODER und...?', 'UND'),
(2, 4, 'Wie heißt der berühmte Spruch im Casino beim Roulette?', 'Rien ne va plus (nichts geht mehr)!'),
(3, 1, 'Was ist 7 x 7?', 'Feiner Sand!'),
(4, 1, 'Wie hieß Will Brandt mit Nachnamen?', 'Brandt');

-- --------------------------------------------------------

--
-- Table structure for table `register`
--

CREATE TABLE `register` (
  `register_ID` int(11) NOT NULL,
  `cardbox_ID` int(11) NOT NULL,
  `register_Name` text NOT NULL,
  `register_counter` int(11) NOT NULL,
  `register_rightcounter` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `register`
--

INSERT INTO `register` (`register_ID`, `cardbox_ID`, `register_Name`, `register_counter`, `register_rightcounter`) VALUES
(1, 1, 'Testregister', 0, 0),
(2, 1, '', 0, 0),
(3, 1, '', 0, 0),
(4, 1, '', 0, 0),
(5, 2, '', 0, 0),
(6, 2, '', 0, 0),
(7, 3, '', 0, 0),
(8, 4, '', 0, 0),
(9, 2, 'Exampleregister', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `statistic`
--

CREATE TABLE `statistic` (
  `stat_ID` int(11) NOT NULL,
  `user_ID` int(11) NOT NULL,
  `stat_right` int(11) NOT NULL,
  `stat_wrong` int(11) NOT NULL,
  `stat_time` int(11) NOT NULL,
  `stat_round` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `statistic`
--

INSERT INTO `statistic` (`stat_ID`, `user_ID`, `stat_right`, `stat_wrong`, `stat_time`, `stat_round`) VALUES
(1, 1, 0, 0, 0, 0),
(2, 2, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `user_ID` int(11) NOT NULL,
  `user_name` varchar(20) NOT NULL,
  `user_password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_ID`, `user_name`, `user_password`) VALUES
(1, 'Albert', '1234'),
(2, 'Bertram', '5678'),
(3, 'Cäsar', '9999'),
(4, 'Dolf', '0000'),
(5, 'Elfride', '1234');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cardbox`
--
ALTER TABLE `cardbox`
  ADD PRIMARY KEY (`cardbox_ID`);

--
-- Indexes for table `filecard`
--
ALTER TABLE `filecard`
  ADD PRIMARY KEY (`fc_ID`);

--
-- Indexes for table `register`
--
ALTER TABLE `register`
  ADD PRIMARY KEY (`register_ID`);

--
-- Indexes for table `statistic`
--
ALTER TABLE `statistic`
  ADD PRIMARY KEY (`stat_ID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cardbox`
--
ALTER TABLE `cardbox`
  MODIFY `cardbox_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `filecard`
--
ALTER TABLE `filecard`
  MODIFY `fc_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `register`
--
ALTER TABLE `register`
  MODIFY `register_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `statistic`
--
ALTER TABLE `statistic`
  MODIFY `stat_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `user_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
