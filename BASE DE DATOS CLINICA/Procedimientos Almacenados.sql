use Clinica

-- Obtener Usuarios
CREATE PROCEDURE usp_ObtenerUsuarios
as
SELECT Nombres, Usuario, Clave, IdRol, Activo FROM USUARIOS
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
SELECT u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol
FROM USUARIOS u
inner JOIN ROL r ON u.IdRol = r.IdRol
GO
-------------------------
Create PROCEDURE usp_buscar_usuarios
    @nombre VARCHAR(50)
AS
BEGIN
    SELECT u.Nombres, u.Usuario, u.Clave, r.Nombre as Rol
    FROM Usuarios u inner join ROL r on r.IdRol = u.IdRol
    WHERE Nombres LIKE '%' + @nombre + '%';
END;
GO
------------------------------------------
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

-- Procedimiento almacenado para mantanedor usuario
CREATE PROCEDURE usp_mantenedor_usuarios
    @Nombres VARCHAR(50) = NULL,
    @Usuario VARCHAR(50) = NULL,
    @Clave VARCHAR(50) = NULL,
    @IdRol INT = NULL,
    @Activo BIT = 1,
    @accion CHAR(1)
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
        -- Validar que el nombre no sea NULL para actualizar
        IF @Nombres IS NOT NULL
        BEGIN
            -- Actualizar datos del usuario en la tabla USUARIOS por nombre
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
        -- Validar que el nombre no sea NULL para eliminar
        IF @Nombres IS NOT NULL
        BEGIN
            -- Eliminar usuario de la tabla USUARIOS por nombre
            DELETE FROM USUARIOS
            WHERE Nombres = @Nombres;
        END
    END
END;
GO
--------------------------------------------------------------------
-- Procedimiento almacenado para Listar hospitalización
Create proc sp_listar_pacientes
as
SELECT
	p.Codigo as Codigo,
    p.Nombre AS Nombre,
    p.DNI AS Dni,
	p.FechaNacimiento as FechaNacimiento,
	p.Telefono as Telefono,
	p.Direccion as Direccion,
	g.Nombre as Genero,
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
LEFT JOIN
	Genero g ON g.IdGenero = p.IdGenero
GROUP BY
	p.Codigo,
    p.Nombre,
    p.DNI,
	p.FechaNacimiento,
	p.Telefono,
	p.Direccion,
	g.Nombre,
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
CREATE PROCEDURE sp_buscar_pacientes
    @nombre NVARCHAR(50)
AS
BEGIN
    SELECT 
        p.Codigo, 
        p.Nombre, 
        p.DNI, 
        p.FechaNacimiento, 
        p.Telefono, 
        p.Direccion, 
        g.Nombre AS Genero
    FROM 
        Pacientes p
        INNER JOIN Genero g ON g.IdGenero = p.IdGenero
    WHERE 
        p.Nombre LIKE '%' + @nombre + '%';
END;
GO
-----------------------------------------------
Alter PROCEDURE sp_buscar_pacientes_consulta
    @nombre VARCHAR(50) = NULL,
    @dni INT = NULL
AS
BEGIN
    SELECT 
        p.Nombre, 
        p.DNI, 
        h.Nombre AS Habitacion, 
        c.Nombre AS Camilla, 
        ho.FechaIngreso, 
        ho.HoraIngreso, 
        ho.FechaSalida, 
        ho.HoraSalida
    FROM 
        Hospitalizaciones ho 
        INNER JOIN Pacientes p ON p.IdPaciente = ho.IdPaciente
        LEFT JOIN Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
        LEFT JOIN Camillas c ON c.IdCamilla = ho.IdCamilla
    WHERE 
        (@nombre IS NOT NULL AND p.Nombre LIKE '%' + @nombre + '%') 
        OR (@dni IS NOT NULL AND p.DNI = @dni)
END;
GO

----------------------------------
CREATE PROCEDURE sp_listar_pacientes_consultas
as
SELECT 
        p.Nombre, 
        p.DNI, 
        h.Nombre AS Habitacion, 
        c.Nombre AS Camilla, 
        ho.FechaIngreso, 
        ho.HoraIngreso, 
        ho.FechaSalida, 
        ho.HoraSalida
    FROM 
        Hospitalizaciones ho 
        INNER JOIN Pacientes p ON p.IdPaciente = ho.IdPaciente
        LEFT JOIN Habitaciones h ON h.IdHabitacion = ho.IdHabitacion
        LEFT JOIN Camillas c ON c.IdCamilla = ho.IdCamilla
go
----------------------------------
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
    IF (@accion = '1')
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI)
        BEGIN
            DECLARE @codnuevo VARCHAR(5), @codmax VARCHAR(5), @IdPaciente INT;
            SET @codmax = (SELECT MAX(Codigo) FROM Pacientes);
            SET @codmax = ISNULL(@codmax, 'P0000');
            SET @codnuevo = 'P' + RIGHT('0000' + CAST(CAST(RIGHT(@codmax, 4) AS INT) + 1 AS VARCHAR(4)), 4);

            INSERT INTO Pacientes (Codigo, Nombre, DNI, FechaNacimiento, Telefono, Direccion, IdGenero)
            VALUES (@codnuevo, @nombre, @DNI, @FechaNacimiento, @Telefono, @Direccion, @Genero);

            SET @IdPaciente = SCOPE_IDENTITY();

            INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdTipoHabitacion, FechaIngreso, HoraIngreso)
            VALUES (@IdPaciente, @Estadia, @Habitacion, @Camilla, @TipoHabitacion, GETDATE(), GETDATE());

            SET @accion = 'Se agregó el paciente: ' + @nombre;
        END
        ELSE
        BEGIN
            SET @accion = 'DNI_EXISTE';
        END
    END
    ELSE IF (@accion = '2')
    BEGIN
        -- Actualizar datos del paciente solo si el DNI no existe o pertenece al mismo paciente
        IF NOT EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNI AND Codigo <> @codigo)
        BEGIN
            UPDATE Pacientes 
            SET Nombre = @nombre, 
                DNI = @DNI, 
                FechaNacimiento = @FechaNacimiento, 
                Telefono = @Telefono, 
                Direccion = @Direccion, 
                IdGenero = @Genero
            WHERE Codigo = @codigo;

            -- Actualizar datos de hospitalización si es necesario
            UPDATE Hospitalizaciones
            SET IdEstadia = @Estadia,
                IdHabitacion = @Habitacion,
                IdCamilla = @Camilla,
                IdTipoHabitacion = @TipoHabitacion
            WHERE IdPaciente = (SELECT IdPaciente FROM Pacientes WHERE Codigo = @codigo);

            SET @accion = 'Se modificó el paciente: ' + @nombre;
        END
        ELSE
        BEGIN
            SET @accion = 'DNI_EXISTE';
        END
    END
    ELSE IF (@accion = '3')
    BEGIN
        -- Registrar salida del paciente en la tabla Hospitalizaciones
        UPDATE Hospitalizaciones 
        SET FechaSalida = GETDATE(), 
            HoraSalida = GETDATE() 
        WHERE IdPaciente = (SELECT IdPaciente FROM Pacientes WHERE Codigo = @codigo);

        SET @accion = 'Se registró la salida del paciente: ' + @nombre;
    END
    ELSE IF (@accion = '4')
    BEGIN
        -- Obtener el ID del paciente a eliminar
        DECLARE @IdPacienteToDelete INT;
        SELECT @IdPacienteToDelete = IdPaciente FROM Pacientes WHERE Codigo = @codigo;

        -- Eliminar las hospitalizaciones asociadas al paciente
        DELETE FROM Hospitalizaciones WHERE IdPaciente = @IdPacienteToDelete;

        -- Eliminar paciente de la tabla Pacientes
        DELETE FROM Pacientes WHERE Codigo = @codigo;

        SET @accion = 'Se borró el paciente: ' + @nombre;
    END
END;
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
CREATE PROCEDURE sp_listar_genero
as
Begin
	select IdGenero, Nombre from Genero;
end
go
----------------------------------
CREATE PROCEDURE sp_listar_roles
AS
SELECT IdRol, Nombre FROM ROL
GO
------------------------------------------
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
--------------------------------------
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

Select * from Menu
EXEC sp_modificar_permiso @IdRol = 5, @IdMenu = 1, @NuevoPermiso = 1;

-------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_AgregarCirugia
    @TipoCirugia NVARCHAR(100),
    @IdPaciente INT,
    @NombrePaciente NVARCHAR(100),
    @Sala NVARCHAR(50),
    @HoraCirugia TIME,
    @FechaCirugia DATETIME
AS
BEGIN
    INSERT INTO Cirugias (TipoCirugia, IdPaciente, NombrePaciente, IdSala, HoraCirugia, FechaCirugia)
    VALUES (@TipoCirugia, @IdPaciente, @NombrePaciente, @Sala, @HoraCirugia, @FechaCirugia);
END
-------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_ObtenerCirugias
AS
BEGIN
    SELECT c.IdCirugia, c.TipoCirugia, p.Nombre AS NombrePaciente, c.IdSala, c.HoraCirugia, c.FechaCirugia
    FROM Cirugias c
    INNER JOIN Pacientes p ON c.IdPaciente = p.IdPaciente;
END
-------------------------------------------------------------------------------------------------
ALTER PROCEDURE usp_ObtenerCirugias
AS
BEGIN
    SELECT c.IdCirugia, c.TipoCirugia, c.IdPaciente, p.Nombre AS NombrePaciente, s.Nombre AS NombreSala, 
           c.HoraCirugia, c.FechaCirugia
    FROM Cirugias c
    INNER JOIN Pacientes p ON c.IdPaciente = p.IdPaciente
    INNER JOIN Salas s ON c.IdSala = s.IdSala
END
--------------------------------------------------------------------------------------------------