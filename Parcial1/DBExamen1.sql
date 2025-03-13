USE master;
GO

-- Verificar si la base de datos existe y eliminarla si es necesario
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'BDExamen1')
BEGIN
    ALTER DATABASE BDExamen1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE BDExamen1;
END
GO

-- Crear la base de datos
CREATE DATABASE BDExamen1;
GO

-- Usar la base de datos recién creada
USE BDExamen1;
GO

-- Crear la tabla Agencia
CREATE TABLE Agencia (
    id_agencia INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,	
	direccion VARCHAR(255) NOT NULL,
    telefono VARCHAR(20) NOT NULL
);
GO

-- Crear la tabla Cliente
CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    email NVARCHAR(225) UNIQUE NOT NULL,
	documento NVARCHAR(50) NOT NULL,
    telefono NVARCHAR(20) NOT NULL,
	direccion VARCHAR(255) NOT NULL,
);
GO

-- Crear la tabla TipoComputador
CREATE TABLE TipoComputador (
    id_tipo INT IDENTITY(1,1) PRIMARY KEY,
    nombre_tipo NVARCHAR(50) NOT NULL
);
GO

-- Crear la tabla Computador
CREATE TABLE Computador (
    id_computador INT IDENTITY(1,1) PRIMARY KEY,
    num_procesadores INT NOT NULL,
    marca_procesador NVARCHAR(50) NOT NULL,
    tam_disco INT NOT NULL, -- Tamaño en GB
    tam_memoria INT NOT NULL, -- Tamaño en GB
    componentes TEXT NULL, -- Lista de componentes en texto
    id_tipo INT NOT NULL,
    FOREIGN KEY (id_tipo) REFERENCES TipoComputador(id_tipo),
);
GO

-- Crear la tabla Venta
CREATE TABLE Venta (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    fecha_venta DATETIME DEFAULT GETDATE(),
    id_cliente INT NOT NULL,
    id_computador INT NOT NULL UNIQUE, -- Un computador solo se vende una vez
	id_agencia INT NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_computador) REFERENCES Computador(id_computador),
	FOREIGN KEY (id_agencia) REFERENCES Agencia(id_agencia)
);
GO


---Datos
INSERT INTO Agencia (nombre, direccion, telefono) 
VALUES 
('ITM Computadores', 'Calle 10 #50-30, Medellín', '6041234567');

INSERT INTO Cliente (nombre, email, documento, telefono, direccion) 
VALUES 
('Juan Pérez', 'juan.perez@email.com', 'CC 123456789', '3001234567', 'Carrera 45 #10-20, Medellín'),
('María Gómez', 'maria.gomez@email.com', 'CC 987654321', '3019876543', 'Calle 30 #20-15, Medellín'),
('Carlos López', 'carlos.lopez@email.com', 'CC 456789123', '3025678912', 'Diagonal 75 #80-90, Medellín');

INSERT INTO TipoComputador (nombre_tipo) 
VALUES 
('Gamer'),
('Portátil'),
('Servidor'),
('Escritorio');

INSERT INTO Computador (num_procesadores, marca_procesador, tam_disco, tam_memoria, componentes, id_tipo) 
VALUES 
(8, 'Intel i7', 1000, 16, 'Mouse, Teclado mecánico, Tarjeta gráfica RTX 3060', 1), 
(4, 'AMD Ryzen 5', 500, 8, 'Mouse, Teclado inalámbrico', 2),
(16, 'Intel Xeon', 2000, 64, 'RAID SSD, Red 10Gbps, Controladora RAID', 3),
(6, 'Intel i5', 512, 16, 'Mouse, Teclado, Monitor 24"', 4);

INSERT INTO Venta (fecha_venta, id_cliente, id_computador, id_agencia) 
VALUES 
(GETDATE(), 1, 1, 1),  -- Juan Pérez compra un Gamer
(GETDATE(), 2, 2, 1),  -- María Gómez compra un Portátil
(GETDATE(), 3, 3, 1);  -- Carlos López compra un Servidor

SELECT * FROM Agencia;
SELECT * FROM Cliente;
SELECT * FROM TipoComputador;
SELECT * FROM Computador;
SELECT * FROM Venta;
