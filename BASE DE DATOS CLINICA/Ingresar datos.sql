USE Clinica

-- Insertar nuevos registros en MENU
INSERT INTO MENU(IdMenu, Nombre, NombreFormulario) VALUES
(1,'Consultas','frmConsultas'),
(2,'Hospitalización','frmHospitalizacion'),
(3,'Cirugías','frmCirugias'),
(4,'Cronograma','frmCronograma'),
(5,'Historial','frmHistorial'),
(6, 'Usuarios', 'frmUsuarios'),
(7, 'Permisos', 'frmPermisos'),
(8, 'Reportes', 'frmReportes')

-- Insertar nuevos registros en ROL
INSERT INTO ROL(IdRol, Nombre, Activo) VALUES
(1,'Recepcionista', 1),
(2,'Lic. de Enfermería', 1),
(3,'Medico', 1),
(4,'Pers. de Mantenimiento', 1),
(5,'Administrador', 1)

-- Insertar nuevos registros en PERMISO
-- Recepcionista
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(1, 1, 1, 1), -- Consultas
(2, 1, 2, 0), -- Hospitalizacion
(3, 1, 3, 0), -- Cirugías
(4, 1, 4, 0), -- Cronograma
(5, 1, 5, 0), -- Historial
(6, 1, 6, 0), -- Usuarios
(7, 1, 7, 0), -- Permisos
(8, 1, 8, 0) -- Reportes

-- Lic. de Enfermería
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(9, 2, 1, 1), -- Consultas
(10, 2, 2, 1), -- Hospitalizacion
(11, 2, 3, 0), -- Cirugías
(12, 2, 4, 0), -- Cronograma
(13, 2, 5, 0), -- Historial
(14, 2, 6, 0), -- Usuarios
(15, 2, 7, 0), -- Permisos
(16, 2, 8, 0) -- Reportes

-- Medico
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(17, 3, 1, 0), -- Consultas
(18, 3, 2, 0), -- Hospitalizacion
(19, 3, 3, 1), -- Cirugías
(20, 3, 4, 1), -- Cronograma
(21, 3, 5, 0), -- Historial
(22, 3, 6, 0), -- Usuarios
(23, 3, 7, 0), -- Permisos
(24, 3, 8, 0) -- Reportes

-- Pers. de Mantenimiento
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(25, 4, 1, 0), -- Consultas
(26, 4, 2, 0), -- Hospitalizacion
(27, 4, 3, 0), -- Cirugías
(28, 4, 4, 1), -- Cronograma
(29, 4, 5, 0), -- Historial
(30, 4, 6, 0), -- Usuarios
(31, 4, 7, 0), -- Permisos
(32, 4, 8, 0) -- Reportes

-- Administrador
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(33, 5, 1, 1), -- Consultas
(34, 5, 2, 1), -- Hospitalizacion
(35, 5, 3, 1), -- Cirugías
(36, 5, 4, 1), -- Cronograma
(37, 5, 5, 1), -- Historial
(38, 5, 6, 1), -- Usuarios
(39, 5, 7, 1), -- Permisos
(40, 5, 8, 1) -- Reportes

-- Insertar nuevos registros en USUARIOS
INSERT INTO USUARIOS(Nombres, Usuario, Clave, IdRol) VALUES
('Luis Alvinagorta', 'Luis', 'recepcionista', 1), -- Recepcionista
('Gary Bocanegra', 'Gary', 'licenciado', 2), -- Licenciado de Enfermería
('Matías Guevara', 'Matías', 'medico', 3), -- Medico
('Manuel Ortiz', 'Manuel', 'mantenimiento', 4), -- Mantenimiento
('Victor Tuesta', 'Victor', 'administrador', 5); -- Administrador