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

-- Insertar registros por defecto en Estadias
INSERT INTO Estadias (Nombre)
VALUES ('2'),
       ('3'),
       ('4'),
       ('5'),
       ('6'),
       ('7'),
       ('Indefinido');
GO

-- Insertar registros en Tipo de Habitación
INSERT INTO TipoHabitacion (Nombre, Ocupado)
VALUES ('Hab. Priv. + AC',0),
			   ('Hab. Priv. + Ventilador',0),
			   ('Hab. Comp. + AC',0),
			   ('Hab. Com. + Ventilador',0);
GO

-- Insertar registros en la tabla Habitaciones
INSERT INTO Habitaciones (Nombre, Ocupado, IdTipoHabitacion)
VALUES 
    ('101', 0, 1),
    ('102', 0, 1),
    ('103', 0, 2),
    ('104', 0, 2),
    ('105', 0, 3),
    ('106', 0, 3),
    ('107', 0, 4),
    ('108', 0, 4),
    ('109', 0, 1),
    ('110', 0, 1),
    ('201', 0, 2),
    ('202', 0, 2),
    ('203', 0, 3),
    ('204', 0, 3),
    ('205', 0, 4),
    ('206', 0, 4),
    ('207', 0, 1),
    ('208', 0, 1),
    ('209', 0, 2),
    ('210', 0, 2),
    ('301', 0, 3),
    ('302', 0, 3),
    ('303', 0, 4),
    ('304', 0, 4),
    ('305', 0, 1),
    ('306', 0, 1),
    ('307', 0, 2),
    ('308', 0, 2),
    ('309', 0, 3),
    ('310', 0, 3),
    ('401-A', 0, 4),
    ('402-A', 0, 4),
    ('403-A', 0, 1),
    ('404-A', 0, 1),
    ('405-A', 0, 2),
    ('406-A', 0, 2),
    ('407-A', 0, 3),
    ('408-A', 0, 3),
    ('409-A', 0, 4),
    ('410-A', 0, 4),
    ('401-B', 0, 1),
    ('402-B', 0, 1),
    ('403-B', 0, 2),
    ('404-B', 0, 2),
    ('405-B', 0, 3),
    ('406-B', 0, 3),
    ('407-B', 0, 4),
    ('408-B', 0, 4),
    ('409-B', 0, 1),
    ('410-B', 0, 1);
GO

-- Insertar registros iniciales en la tabla Camilla
INSERT INTO Camillas (Nombre, Ocupado)
VALUES 
    (1, 0),
    (2, 0),
    (3, 0),
    (4, 0),
    (5, 0),
    (6, 0),
    (7, 0),
    (8, 0),
    (9, 0),
    (10, 0),
    (11, 0),
    (12, 0),
    (13, 0),
    (14, 0),
    (15, 0),
    (16, 0),
    (17, 0),
    (18, 0),
    (19, 0),
    (20, 0),
    (21, 0),
    (22, 0),
    (23, 0),
    (24, 0),
    (25, 0),
    (26, 0),
    (27, 0),
    (28, 0),
    (29, 0),
    (30, 0),
    (31, 0),
    (32, 0),
    (33, 0),
    (34, 0),
    (35, 0),
    (36, 0),
    (37, 0),
    (38, 0),
    (39, 0),
    (40, 0),
    (41, 0),
    (42, 0),
    (43, 0),
    (44, 0),
    (45, 0),
    (46, 0),
    (47, 0),
    (48, 0),
    (49, 0),
    (50, 0),
    (51, 0),
    (52, 0),
    (53, 0),
    (54, 0),
    (55, 0),
    (56, 0),
    (57, 0),
    (58, 0),
    (59, 0),
    (60, 0),
    (61, 0),
    (62, 0),
    (63, 0),
    (64, 0),
    (65, 0),
    (66, 0),
    (67, 0),
    (68, 0),
    (69, 0),
    (70, 0),
    (71, 0),
    (72, 0),
    (73, 0),
    (74, 0),
    (75, 0),
    (76, 0),
    (77, 0),
    (78, 0),
    (79, 0),
    (80, 0);
GO

-- Insertar registros en Genero
INSERT INTO Genero (Nombre)
VALUES ('Femenino'),
			   ('Masculino');
GO

-- Insertar registros en SalaCirugia
INSERT INTO SalaCirugia (Nombre, Ocupado)
VALUES ('Sala 1', 0),
			   ('Sala 2', 0)
GO

-- Asignar camillas a habitaciones
INSERT INTO HabitacionCamilla (IdHabitacion, IdCamilla) VALUES
-- Para habitación '101'
(1, 1), 
(1, 2),
-- Para habitación '102'
(2, 3),
(2, 4),
-- Para habitación '103'
(3, 5),
(3, 6),
-- Para habitación '104'
(4, 7),
(4, 8),
-- Para habitación '105'
(5, 9),
(5, 10),
-- Para habitación '106'
(6, 11),
(6, 12),
-- Para habitación '107'
(7, 13),
(7, 14),
-- Para habitación '108'
(8, 15),
(8, 16),
-- Para habitación '109'
(9, 17),
(9, 18),
-- Para habitación '110'
(10, 19),
(10, 20),
-- Para habitación '201'
(11, 21),
(11, 22),
-- Para habitación '202'
(12, 23),
(12, 24),
-- Para habitación '203'
(13, 25),
(13, 26),
-- Para habitación '204'
(14, 27),
(14, 28),
-- Para habitación '205'
(15, 29),
(15, 30),
-- Para habitación '206'
(16, 31),
(16, 32),
-- Para habitación '207'
(17, 33),
(17, 34),
-- Para habitación '208'
(18, 35),
(18, 36),
-- Para habitación '209'
(19, 37),
(19, 38),
-- Para habitación '210'
(20, 39),
(20, 40),
-- Para habitación '301'
(21, 41),
(21, 42),
-- Para habitación '302'
(22, 43),
(22, 44),
-- Para habitación '303'
(23, 45),
(23, 46),
-- Para habitación '304'
(24, 47),
(24, 48),
-- Para habitación '305'
(25, 49),
(25, 50),
-- Para habitación '306'
(26, 51),
(26, 52),
-- Para habitación '307'
(27, 53),
(27, 54),
-- Para habitación '308'
(28, 55),
(28, 56),
-- Para habitación '309'
(29, 57),
(29, 58),
-- Para habitación '310'
(30, 59),
(30, 60),
-- Para habitación '401-A'
(31, 61),
(31, 62),
-- Para habitación '402-A'
(32, 63),
(32, 64),
-- Para habitación '403-A'
(33, 65),
(33, 66),
-- Para habitación '404-A'
(34, 67),
(34, 68),
-- Para habitación '405-A'
(35, 69),
(35, 70),
-- Para habitación '406-A'
(36, 71),
(36, 72),
-- Para habitación '407-A'
(37, 73),
(37, 74),
-- Para habitación '408-A'
(38, 75),
(38, 76),
-- Para habitación '409-A'
(39, 77),
(39, 78),
-- Para habitación '410-A'
(40, 79),
(40, 80),
-- Para habitación '401-B'
(41, 81),
(41, 82),
-- Para habitación '402-B'
(42, 83),
(42, 84),
-- Para habitación '403-B'
(43, 85),
(43, 86),
-- Para habitación '404-B'
(44, 87),
(44, 88),
-- Para habitación '405-B'
(45, 89),
(45, 90),
-- Para habitación '406-B'
(46, 91),
(46, 92),
-- Para habitación '407-B'
(47, 93),
(47, 94),
-- Para habitación '408-B'
(48, 95),
(48, 96),
-- Para habitación '409-B'
(49, 97),
(49, 98),
-- Para habitación '410-B'
(50, 99),
(50, 100);
GO
