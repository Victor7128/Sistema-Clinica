CREATE DATABASE Clinica

USE Clinica

-- Tabla MENU
CREATE TABLE MENU (
    IdMenu INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    NombreFormulario NVARCHAR(50) 
);

-- Tabla ROL
CREATE TABLE ROL (
    IdRol INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Activo BIT
);

-- Tabla PERMISO
CREATE TABLE PERMISO (
    IdPermiso INT PRIMARY KEY,
    IdRol INT REFERENCES ROL(IdRol),
    IdMenu INT REFERENCES MENU(IdMenu),
    Activo BIT
);

-- Tabla USUARIOS (Incluyendo Médicos)
CREATE TABLE USUARIOS (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombres NVARCHAR(50),
    Usuario NVARCHAR(50),
    Clave NVARCHAR(50),
    IdRol INT REFERENCES ROL(IdRol),
    Activo BIT
);

-- Tabla Pacientes
CREATE TABLE Pacientes (
    IdPaciente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    DNI NVARCHAR(20) NOT NULL
);

-- Tabla Estadias
CREATE TABLE Estadias (
    IdEstadia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Habitaciones
CREATE TABLE Habitaciones (
    IdHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Camillas
CREATE TABLE Camillas (
    IdCamilla INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla Hospitalizaciones
CREATE TABLE Hospitalizaciones (
    IdHospitalizacion INT IDENTITY(1,1) PRIMARY KEY,
    IdPaciente INT NOT NULL,
    IdEstadia INT NOT NULL,
    IdHabitacion INT NOT NULL,
    IdCamilla INT NOT NULL,
    IdMedico INT NOT NULL,
    FechaIngreso DATETIME NOT NULL,
    FechaSalida DATETIME NULL,
    FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente),
    FOREIGN KEY (IdEstadia) REFERENCES Estadias(IdEstadia),
    FOREIGN KEY (IdHabitacion) REFERENCES Habitaciones(IdHabitacion),
    FOREIGN KEY (IdCamilla) REFERENCES Camillas(IdCamilla),
    FOREIGN KEY (IdMedico) REFERENCES Usuarios(IdUsuario)
);

SELECT u.IdUsuario, u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
FROM USUARIOS u
inner JOIN ROL r ON u.IdRol = r.IdRol
ORDER BY u.IdUsuario
