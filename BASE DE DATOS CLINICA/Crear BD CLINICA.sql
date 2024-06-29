CREATE DATABASE Clinica

USE Clinica

-- Tabla MENU
CREATE TABLE MENU (
    IdMenu INT PRIMARY KEY,
    Nombre VARCHAR(50),
    NombreFormulario NVARCHAR(50) 
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

-- Tabla USUARIOS
CREATE TABLE USUARIOS (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(50),
    Usuario VARCHAR(50),
    Clave VARCHAR(50),
    IdRol INT REFERENCES ROL(IdRol),
    Activo BIT
);

-- Tabla Genero
CREATE TABLE Genero (
	IdGenero INT IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(10)
)
GO

CREATE TABLE Pacientes(
    IdPaciente INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(5),
    Nombre VARCHAR(100),
    DNI INT UNIQUE,
    FechaNacimiento DATE,
    Telefono INT,
    Direccion VARCHAR(100),
    IdGenero INT,
    FOREIGN KEY (IdGenero) REFERENCES Genero(IdGenero),
	MedicoResponsable NVARCHAR(100) NULL
);

-- Tabla Estadias
CREATE TABLE Estadias (
    IdEstadia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);

-- Tabla Habitaciones
CREATE TABLE Habitaciones (
    IdHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

-- Tabla TipoHabitaciones
CREATE TABLE TipoHabitacion (
    IdTipoHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

-- Tabla Camillas
CREATE TABLE Camillas (
    IdCamilla INT IDENTITY(1,1) PRIMARY KEY,
    Nombre INT NOT NULL
);

-- Tabla Hospitalizaciones
CREATE TABLE Hospitalizaciones (
    IdHospitalizacion INT IDENTITY(1,1) PRIMARY KEY,
    IdPaciente INT NOT NULL,
    IdEstadia INT NOT NULL,
    IdHabitacion INT NOT NULL,
    IdCamilla INT NOT NULL,
    IdUsuario INT NULL,	
    IdTipoHabitacion INT NOT NULL,
    FechaIngreso DATE NOT NULL,
    HoraIngreso TIME NOT NULL,
    FechaSalida DATE NULL,
    HoraSalida TIME NULL,
    FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente),
    FOREIGN KEY (IdEstadia) REFERENCES Estadias(IdEstadia),
    FOREIGN KEY (IdHabitacion) REFERENCES Habitaciones(IdHabitacion),
    FOREIGN KEY (IdCamilla) REFERENCES Camillas(IdCamilla),
    FOREIGN KEY (IdUsuario) REFERENCES USUARIOS(IdUsuario),
    FOREIGN KEY (IdTipoHabitacion) REFERENCES TipoHabitacion(IdTipoHabitacion)
);

-- Tabla Cirugias
CREATE TABLE Cirugias (
    IdCirugia INT IDENTITY(1,1) PRIMARY KEY,
    TipoCirugia VARCHAR(100) NOT NULL,
    IdPaciente INT NOT NULL,
    NombrePaciente VARCHAR(100) NOT NULL,
    Sala VARCHAR(50) NOT NULL,
    Turno VARCHAR(20) NOT NULL,
    FechaCirugia DATETIME NOT NULL,
    CONSTRAINT FK_Cirugias_Pacientes FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente)
);

