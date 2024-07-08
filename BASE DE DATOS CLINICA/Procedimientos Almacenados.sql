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
        -- Insertar nuevo usuario en la tabla USUARIOS
        INSERT INTO USUARIOS (Nombres, Usuario, Clave, IdRol, Activo)
        VALUES (@Nombres, @Usuario, @Clave, @IdRol, @Activo);
    END
    ELSE IF (@accion = '2')
    BEGIN
        -- Actualizar datos del usuario en la tabla USUARIOS por nombre
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
        -- Eliminar usuario de la tabla USUARIOS por nombre
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

CREATE PROCEDURE sp_ListarPacientesHospitalizados
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
		e.Nombre as Estadia,
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
        TipoHabitacion th ON th.IdTipoHabitacion = h.IdTipoHabitacion
    LEFT JOIN 
        Camillas c ON c.IdCamilla = ho.IdCamilla AND c.IdHabitacion = h.IdHabitacion
	LEFT JOIN
		Estadias e ON e.IdEstadia = ho.IdEstadia
    LEFT JOIN 
        Cirugias ci ON ci.IdCirugia = ho.IdCirugia
    LEFT JOIN 
        Usuarios u ON u.IdUsuario = ci.IdUsuario
	LEFT JOIN Genero G ON G.IdGenero = P.IdGenero;

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

CREATE PROCEDURE sp_mantenedor_pacientes
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

    DECLARE @IdPaciente INT = 0;
    DECLARE @IdHabitacionActual INT = 0;
    DECLARE @IdCamillaActual INT = 0;

    IF (@accion = '1')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI)
        BEGIN
            DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5);
            SET @codmax = (SELECT MAX(Codigo) FROM Pacientes);
            SET @codmax = ISNULL(@codmax, 'P0000');
            SET @codnuevo = 'P' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR(4)), 4);

            INSERT INTO Pacientes (Codigo, Nombre, DNI, FechaNacimiento, Telefono, Direccion, IdGenero)
            VALUES (@codnuevo, @nombre, @DNI, @FechaNacimiento, @Telefono, @Direccion, @Genero);

            SET @IdPaciente = SCOPE_IDENTITY();

            INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdTipoHabitacion, FechaIngreso, HoraIngreso)
            VALUES (@IdPaciente, @Estadia, @Habitacion, @Camilla, @TipoHabitacion, CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME));
            UPDATE Camillas
            SET Ocupado = 1
            WHERE IdCamilla = @Camilla;
            SET @accion = 'Se agregó el paciente: ' + @nombre;
        END
        ELSE
        BEGIN
            SET @accion = 'DNI_EXISTE';
        END
    END
    ELSE IF (@accion = '2')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI AND Codigo <> @codigo)
        BEGIN
            SELECT @IdPaciente = ho.IdPaciente, @IdHabitacionActual = ho.IdHabitacion, @IdCamillaActual = ho.IdCamilla
            FROM Hospitalizaciones ho
            INNER JOIN Pacientes p ON p.IdPaciente = ho.IdPaciente
            WHERE p.Codigo = @codigo;
            IF @IdCamillaActual <> @Camilla
            BEGIN
                UPDATE Camillas
                SET Ocupado = 0
                WHERE IdCamilla = @IdCamillaActual;
                UPDATE Camillas
                SET Ocupado = 1
                WHERE IdCamilla = @Camilla;
            END
            UPDATE Pacientes 
            SET Nombre = @nombre, 
                DNI = @DNI, 
                FechaNacimiento = @FechaNacimiento, 
                Telefono = @Telefono, 
                Direccion = @Direccion, 
                IdGenero = @Genero
            WHERE Codigo = @codigo;
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
    END
    ELSE IF (@accion = '3')
	BEGIN
		-- Obtener el IdPaciente
		SELECT @IdPaciente = p.IdPaciente
		FROM Pacientes p
		WHERE p.Codigo = @codigo;

		-- Capturar fecha y hora de salida de hospitalización
		DECLARE @FechaSalidaHospitalizacion DATE;
		DECLARE @HoraSalidaHospitalizacion TIME;

		SELECT @FechaSalidaHospitalizacion = CAST(GETDATE() AS DATE),
			   @HoraSalidaHospitalizacion = CAST(GETDATE() AS TIME);

		-- Actualizar datos de salida en Hospitalizaciones
		UPDATE Hospitalizaciones
		SET FechaSalida = @FechaSalidaHospitalizacion,
			HoraSalida = @HoraSalidaHospitalizacion
		WHERE IdPaciente = @IdPaciente;
		DECLARE @IdCamilla INT;

		SELECT @IdCamilla = ho.IdCamilla
		FROM Hospitalizaciones ho
		WHERE ho.IdPaciente = @IdPaciente;

		-- Mover los datos a HistorialSalidaPacientes
		INSERT INTO HistorialSalidaPacientes (Paciente, DNI, FechaNacimiento, Telefono, Direccion, Genero, 
			Habitacion, TipoHabitacion, Camilla, Estadia, MedicoAsignado, Cirugia, FechaCirugia, HoraCirugia,
			CirugiaEntrada, CirugiaSalida, SalaCirugia, FechaEntradaHospitalizacion, HoraEntradaHospitalizacion,
			FechaSalidaHospitalizacion, HoraSalidaHospitalizacion)
		SELECT
			p.Nombre AS Paciente,
			p.DNI,
			p.FechaNacimiento,
			p.Telefono,
			p.Direccion,
			g.Nombre as Genero,
			h.Nombre AS Habitacion,
			th.Nombre AS TipoHabitacion,
			c.Nombre AS Camilla,
			e.Nombre as Estadia,
			u.Nombres AS MedicoAsignado,
			ci.Descripcion AS Cirugia,
			ci.FechaCirugia,
			ci.HoraCirugia,
			ci.HoraEntrada as CirugiaEntrada,
			ci.HoraSalida as CirugiaSalida,
			sc.Nombre as SalaCirugia,
			ho.FechaIngreso as FechaEntradaHospitalizacion,
			ho.HoraIngreso as HoraEntradaHospitalizacion,
			@FechaSalidaHospitalizacion as FechaSalidaHospitalizacion,
			@HoraSalidaHospitalizacion as HoraSalidaHospitalizacion
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
			Cirugias ci ON ci.IdCirugia = ho.IdCirugia
		LEFT JOIN 
			Usuarios u ON u.IdUsuario = ci.IdUsuario
		LEFT JOIN
			SalaCirugia sc ON sc.IdSala = ci.IdSala
		LEFT JOIN 
			Genero g ON g.IdGenero = p.IdGenero
		WHERE p.Codigo = @codigo;
		UPDATE Camillas
		SET Ocupado = 0
		WHERE IdCamilla = @IdCamilla;
		DELETE FROM Cirugias WHERE IdPaciente = @IdPaciente;
		DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente;
		DELETE FROM Pacientes WHERE IdPaciente = @IdPaciente;

		SET @accion = 'Se registró la salida y se eliminó al paciente de Hospitalización: ' + @nombre;
	END
    ELSE IF (@accion = '4')
    BEGIN
        SELECT @IdPaciente = p.IdPaciente
        FROM Pacientes p
        WHERE p.Codigo = @codigo;

        DELETE FROM Cirugias WHERE IdPaciente = @IdPaciente;
        DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente;
        DELETE FROM Pacientes WHERE Codigo = @codigo;

        SET @accion = 'Se borró el paciente: ' + @nombre;
    END

    SET NOCOUNT OFF;
END;
GO
-------------------------------
EXEC sp_mantenedor_pacientes
    @codigo = NULL,
    @nombre = 'María',
    @DNI = 12345678,
    @FechaNacimiento = '1990-05-15',
    @Telefono = 987654321,
    @Direccion = 'Calle A #123',
    @Genero = 1,
    @TipoHabitacion = 1,
    @Habitacion = 31,
    @Camilla = 51,
    @Estadia = 7,
    @accion = '1';
GO

EXEC sp_mantenedor_pacientes
    @codigo = NULL,
    @nombre = 'Pedro',
    @DNI = 87654321,
    @FechaNacimiento = '1985-08-20',
    @Telefono = 654321987,
    @Direccion = 'Avenida B #456',
    @Genero = 2,
    @TipoHabitacion = 2,
    @Habitacion = 11,
    @Camilla = 21,
    @Estadia = 2,
    @accion = '1';
GO

EXEC sp_mantenedor_pacientes
    @codigo = NULL,
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

EXEC sp_mantenedor_pacientes
    @codigo = NULL,
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

EXEC sp_mantenedor_pacientes
    @codigo = NULL,
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

-------------------------------------------------------
CREATE PROCEDURE sp_listar_cirugias
AS 
BEGIN
	SELECT P.Nombre as Paciente,
	U.Nombres as MedicoAsignado,
	C.Descripcion as DescripcionCirugia,
	SC.Nombre as Sala,
	C.FechaCirugia, C.HoraCirugia, C.HoraEntrada as HoraEntradaSala, C.HoraSalida as HoraSalidaSala
	FROM
	Cirugias C INNER JOIN Pacientes P ON P.IdPaciente = C.IdPaciente
	LEFT JOIN USUARIOS U ON U.IdUsuario = C.IdUsuario
	LEFT JOIN SalaCirugia SC ON SC.IdSala = C.IdSala
END
GO

CREATE PROCEDURE sp_listarNombrePacientes
AS
BEGIN
	SELECT Nombre AS Paciente 
	FROM Pacientes
	ORDER BY Nombre
END
GO

CREATE PROCEDURE sp_buscarPacientesNombre
@Nombre varchar(50)
AS
BEGIN
	SELECT Nombre AS Paciente 
	FROM Pacientes
	WHERE @Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%';
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
	C.FechaCirugia, C.HoraCirugia,
	SC.Nombre AS Sala
	FROM 
	Cirugias C INNER JOIN
	SalaCirugia SC ON SC.IdSala = C.IdSala
	WHERE C.FechaCirugia = @Fecha
END
GO
-----------------------------------------
--CREATE PROCEDURE sp_mantenedorCirugias
--    @nombrePaciente VARCHAR(100),
--    @descripcionCirugia VARCHAR(200),
--    @fechaCirugia DATE,
--    @horaCirugia TIME,
--    @salaCirugia INT,
--    @accion VARCHAR(50) OUTPUT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    DECLARE @IdPaciente INT;
--    DECLARE @IdCirugia INT;

--    IF (@accion = '1')
--    BEGIN
        
--        IF EXISTS (SELECT IdPaciente FROM Hospitalizaciones WHERE IdPaciente = @IdPaciente)
--        BEGIN
--            INSERT INTO Cirugias (IdPaciente, Descripcion, FechaCirugia, HoraCirugia, IdSala)
--            VALUES (@IdPaciente, @descripcionCirugia, @fechaCirugia, @horaCirugia, @salaCirugia);
--            SET @IdCirugia = SCOPE_IDENTITY();
--            SET @accion = 'Se registró la cirugía para el paciente: ' + @nombrePaciente;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'PACIENTE NO ENCONTRADO';
--        END
--    END
--    ELSE IF (@accion = '2')
--    BEGIN
--        SELECT @IdPaciente = IdPaciente
--        FROM Pacientes
--        WHERE Nombre = @nombrePaciente;
--        IF @IdPaciente IS NOT NULL
--        BEGIN
--            UPDATE Cirugias
--            SET Descripcion = @descripcionCirugia,
--                FechaCirugia = @fechaCirugia,
--                HoraCirugia = @horaCirugia,
--                IdSala = @salaCirugia
--            WHERE IdPaciente = @IdPaciente;
--            SET @accion = 'Se modificó la cirugía del paciente: ' + @nombrePaciente;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'PACIENTE NO ENCONTRADO';
--        END
--    END
--    ELSE IF (@accion = '3')
--    BEGIN
--        SELECT @IdPaciente = IdPaciente
--        FROM Pacientes
--        WHERE Nombre = @nombrePaciente;
--        IF @IdPaciente IS NOT NULL
--        BEGIN
--            UPDATE Cirugias
--            SET HoraEntrada = CAST(GETDATE() AS TIME)
--            WHERE IdPaciente = @IdPaciente;
--            UPDATE SalaCirugia
--            SET Ocupado = 1
--            WHERE IdSala = @salaCirugia;
--            SET @accion = 'Registrada la hora de ENTRADA a sala para el paciente ' + @nombrePaciente;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'PACIENTE NO ENCONTRADO';
--        END
--    END
--    ELSE IF (@accion = '4')
--    BEGIN
--        SELECT @IdPaciente = IdPaciente
--        FROM Pacientes
--        WHERE Nombre = @nombrePaciente;

--        IF @IdPaciente IS NOT NULL
--        BEGIN
--            UPDATE Cirugias
--            SET HoraSalida = CAST(GETDATE() AS TIME)
--            WHERE IdPaciente = @IdPaciente;
--            UPDATE SalaCirugia
--            SET Ocupado = 0
--            WHERE IdSala = @salaCirugia;
--            SET @accion = 'Registrada la hora de SALIDA de sala para el paciente ' + @nombrePaciente;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'PACIENTE NO ENCONTRADO';
--        END
--    END
--    ELSE IF (@accion = '5')
--    BEGIN
--        SELECT @IdPaciente = IdPaciente
--        FROM Pacientes
--        WHERE Nombre = @nombrePaciente;

--        IF @IdPaciente IS NOT NULL
--        BEGIN
--            DELETE FROM Cirugias
--            WHERE IdPaciente = @IdPaciente;
--            SET @accion = 'Se ha eliminado la cirugía para el paciente ' + @nombrePaciente;
--        END
--        ELSE
--        BEGIN
--            SET @accion = 'PACIENTE NO ENCONTRADO';
--        END
--    END

--    SET NOCOUNT OFF;
--END;
--GO