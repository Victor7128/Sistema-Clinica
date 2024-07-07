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
	IdGenero INT PRIMARY KEY,
	Nombre varchar(10)
)
GO

-- Tabla Estadias
CREATE TABLE Estadias (
    IdEstadia INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL
);
go

-- Crear tabla TipoHabitacion
CREATE TABLE TipoHabitacion (
    IdTipoHabitacion INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Ocupado BIT
);
GO

-- Crear tabla Habitaciones
CREATE TABLE Habitaciones (
    IdHabitacion INT PRIMARY KEY,
    IdTipoHabitacion INT,
    Nombre NVARCHAR(50),
    Ocupado BIT,
    FOREIGN KEY (IdTipoHabitacion) REFERENCES TipoHabitacion(IdTipoHabitacion)
);
GO

-- Crear tabla Camillas
CREATE TABLE Camillas (
    IdCamilla INT PRIMARY KEY,
    IdHabitacion INT,
    Nombre NVARCHAR(50),
    Ocupado BIT,
    FOREIGN KEY (IdHabitacion) REFERENCES Habitaciones(IdHabitacion)
);
GO

-- Tabla SalaCirugia
CREATE TABLE SalaCirugia (
    IdSala INT PRIMARY KEY,
    Nombre VARCHAR(50),
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
);
GO

-- Creaci�n de la tabla Cirugias sin restricciones de clave for�nea
CREATE TABLE Cirugias (
    IdCirugia INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(150) NOT NULL,
    IdUsuario INT,
    IdSala INT,
	IdPaciente INT,
    HoraCirugia VARCHAR(50) NOT NULL,
    FechaCirugia DATE NOT NULL,
    HoraEntrada TIME NULL,
    HoraSalida TIME NULL
);
GO

-- Creaci�n de la tabla Hospitalizaciones sin restricciones de clave for�nea
CREATE TABLE Hospitalizaciones (
    IdHospitalizacion INT IDENTITY(1,1) PRIMARY KEY,
    IdPaciente INT NOT NULL,
    IdEstadia INT NOT NULL,
    IdHabitacion INT NOT NULL,
	IdTipoHabitacion INT NOT NULL,
	IdCamilla INT NOT NULL,
    IdCirugia INT,
    FechaIngreso DATE NOT NULL,
    HoraIngreso TIME NOT NULL,
    FechaSalida DATE NULL,
    HoraSalida TIME NULL
);
GO

-- Creaci�n de la tabla HistorialSalidaPacientes sin restricciones de clave for�nea
CREATE TABLE HistorialSalidaPacientes (
    IdHistorial INT IDENTITY(1,1) PRIMARY KEY,
    Paciente VARCHAR(50),
	DNI INT, 
	FechaNacimiento DATE,
	Telefono INT,
	Direccion VARCHAR(200), 
	Genero VARCHAR(10),
	Habitacion VARCHAR(4),
	TipoHabitacion VARCHAR(50), 
	Camilla VARCHAR(10),
	Estadia VARCHAR(10),
	MedicoAsignado VARCHAR(50) NULL,
	Cirugia VARCHAR(100) NULL,
	FechaCirugia DATE NULL,
	HoraCirugia TIME NULL,
	CirugiaEntrada TIME NULL,
	CirugiaSalida TIME NULL,
	SalaCirugia VARCHAR(10) NULL,
	FechaEntradaHospitalizacion DATE,
	HoraEntradaHospitalizacion TIME,
	FechaSalidaHospitalizacion DATE,
	HoraSalidaHospitalizacion TIME,	
);
GO

-- Alterar tabla Cirugias para agregar restricciones de clave for�nea
ALTER TABLE Cirugias
ADD CONSTRAINT FK_Cirugias_Usuario FOREIGN KEY (IdUsuario) REFERENCES USUARIOS(IdUsuario);

ALTER TABLE Cirugias
ADD CONSTRAINT FK_Cirugias_Sala FOREIGN KEY (IdSala) REFERENCES SalaCirugia(IdSala);

ALTER TABLE Cirugias
ADD CONSTRAINT FK_Cirugias_Pacientes FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente);
GO

-- Alterar tabla Hospitalizaciones para agregar restricciones de clave for�nea
ALTER TABLE Hospitalizaciones
ADD CONSTRAINT FK_Hospitalizaciones_Paciente FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente);
GO

ALTER TABLE Hospitalizaciones
ADD CONSTRAINT FK_Hospitalizaciones_Estadia FOREIGN KEY (IdEstadia) REFERENCES Estadias(IdEstadia);
GO

ALTER TABLE Hospitalizaciones
ADD CONSTRAINT FK_Hospitalizaciones_Habitacion FOREIGN KEY (IdHabitacion) REFERENCES Habitaciones(IdHabitacion);
GO

ALTER TABLE Hospitalizaciones
ADD CONSTRAINT FK_Hospitalizaciones_TipoHabitacion FOREIGN KEY (IdTipoHabitacion) REFERENCES TipoHabitacion(IdTipoHabitacion);
GO

ALTER TABLE Hospitalizaciones
ADD CONSTRAINT FK_Hospitalizaciones_Cirugia FOREIGN KEY (IdCirugia) REFERENCES Cirugias(IdCirugia);

ALTER TABLE Hospitalizaciones
ADD CONSTRAINT FK_Hospitalizaciones_Camilla FOREIGN KEY (IdCamilla) REFERENCES Camillas(IdCamilla);
GO