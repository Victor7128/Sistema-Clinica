USE Clinica
GO

-- Insertar registros en MENU
INSERT INTO MENU(IdMenu, Nombre, NombreFormulario) VALUES
(1, 'Consultas', 'frmConsultas'),
(2, 'Hospitalización', 'frmHospitalizacion'),
(3, 'Cirugías', 'frmCirugias'),
(4, 'Cronograma', 'frmCronograma'),
(5, 'Historial', 'frmHistorial'),
(6, 'Usuarios', 'frmUsuarios'),
(7, 'Permisos', 'frmPermisos'),
(8, 'Reportes', 'frmReportes');
GO

-- Insertar registros en ROL
INSERT INTO ROL(IdRol, Nombre, Activo) VALUES
(1, 'Recepcionista', 1),
(2, 'Lic. de Enfermería', 1),
(3, 'Médico', 1),
(4, 'Personal de Mantenimiento', 1),
(5, 'Administrador', 1);
GO

-- Insertar registros en PERMISO
-- Recepcionista
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(1, 1, 1, 1), -- Consultas
(2, 1, 2, 0), -- Hospitalización
(3, 1, 3, 0), -- Cirugías
(4, 1, 4, 0), -- Cronograma
(5, 1, 5, 0), -- Historial
(6, 1, 6, 0), -- Usuarios
(7, 1, 7, 0), -- Permisos
(8, 1, 8, 0); -- Reportes
GO

-- Lic. de Enfermería
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(9, 2, 1, 1), -- Consultas
(10, 2, 2, 1), -- Hospitalización
(11, 2, 3, 0), -- Cirugías
(12, 2, 4, 0), -- Cronograma
(13, 2, 5, 0), -- Historial
(14, 2, 6, 0), -- Usuarios
(15, 2, 7, 0), -- Permisos
(16, 2, 8, 0); -- Reportes
GO

-- Médico
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(17, 3, 1, 0), -- Consultas
(18, 3, 2, 0), -- Hospitalización
(19, 3, 3, 1), -- Cirugías
(20, 3, 4, 1), -- Cronograma
(21, 3, 5, 0), -- Historial
(22, 3, 6, 0), -- Usuarios
(23, 3, 7, 0), -- Permisos
(24, 3, 8, 0); -- Reportes
GO

-- Personal de Mantenimiento
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(25, 4, 1, 0), -- Consultas
(26, 4, 2, 0), -- Hospitalización
(27, 4, 3, 0), -- Cirugías
(28, 4, 4, 1), -- Cronograma
(29, 4, 5, 0), -- Historial
(30, 4, 6, 0), -- Usuarios
(31, 4, 7, 0), -- Permisos
(32, 4, 8, 0); -- Reportes
GO

-- Administrador
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(33, 5, 1, 1), -- Consultas
(34, 5, 2, 1), -- Hospitalización
(35, 5, 3, 1), -- Cirugías
(36, 5, 4, 1), -- Cronograma
(37, 5, 5, 1), -- Historial
(38, 5, 6, 1), -- Usuarios
(39, 5, 7, 1), -- Permisos
(40, 5, 8, 1); -- Reportes
GO

-- Insertar registros en USUARIOS
INSERT INTO USUARIOS(Nombres, Usuario, Clave, IdRol, Activo) VALUES
('Luis Alvinagorta', 'Luis', 'recepcionista', 1, 1), -- Recepcionista
('Gary Bocanegra', 'Gary', 'licenciado', 2, 1), -- Licenciado de Enfermería
('Matías Guevara', 'Matías', 'medico', 3, 1), -- Médico
('Manuel Ortiz', 'Manuel', 'mantenimiento', 4, 1), -- Mantenimiento
('Victor Tuesta', 'Victor', 'administrador', 5, 1); -- Administrador
GO

-- Insertar registros en Genero
INSERT INTO Genero (IdGenero, Nombre)
VALUES (1,'Femenino'),
	   (2,'Masculino');
GO

-- Insertar registros en SalaCirugia
INSERT INTO SalaCirugia (IdSala, Nombre, Ocupado)
VALUES (1,'Sala 1', 0),
	   (2,'Sala 2', 0)
GO

-- Insertar registros por defecto en Estadias
INSERT INTO Estadias (IdEstadia, Nombre)
VALUES (1,'2'),
       (2,'3'),
       (3,'4'),
       (4,'5'),
       (5,'6'),
       (6,'7'),
       (7,'Indefinido');
GO

-- Insertar registros en Tipo de Habitación
INSERT INTO TipoHabitacion (IdTipoHabitacion, Nombre, Ocupado)
VALUES 
    (1, 'Hab. Priv. + AC', 0),
    (2, 'Hab. Priv. + Ventilador', 0),
    (3, 'Hab. Comp. + AC', 0),
    (4, 'Hab. Com. + Ventilador', 0);
GO

-- Insertar registros en la tabla Habitaciones
INSERT INTO Habitaciones (IdHabitacion, Nombre, Ocupado, IdTipoHabitacion)
VALUES 
    (1, '201', 0, 4),
    (2, '202', 0, 4),
    (3, '203', 0, 4),
    (4, '204', 0, 4),
    (5, '205', 0, 4),
    (6, '206', 0, 4),
    (7, '207', 1, 4),
    (8, '208', 0, 4),
    (9, '209', 0, 4),
    (10, '210', 0, 4),
    (11, '301', 0, 2),
    (12, '302', 0, 2),
    (13, '303', 0, 2),
    (14, '304', 0, 2),
    (15, '305', 0, 2),
    (16, '306', 0, 2),
    (17, '307', 0, 2),
    (18, '308', 0, 2),
    (19, '309', 0, 2),
    (20, '310', 0, 2),
    (21, '401', 0, 3),
    (22, '402', 0, 3),
    (23, '403', 0, 3),
    (24, '404', 0, 3),
    (25, '405', 0, 3),
    (26, '406', 0, 3),
    (27, '407', 0, 3),
    (28, '408', 0, 3),
    (29, '409', 0, 3),
    (30, '410', 0, 3),
    (31, '501', 0, 1),
    (32, '502', 0, 1),
    (33, '503', 0, 1),
    (34, '504', 0, 1),
    (35, '505', 0, 1),
    (36, '506', 0, 1),
    (37, '507', 0, 1),
    (38, '508', 0, 1),
    (39, '509', 0, 1),
    (40, '510', 0, 1)
GO

-- Insertar registros iniciales en la tabla Camillas
INSERT INTO Camillas (IdCamilla, Nombre, Ocupado, IdHabitacion)
VALUES 
    (1, 'Camilla 1', 0, 1),
    (2, 'Camilla 2', 0, 1),
    (3, 'Camilla 1', 0, 2),
    (4, 'Camilla 2', 0, 2),
    (5, 'Camilla 1', 0, 3),
    (6, 'Camilla 2', 0, 3),
    (7, 'Camilla 1', 0, 4),
    (8, 'Camilla 2', 0, 4),
    (9, 'Camilla 1', 0, 5),
    (10, 'Camilla 2', 0, 5),
    (11, 'Camilla 1', 0, 6),
    (12, 'Camilla 2', 0, 6),
    (13, 'Camilla 1', 0, 7),
    (14, 'Camilla 2', 0, 7),
    (15, 'Camilla 1', 0, 8),
    (16, 'Camilla 2', 0, 8),
    (17, 'Camilla 1', 0, 9),
    (18, 'Camilla 2', 0, 9),
    (19, 'Camilla 1', 0, 10),
    (20, 'Camilla 2', 0, 10),
    (21, 'Camilla 1', 0, 11),
    (22, 'Camilla 1', 0, 12),
    (23, 'Camilla 1', 0, 13),
    (24, 'Camilla 1', 0, 14),
    (25, 'Camilla 1', 0, 15),
    (26, 'Camilla 1', 0, 16),
    (27, 'Camilla 1', 0, 17),
    (28, 'Camilla 1', 0, 18),
    (29, 'Camilla 1', 0, 19),
    (30, 'Camilla 1', 0, 20),
    (31, 'Camilla 1', 0, 21),
    (32, 'Camilla 2', 0, 21),
    (33, 'Camilla 1', 0, 22),
    (34, 'Camilla 2', 0, 22),
    (35, 'Camilla 1', 0, 23),
    (36, 'Camilla 2', 0, 23),
    (37, 'Camilla 1', 0, 24),
    (38, 'Camilla 2', 0, 24),
    (39, 'Camilla 1', 0, 25),
    (40, 'Camilla 2', 0, 25),
    (41, 'Camilla 1', 0, 26),
    (42, 'Camilla 2', 0, 26),
    (43, 'Camilla 1', 0, 27),
    (44, 'Camilla 2', 0, 27),
    (45, 'Camilla 1', 0, 28),
    (46, 'Camilla 2', 0, 28),
    (47, 'Camilla 1', 0, 29),
    (48, 'Camilla 2', 0, 29),
    (49, 'Camilla 1', 0, 30),
    (50, 'Camilla 2', 0, 30),
    (51, 'Camilla 1', 0, 31),
    (52, 'Camilla 1', 0, 32),
    (53, 'Camilla 1', 0, 33),
    (54, 'Camilla 1', 0, 34),
    (55, 'Camilla 1', 0, 35),
    (56, 'Camilla 1', 0, 36),
    (57, 'Camilla 1', 0, 37),
    (58, 'Camilla 1', 0, 38),
    (59, 'Camilla 1', 0, 39),
    (60, 'Camilla 1', 0, 40)
GO
