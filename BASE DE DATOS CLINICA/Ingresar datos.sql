USE Clinica

-- Insertar nuevos registros en MENU
INSERT INTO MENU(IdMenu, Nombre, NombreFormulario) VALUES
(1,'Consultas','frmConsultas'),
(2,'Hospitalización','frmHospitalizacion'),
(3,'Cirugías','frmCirugias'),
(4,'Cronograma','frmCronograma'),
(5,'Historial','frmHistorial'),
(6, 'Usuarios', 'frmUsuarios'),
(7, 'Roles', 'frmRoles'),
(8, 'Permisos', 'frmPermisos'),
(9, 'Reportes', 'frmReportes')

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
(7, 1, 7, 0), -- Roles
(8, 1, 8, 0), -- Permisos
(9, 1, 9, 0) -- Reportes

-- Lic. de Enfermería
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(10, 2, 1, 1), -- Consultas
(11, 2, 2, 1), -- Hospitalizacion
(12, 2, 3, 0), -- Cirugías
(13, 2, 4, 0), -- Cronograma
(14, 2, 5, 0), -- Historial
(15, 2, 6, 0), -- Usuarios
(16, 2, 7, 0), -- Roles
(17, 2, 8, 0), -- Permisos
(18, 2, 9, 0) -- Reportes

-- Medico
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(19, 3, 1, 0), -- Consultas
(20, 3, 2, 0), -- Hospitalizacion
(21, 3, 3, 1), -- Cirugías
(22, 3, 4, 1), -- Cronograma
(23, 3, 5, 0), -- Historial
(24, 3, 6, 0), -- Usuarios
(25, 3, 7, 0), -- Roles
(26, 3, 8, 0), -- Permisos
(27, 3, 9, 0) -- Reportes

-- Pers. de Mantenimiento
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(28, 4, 1, 0), -- Consultas
(29, 4, 2, 0), -- Hospitalizacion
(30, 4, 3, 0), -- Cirugías
(31, 4, 4, 1), -- Cronograma
(32, 4, 5, 0), -- Historial
(33, 4, 6, 0), -- Usuarios
(34, 4, 7, 0), -- Roles
(35, 4, 8, 0), -- Permisos
(36, 4, 9, 0) -- Reportes

-- Administrador
INSERT INTO PERMISO(IdPermiso, IdRol, IdMenu, Activo) VALUES
(37, 5, 1, 1), -- Consultas
(38, 5, 2, 1), -- Hospitalizacion
(39, 5, 3, 1), -- Cirugías
(40, 5, 4, 1), -- Cronograma
(41, 5, 5, 1), -- Historial
(42, 5, 6, 1), -- Usuarios
(43, 5, 7, 1), -- Roles
(44, 5, 8, 1), -- Permisos
(45, 5, 9, 1) -- Reportes

-- Insertar nuevos registros en USUARIOS
INSERT INTO USUARIOS(IdUsuario, Nombres, Usuario, Clave, IdRol) VALUES
(1, 'Luis Alvinagorta', 'Luis', 'recepcionista', 1), -- Recepcionista
(2, 'Gary Bocanegra', 'Gary', 'licenciado', 2), -- Licenciado de Enfermería
(3, 'Matías Guevara', 'Matías', 'medico', 3), -- Medico
(4, 'Manuel Ortiz', 'Manuel', 'mantenimiento', 4), -- Mantenimiento
(5, 'Victor Tuesta', 'Victor', 'administrador', 5) -- Administrador