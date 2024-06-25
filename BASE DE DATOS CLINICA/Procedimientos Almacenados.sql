use CLinica

-- Obtener Usuarios
CREATE PROCEDURE usp_ObtenerUsuarios
as
SELECT IdUsuario, Nombres, Usuario, Clave, IdRol, Activo FROM USUARIOS
GO
----------------------------------------
-- Obtener Roles
CREATE PROCEDURE usp_ObtenerRoles
as
SELECT IdRol, Nombre, Activo FROM ROL
GO
----------------------------------------
CREATE PROCEDURE usp_ObtenerUsuariosConRoles
as
SELECT u.IdUsuario, u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
FROM USUARIOS u
inner JOIN ROL r ON u.IdRol = r.IdRol
ORDER BY u.IdUsuario
GO
----------------------------------------
-- Procedimiento almacenado para login de usuarios
CREATE PROCEDURE usp_LoginUsuario
    @Usuario VARCHAR(60),
    @Clave VARCHAR(60),
    @IdUsuario INT OUTPUT
AS
BEGIN
    SET @IdUsuario = 0;
    IF EXISTS (
        SELECT * FROM USUARIOS
        WHERE Usuario COLLATE Latin1_General_CS_AS = @Usuario
          AND Clave COLLATE Latin1_General_CS_AS = @Clave
    )
    BEGIN
        SELECT @IdUsuario = IdUsuario FROM USUARIOS
        WHERE Usuario COLLATE Latin1_General_CS_AS = @Usuario
          AND Clave COLLATE Latin1_General_CS_AS = @Clave;
    END
END;
GO

-- Stored Procedure for fetching user permissions
CREATE PROCEDURE usp_ObtenerPermisos
    @IdUsuario INT
AS
BEGIN
    SELECT (
        SELECT 
            M.Nombre,
            M.NombreFormulario
        FROM
            PERMISO P
        JOIN ROL R ON R.IdRol = P.IdRol
        JOIN MENU M ON M.IdMenu = P.IdMenu
        WHERE P.IdRol = (SELECT IdRol FROM USUARIOS WHERE IdUsuario = @IdUsuario)
          AND P.Activo = 1
        FOR XML PATH('Menu'), TYPE
    ) AS 'DetalleMenu'
    FOR XML PATH(''), ROOT('PERMISOS');
END;
GO
exec usp_ObtenerPermisos 5

-- Procedimiento almacenado para registrar usuario
CREATE PROCEDURE usp_RegistrarUsuario
    @Nombres NVARCHAR(100),
    @Usuario NVARCHAR(50),
    @Clave NVARCHAR(50),
    @IdRol INT,
    @IdUsuario INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO USUARIOS (Nombres, Usuario, Clave, IdRol, Activo)
        VALUES (@Nombres, @Usuario, @Clave, @IdRol, 1);

        SET @IdUsuario = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        SET @IdUsuario = 0;
    END CATCH
END;
GO

-- Procedimiento almacenado para eliminar usuario
CREATE PROCEDURE usp_EliminarUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DELETE FROM USUARIOS WHERE IdUsuario = @IdUsuario;
    END TRY
    BEGIN CATCH
        PRINT 'Error al eliminar usuario.';
    END CATCH
END;
GO
--------------------------------------------------------------------
-- Procedimiento almacenado para Listar hospitalización
create proc sp_listar_pacientes
as
SELECT
	p.Codigo as Codigo,
    p.Nombre AS Nombre,
    p.DNI AS Dni,
    e.Nombre AS Estadia,
    c.Nombre AS Camilla,
    h.Nombre AS Habitacion,
    th.Nombre AS TipoHabitacion,
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
    TipoHabitacion th ON ho.IdTipoHabitacion = th.IdTipoHabitacion
LEFT JOIN 
    Camillas c ON ho.IdCamilla = c.IdCamilla
GROUP BY
	p.Codigo,
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
go
----------------------------------
create proc sp_buscar_pacientes
@nombre varchar(50)
as
select codigo, nombre, dni from Pacientes where nombre like @nombre + '%'
go
----------------------------------
CREATE PROCEDURE sp_mantenedor_pacientes
    @codigo VARCHAR(5),
    @nombre VARCHAR(100),
    @DNI INT,
    @TipoHabitacion INT,
    @Habitacion INT,
    @Camilla INT,
    @Estadia INT,
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    IF (@accion = '1')
    BEGIN
        -- Generar nuevo código para el paciente
        DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5), @IdPaciente INT;
        SET @codmax = (SELECT MAX(Codigo) FROM Pacientes);
        SET @codmax = ISNULL(@codmax, 'P0000');
        SET @codnuevo = 'P' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR(4)), 4);

        -- Insertar nuevo paciente en la tabla Pacientes
        INSERT INTO Pacientes (Codigo, Nombre, DNI)
        VALUES (@codnuevo, @nombre, @DNI);

        -- Obtener el ID del paciente insertado
        SET @IdPaciente = SCOPE_IDENTITY();

        -- Insertar hospitalización en la tabla Hospitalizaciones
        INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdTipoHabitacion, FechaIngreso, HoraIngreso)
        VALUES (@IdPaciente, @Estadia, @Habitacion, @Camilla, @TipoHabitacion, GETDATE(), GETDATE());

        -- Configurar mensaje de salida
        SET @accion = 'Se agregó el paciente: ' + @nombre;
    END
    ELSE IF (@accion = '2')
    BEGIN
        -- Actualizar datos del paciente en la tabla Pacientes
        UPDATE Pacientes 
        SET Nombre = @nombre, DNI = @DNI 
        WHERE Codigo = @codigo;

        -- Actualizar datos de hospitalización si es necesario
        UPDATE Hospitalizaciones
        SET IdEstadia = @Estadia,
            IdHabitacion = @Habitacion,
            IdCamilla = @Camilla,
            IdTipoHabitacion = @TipoHabitacion
        WHERE IdPaciente = (SELECT IdPaciente FROM Pacientes WHERE Codigo = @codigo);

        -- Configurar mensaje de salida
        SET @accion = 'Se modificó el paciente: ' + @nombre;
    END
    ELSE IF (@accion = '3')
    BEGIN
        -- Registrar salida del paciente en la tabla Hospitalizaciones
        UPDATE Hospitalizaciones 
        SET FechaSalida = GETDATE(), HoraSalida = GETDATE() 
        WHERE IdPaciente = (SELECT IdPaciente FROM Pacientes WHERE Codigo = @codigo);

        -- Configurar mensaje de salida
        SET @accion = 'Se registró la salida del paciente: ' + @nombre;
    END
    ELSE IF (@accion = '4')
    BEGIN
        DECLARE @IdPacienteToDelete INT

        -- Obtener el ID del paciente a eliminar
        SELECT @IdPacienteToDelete = IdPaciente FROM Pacientes WHERE Codigo = @codigo;

        -- Eliminar las hospitalizaciones asociadas al paciente
        DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPacienteToDelete;

        -- Eliminar paciente de la tabla Pacientes
        DELETE FROM Pacientes WHERE Codigo = @codigo;

        -- Configurar mensaje de salida
        SET @accion = 'Se borró el paciente: ' + @nombre;
    END
END
GO
------------------------------------------
CREATE PROCEDURE sp_listar_estadias
AS
BEGIN
    SELECT IdEstadia, Nombre FROM Estadias;
END
GO
------------------------------------------
CREATE PROCEDURE sp_listar_habitaciones
AS
BEGIN
    SELECT IdHabitacion, Nombre FROM Habitaciones;
END
GO
------------------------------------------
CREATE PROCEDURE sp_listar_tipo_habitacion
AS
BEGIN
    SELECT IdTipoHabitacion, Nombre FROM TipoHabitacion;
END
GO
------------------------------------------
CREATE PROCEDURE sp_listar_camillas
AS
BEGIN
    SELECT IdCamilla, Nombre FROM Camillas;
END
GO
------------------------------------------
SELECT IdPaciente, Nombre, DNI FROM Pacientes WHERE Nombre LIKE @Apellido
select * from Pacientes

------------------------------------------
-- CREATE PROCEDURE usp_AgregarCirugia
--    @TipoCirugia NVARCHAR(100),
--    @IdPaciente INT,
--    @NombrePaciente NVARCHAR(100),
--    @Sala NVARCHAR(50),
--    @Turno NVARCHAR(20),
--    @FechaCirugia DATETIME
--AS
--BEGIN
--    INSERT INTO Cirugias (TipoCirugia, IdPaciente, NombrePaciente, Sala, Turno, FechaCirugia)
--    VALUES (@TipoCirugia, @IdPaciente, @NombrePaciente, @Sala, @Turno, @FechaCirugia);
--END
----------------------------------
--CREATE PROCEDURE usp_ObtenerCirugias
--AS
--BEGIN
--    SELECT c.IdCirugia, c.TipoCirugia, p.Nombre AS NombrePaciente, c.Sala, c.Turno, c.FechaCirugia
--    FROM Cirugias c
--    INNER JOIN Pacientes p ON c.IdPaciente = p.IdPaciente;
--END
----------------------------------
--CREATE PROCEDURE usp_ObtenerCirugiasConEstado
--AS
--BEGIN
--    SELECT 
--        c.IdCirugia, 
--        c.TipoCirugia, 
--        p.Nombre AS Paciente, 
--        c.Sala, 
--        c.FechaCirugia,
--        CASE 
--            WHEN c.FechaCirugia = CAST(GETDATE() AS DATE) THEN 'Activo'
--            WHEN c.FechaCirugia > CAST(GETDATE() AS DATE) THEN 'Pendiente'
--            ELSE 'Finalizada'
--        END AS Estado
--    FROM Cirugias c
--    JOIN Pacientes p ON c.IdPaciente = p.IdPaciente;
--END
------------------------------------

