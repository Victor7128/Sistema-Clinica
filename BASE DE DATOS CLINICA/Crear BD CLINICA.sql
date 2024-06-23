CREATE DATABASE Clinica

USE Clinica

-- Tabla MENU
CREATE TABLE MENU (
    IdMenu INT PRIMARY KEY,
    Nombre VARCHAR(50),
    NombreFormulario VARCHAR(50) 
);

-- Tabla ROL
CREATE TABLE ROL (
    IdRol INT PRIMARY KEY,
    Nombre VARCHAR(50),
	Activo BIT
);

-- Tabla PERMISO
CREATE TABLE PERMISO (
    IdPermiso INT PRIMARY KEY,
    IdRol INT REFERENCES ROL(IdRol),
    IdMenu INT REFERENCES MENU(IdMenu),
    Activo BIT
);

CREATE TABLE ESPECIALIDAD (
    IdEspecialidad INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla USUARIOS
CREATE TABLE USUARIOS (
    IdUsuario INT PRIMARY KEY,
    Nombres VARCHAR(50),
    Usuario VARCHAR(50),
    Clave VARCHAR(50),
    IdRol INT REFERENCES ROL(IdRol)
);

--SELECT u.IdUsuario, u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
--FROM USUARIOS u
--inner JOIN ROL r ON u.IdRol = r.IdRol
--ORDER BY u.IdUsuario