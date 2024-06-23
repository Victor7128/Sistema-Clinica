USE Clinica

INSERT INTO MENU(IdMenu, Nombre, NombreFormulario) VALUES
(1, 'Consultas', 'frmConsultas'),
(2, 'Hospitalización', 'frmHospitalizacion'),
(3, 'Cirugías', 'frmCirugias'),
(4, 'Cronograma', 'frmCronograma'),
(5, 'Historial', 'frmHistorial'),
(6, 'Usuarios', 'frmUsuarios'),
(7, 'Permisos', 'frmPermisos'),
(8, 'Reportes', 'frmReportes');

-- Insertar registros en ROL
INSERT INTO ROL(IdRol, Nombre, Activo) VALUES
(1, 'Recepcionista', 1),
(2, 'Lic. de Enfermería', 1),
(3, 'Médico', 1),
(4, 'Personal de Mantenimiento', 1),
(5, 'Administrador', 1);

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

-- Insertar registros en USUARIOS
INSERT INTO USUARIOS(Nombres, Usuario, Clave, IdRol, Activo) VALUES
('Luis Alvinagorta', 'Luis', 'administrador', 5, 1), -- Recepcionista
('Gary Bocanegra', 'Gary', 'administrador', 5, 1), -- Licenciado de Enfermería
('Matías Guevara', 'Matías', 'administrador', 5, 1), -- Médico
('Manuel Ortiz', 'Manuel', 'administrador', 5, 1), -- Mantenimiento
('Victor Tuesta', 'Victor', 'administrador', 5, 1); -- Administrador

-- Insertar registros por defecto en Estadias
INSERT INTO Estadias (IdEstadia, Nombre)
VALUES (2, '2'),
       (3, '3'),
       (4, '4'),
       (5, '5'),
       (6, '6'),
       (7, '7'),
       (8, 'Indefinido');

-- Insertar registros en Tipo de Habitación
INSERT INTO TipoHabitacion (IdTipoHabitacion, Nombre)
VALUES (1, 'Hab. Priv. + AC'),
       (2, 'Hab. Priv. + Ventilador'),
       (3, 'Hab. Comp. + AC'),
       (4, 'Hab. Com. + Ventilador');

	  

-- Insertar registros en la tabla Habitación
INSERT INTO Habitaciones (IdHabitacion, Nombre)
VALUES 
    (1, '101'),
    (2, '102'),
    (3, '103'),
    (4, '104'),
    (5, '105'),
    (6, '106'),
    (7, '107'),
    (8, '108'),
    (9, '109'),
    (10, '110'),
    (11, '201'),
    (12, '202'),
    (13, '203'),
    (14, '204'),
    (15, '205'),
    (16, '206'),
    (17, '207'),
    (18, '208'),
    (19, '209'),
    (20, '210'),
    (21, '301'),
    (22, '302'),
    (23, '303'),
    (24, '304'),
    (25, '305'),
    (26, '306'),
    (27, '307'),
    (28, '308'),
    (29, '309'),
    (30, '310'),
    (31, '401-A'),
    (32, '402-A'),
    (33, '403-A'),
    (34, '404-A'),
    (35, '405-A'),
    (36, '406-A'),
    (37, '407-A'),
    (38, '408-A'),
    (39, '409-A'),
    (40, '410-A'),
    (41, '401-B'),
    (42, '402-B'),
    (43, '403-B'),
    (44, '404-B'),
    (45, '405-B'),
    (46, '406-B'),
    (47, '407-B'),
    (48, '408-B'),
    (49, '409-B'),
    (50, '410-B');

-- Insertar registros iniciales en la tabla Camilla
INSERT INTO Camillas (Nombre)
VALUES (1),
       (2);
