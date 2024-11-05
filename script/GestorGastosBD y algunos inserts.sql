CREATE DATABASE GestorGastosAmigos;

USE GestorGastosAmigos;

CREATE TABLE Usuarios (
    idUsuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    passwordHash VARCHAR(255) NOT NULL,
    fechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Grupos (
    idGrupo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombreGrupo VARCHAR(100) NOT NULL,
    fechaCreacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    creadoPor INT,
    codigoInvitacion VARCHAR(50) UNIQUE,
    FOREIGN KEY (creadoPor) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE MiembrosGrupos (
    idGrupo INT,
    idUsuario INT,
    fechaUnion DATETIME DEFAULT CURRENT_TIMESTAMP,
    rol VARCHAR(50) DEFAULT 'miembro',
    PRIMARY KEY (idGrupo, idUsuario),
    FOREIGN KEY (idGrupo) REFERENCES Grupos(idGrupo),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE Gastos (
    idGasto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idGrupo INT,
    descripcion VARCHAR(255),
    montoTotal DECIMAL(10, 2) NOT NULL,
    fechaGasto DATETIME DEFAULT CURRENT_TIMESTAMP,
    creadoPor INT,   
    FOREIGN KEY (idGrupo) REFERENCES Grupos(idGrupo),
    FOREIGN KEY (creadoPor) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE ParticipantesGasto (
    idGasto INT,
    idUsuario INT,
    montoIndividual DECIMAL(10, 2),
    PRIMARY KEY (idGasto, idUsuario),
    FOREIGN KEY (idGasto) REFERENCES Gastos(idGasto),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE Pagos (
    idP INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idGasto INT,
    idUsuario INT,
    montoPagado DECIMAL(10, 2),
    fechaPago DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idGasto) REFERENCES Gastos(idGasto),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE UsuarioImagenes (
    idImagen INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idUsuario INT NOT NULL,
    urlImagen VARCHAR(255) NOT NULL,
    fechaCarga DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

--Algunos inserts 

INSERT INTO Usuarios (nombre, email, passwordHash, Activo)
VALUES ('Juan', 'juan@example.com', 'hashedpassword', 1);

INSERT INTO Usuarios (nombre, email, passwordHash, Activo)
VALUES ('Marina', 'marina@example.com', 'hashedpassword', 1);

INSERT INTO Usuarios (nombre, email, passwordHash, Activo)
VALUES ('Martín', 'martin@example.com', 'hashedpassword', 1);

INSERT INTO Grupos (nombreGrupo, creadoPor, codigoInvitacion)
VALUES ('Grupo JuanMariMar', 1, 'INV123');

INSERT INTO Gastos (IdGrupo, Descripcion, MontoTotal, FechaGasto, CreadoPor)
VALUES (2, 'Cena de grupo', 30000.00, GETDATE(), 1);

INSERT INTO Gastos (IdGrupo, Descripcion, MontoTotal, FechaGasto, CreadoPor)
VALUES (2, 'Cine', 21600.00, GETDATE(), 1);

INSERT INTO MiembrosGrupos(IdGrupo, idUsuario,  fechaUnion, rol)
VALUES (2, , 30000.00, GETDATE(), 1);

INSERT INTO MiembrosGrupos (idGrupo, idUsuario, fechaUnion, rol)
VALUES (2, 1, GETDATE(), 'miembro'); -- Juan

INSERT INTO MiembrosGrupos (idGrupo, idUsuario, fechaUnion, rol)
VALUES (2, 2, GETDATE(), 'miembro'); -- Martín

INSERT INTO MiembrosGrupos (idGrupo, idUsuario, fechaUnion, rol)
VALUES (2, 3, GETDATE(), 'miembro'); -- Marina

select * from Gastos
select * from MiembrosGrupos
select * from Grupos
select * from ParticipantesGasto
select * from Usuarios
select * from Pagos

CREATE TABLE UsuarioImagenes (
    idImagen INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idUsuario INT NOT NULL,
    urlImagen VARCHAR(255) NOT NULL,
    fechaCarga DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);
