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
    DNI INT NOT NULL
);

-- Tabla Estadias
CREATE TABLE Estadias (
    IdEstadia INT PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL
);

-- Tabla Habitaciones
CREATE TABLE Habitaciones (
    IdHabitacion INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Tabla TipoHabitaciones
CREATE TABLE TipoHabitacion (
    IdTipoHabitacion INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
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
    IdMedico INT NULL,
    IdTipoHabitacion INT NULL, -- Nueva columna para relacionar con TipoHabitacion
    FechaIngreso DATE NOT NULL,
    HoraIngreso TIME NOT NULL,
    FechaSalida DATE NULL,
    HoraSalida TIME NULL,
    Estado NVARCHAR(50)
    FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente),
    FOREIGN KEY (IdEstadia) REFERENCES Estadias(IdEstadia),
    FOREIGN KEY (IdHabitacion) REFERENCES Habitaciones(IdHabitacion),
    FOREIGN KEY (IdCamilla) REFERENCES Camillas(IdCamilla),
    FOREIGN KEY (IdMedico) REFERENCES USUARIOS(IdUsuario),
    FOREIGN KEY (IdTipoHabitacion) REFERENCES TipoHabitacion(IdTipoHabitacion) -- Restricción de clave externa
);


CREATE TABLE Cirugias (
    IdCirugia INT IDENTITY(1,1) PRIMARY KEY,
    TipoCirugia NVARCHAR(100) NOT NULL,
    IdPaciente INT NOT NULL,
    NombrePaciente NVARCHAR(100) NOT NULL, -- Nueva columna para el nombre del paciente
    Sala NVARCHAR(50) NOT NULL,
    Turno NVARCHAR(20) NOT NULL,
    FechaCirugia DATETIME NOT NULL,
    CONSTRAINT FK_Cirugias_Pacientes FOREIGN KEY (IdPaciente) REFERENCES Pacientes(IdPaciente)
);


SELECT u.IdUsuario, u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
FROM USUARIOS u
inner JOIN ROL r ON u.IdRol = r.IdRol
ORDER BY u.IdUsuario

select Nombres from USUARIOS where IdRol = 3



SELECT
    ho.IdHospitalizacion AS ID_Hospitalizacion,
    p.Nombre AS Nombre_Paciente,
    p.DNI AS Dni_Paciente,
    e.Nombre AS Estadia,
    c.Nombre AS Camilla,
    h.Nombre AS Habitacion,
    th.Nombre AS Tipo_Habitacion,
    ho.FechaIngreso AS FechaIngreso,
    ho.HoraIngreso AS HoraIngreso,
    ho.FechaSalida AS FechaSalida,
    ho.HoraSalida AS HoraSalida
FROM 
    Hospitalizaciones ho
INNER JOIN 
    Pacientes p ON ho.IdPaciente = p.IdPaciente
LEFT JOIN 
    Estadias e ON ho.IdEstadia = e.IdEstadia
LEFT JOIN 
    Habitaciones h ON ho.IdHabitacion = h.IdHabitacion
LEFT JOIN 
    TipoHabitacion th ON ho.IdTipoHabitacion = th.IdTipoHabitacion -- Relación con TipoHabitacion
LEFT JOIN 
    Camillas c ON ho.IdCamilla = c.IdCamilla
GROUP BY
    ho.IdHospitalizacion,
    p.Nombre,
    p.DNI,
    e.Nombre,
    c.Nombre,
    h.Nombre,
    th.Nombre,
    ho.FechaIngreso,
    ho.HoraIngreso,
    ho.FechaSalida,
    ho.HoraSalida;