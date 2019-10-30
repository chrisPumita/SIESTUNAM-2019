-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 24-09-2019 a las 03:02:40
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `siestunam`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `auto`
--

CREATE TABLE `auto` (
  `idAuto` tinyint(3) NOT NULL COMMENT 'Identificador unico del auto',
  `marca` varchar(20) NOT NULL COMMENT 'Marca del automovil',
  `modelo` varchar(20) NOT NULL COMMENT 'Modelo del automovil',
  `placa` varchar(10) NOT NULL COMMENT 'Placa del vehiculo',
  `color` varchar(10) NOT NULL COMMENT 'Color del vehiculo',
  `tipoV` tinyint(2) NOT NULL COMMENT '1-moto; 2-auto; 3-camioneta; 4-camion; 5-otro',
  `idUser` tinyint(3) NOT NULL COMMENT 'FK que apunta al id del usuario'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `idEmp` tinyint(3) NOT NULL COMMENT 'Identificador unico de empleado',
  `noCuenta` int(15) NOT NULL COMMENT 'No de cuenta de empleado',
  `nomEmp` varchar(30) NOT NULL COMMENT 'Nombre de empleado',
  `apP` varchar(30) NOT NULL COMMENT 'Apellido paterno de empleado',
  `apM` varchar(30) NOT NULL COMMENT 'Apellido materno de empleado',
  `tel` varchar(30) NOT NULL COMMENT 'Numero de telefono de empleado',
  `email` varchar(50) NOT NULL COMMENT 'Email de empleado',
  `sex` tinyint(2) NOT NULL COMMENT '0-Hombre; 1-Mujer',
  `tipoCta` tinyint(2) NOT NULL COMMENT '0-SuperUser; 1-admin; 2-empleado',
  `status` tinyint(2) NOT NULL COMMENT '1-activo; 2-inactivo',
  `psw` varchar(100) NOT NULL COMMENT 'contraseña encriptada'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pase_v`
--

CREATE TABLE `pase_v` (
  `idPase` tinyint(3) NOT NULL COMMENT 'Identificador unico de pase',
  `idAuto` tinyint(3) NOT NULL COMMENT 'Identificador unico de auto',
  `idEmp` tinyint(3) NOT NULL COMMENT 'Identificador unico de empleado',
  `idReporte` tinyint(3) DEFAULT NULL COMMENT 'Identificador de reporte',
  `horaE` datetime NOT NULL COMMENT 'Hora de registro de entrada de pase',
  `horaS` datetime DEFAULT NULL COMMENT 'Hora de registro de salida de pase',
  `status` tinyint(2) NOT NULL COMMENT '0-activo; 0-inactivo'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reporte_pase`
--

CREATE TABLE `reporte_pase` (
  `idReporte` tinyint(3) NOT NULL COMMENT 'identificador de cada reporte que se genere',
  `fechaRepo` datetime NOT NULL COMMENT 'Fecha y Hora en la que se genera el reporte',
  `descRepo` text NOT NULL COMMENT 'Descripcion detallada del reporte generado del pase con insidencia.',
  `visible` tinyint(2) NOT NULL COMMENT '1- Visible; 2- Oculto, es oculto es la aliminacion de reporte a nivel usuario',
  `idPase` tinyint(3) NOT NULL COMMENT 'FK que apunta al ID del pase que se infracciona'
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Los reportes se generaran cuando se detecte una incidencia';

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sesion`
--

CREATE TABLE `sesion` (
  `idSesion` tinyint(3) NOT NULL COMMENT 'Identificador del numero de sesion creada',
  `status` tinyint(2) NOT NULL DEFAULT '1' COMMENT '1-activo; 0-inactivo',
  `fInicio` datetime NOT NULL COMMENT 'Hora y fecha de inicio la sesion',
  `fFin` datetime DEFAULT NULL COMMENT 'Hora y fecha de cierre de sesion',
  `uniqueSesion` tinyint(2) NOT NULL COMMENT 'Permite que se conecte e inicie sesion en solo un equipo',
  `ipEquipo` varchar(20) DEFAULT NULL COMMENT 'Identificador del equipo',
  `idEmp` tinyint(3) NOT NULL COMMENT 'FK que apunta al id del empleado'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `idUser` tinyint(3) NOT NULL COMMENT 'Identificador unico de usuario',
  `noCta` int(15) NOT NULL COMMENT 'Numero de cuenta del usuario',
  `nomUser` varchar(30) NOT NULL COMMENT 'Nombre del usuario',
  `apP` varchar(30) NOT NULL COMMENT 'Apellido paterno del usuario',
  `apM` varchar(30) NOT NULL COMMENT 'Apellido materno del usuario',
  `tel` varchar(30) NOT NULL COMMENT 'Telefono del usuario',
  `email` varchar(50) NOT NULL COMMENT 'Correo electronico del usuario',
  `sex` tinyint(2) NOT NULL COMMENT '0-Hombre; 1-Mujer',
  `tipoUser` tinyint(2) NOT NULL COMMENT '1-Estudiante; 2-Profesor; 3-Admin; 4-Trabajador; 5-Profesor; 6-Otro',
  `status` tinyint(2) NOT NULL DEFAULT '1' COMMENT '1-Activo; 0-Inactivo'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `auto`
--
ALTER TABLE `auto`
  ADD PRIMARY KEY (`idAuto`),
  ADD KEY `idUser` (`idUser`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`idEmp`);

--
-- Indices de la tabla `pase_v`
--
ALTER TABLE `pase_v`
  ADD PRIMARY KEY (`idPase`),
  ADD KEY `idAuto` (`idAuto`),
  ADD KEY `idEmp` (`idEmp`),
  ADD KEY `idReporte` (`idReporte`);

--
-- Indices de la tabla `reporte_pase`
--
ALTER TABLE `reporte_pase`
  ADD PRIMARY KEY (`idReporte`),
  ADD KEY `idPase` (`idPase`);

--
-- Indices de la tabla `sesion`
--
ALTER TABLE `sesion`
  ADD PRIMARY KEY (`idSesion`),
  ADD KEY `idEmp` (`idEmp`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idUser`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `auto`
--
ALTER TABLE `auto`
  MODIFY `idAuto` tinyint(3) NOT NULL AUTO_INCREMENT COMMENT 'Identificador unico del auto';

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `idEmp` tinyint(3) NOT NULL AUTO_INCREMENT COMMENT 'Identificador unico de empleado';

--
-- AUTO_INCREMENT de la tabla `pase_v`
--
ALTER TABLE `pase_v`
  MODIFY `idPase` tinyint(3) NOT NULL AUTO_INCREMENT COMMENT 'Identificador unico de pase';

--
-- AUTO_INCREMENT de la tabla `reporte_pase`
--
ALTER TABLE `reporte_pase`
  MODIFY `idReporte` tinyint(3) NOT NULL AUTO_INCREMENT COMMENT 'identificador de cada reporte que se genere';

--
-- AUTO_INCREMENT de la tabla `sesion`
--
ALTER TABLE `sesion`
  MODIFY `idSesion` tinyint(3) NOT NULL AUTO_INCREMENT COMMENT 'Identificador del numero de sesion creada';

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idUser` tinyint(3) NOT NULL AUTO_INCREMENT COMMENT 'Identificador unico de usuario';

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `auto`
--
ALTER TABLE `auto`
  ADD CONSTRAINT `auto_ibfk_1` FOREIGN KEY (`idUser`) REFERENCES `usuario` (`idUser`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `pase_v`
--
ALTER TABLE `pase_v`
  ADD CONSTRAINT `pase_v_ibfk_1` FOREIGN KEY (`idAuto`) REFERENCES `auto` (`idAuto`),
  ADD CONSTRAINT `pase_v_ibfk_2` FOREIGN KEY (`idEmp`) REFERENCES `empleado` (`idEmp`);

--
-- Filtros para la tabla `reporte_pase`
--
ALTER TABLE `reporte_pase`
  ADD CONSTRAINT `reporte_pase_ibfk_1` FOREIGN KEY (`idPase`) REFERENCES `pase_v` (`idReporte`);

--
-- Filtros para la tabla `sesion`
--
ALTER TABLE `sesion`
  ADD CONSTRAINT `sesion_ibfk_1` FOREIGN KEY (`idEmp`) REFERENCES `empleado` (`idEmp`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
