IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BdXOLITSharedSpacesTEST')
BEGIN
    CREATE DATABASE BdXOLITSharedSpacesTEST;
END;

USE [BdXOLITSharedSpacesTEST]

-- Clientes
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clientes' AND xtype='U')
CREATE TABLE Clientes (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Cedula VARCHAR(10) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL
);

-- EspaciosCompartidos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EspaciosCompartidos' AND xtype='U')
CREATE TABLE EspaciosCompartidos (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    NIT VARCHAR(10) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Direccion VARCHAR(50) NOT NULL
);

-- Reservas
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Reservas' AND xtype='U')
CREATE TABLE Reservas (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    FechaRegistro DATETIME NOT NULL,
    FechaIniReserva DATETIME NOT NULL,
    FechaFinReserva DATETIME NOT NULL,
    Estado INT NOT NULL,
    ClienteId UNIQUEIDENTIFIER NOT NULL,
    EspaciosCompartidosId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (EspaciosCompartidosId) REFERENCES EspaciosCompartidos(Id)
);