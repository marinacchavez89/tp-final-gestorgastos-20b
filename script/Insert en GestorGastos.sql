INSERT INTO Amigos (Nombre, Email, Telefono, Estado)
VALUES 
('María Pérez', 'maria.perez@email.com', '123456789', 1),
('Juan López', 'juan.lopez@email.com', '987654321', 1),
('Ana Rodríguez', 'ana.rodriguez@email.com', '1122334455', 1),
('Carlos Díaz', 'carlos.diaz@email.com', '5566778899', 1);
GO

INSERT INTO Gastos (Fecha, Concepto, Monto)
VALUES 
('2024-10-01', 'Asado', 30000.00),
('2024-10-02', 'Impuestos', 25000.00),
('2024-10-03', 'Alquiler', 500000.00),
('2024-10-04', 'Entradas cine', 15000.00);
GO

-- Insertar divisiones de gastos
-- Asado, 30,000 dividido entre 4 amigos
INSERT INTO DivisionGastos (IdGasto, IdAmigo, MontoAPagar)
VALUES 
(1, 1, 7500.00),  -- María
(1, 2, 7500.00),  -- Juan
(1, 3, 7500.00),  -- Ana
(1, 4, 7500.00);  -- Carlos

-- Impuestos, 25,000 dividido entre 4 amigos
INSERT INTO DivisionGastos (IdGasto, IdAmigo, MontoAPagar)
VALUES 
(2, 1, 6250.00),  -- María
(2, 2, 6250.00),  -- Juan
(2, 3, 6250.00),  -- Ana
(2, 4, 6250.00);  -- Carlos

-- Alquiler, 500,000 dividido entre 4 amigos
INSERT INTO DivisionGastos (IdGasto, IdAmigo, MontoAPagar)
VALUES 
(3, 1, 125000.00),  -- María
(3, 2, 125000.00),  -- Juan
(3, 3, 125000.00),  -- Ana
(3, 4, 125000.00);  -- Carlos

-- Entradas cine, 15,000 dividido entre 4 amigos
INSERT INTO DivisionGastos (IdGasto, IdAmigo, MontoAPagar)
VALUES 
(4, 1, 3750.00),  -- María
(4, 2, 3750.00),  -- Juan
(4, 3, 3750.00),  -- Ana
(4, 4, 3750.00);  -- Carlos
GO

