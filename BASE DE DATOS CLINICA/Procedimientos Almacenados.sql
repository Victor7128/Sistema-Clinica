use Clinica
GO

CREATE PROCEDURE usp_ObtenerUsuarios
AS
BEGIN
    SELECT Nombres, Usuario, Clave, IdRol, Activo FROM USUARIOS;
END;
GO

CREATE PROCEDURE usp_ObtenerRoles
AS
BEGIN
    SELECT IdRol, Nombre, Activo FROM ROL;
END;
GO

CREATE PROCEDURE usp_ObtenerUsuariosConRoles
AS
BEGIN
    SELECT u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
    FROM USUARIOS u
    INNER JOIN ROL r ON u.IdRol = r.IdRol;
END;
GO

CREATE PROCEDURE usp_BuscarUsuarios
    @nombre NVARCHAR(50)
AS
BEGIN
    SELECT u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
    FROM USUARIOS u
    INNER JOIN ROL r ON u.IdRol = r.IdRol
    WHERE u.Nombres LIKE '%' + @nombre + '%';
END;
GO

CREATE PROCEDURE usp_BuscarNombre
@Usuario VARCHAR(100),
@Clave VARCHAR(100)
AS 
BEGIN
	SELECT DISTINCT Nombres  FROM USUARIOS WHERE Usuario = @Usuario AND Clave = @Clave
END
GO

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

CREATE PROCEDURE usp_MantenedorUsuarios
    @Nombres VARCHAR(50) = NULL,
    @Usuario VARCHAR(50) = NULL,
    @Clave VARCHAR(50) = NULL,
    @IdRol INT = NULL,
    @Activo BIT = 1,
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF (@accion = '1')
    BEGIN
        INSERT INTO USUARIOS (Nombres, Usuario, Clave, IdRol, Activo)
        VALUES (@Nombres, @Usuario, @Clave, @IdRol, @Activo);
    END
    ELSE IF (@accion = '2')
    BEGIN
        IF @Nombres IS NOT NULL
        BEGIN
            UPDATE USUARIOS
            SET Usuario = @Usuario,
                Clave = @Clave,
                IdRol = @IdRol,
                Activo = @Activo
            WHERE Nombres = @Nombres;
        END
    END
    ELSE IF (@accion = '3')
    BEGIN
        IF @Nombres IS NOT NULL
        BEGIN
            DELETE FROM USUARIOS
            WHERE Nombres = @Nombres;
        END
    END
END;
GO

CREATE PROCEDURE sp_listar_tipo_habitacion
AS
BEGIN
    SELECT IdTipoHabitacion, Nombre
	FROM TipoHabitacion;
END
GO

CREATE PROCEDURE sp_listar_habitaciones
@IdTipoHabitacion INT
AS
BEGIN
    SELECT IdHabitacion, Nombre
	FROM Habitaciones
	WHERE IdTipoHabitacion = @IdTipoHabitacion
	AND Ocupado = 0;
END
GO 

CREATE PROCEDURE sp_listar_camillas
@IdHabitacion INT
AS
BEGIN
    SELECT IdCamilla, Nombre
	FROM Camillas
	WHERE IdHabitacion = @IdHabitacion
	AND Ocupado = 0;
END
GO 

CREATE PROCEDURE sp_listar_camillas_todas
@IdHabitacion INT
AS
BEGIN
    SELECT IdCamilla, Nombre
	FROM Camillas
	WHERE IdHabitacion = @IdHabitacion
END
GO 

CREATE PROCEDURE sp_listar_estadias
AS
BEGIN
	SELECT IdEstadia, Nombre
	FROM Estadias
END
GO

ALTER PROCEDURE sp_ListarPacientesHospitalizados
AS
BEGIN
    SET NOCOUNT ON;
	SELECT
		p.Codigo,
		p.Nombre AS Paciente,
		p.DNI,
		p.FechaNacimiento,
		p.Telefono,
		p.Direccion,
		G.Nombre AS Genero,
		th.Nombre AS TipoHabitacion,
		h.Nombre AS Habitacion,        
		c.Nombre AS Camilla,
		e.Nombre AS Estadia,
		u.Nombres AS MedicoAsignado,
		ci.Descripcion AS Cirugia,
		ci.FechaCirugia,
		ho.FechaIngreso,
		ho.HoraIngreso
	FROM 
		Hospitalizaciones ho
	INNER JOIN 
		Pacientes p ON p.IdPaciente = ho.IdPaciente
	LEFT JOIN 
		Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
	LEFT JOIN 
		TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
	LEFT JOIN 
		Camillas c ON c.IdCamilla = ho.IdCamilla AND c.IdHabitacion = h.IdHabitacion
	LEFT JOIN
		Estadias e ON e.IdEstadia = ho.IdEstadia
	LEFT JOIN 
		Cirugias ci ON ci.IdPaciente = ho.IdPaciente
	LEFT JOIN 
		Usuarios u ON u.IdUsuario = ci.IdUsuario
	LEFT JOIN 
		Genero G ON G.IdGenero = p.IdGenero;
	SET NOCOUNT OFF;
END;
GO

CREATE PROCEDURE sp_BuscarPacientesConsulta
    @nombre VARCHAR(50)
AS
BEGIN
    SELECT 
        p.Nombre, 
        p.DNI, 
        th.Nombre AS TipoHabitacion,
        h.Nombre AS Habitacion, 
        c.Nombre AS Camilla,
		u.Nombres AS MedicoAsignado,
        ho.FechaIngreso, 
        ho.HoraIngreso
    FROM 
        Hospitalizaciones ho 
    INNER JOIN 
        Pacientes p ON p.IdPaciente = ho.IdPaciente
    LEFT JOIN 
        Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
    LEFT JOIN 
        TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
    LEFT JOIN 
        Camillas c ON c.IdCamilla = ho.IdCamilla
    LEFT JOIN 
        Cirugias ci ON ci.IdCirugia = ho.IdCirugia
    LEFT JOIN 
        Usuarios u ON u.IdUsuario = ci.IdUsuario
    WHERE 
        @nombre IS NULL OR p.Nombre LIKE '%' + @nombre + '%';
END;
GO

CREATE PROCEDURE sp_listar_pacientes_consultas
AS
BEGIN
    SELECT 
        p.Nombre, 
        p.DNI, 
        th.Nombre AS TipoHabitacion,
        h.Nombre AS Habitacion, 
        c.Nombre AS Camilla,
        u.Nombres AS MedicoAsignado,
        ho.FechaIngreso, 
        ho.HoraIngreso
    FROM 
        Hospitalizaciones ho 
    INNER JOIN 
        Pacientes p ON p.IdPaciente = ho.IdPaciente
    LEFT JOIN 
        Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
    LEFT JOIN 
        TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
    LEFT JOIN 
        Camillas c ON c.IdCamilla = ho.IdCamilla
    LEFT JOIN 
        Cirugias ci ON ci.IdCirugia = ho.IdCirugia
    LEFT JOIN 
        Usuarios u ON u.IdUsuario = ci.IdUsuario;
END;
GO

CREATE PROCEDURE sp_BuscarPacientes
    @nombre NVARCHAR(50)
AS
BEGIN
    SELECT 
        p.Codigo, 
        p.Nombre AS Paciente, 
        p.DNI, 
        p.FechaNacimiento, 
        p.Telefono, 
        p.Direccion, 
        h.Nombre AS Habitacion, 
        th.Nombre AS TipoHabitacion, 
        c.Nombre AS Camilla, 
        u.Nombres AS MedicoAsignado, 
        ci.Descripcion AS Cirugia, 
        ci.FechaCirugia, 
        ho.FechaIngreso, 
        ho.HoraIngreso, 
        ho.FechaSalida, 
        ho.HoraSalida
    FROM 
        Hospitalizaciones ho
    INNER JOIN 
        Pacientes p ON p.IdPaciente = ho.IdPaciente
    LEFT JOIN 
        Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
    LEFT JOIN 
        Camillas c ON c.IdCamilla = ho.IdCamilla
    LEFT JOIN 
        Cirugias ci ON ci.IdCirugia = ho.IdCirugia
    LEFT JOIN 
        Usuarios u ON u.IdUsuario = ci.IdUsuario
    LEFT JOIN 
        Estadias e ON e.IdEstadia = ho.IdEstadia
    LEFT JOIN 
        TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
    WHERE 
        p.Nombre LIKE '%' + @nombre + '%';
END;
GO 
-----------------------
CREATE PROCEDURE sp_insertar_paciente_hospitalizacion
    @nombre VARCHAR(100),
    @DNI INT,
    @FechaNacimiento DATE,
    @Telefono INT,
    @Direccion VARCHAR(100),
    @Genero INT,
    @TipoHabitacion INT,
    @Habitacion INT,
    @Camilla INT,
    @Estadia INT,
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI)
    BEGIN
        -- Generar código único para el paciente
        DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
        SET @codmax = (SELECT MAX(Codigo) FROM Pacientes);
        SET @codmax = ISNULL(@codmax, 'P0000');
        SET @codnuevo = 'P' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR(4)), 4);

        -- Insertar nuevo paciente
        INSERT INTO Pacientes (Codigo, Nombre, DNI, FechaNacimiento, Telefono, Direccion, IdGenero)
        VALUES (@codnuevo, @nombre, @DNI, @FechaNacimiento, @Telefono, @Direccion, @Genero);

        DECLARE @IdPaciente INT = SCOPE_IDENTITY();

        -- Insertar hospitalización
        INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdTipoHabitacion, FechaIngreso, HoraIngreso)
        VALUES (@IdPaciente, @Estadia, @Habitacion, @Camilla, @TipoHabitacion, CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME));

        -- Marcar la camilla como ocupada
        UPDATE Camillas
        SET Ocupado = 1
        WHERE IdCamilla = @Camilla;

        SET @accion = 'Se agregó el paciente: ' + @nombre;
    END
    ELSE
    BEGIN
        SET @accion = 'DNI_EXISTE';
    END

    SET NOCOUNT OFF;
END;
GO

CREATE PROCEDURE sp_modificar_paciente_hospitalizacion
    @codigo VARCHAR(5),
    @nombre VARCHAR(100),
    @DNI INT,
    @FechaNacimiento DATE,
    @Telefono INT,
    @Direccion VARCHAR(100),
    @Genero INT,
    @TipoHabitacion INT,
    @Habitacion INT,
    @Camilla INT,
    @Estadia INT,
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI AND Codigo <> @codigo)
    BEGIN
        -- Obtener datos actuales de hospitalización
        DECLARE @IdPaciente INT = (SELECT ho.IdPaciente
                                   FROM Hospitalizaciones ho
                                   INNER JOIN Pacientes p ON p.IdPaciente = ho.IdPaciente
                                   WHERE p.Codigo = @codigo);

        -- Si se cambia la camilla, actualizar estado de ocupación
        IF @Camilla <> (SELECT IdCamilla FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente)
        BEGIN
            DECLARE @IdCamillaAnterior INT = (SELECT IdCamilla FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente);

            UPDATE Camillas
            SET Ocupado = 0
            WHERE IdCamilla = @IdCamillaAnterior;

            UPDATE Camillas
            SET Ocupado = 1
            WHERE IdCamilla = @Camilla;
        END

        -- Actualizar datos del paciente
        UPDATE Pacientes 
        SET Nombre = @nombre, 
            DNI = @DNI, 
            FechaNacimiento = @FechaNacimiento, 
            Telefono = @Telefono, 
            Direccion = @Direccion, 
            IdGenero = @Genero
        WHERE Codigo = @codigo;

        -- Actualizar datos de hospitalización
        UPDATE Hospitalizaciones
        SET IdEstadia = @Estadia,
            IdHabitacion = @Habitacion,
            IdCamilla = @Camilla,
            IdTipoHabitacion = @TipoHabitacion
        WHERE IdPaciente = @IdPaciente;

        SET @accion = 'Se modificó el paciente: ' + @nombre;
    END
    ELSE
    BEGIN
        SET @accion = 'DNI_EXISTE';
    END

    SET NOCOUNT OFF;
END;
GO

CREATE PROCEDURE sp_registrar_salida_hospitalizacion
    @codigo VARCHAR(5),
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Obtener datos para insertar en HistorialSalidaPacientes
    DECLARE @IdPaciente INT, @IdCamilla INT;

    SELECT @IdPaciente = p.IdPaciente, @IdCamilla = ho.IdCamilla
    FROM Pacientes p
    INNER JOIN Hospitalizaciones ho ON ho.IdPaciente = p.IdPaciente
    WHERE p.Codigo = @codigo;

    -- Actualizar hospitalización con fecha y hora de salida
    UPDATE Hospitalizaciones
    SET FechaSalida = CAST(GETDATE() AS DATE),
        HoraSalida = CAST(GETDATE() AS TIME)
    WHERE IdPaciente = @IdPaciente;

    -- Insertar registro en HistorialSalidaPacientes
    INSERT INTO HistorialSalidaPacientes (
        Paciente, DNI, FechaNacimiento, Telefono, Direccion, Genero,
        TipoHabitacion, Habitacion, Camilla, Estadia, 
        MedicoAsignado, Cirugia, FechaCirugia, HoraCirugia,
        CirugiaEntrada, CirugiaSalida, SalaCirugia, 
        FechaEntradaHospitalizacion, HoraEntradaHospitalizacion,
        FechaSalidaHospitalizacion, HoraSalidaHospitalizacion
    )
    SELECT
        p.Nombre AS Paciente,
        p.DNI,
        p.FechaNacimiento,
        p.Telefono,
        p.Direccion,
        G.Nombre AS Genero,
        th.Nombre AS TipoHabitacion,
        h.Nombre AS Habitacion,        
        c.Nombre AS Camilla,
        e.Nombre AS Estadia,
        u.Nombres AS MedicoAsignado,
        ci.Descripcion AS Cirugia,
        ci.FechaCirugia,
        ci.HoraCirugia,
        ci.HoraEntrada AS CirugiaEntrada,
        ci.HoraSalida AS CirugiaSalida,
        sc.Nombre AS SalaCirugia,
        ho.FechaIngreso AS FechaEntradaHospitalizacion,
        ho.HoraIngreso AS HoraEntradaHospitalizacion,
        ho.FechaSalida AS FechaSalidaHospitalizacion,
        ho.HoraSalida AS HoraSalidaHospitalizacion
    FROM 
        Hospitalizaciones ho
    INNER JOIN 
        Pacientes p ON p.IdPaciente = ho.IdPaciente
    LEFT JOIN 
        Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
    LEFT JOIN 
        TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
    LEFT JOIN 
        Camillas c ON c.IdCamilla = ho.IdCamilla AND c.IdHabitacion = h.IdHabitacion
    LEFT JOIN
        Estadias e ON e.IdEstadia = ho.IdEstadia
    LEFT JOIN 
        Cirugias ci ON ci.IdPaciente = ho.IdPaciente
    LEFT JOIN 
        Usuarios u ON u.IdUsuario = ci.IdUsuario
    LEFT JOIN 
        Genero G ON G.IdGenero = p.IdGenero
    LEFT JOIN
        SalaCirugia sc ON sc.IdSala = ci.IdSala
    WHERE p.Codigo = @codigo;

    -- Marcar camilla como desocupada
    UPDATE Camillas
    SET Ocupado = 0
    WHERE IdCamilla = @IdCamilla;

    -- Eliminar cirugías relacionadas
    DELETE FROM Cirugias WHERE IdPaciente = @IdPaciente;

    -- Eliminar hospitalización
    DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente;

    -- Eliminar paciente
    DELETE FROM Pacientes WHERE IdPaciente = @IdPaciente;

    SET @accion = 'Se registró la salida y se eliminó al paciente de Hospitalización.';
    
    SET NOCOUNT OFF;
END;
GO

CREATE PROCEDURE sp_eliminar_paciente
    @codigo VARCHAR(5),
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Obtener IdPaciente para eliminación
    DECLARE @IdPaciente INT = (SELECT IdPaciente FROM Pacientes WHERE Codigo = @codigo);

    -- Eliminar cirugías relacionadas
    DELETE FROM Cirugias WHERE IdPaciente = @IdPaciente;

    -- Eliminar hospitalización
    DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente;

    -- Eliminar paciente
    DELETE FROM Pacientes WHERE Codigo = @codigo;

    SET @accion = 'Se borró el paciente con código: ' + @codigo;

    SET NOCOUNT OFF;
END;
GO

--CREATE PROCEDURE sp_mantenedor_pacientes
--    @codigo VARCHAR(5),
--    @nombre VARCHAR(100),
--    @DNI INT,
--    @FechaNacimiento DATE,
--    @Telefono INT,
--    @Direccion VARCHAR(100),
--    @Genero INT,
--    @TipoHabitacion INT,
--    @Habitacion INT,
--    @Camilla INT,
--    @Estadia INT,
--    @accion VARCHAR(50) OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    DECLARE @IdPaciente INT = 0;
--    DECLARE @IdCamilla INT = 0;

--    IF (@accion = '1') -- Insertar paciente y hospitalización
--    BEGIN
--        IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI)
--        BEGIN
--            -- Generar código único para el paciente
--            DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
--            SET @codmax = (SELECT MAX(Codigo) FROM Pacientes);
--            SET @codmax = ISNULL(@codmax, 'P0000');
--            SET @codnuevo = 'P' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR(4)), 4);

--            -- Insertar nuevo paciente
--            INSERT INTO Pacientes (Codigo, Nombre, DNI, FechaNacimiento, Telefono, Direccion, IdGenero)
--            VALUES (@codnuevo, @nombre, @DNI, @FechaNacimiento, @Telefono, @Direccion, @Genero);

--            SET @IdPaciente = SCOPE_IDENTITY();

--            -- Insertar hospitalización
--            INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdTipoHabitacion, FechaIngreso, HoraIngreso)
--            VALUES (@IdPaciente, @Estadia, @Habitacion, @Camilla, @TipoHabitacion, CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME));

--            -- Marcar la camilla como ocupada
--            UPDATE Camillas
--            SET Ocupado = 1
--            WHERE IdCamilla = @Camilla;

--            SET @accion = 'Se agregó el paciente: ' + @nombre;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'DNI_EXISTE';
--        END
--    END
--    ELSE IF (@accion = '2') -- Modificar paciente y hospitalización
--    BEGIN
--        IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI AND Codigo <> @codigo)
--        BEGIN
--            -- Obtener datos actuales de hospitalización
--            SELECT @IdPaciente = ho.IdPaciente
--            FROM Hospitalizaciones ho
--            INNER JOIN Pacientes p ON p.IdPaciente = ho.IdPaciente
--            WHERE p.Codigo = @codigo;

--            -- Si se cambia la camilla, actualizar estado de ocupación
--            IF @Camilla <> (SELECT IdCamilla FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente)
--            BEGIN
--                SET @IdCamilla = (SELECT IdCamilla FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente);

--                UPDATE Camillas
--                SET Ocupado = 0
--                WHERE IdCamilla = @IdCamilla;

--                UPDATE Camillas
--                SET Ocupado = 1
--                WHERE IdCamilla = @Camilla;
--            END

--            -- Actualizar datos del paciente
--            UPDATE Pacientes 
--            SET Nombre = @nombre, 
--                DNI = @DNI, 
--                FechaNacimiento = @FechaNacimiento, 
--                Telefono = @Telefono, 
--                Direccion = @Direccion, 
--                IdGenero = @Genero
--            WHERE Codigo = @codigo;

--            -- Actualizar datos de hospitalización
--            UPDATE Hospitalizaciones
--            SET IdEstadia = @Estadia,
--                IdHabitacion = @Habitacion,
--                IdCamilla = @Camilla,
--                IdTipoHabitacion = @TipoHabitacion
--            WHERE IdPaciente = @IdPaciente;

--            SET @accion = 'Se modificó el paciente: ' + @nombre;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'DNI_EXISTE';
--        END
--    END
--    ELSE IF (@accion = '3') -- Registrar salida de hospitalización
--    BEGIN
--        -- Obtener datos para insertar en HistorialSalidaPacientes
--        SELECT @IdPaciente = p.IdPaciente, @IdCamilla = ho.IdCamilla
--        FROM Pacientes p
--        INNER JOIN Hospitalizaciones ho ON ho.IdPaciente = p.IdPaciente
--        WHERE p.Codigo = @codigo;

--		UPDATE Hospitalizaciones
--            SET FechaSalida = CAST(GETDATE() AS DATE),
--				HoraSalida = CAST(GETDATE() AS TIME)
--            WHERE IdPaciente = @IdPaciente;

--        -- Insertar registro en HistorialSalidaPacientes
--        INSERT INTO HistorialSalidaPacientes (
--            Paciente, DNI, FechaNacimiento, Telefono, Direccion, Genero,
--            TipoHabitacion, Habitacion, Camilla, Estadia, 
--            MedicoAsignado, Cirugia, FechaCirugia, HoraCirugia,
--            CirugiaEntrada, CirugiaSalida, SalaCirugia, 
--            FechaEntradaHospitalizacion, HoraEntradaHospitalizacion,
--            FechaSalidaHospitalizacion, HoraSalidaHospitalizacion
--        )
--		SELECT
--			p.Nombre AS Paciente,
--			p.DNI,
--			p.FechaNacimiento,
--			p.Telefono,
--			p.Direccion,
--			G.Nombre AS Genero,
--			th.Nombre AS TipoHabitacion,
--			h.Nombre AS Habitacion,        
--			c.Nombre AS Camilla,
--			e.Nombre AS Estadia,
--			u.Nombres AS MedicoAsignado,
--			ci.Descripcion AS Cirugia,
--			ci.FechaCirugia,
--			ci.HoraCirugia,
--			ci.HoraEntrada AS CirugiaEntrada,
--			ci.HoraSalida AS CirugiaSalida,
--			sc.Nombre AS SalaCirugia,
--			ho.FechaIngreso AS FechaEntradaHospitalizacion,
--			ho.HoraIngreso AS HoraEntradaHospitalizacion,
--			ho.FechaSalida AS FechaSalidaHospitalizacion,
--			ho.HoraSalida AS HoraSalidaHospitalizacion
--		FROM 
--			Hospitalizaciones ho
--		INNER JOIN 
--			Pacientes p ON p.IdPaciente = ho.IdPaciente
--		LEFT JOIN 
--			Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
--		LEFT JOIN 
--			TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
--		LEFT JOIN 
--			Camillas c ON c.IdCamilla = ho.IdCamilla AND c.IdHabitacion = h.IdHabitacion
--		LEFT JOIN
--			Estadias e ON e.IdEstadia = ho.IdEstadia
--		LEFT JOIN 
--			Cirugias ci ON ci.IdPaciente = ho.IdPaciente
--		LEFT JOIN 
--			Usuarios u ON u.IdUsuario = ci.IdUsuario
--		LEFT JOIN 
--			Genero G ON G.IdGenero = p.IdGenero
--		LEFT JOIN
--			SalaCirugia sc ON sc.IdSala = ci.IdSala
--        WHERE p.Codigo = @codigo;

--        -- Marcar camilla como desocupada
--        UPDATE Camillas
--        SET Ocupado = 0
--        WHERE IdCamilla = @IdCamilla;

--        -- Eliminar cirugías relacionadas
--        DELETE FROM Cirugias WHERE IdPaciente = @IdPaciente;

--        -- Eliminar hospitalización
--        DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente;

--        -- Eliminar paciente
--        DELETE FROM Pacientes WHERE IdPaciente = @IdPaciente;

--        SET @accion = 'Se registró la salida y se eliminó al paciente de Hospitalización: ' + @nombre;
--    END
--    ELSE IF (@accion = '4') -- Eliminar paciente
--    BEGIN
--        -- Obtener IdPaciente
--        SELECT @IdPaciente = p.IdPaciente
--        FROM Pacientes p
--        WHERE p.Codigo = @codigo;

--        -- Eliminar cirugías relacionadas
--        DELETE FROM Cirugias WHERE IdPaciente = @IdPaciente;

--        -- Eliminar hospitalización
--        DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente;

--        -- Eliminar paciente
--        DELETE FROM Pacientes WHERE Codigo = @codigo;

--        SET @accion = 'Se borró el paciente: ' + @nombre;
--    END

--    SET NOCOUNT OFF;
--END;


--EXEC sp_mantenedor_pacientes
--    @codigo = NULL,
--    @nombre = 'Pedro',
--    @DNI = 87654321,
--    @FechaNacimiento = '1985-08-20',
--    @Telefono = 654321987,
--    @Direccion = 'Avenida B #456',
--    @Genero = 2,
--    @TipoHabitacion = 2,
--    @Habitacion = 11,
--    @Camilla = 21,
--    @Estadia = 2,
--    @accion = '1';
--GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Ana',
    @DNI = 13579246,
    @FechaNacimiento = '1988-03-10',
    @Telefono = 789456123,
    @Direccion = 'Plaza C #789',
    @Genero = 1,
    @TipoHabitacion = 3,
    @Habitacion = 22,
    @Camilla = 34,
    @Estadia = 3,
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Juan',
    @DNI = 24681357,
    @FechaNacimiento = '1995-11-25',
    @Telefono = 456123789,
    @Direccion = 'Calle D #321',
    @Genero = 2,
    @TipoHabitacion = 4,
    @Habitacion = 1,
    @Camilla = 2,
    @Estadia = 7,
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Luisa',
    @DNI = 98765432,
    @FechaNacimiento = '1983-07-12',
    @Telefono = 321654987,
    @Direccion = 'Avenida E #654',
    @Genero = 1,
    @TipoHabitacion = 1,
    @Habitacion = 33,
    @Camilla = 53,
    @Estadia = 5,
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Luis',
    @DNI = 11111111,
    @FechaNacimiento = '1992-06-25',
    @Telefono = 123456789,
    @Direccion = 'Av. Principal #111',
    @Genero = 2,
    @TipoHabitacion = 2,  -- Tipo de habitación con ventilador
    @Habitacion = 12,     -- Habitación específica del tipo 2
    @Camilla = 22,        -- Camilla específica de la habitación 12
    @Estadia = 5,         -- Estadía de 5 días
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Laura',
    @DNI = 22222222,
    @FechaNacimiento = '1987-09-12',
    @Telefono = 234567890,
    @Direccion = 'Calle Secundaria #222',
    @Genero = 1,
    @TipoHabitacion = 4,  -- Habitación compartida con ventilador
    @Habitacion = 5,      -- Habitación específica del tipo 4
    @Camilla = 10,        -- Camilla específica de la habitación 5
    @Estadia = 3,         -- Estadía de 3 días
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Carlos',
    @DNI = 33333333,
    @FechaNacimiento = '1980-04-18',
    @Telefono = 345678901,
    @Direccion = 'Plaza Principal #333',
    @Genero = 2,
    @TipoHabitacion = 3,  -- Habitación compartida con AC
    @Habitacion = 23,     -- Habitación específica del tipo 3
    @Camilla = 35,        -- Camilla específica de la habitación 23
    @Estadia = 4,         -- Estadía de 4 días
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Marta',
    @DNI = 44444444,
    @FechaNacimiento = '1998-01-30',
    @Telefono = 456789012,
    @Direccion = 'Av. Central #444',
    @Genero = 1,
    @TipoHabitacion = 1,  -- Habitación privada con AC
    @Habitacion = 33,     -- Habitación específica del tipo 1
    @Camilla = 53,        -- Camilla específica de la habitación 33
    @Estadia = 6,         -- Estadía de 6 días
    @accion = '1';
GO

EXEC sp_insertar_paciente_hospitalizacion
    @nombre = 'Pablo',
    @DNI = 55555555,
    @FechaNacimiento = '1993-07-05',
    @Telefono = 567890123,
    @Direccion = 'Calle Tranquila #555',
    @Genero = 2,
    @TipoHabitacion = 2,  -- Habitación con ventilador
    @Habitacion = 13,     -- Habitación específica del tipo 2
    @Camilla = 23,        -- Camilla específica de la habitación 13
    @Estadia = 5,         -- Estadía de 5 días
    @accion = '1';
GO
-------------------------------

CREATE PROCEDURE sp_listar_genero
as
Begin
	select IdGenero, Nombre from Genero;
end
go

CREATE PROCEDURE sp_listar_roles
AS
	SELECT IdRol, Nombre FROM ROL
GO

CREATE PROCEDURE sp_buscar_rol
    @IdRol INT
AS
BEGIN
    SELECT 
        P.IdMenu,
        P.Activo AS Permiso,
        M.Nombre AS Menu
    FROM 
        PERMISO P
    INNER JOIN 
        MENU M ON P.IdMenu = M.IdMenu
    WHERE 
        P.IdRol = @IdRol
    ORDER BY 
        M.Nombre;
END
GO

CREATE PROCEDURE sp_modificar_permiso
    @IdRol INT,
    @IdMenu INT,
    @NuevoPermiso BIT
AS
BEGIN
    UPDATE PERMISO
    SET Activo = @NuevoPermiso
    WHERE IdRol = @IdRol AND IdMenu = @IdMenu;
END
GO

CREATE PROCEDURE sp_listarHistorial
AS
BEGIN
	SELECT * FROM HistorialSalidaPacientes
END
GO

CREATE PROCEDURE sp_BuscarHistorial
@DNI INT
AS
BEGIN
	SELECT * FROM HistorialSalidaPacientes WHERE DNI = @DNI
END
GO

CREATE PROCEDURE sp_listar_cirugias
AS 
BEGIN
    SELECT 
        P.IdPaciente,
        P.Nombre as Paciente,
        U.Nombres as MedicoAsignado,
        C.Descripcion as DescripcionCirugia,
        SC.Nombre as Sala,
        C.FechaCirugia,
        C.HoraCirugia,
        C.HoraEntrada as HoraEntradaSala,
        C.HoraSalida as HoraSalidaSala
    FROM
        Cirugias C
        INNER JOIN Pacientes P ON P.IdPaciente = C.IdPaciente
        LEFT JOIN USUARIOS U ON U.IdUsuario = C.IdUsuario
        LEFT JOIN SalaCirugia SC ON SC.IdSala = C.IdSala
    WHERE
        C.HoraSalida IS NULL OR C.HoraSalida = ''
END
GO

CREATE PROCEDURE sp_listarNombrePacientes
AS
BEGIN
    SELECT p.IdPaciente, p.Nombre AS Paciente 
    FROM Pacientes p
    LEFT JOIN Cirugias c ON p.IdPaciente = c.IdPaciente
    WHERE c.IdCirugia IS NULL;
END
GO

CREATE PROCEDURE sp_buscarPacientesNombre
    @Nombre VARCHAR(50)
AS
BEGIN
    SELECT p.IdPaciente, p.Nombre AS Paciente 
    FROM Pacientes p
    LEFT JOIN Cirugias c ON p.IdPaciente = c.IdPaciente
    WHERE (@Nombre IS NULL OR p.Nombre LIKE '%' + @Nombre + '%')
          AND c.IdCirugia IS NULL;
END
GO

CREATE PROCEDURE sp_listarSala
AS
BEGIN
	SELECT IdSala, Nombre FROM SalaCirugia
END
GO

CREATE PROCEDURE sp_buscarCirugiasDisponibles
    @Fecha DATE
AS
BEGIN
    SELECT
        C.FechaCirugia,
        C.HoraCirugia,
        SC.Nombre AS Sala
    FROM
        Cirugias C
        INNER JOIN SalaCirugia SC ON SC.IdSala = C.IdSala
    WHERE
        C.FechaCirugia = @Fecha
        AND (C.HoraEntrada IS NULL OR C.HoraSalida IS NULL)
END
GO

CREATE PROCEDURE sp_buscarMedico
AS
BEGIN
	SELECT IdUsuario, Nombres
	FROM USUARIOS
	WHERE IdRol = 3
END
GO

CREATE PROCEDURE sp_mantenedorCirugias
    @IdUsuario INT,
    @IdPaciente INT,
    @Descripcion VARCHAR(200),
    @FechaCirugia DATE,
    @HoraCirugia TIME,
    @IdSala INT,
    @accion VARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @IdCirugia INT;

    IF (@accion = '1')
    BEGIN
        IF EXISTS (SELECT IdPaciente FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente)
        BEGIN
            INSERT INTO Cirugias (IdUsuario, IdPaciente, Descripcion, FechaCirugia, HoraCirugia, IdSala)
            VALUES (@IdUsuario, @IdPaciente, @Descripcion, @FechaCirugia, @HoraCirugia, @IdSala);

            SET @IdCirugia = SCOPE_IDENTITY();
            SET @accion = 'Se registró la cirugía para el paciente: ' + (SELECT Nombre FROM Pacientes WHERE IdPaciente = @IdPaciente);
        END
        ELSE
        BEGIN
            SET @accion = 'PACIENTE NO ENCONTRADO';
        END
    END
    ELSE IF (@accion = '2')
    BEGIN
        IF EXISTS (SELECT IdPaciente FROM Pacientes WHERE IdPaciente = @IdPaciente)
        BEGIN
            UPDATE Cirugias
            SET Descripcion = @Descripcion,
                FechaCirugia = @FechaCirugia,
                HoraCirugia = @HoraCirugia,
                IdSala = @IdSala
            WHERE IdPaciente = @IdPaciente;

            SET @accion = 'Se modificó la cirugía del paciente: ' + (SELECT Nombre FROM Pacientes WHERE IdPaciente = @IdPaciente);
        END
        ELSE
        BEGIN
            SET @accion = 'PACIENTE NO ENCONTRADO';
        END
    END
    ELSE IF (@accion = '3')
    BEGIN
        IF EXISTS (SELECT IdPaciente FROM Pacientes WHERE IdPaciente = @IdPaciente)
        BEGIN
            UPDATE Cirugias
            SET HoraEntrada = GETDATE()
			WHERE IdPaciente = @IdPaciente;

            UPDATE SalaCirugia
            SET Ocupado = 1
            WHERE IdSala = (SELECT IdSala FROM Cirugias WHERE IdPaciente = @IdPaciente);

            SET @accion = 'Registrada la hora de ENTRADA a sala para el paciente ' + (SELECT Nombre FROM Pacientes WHERE IdPaciente = @IdPaciente);
        END
        ELSE
        BEGIN
            SET @accion = 'PACIENTE NO ENCONTRADO';
        END
    END
    ELSE IF (@accion = '4')
    BEGIN
        IF EXISTS (SELECT IdPaciente FROM Pacientes WHERE IdPaciente = @IdPaciente)
        BEGIN
            UPDATE Cirugias
            SET HoraSalida = GETDATE()
            WHERE IdPaciente = @IdPaciente;

            UPDATE SalaCirugia
            SET Ocupado = 0
            WHERE IdSala = @IdSala;

            SET @accion = 'Registrada la hora de SALIDA de sala para el paciente ' + (SELECT Nombre FROM Pacientes WHERE IdPaciente = @IdPaciente);
        END
        ELSE
        BEGIN
            SET @accion = 'PACIENTE NO ENCONTRADO';
        END
    END
    ELSE IF (@accion = '5')
    BEGIN
        IF EXISTS (SELECT IdPaciente FROM Pacientes WHERE IdPaciente = @IdPaciente)
        BEGIN
            DELETE FROM Cirugias
            WHERE IdPaciente = @IdPaciente;

            SET @accion = 'Se ha eliminado la cirugía para el paciente ' + (SELECT Nombre FROM Pacientes WHERE IdPaciente = @IdPaciente);
        END
        ELSE
        BEGIN
            SET @accion = 'PACIENTE NO ENCONTRADO';
        END
    END

    SET NOCOUNT OFF;
END;
GO