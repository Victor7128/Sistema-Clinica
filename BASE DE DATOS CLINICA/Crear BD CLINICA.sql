CREATE DATABASE Clinica
GO

USE Clinica
GO

-- Tabla MENU
CREATE TABLE MENU (
    IdMenu INT PRIMARY KEY,
    Nombre VARCHAR(50),
    NombreFormulario NVARCHAR(50) 
);
go

-- Tabla ROL
CREATE TABLE ROL (
    IdRol INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Activo BIT
);
go

-- Tabla PERMISO
CREATE TABLE PERMISO (
    IdPermiso INT PRIMARY KEY,
    IdRol INT REFERENCES ROL(IdRol),
    IdMenu INT REFERENCES MENU(IdMenu),
    Activo BIT
);
go

-- Tabla USUARIOS
CREATE TABLE USUARIOS (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombres VARCHAR(50),
    Usuario VARCHAR(50),
    Clave VARCHAR(50),
    IdRol INT REFERENCES ROL(IdRol),
    Activo BIT
);
go

-- Tabla Genero
CREATE TABLE Genero (
	IdGenero INT IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(10)
)
GO

-- Tabla Estadias
CREATE TABLE Estadias (
    IdEstadia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
go

-- Tabla TipoHabitacion
CREATE TABLE TipoHabitacion (
    IdTipoHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Ocupado BIT 
);
GO

-- Tabla Camillas
CREATE TABLE Camillas (
    IdCamilla INT IDENTITY(1,1) PRIMARY KEY,
    Nombre INT,
    Ocupado BIT
);
GO

-- Tabla Habitaciones
CREATE TABLE Habitaciones (
    IdHabitacion INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Ocupado BIT,
    IdTipoHabitacion INT REFERENCES TipoHabitacion(IdTipoHabitacion),
    IdCamilla INT REFERENCES Camillas(IdCamilla)
);
GO

-- Tabla SalaCirugia
CREATE TABLE SalaCirugia (
    IdSala INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Ocupado BIT 
);
GO

-- Tabla Pacientes
CREATE TABLE Pacientes (
    IdPaciente INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(5),
    Nombre VARCHAR(100),
    DNI INT UNIQUE,
    FechaNacimiento DATE,
    Telefono INT,
    Direccion VARCHAR(100),
    IdGenero INT REFERENCES Genero(IdGenero),
    IdUsuario INT NULL
);
GO

-- Tabla relacion Habitacion-camilla
CREATE TABLE HabitacionCamilla (
    IdHabitacion INT,
    IdCamilla INT,
    PRIMARY KEY (IdHabitacion, IdCamilla),
    FOREIGN KEY (IdHabitacion) REFERENCES Habitaciones(IdHabitacion),
    FOREIGN KEY (IdCamilla) REFERENCES Camillas(IdCamilla)
);
GO

-- Tabla Cirugias
CREATE TABLE Cirugias (
    IdCirugia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    IdSala INT REFERENCES SalaCirugia(IdSala) NOT NULL,
    IdPaciente INT REFERENCES Pacientes(IdPaciente) NOT NULL,
    HoraCirugia TIME NOT NULL,
    FechaCirugia DATE NOT NULL,
    HoraEntrada TIME NULL,
    HoraSalida TIME NULL
);
GO

-- Tabla Hospitalizaciones
CREATE TABLE Hospitalizaciones (
    IdHospitalizacion INT IDENTITY(1,1) PRIMARY KEY,
    IdPaciente INT REFERENCES Pacientes(IdPaciente) NOT NULL,
    IdEstadia INT REFERENCES Estadias(IdEstadia) NOT NULL,
    IdHabitacion INT REFERENCES Habitaciones(IdHabitacion) NOT NULL,
    IdUsuario INT REFERENCES USUARIOS(IdUsuario) NULL,
    IdCirugia INT REFERENCES Cirugias(IdCirugia) NULL,
    FechaIngreso DATE NOT NULL,
    HoraIngreso TIME NOT NULL,
    FechaSalida DATE NULL,
    HoraSalida TIME NULL
);
GO

-- Tabla HistorialSalidaPacientes
CREATE TABLE HistorialSalidaPacientes (
    IdHistorialSalida INT IDENTITY(1,1) PRIMARY KEY,
    IdPaciente INT REFERENCES Pacientes(IdPaciente),
    IdHospitalizacion INT REFERENCES Hospitalizaciones(IdHospitalizacion),
    FechaSalida DATE NOT NULL,
    HoraSalida TIME NOT NULL,
    MotivoSalida VARCHAR(255),
    IdUsuario INT REFERENCES USUARIOS(IdUsuario) NULL
);
GO