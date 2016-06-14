-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Czas generowania: 02 Gru 2014, 12:02
-- Wersja serwera: 5.6.20
-- Wersja PHP: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Baza danych: `biblioteka`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kategoria`
--

CREATE TABLE IF NOT EXISTS `kategoria` (
`IDkategorii` int(5) NOT NULL,
  `Kategoria` varchar(20) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=12 ;

--
-- Zrzut danych tabeli `kategoria`
--

INSERT INTO `kategoria` (`IDkategorii`, `Kategoria`) VALUES
(1, 'Powiesc'),
(2, 'Klasyka polska'),
(3, 'Klasyka zagraniczna'),
(4, 'Kryminal'),
(5, 'Sensacja'),
(6, 'Dla dzieci'),
(7, 'Poradnik'),
(8, 'Romans'),
(9, 'Biznes'),
(10, 'Biografia'),
(11, 'Historia');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klasa`
--

CREATE TABLE IF NOT EXISTS `klasa` (
`IDklasy` int(4) NOT NULL,
  `Klasa` varchar(4) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=25 ;

--
-- Zrzut danych tabeli `klasa`
--

INSERT INTO `klasa` (`IDklasy`, `Klasa`) VALUES
(1, '1A'),
(2, '1B'),
(3, '1C'),
(4, '1D'),
(5, '1E'),
(6, '1F'),
(7, '2A'),
(8, '2B'),
(9, '2C'),
(10, '2D'),
(11, '2E'),
(12, '2F'),
(13, '3A'),
(14, '3B'),
(15, '3C'),
(16, '3D'),
(17, '3E'),
(18, '3F'),
(19, '4A'),
(20, '4B'),
(21, '4C'),
(22, '4D'),
(23, '4E'),
(24, '4F');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `ksiazki`
--

CREATE TABLE IF NOT EXISTS `ksiazki` (
`IDksiazki` int(5) NOT NULL,
  `Tytul` varchar(50) NOT NULL,
  `Autor` varchar(25) NOT NULL,
  `Wydawnictwo` varchar(25) NOT NULL,
  `Rok_wydania` varchar(5) NOT NULL,
  `Miejsce_wydania` varchar(20) NOT NULL,
  `Kategoria` varchar(5) NOT NULL,
  `Ilosc` varchar(5) NOT NULL,
  `Dostepnych` varchar(5) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Zrzut danych tabeli `ksiazki`
--

INSERT INTO `ksiazki` (`IDksiazki`, `Tytul`, `Autor`, `Wydawnictwo`, `Rok_wydania`, `Miejsce_wydania`, `Kategoria`, `Ilosc`, `Dostepnych`) VALUES
(1, 'Krzyzacy', 'Sienkiewicz Henryk', 'OPERON', '111', 'WARSZAWA', '2', '50', '49'),
(2, 'Lalka', 'Prus Boleslaw', 'PWN', '115', 'KRAKÓW', '2', '28', '27'),
(5, 'Autobiografia Piotra Dziekonskiego', 'Piotr Dziekonski', 'DZIEKON SA', '115', 'WROCLAW', '10', '10', '10');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rokwydania`
--

CREATE TABLE IF NOT EXISTS `rokwydania` (
`IDroku` int(10) NOT NULL,
  `RokWydania` varchar(10) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=116 ;

--
-- Zrzut danych tabeli `rokwydania`
--

INSERT INTO `rokwydania` (`IDroku`, `RokWydania`) VALUES
(1, '1900'),
(2, '1901'),
(3, '1902'),
(4, '1903'),
(5, '1904'),
(6, '1905'),
(7, '1906'),
(8, '1907'),
(9, '1908'),
(10, '1909'),
(11, '1910'),
(12, '1911'),
(13, '1912'),
(14, '1913'),
(15, '1914'),
(16, '1915'),
(17, '1916'),
(18, '1917'),
(19, '1918'),
(20, '1919'),
(21, '1920'),
(22, '1921'),
(23, '1922'),
(24, '1923'),
(25, '1924'),
(26, '1925'),
(27, '1926'),
(28, '1927'),
(29, '1928'),
(30, '1929'),
(31, '1930'),
(32, '1931'),
(33, '1932'),
(34, '1933'),
(35, '1934'),
(36, '1935'),
(37, '1936'),
(38, '1937'),
(39, '1938'),
(40, '1939'),
(41, '1940'),
(42, '1941'),
(43, '1942'),
(44, '1943'),
(45, '1944'),
(46, '1945'),
(47, '1946'),
(48, '1947'),
(49, '1948'),
(50, '1949'),
(51, '1950'),
(52, '1951'),
(53, '1952'),
(54, '1953'),
(55, '1954'),
(56, '1955'),
(57, '1956'),
(58, '1957'),
(59, '1958'),
(60, '1959'),
(61, '1960'),
(62, '1961'),
(63, '1962'),
(64, '1963'),
(65, '1964'),
(66, '1965'),
(67, '1966'),
(68, '1967'),
(69, '1968'),
(70, '1969'),
(71, '1970'),
(72, '1971'),
(73, '1972'),
(74, '1973'),
(75, '1974'),
(76, '1975'),
(77, '1976'),
(78, '1977'),
(79, '1978'),
(80, '1979'),
(81, '1980'),
(82, '1981'),
(83, '1982'),
(84, '1983'),
(85, '1984'),
(86, '1985'),
(87, '1986'),
(88, '1987'),
(89, '1988'),
(90, '1989'),
(91, '1990'),
(92, '1991'),
(93, '1992'),
(94, '1993'),
(95, '1994'),
(96, '1995'),
(97, '1996'),
(98, '1997'),
(99, '1998'),
(100, '1999'),
(101, '2000'),
(102, '2001'),
(103, '2002'),
(104, '2003'),
(105, '2004'),
(106, '2005'),
(107, '2006'),
(108, '2007'),
(109, '2008'),
(110, '2009'),
(111, '2010'),
(112, '2011'),
(113, '2012'),
(114, '2013'),
(115, '2014');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `uczniowie`
--

CREATE TABLE IF NOT EXISTS `uczniowie` (
`IDucznia` int(5) NOT NULL,
  `Imie` varchar(25) NOT NULL,
  `Nazwisko` varchar(25) NOT NULL,
  `Klasa` varchar(5) NOT NULL,
  `Telefon` varchar(12) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Zrzut danych tabeli `uczniowie`
--

INSERT INTO `uczniowie` (`IDucznia`, `Imie`, `Nazwisko`, `Klasa`, `Telefon`) VALUES
(1, 'Piotr', 'Dziekonski', '18', '646666646'),
(2, 'Radoslaw', 'Jachymiak', '11', '7373737373'),
(3, 'Daniel', 'Bakowski', '18', '666666666'),
(5, 'Jan', 'Kowalski', '5', '666666666');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wypozyczenia`
--

CREATE TABLE IF NOT EXISTS `wypozyczenia` (
`IDwypozyczenia` int(5) NOT NULL,
  `Uczen` varchar(30) NOT NULL,
  `Ksiazka` varchar(30) NOT NULL,
  `DataWypozyczenia` varchar(20) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=43 ;

--
-- Zrzut danych tabeli `wypozyczenia`
--

INSERT INTO `wypozyczenia` (`IDwypozyczenia`, `Uczen`, `Ksiazka`, `DataWypozyczenia`) VALUES
(41, '1', '1', '2014-11-24'),
(42, '1', '2', '2014-11-24');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `kategoria`
--
ALTER TABLE `kategoria`
 ADD PRIMARY KEY (`IDkategorii`);

--
-- Indexes for table `klasa`
--
ALTER TABLE `klasa`
 ADD PRIMARY KEY (`IDklasy`);

--
-- Indexes for table `ksiazki`
--
ALTER TABLE `ksiazki`
 ADD PRIMARY KEY (`IDksiazki`);

--
-- Indexes for table `rokwydania`
--
ALTER TABLE `rokwydania`
 ADD PRIMARY KEY (`IDroku`);

--
-- Indexes for table `uczniowie`
--
ALTER TABLE `uczniowie`
 ADD PRIMARY KEY (`IDucznia`);

--
-- Indexes for table `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
 ADD PRIMARY KEY (`IDwypozyczenia`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `kategoria`
--
ALTER TABLE `kategoria`
MODIFY `IDkategorii` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT dla tabeli `klasa`
--
ALTER TABLE `klasa`
MODIFY `IDklasy` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=25;
--
-- AUTO_INCREMENT dla tabeli `ksiazki`
--
ALTER TABLE `ksiazki`
MODIFY `IDksiazki` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT dla tabeli `rokwydania`
--
ALTER TABLE `rokwydania`
MODIFY `IDroku` int(10) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=116;
--
-- AUTO_INCREMENT dla tabeli `uczniowie`
--
ALTER TABLE `uczniowie`
MODIFY `IDucznia` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT dla tabeli `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
MODIFY `IDwypozyczenia` int(5) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=43;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
