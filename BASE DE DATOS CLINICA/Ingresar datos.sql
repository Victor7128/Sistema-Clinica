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
('Luis Alvinagorta', 'Luis', 'recepcionista', 1, 1), -- Recepcionista
('Gary Bocanegra', 'Gary', 'licenciado', 2, 1), -- Licenciado de Enfermería
('Matías Guevara', 'Matías', 'medico', 3, 1), -- Médico
('Manuel Ortiz', 'Manuel', 'mantenimiento', 4, 1), -- Mantenimiento
('Victor Tuesta', 'Victor', 'administrador', 5, 1); -- Administrador

-- Insertar registros por defecto en Estadias
INSERT INTO Estadias (Nombre)
VALUES ('2'),
       ('3'),
       ('4'),
       ('5'),
       ('6'),
       ('7'),
       ('Indefinido');

-- Insertar registros en Tipo de Habitación
INSERT INTO TipoHabitacion (Nombre)
VALUES ('Hab. Priv. + AC'),
       ('Hab. Priv. + Ventilador'),
       ('Hab. Comp. + AC'),
       ('Hab. Com. + Ventilador');

	  

-- Insertar registros en la tabla Habitación
INSERT INTO Habitaciones (Nombre)
VALUES 
    ('101'),
    ('102'),
    ('103'),
    ('104'),
    ('105'),
    ('106'),
    ('107'),
    ('108'),
    ('109'),
    ('110'),
    ('201'),
    ('202'),
    ('203'),
    ('204'),
    ('205'),
    ('206'),
    ('207'),
    ('208'),
    ('209'),
    ('210'),
    ('301'),
    ('302'),
    ('303'),
    ('304'),
    ('305'),
    ('306'),
    ('307'),
    ('308'),
    ('309'),
    ('310'),
    ('401-A'),
    ('402-A'),
    ('403-A'),
    ('404-A'),
    ('405-A'),
    ('406-A'),
    ('407-A'),
    ('408-A'),
    ('409-A'),
    ('410-A'),
    ('401-B'),
    ('402-B'),
    ('403-B'),
    ('404-B'),
    ('405-B'),
    ('406-B'),
    ('407-B'),
    ('408-B'),
    ('409-B'),
    ('410-B');

-- Insertar registros iniciales en la tabla Camilla
INSERT INTO Camillas (Nombre)
VALUES (1),
       (2);

-- Insertar Genero
INSERT INTO Genero (Nombre)
VALUES ('Femenino'),
	   ('Masculino');

-- Insertar Salas
INSERT INTO Salas (Nombre)
VALUES 
    ('Sala 1'),
    ('Sala 2'),
    ('Sala 3'),
    ('Sala 4'),
    ('Sala 5'),
    ('Sala 6'),
    ('Sala 7'),
    ('Sala 8');
