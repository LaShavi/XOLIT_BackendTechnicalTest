USE [BdXOLITSharedSpacesTEST]

---- Insertamos clientes
--INSERT INTO Clientes (Id, Cedula, Email, Telefono, Nombre, Apellido)
--VALUES 
--(NEWID(), '1234567890', 'juan.perez@example.com', '3001234567', 'Juan', 'Pérez'),
--(NEWID(), '0987654321', 'ana.gomez@example.com', '3007654321', 'Ana', 'Gómez'),
--(NEWID(), '1122334455', 'carlos.lopez@example.com', '3101122334', 'Carlos', 'López'),
--(NEWID(), '5566778899', 'maria.fernandez@example.com', '3205566778', 'María', 'Fernández'),
--(NEWID(), '6677889900', 'luis.martinez@example.com', '3506677889', 'Luis', 'Martínez'),
--(NEWID(), '3344556677', 'laura.rodriguez@example.com', '3153344556', 'Laura', 'Rodríguez'),
--(NEWID(), '7788990011', 'pedro.garcia@example.com', '3207788990', 'Pedro', 'García'),
--(NEWID(), '9900112233', 'sofia.ramirez@example.com', '3139900112', 'Sofía', 'Ramírez'),
--(NEWID(), '2211445566', 'andres.velasquez@example.com', '3172211445', 'Andrés', 'Velásquez'),
--(NEWID(), '8899001122', 'diana.castillo@example.com', '3118899001', 'Diana', 'Castillo');
---- //


---- Insertamos Espacios Compartidos
--INSERT INTO EspaciosCompartidos (Id, NIT, Nombre, Direccion)
--VALUES 
--(NEWID(), '111222333', 'Oficina Central', 'Calle 10 #5-67'),
--(NEWID(), '222333444', 'Coworking Norte', 'Carrera 45 #20-12'),
--(NEWID(), '333444555', 'Auditorio Principal', 'Avenida Siempre Viva 123'),
--(NEWID(), '444555666', 'Sala de Juntas', 'Calle 22 #14-89'),
--(NEWID(), '555666777', 'Coworking Sur', 'Carrera 10 #5-20'),
--(NEWID(), '666777888', 'Centro de Convenciones', 'Diagonal 40 #27-50'),
--(NEWID(), '777888999', 'Oficina Administrativa', 'Carrera 15 #8-44'),
--(NEWID(), '888999000', 'Sala Creativa', 'Calle 13 #9-30'),
--(NEWID(), '999000111', 'Auditorio Secundario', 'Transversal 60 #12-10'),
--(NEWID(), '000111222', 'Espacio de Reuniones', 'Calle 25 #7-15');
---- //


-- Limpiamos data
--DELETE FROM Reservas;
--DELETE FROM Clientes;
--DELETE FROM EspaciosCompartidos;
--
SELECT * FROM Reservas;
SELECT * FROM Clientes;
SELECT * FROM EspaciosCompartidos;