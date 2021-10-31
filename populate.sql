/* LEVEL 1 */
INSERT INTO tiposdocumento (descripcion)
VALUES
("Cedula de ciudadania"),
("Tarjeta de identidad"),
("Pasaporte"),
("Otro");

INSERT INTO TIPOSPERSONA(DESCRIPCION)
VALUES
("Administrador"),
("Empleado"),
("Usuario");

INSERT INTO TARIFA (COSTO)
VALUES
(45),
(50),
(60),
(90),
(120),
(125);

INSERT INTO PARQUEADERO(NOMBRE, UBICACION)
VALUES
("Unilago", "Av Carrera 15 # 78 - 33, Bogotá"),
("Metrópolis", "Ak 68 #75a-50, Bogotá"),
("uNICENTRO", "Cra. 15 #124-30, Bogotá");

/* LEVEL 2 */
DELIMITER //
CREATE FUNCTION PopulateBahia ()
RETURNS int
BEGIN
	DECLARE cant int;
    DECLARE pos int;
    DECLARE par int;
    SET pos = 0;
    SET par = 1;
    
    algo:
    WHILE par < 4 DO
		SET cant = RAND() * 100;
		mas:
		WHILE pos <= cant DO
			insert into BAHIA (IDPARQUEADERO, DISPONIBLE)
            VALUES (par, ROUND(RAND()));
            set pos = pos + 1;
        END
        WHILE mas;
        set par = par + 1;
        set pos = 0;
    END
    WHILE algo;
    RETURN 0;
END//
delimiter ;
SELECT PopulateBahia();

INSERT INTO TIPOVEHICULO (IDTARIFA, CLASE)
VALUES
(1, "Moto"),
(1, "Bicicleta"),
(2, "Bicitaxi"),
(3, "Vehículo pequeño"),
(4, "Camioneta pickup"),
(5, "Camion de carga");

INSERT INTO PERSONA
(NOMBRE,  APELLIDO, TIPODOCUMENTO, NUMERODOCUMENTO, DIRECCION, TELEFONO, TIPOPERSONA)
VALUES
("Miguel", "Avendaño", 1, 1234567, null, null, 3),
("Fabio", "Posada", 1, 1022455872, null, null, 3),
("Karen", "Gato", 2, 4215678, "Calle con carrera", 3216549870, 2),
("Anderson", "Gomez", 3, 4445566, "Calle falsa 123", 6504125, 2),
("Harold", "Mesa", 4, 11223344, "Arriba en aquel monte", 3213451200, 1),
("Camilo", "Garcia", 1, 1234567890, "Donde el sol no llega", 4125780, 1);

/* LEVEL 3 */
INSERT INTO VEHICULO (MARCA, IDTIPO, IDPERSONA, PLACA)
VALUES
("Chevrolet", 3, 2, "HMK123"),
("Aveo", 5, 6, "JFK451"),
("Nissan", 4, 5, "KQK001"),
("Mini cooper", 3, 1, "ABC123"),
("BMW", 2, 1, "CBA987"),
("Chino barato", 5, 2, "FDA145"),
("Jaguar", 1, 4, "LKO147"),
("Toyota", 4, 4, "MMM124"),
("Chevrolet", 5, 10, "ZZZ000");

/* LEVEL 4 */
INSERT INTO PAGO (IDBAHIA, IDVEHICULO, TIEMPO, COSTO, FECHA)
VALUES
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800)),
(FLOOR( RAND() * (28-1) + 1), FLOOR( RAND() * (9-1) + 1), FLOOR( RAND() * (600-10) + 10), FLOOR( RAND() * (30000-100) + 100), FROM_UNIXTIME(RAND() * (1262246400 - 1230796800) + 1610796800));