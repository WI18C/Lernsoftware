-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 24. Okt 2019 um 18:59
-- Server-Version: 10.4.8-MariaDB
-- PHP-Version: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `lernsoftwaredb`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `cardbox`
--

CREATE TABLE `cardbox` (
  `cardbox_ID` int(11) NOT NULL,
  `cardbox_name` varchar(30) NOT NULL,
  `user_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `cardbox`
--

INSERT INTO `cardbox` (`cardbox_ID`, `cardbox_name`, `user_ID`) VALUES
(1, 'Algebra', 1),
(2, 'Logik und Algebra', 2),
(3, 'Spanisch', 1),
(4, 'Latein', 1),
(5, 'YU-GI-OH', 3),
(6, 'Fabianmieft', 1),
(8, 'Schalke', 1),
(9, 'Schalke', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `filecard`
--

CREATE TABLE `filecard` (
  `fc_ID` int(11) NOT NULL,
  `register_ID` int(11) NOT NULL,
  `fc_question` varchar(200) NOT NULL,
  `fc_answer` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `filecard`
--

INSERT INTO `filecard` (`fc_ID`, `register_ID`, `fc_question`, `fc_answer`) VALUES
(1, 1, 'Wie heißen die Konjunktionen? ODER und...?', 'UND'),
(2, 4, 'Wie heißt der berühmte Spruch im Casino beim Roulette?', 'Rien ne va plus (nichts geht mehr)!'),
(3, 1, 'Was ist 7 x 7?', 'Feiner Sand!'),
(4, 1, 'Wie hieß Will Brandt mit Nachnamen?', 'Brandt');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `register`
--

CREATE TABLE `register` (
  `register_ID` int(11) NOT NULL,
  `cardbox_ID` int(11) NOT NULL,
  `register_Name` text NOT NULL,
  `register_counter` int(11) NOT NULL,
  `register_rightcounter` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `register`
--

INSERT INTO `register` (`register_ID`, `cardbox_ID`, `register_Name`, `register_counter`, `register_rightcounter`) VALUES
(1, 1, 'Testregister', 0, 0),
(2, 1, '', 0, 0),
(3, 1, '', 0, 0),
(4, 1, '', 0, 0),
(5, 2, '', 0, 0),
(6, 2, '', 0, 0),
(7, 3, '', 0, 0),
(8, 6, '', 0, 0),
(9, 2, 'Exampleregister', 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `statistic`
--

CREATE TABLE `statistic` (
  `stat_ID` int(11) NOT NULL,
  `user_ID` int(11) NOT NULL,
  `stat_average` int(11) NOT NULL,
  `stat_time` char(20) NOT NULL,
  `stat_cardboxname` char(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `statistic`
--

INSERT INTO `statistic` (`stat_ID`, `user_ID`, `stat_average`, `stat_time`, `stat_cardboxname`) VALUES
(1, 1, 2, 'jjj', 'Englisch'),
(26, 1, 2, '24.10.2019 18:28:17', 'Fabianmieft');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `user`
--

CREATE TABLE `user` (
  `user_ID` int(11) NOT NULL,
  `user_name` varchar(20) NOT NULL,
  `user_password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `user`
--

INSERT INTO `user` (`user_ID`, `user_name`, `user_password`) VALUES
(1, 'Albert', '123'),
(2, 'Bertram', '5678'),
(3, 'Cäsar', '9999'),
(4, 'Dolf', '0000'),
(5, 'Elfride', '1234'),
(6, 'Heinz', '12343');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `cardbox`
--
ALTER TABLE `cardbox`
  ADD PRIMARY KEY (`cardbox_ID`);

--
-- Indizes für die Tabelle `filecard`
--
ALTER TABLE `filecard`
  ADD PRIMARY KEY (`fc_ID`);

--
-- Indizes für die Tabelle `register`
--
ALTER TABLE `register`
  ADD PRIMARY KEY (`register_ID`);

--
-- Indizes für die Tabelle `statistic`
--
ALTER TABLE `statistic`
  ADD PRIMARY KEY (`stat_ID`);

--
-- Indizes für die Tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`user_ID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `cardbox`
--
ALTER TABLE `cardbox`
  MODIFY `cardbox_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT für Tabelle `filecard`
--
ALTER TABLE `filecard`
  MODIFY `fc_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT für Tabelle `register`
--
ALTER TABLE `register`
  MODIFY `register_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT für Tabelle `statistic`
--
ALTER TABLE `statistic`
  MODIFY `stat_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT für Tabelle `user`
--
ALTER TABLE `user`
  MODIFY `user_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
