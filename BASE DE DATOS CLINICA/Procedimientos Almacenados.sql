use Prueba

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


