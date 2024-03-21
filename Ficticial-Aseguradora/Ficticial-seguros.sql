/*

--DATABASE CREATION 

CREATE DATABASE Ficticia
USE Ficticia

--TABLA PRINCIPAL

    CREATE TABLE Clientes(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    IdRol INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Identificacion NVARCHAR(50) NOT NULL,
    Contrasenia NVARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    Genero VARCHAR(100) NOT NULL,
    Estado BIT NOT NULL,
    AtributosAdicionales NVARCHAR(255),
    Maneja BIT NOT NULL,
    Lentes BIT NOT NULL,
    Diabetico BIT NOT NULL,
    Enfermedad NVARCHAR(255),
    )

--TABLA DE PERMISOS Y ROLES

CREATE TABLE Permisos(
Id_Permiso INT IDENTITY(1,1),
Nombre_Permiso VARCHAR(50)
)

CREATE TABLE Roles(
IdRol INT IDENTITY(1,1),
Nombre_Rol VARCHAR (50)
)

CREATE TABLE Roles_Permisos(
IdRol_Permiso INT IDENTITY(1,1),
IdRol INT,
Id_Permiso INT,
Estado BIT
)

--INSERT PARA PERMISOS Y ROLES


INSERT INTO Roles VALUES('Admin')
INSERT INTO Roles VALUES('User')


INSERT INTO Permisos VALUES ('Create')
INSERT INTO Permisos VALUES ('Read')
INSERT INTO Permisos VALUES ('Update')
INSERT INTO Permisos VALUES ('Delete')


--En este caso modificamos los permisos del administrador
INSERT INTO Roles_Permisos VALUES (1,1,1)
INSERT INTO Roles_Permisos VALUES (1,2,1)
INSERT INTO Roles_Permisos VALUES (1,3,1)
INSERT INTO Roles_Permisos VALUES (1,4,1)


--Aca son los permisos del Usuario, no tiene todos los permisos activos
INSERT INTO Roles_Permisos VALUES (2,1,0)
INSERT INTO Roles_Permisos VALUES (2,2,1)
INSERT INTO Roles_Permisos VALUES (2,3,0)
INSERT INTO Roles_Permisos VALUES (2,4,0)

--Stored Procedures para Registro, Login y consultas

--Registro
CREATE PROCEDURE sp_RegistrarCliente
        @Nombre VARCHAR(100),
        @Identificacion NVARCHAR(50),
        @Contrasenia NVARCHAR(50),
        @Edad INT,
        @Genero NVARCHAR(100),
        @Estado BIT,
        @AtributosAdicionales NVARCHAR(255),
        @Maneja BIT,
        @Lentes BIT,
        @Diabetico BIT,
        @Enfermedad NVARCHAR(255),
        @Passphrase NVARCHAR(50)
    AS  
    BEGIN
        INSERT INTO Clientes (Nombre, Identificacion, Contrasenia, Edad, Genero, Estado, AtributosAdicionales, Maneja, Lentes, Diabetico, Enfermedad)
        VALUES (@Nombre, @Identificacion, ENCRYPTBYPASSPHRASE(@Passphrase, @Contrasenia), @Edad, @Genero, @Estado, @AtributosAdicionales, @Maneja, @Lentes, @Diabetico, @Enfermedad);
    END;

--Logueo

    CREATE PROCEDURE sp_LogInCliente
	    @Identificacion NVARCHAR(50),
	    @Contrasenia NVARCHAR(50),
	    @Passphrase NVARCHAR(50)
    AS
    BEGIN
	    SELECT * FROM Clientes WHERE @Identificacion=@Identificacion AND Convert(VARCHAR(50), DECRYPTBYPASSPHRASE(@Passphrase,Contrasenia))=@Contrasenia
    END

--Permisos

    CREATE PROCEDURE sp_Permisos
	    @IdRol INT 
    AS
    BEGIN
	    SELECT Nombre_Permiso, Estado FROM Roles_Permisos INNER JOIN Permisos ON  Permisos.Id_Permiso=Roles_Permisos.Id_Permiso WHERE Roles_Permisos.Id_Rol=@IdRol
    END

--Muestra de Datos

    CREATE PROCEDURE sp_Datos
    AS 
    BEGIN
	    SELECT * FROM Clientes
    END

---------------------------------------
--Stored Procedures CRUD

--CREATE

CREATE PROCEDURE sp_RegistrarCliente
    @Nombre VARCHAR(100),
    @Identificacion NVARCHAR(50),
    @Contrasenia NVARCHAR(50),
    @Edad INT,
    @Genero NVARCHAR(100),
    @Estado BIT,
    @AtributosAdicionales NVARCHAR(255),
    @Maneja BIT,
    @Lentes BIT,
    @Diabetico BIT,
    @Enfermedad NVARCHAR(255),
    @Passphrase NVARCHAR(50)
AS  
BEGIN
    INSERT INTO Clientes (Nombre, Identificacion, Contrasenia, Edad, Genero, Estado, AtributosAdicionales, Maneja, Lentes, Diabetico, Enfermedad)
    VALUES (@Nombre, @Identificacion, ENCRYPTBYPASSPHRASE(@Passphrase, @Contrasenia), @Edad, @Genero, @Estado, @AtributosAdicionales, @Maneja, @Lentes, @Diabetico, @Enfermedad);
END;

--READ

CREATE PROCEDURE sp_Read
    @Identificacion NVARCHAR(50)
AS
BEGIN
    SELECT UserId, IdRol, Nombre, Identificacion, Contrasenia, Edad, Genero, Estado, AtributosAdicionales, Maneja, Lentes, Diabetico, Enfermedad
    FROM Clientes
    WHERE Identificacion = @Identificacion;
END;

--Update

CREATE PROCEDURE sp_Actualizar
    @Identificacion NVARCHAR(50),
    @Nombre VARCHAR(100),
    @Contrasenia NVARCHAR(50),
    @Edad INT,
    @Genero VARCHAR(100),
    @Estado BIT,
    @AtributosAdicionales NVARCHAR(255),
    @Maneja BIT,
    @Lentes BIT,
    @Diabetico BIT,
    @Enfermedad NVARCHAR(255),
    @Passphrase NVARCHAR(50)
AS
BEGIN
    DECLARE @EncryptedPassword NVARCHAR(50);
    SET @EncryptedPassword = CONVERT(NVARCHAR(50), ENCRYPTBYPASSPHRASE(@Passphrase, @Contrasenia));

    UPDATE Clientes
    SET Nombre = @Nombre,
        Contrasenia = @EncryptedPassword,
        Edad = @Edad,
        Genero = @Genero,
        Estado = @Estado,
        AtributosAdicionales = @AtributosAdicionales,
        Maneja = @Maneja,
        Lentes = @Lentes,
        Diabetico = @Diabetico,
        Enfermedad = @Enfermedad
    WHERE Identificacion = @Identificacion;
END;

--Delete
    
CREATE PROCEDURE sp_EliminarCliente
    @Identificacion NVARCHAR(50)
AS
BEGIN
    DELETE FROM Clientes
    WHERE Identificacion = @Identificacion;
END;


*/
