use Clinica

create procedure usp_LoginUsuario(
@Usuario varchar(60),
@Clave varchar(60),
@IdUsuario int output
)
as
Begin
	set @IdUsuario = 0
	if exists (
	select * from USUARIOS
	where Usuario collate Latin1_General_CS_AS = @Usuario
	and Clave collate Latin1_General_CS_AS = @Clave
	)

	set @IdUsuario = (
	select IdUsuario from USUARIOS
	where Usuario collate Latin1_General_CS_AS = @Usuario
	and Clave collate Latin1_General_CS_AS = @Clave
	)
end

----------------------------------------------

create procedure usp_ObtenerPermisos(
    @IdUsuario int
)
as
begin
    select
        (
            select 
                M.Nombre,
                M.NombreFormulario
            from
                PERMISO P
            join ROL R on R.IdRol = P.IdRol
            join MENU M on M.IdMenu = P.IdMenu
            join USUARIOS U on U.IdRol = P.IdRol
            where U.IdUsuario = US.IdUsuario and P.Activo = 1
            for xml path('Menu'), type
        ) as 'DetalleMenu'
    from USUARIOS US
    where US.IdUsuario = @IdUsuario
    for xml path(''), root('PERMISOS');
end
--------------------------------------------
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
        INSERT INTO USUARIOS (Nombres, Usuario, Clave, IdRol) -- Cambiado a USUARIOS
        VALUES (@Nombres, @Usuario, @Clave, @IdRol);

        SET @IdUsuario = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        SET @IdUsuario = 0;
    END CATCH
END
--------------------------------------------------------
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
END
-------------------------------------------------
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
END
-------------------------------------------
-- Registrar Hospitalizacion
CREATE PROCEDURE usp_RegistrarHospitalizacion
    @IdPaciente INT,
    @IdEstadia INT,
    @IdHabitacion INT,
    @IdCamilla INT,
    @IdMedico INT,
    @FechaIngreso DATETIME,
    @Estado NVARCHAR(50)
AS
BEGIN
    INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdMedico, FechaIngreso, Estado)
    VALUES (@IdPaciente, @IdEstadia, @IdHabitacion, @IdCamilla, @IdMedico, @FechaIngreso, @Estado);

    SELECT SCOPE_IDENTITY() AS IdHospitalizacion;
END
---------------------------------
CREATE PROCEDURE usp_ActualizarHospitalizacion
    @IdHospitalizacion INT,
    @IdPaciente INT,
    @IdEstadia INT,
    @IdHabitacion INT,
    @IdCamilla INT,
    @IdMedico INT,
    @FechaIngreso DATETIME,
    @FechaSalida DATETIME,
    @Estado NVARCHAR(50)
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
CREATE PROCEDURE usp_ActualizarCirugia
    @IdCirugia INT,
    @TipoCirugia NVARCHAR(100),
    @Sala NVARCHAR(50),
    @FechaCirugia DATETIME
AS
BEGIN
    UPDATE Cirugias
    SET TipoCirugia = @TipoCirugia,
        Sala = @Sala,
        FechaCirugia = @FechaCirugia
    WHERE IdCirugia = @IdCirugia;
END
GO
----------------------------------