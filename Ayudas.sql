/* LEVEL 1 */
select * from PARQUEADERO;
select * from TARIFA;
SELECT * FROM TIPOSPERSONA;
SELECT * FROM tiposdocumento;

/* LEVEL 2 */
select * from bahia;
select * from tipoVehiculo;
select * from PERSONA;

/* LEVEL 3*/
select * from VEHICULO;

/* LEVEL 4 */
select * from PAGO;

CALL spTraerBahiasParqueadero(1)