use Clinica

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

-- Procedimiento almacenado para obtener permisos de usuario
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

-- Procedimiento almacenado para actualizar usuario
CREATE PROCEDURE usp_ActualizarUsuario
    @IdUsuario INT,
    @Nombres NVARCHAR(100),
    @Usuario NVARCHAR(50),
    @IdRol INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE USUARIOS
        SET Nombres = @Nombres,
            Usuario = @Usuario,
            IdRol = @IdRol
        WHERE IdUsuario = @IdUsuario;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO

-- Procedimiento almacenado para registrar hospitalización
CREATE PROCEDURE usp_RegistrarHospitalizacion
    @IdPaciente INT,
    @IdEstadia INT,
    @IdHabitacion INT,
    @IdCamilla INT,
    @IdMedico INT,
    @FechaIngreso DATE,
    @HoraIngreso TIME,
    @IdHospitalizacion INT OUTPUT
AS
BEGIN
    INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdMedico, FechaIngreso, HoraIngreso)
    VALUES (@IdPaciente, @IdEstadia, @IdHabitacion, @IdCamilla, @IdMedico, @FechaIngreso, @HoraIngreso);

    SET @IdHospitalizacion = SCOPE_IDENTITY();
END;
GO

-- Procedimiento almacenado para actualizar hospitalización
CREATE PROCEDURE usp_ActualizarHospitalizacion
    @IdHospitalizacion INT,
    @FechaSalida DATE,
    @HoraSalida TIME
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Hospitalizaciones
        SET FechaSalida = @FechaSalida, HoraSalida = @HoraSalida
        WHERE IdHospitalizacion = @IdHospitalizacion;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO