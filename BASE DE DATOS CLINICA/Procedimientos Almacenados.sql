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
CREATE PROCEDURE RegistrarHospitalizacion
    @NombrePaciente NVARCHAR(100),
    @DNIPaciente INT,
    @IdEstadia INT,
    @IdHabitacion INT,
    @IdCamilla INT = NULL,
    @FechaIngreso DATETIME,
    @HoraIngreso TIME
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdPaciente INT;

    -- Verificar si el paciente ya existe
    IF EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNIPaciente)
    BEGIN
        -- Obtener el ID del paciente existente
        SELECT @IdPaciente = IdPaciente FROM Pacientes WHERE DNI = @DNIPaciente;
    END
    ELSE
    BEGIN
        -- Insertar el nuevo paciente
        INSERT INTO Pacientes (Nombre, DNI)
        VALUES (@NombrePaciente, @DNIPaciente);

        -- Obtener el ID del nuevo paciente
        SELECT @IdPaciente = SCOPE_IDENTITY();
    END

    -- Insertar la hospitalización
    INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, FechaIngreso, HoraIngreso)
VALUES (@IdPaciente, @IdEstadia, @IdHabitacion, @IdCamilla, @FechaIngreso, @HoraIngreso);

    -- Devolver el ID de la nueva hospitalización
    SELECT SCOPE_IDENTITY() AS IdHospitalizacion;
END
go

-- Procedimiento almacenado para actualizar hospitalización
CREATE PROCEDURE usp_ActualizarHospitalizacion
    @IdHospitalizacion INT,
    @FechaSalida DATE,
    @HoraSalida TIME
AS
BEGIN

    UPDATE Hospitalizaciones
    SET IdPaciente = @IdPaciente,
        IdEstadia = @IdEstadia,
        IdHabitacion = @IdHabitacion,
        IdCamilla = @IdCamilla,
        IdMedico = @IdMedico,
        FechaIngreso = @FechaIngreso,
        FechaSalida = @FechaSalida,
        Estado = @Estado
    WHERE IdHospitalizacion = @IdHospitalizacion;

    SELECT @@ROWCOUNT AS RowsAffected;
END
----------------------------------
CREATE PROCEDURE usp_AgregarCirugia
    @TipoCirugia NVARCHAR(100),
    @IdPaciente INT,
    @NombrePaciente NVARCHAR(100),
    @Sala NVARCHAR(50),
    @Turno NVARCHAR(20),
    @FechaCirugia DATETIME
AS
BEGIN
    INSERT INTO Cirugias (TipoCirugia, IdPaciente, NombrePaciente, Sala, Turno, FechaCirugia)
    VALUES (@TipoCirugia, @IdPaciente, @NombrePaciente, @Sala, @Turno, @FechaCirugia);
END
----------------------------------
CREATE PROCEDURE usp_ObtenerCirugias
AS
BEGIN
    SELECT c.IdCirugia, c.TipoCirugia, p.Nombre AS NombrePaciente, c.Sala, c.Turno, c.FechaCirugia
    FROM Cirugias c
    INNER JOIN Pacientes p ON c.IdPaciente = p.IdPaciente;
END
----------------------------------
CREATE PROCEDURE usp_ObtenerCirugiasConEstado
AS
BEGIN
    SELECT 
        c.IdCirugia, 
        c.TipoCirugia, 
        p.Nombre AS Paciente, 
        c.Sala, 
        c.FechaCirugia,
        CASE 
            WHEN c.FechaCirugia = CAST(GETDATE() AS DATE) THEN 'Activo'
            WHEN c.FechaCirugia > CAST(GETDATE() AS DATE) THEN 'Pendiente'
            ELSE 'Finalizada'
        END AS Estado
    FROM Cirugias c
    JOIN Pacientes p ON c.IdPaciente = p.IdPaciente;
END
----------------------------------

