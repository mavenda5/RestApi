/* LEVEL 1 */
delimiter !
CREATE PROCEDURE spTraerParqueaderos ()
BEGIN
	Select IDPARQUEADERO, NOMBRE, UBICACION
    from PARQUEADERO;
END!

CREATE PROCEDURE spTraerTarifas ()
BEGIN
	Select IDTARIFA, COSTO
    from TARIFA;
END!

CREATE PROCEDURE spTraerTiposPersonas ()
BEGIN
	Select ID, DESCRIPCION
    from TIPOSPERSONA;
END!

CREATE PROCEDURE spTraerTiposDocumentos ()
BEGIN
	Select ID, DESCRIPCION
    from TIPOSDOCUMENTO;
END!


/* LEVEL 2 */
CREATE PROCEDURE spTraerTipoVehiculo ()
BEGIN
	Select IDTIPO, IDTARIFA, CLASE
    from TIPOVEHICULO;
END!

CREATE PROCEDURE spTraerBahias ()
BEGIN
	Select IDBAHIA, IDPARQUEADERO, DISPONIBLE
    from BAHIA;
END!

CREATE PROCEDURE spTraerBahiasParqueadero (
	IN idparqueader int
)
BEGIN
	Select IDBAHIA, IDPARQUEADERO, DISPONIBLE
    from BAHIA
    where IDPARQUEADERO = idparqueader
    ;
END!

CREATE PROCEDURE spCrearPersona(
	IN Inombre VARCHAR(150),
    IN Iapellido VARCHAR(150),
    IN Itipodocumento int,
    IN Inumerodocumento int,
    IN Idireccion VARCHAR(200),
    IN Itelefono bigint,
    IN ItipoPersona int
)
BEGIN
	set @res = -1;
    if NOT (exists (SELECT 1 FROM PERSONA
        WHERE TIPODOCUMENTO = Itipodocumento AND NUMERODOCUMENTO = Inumerodocumento))
	then begin
		INSERT INTO PERSONA
		(NOMBRE, APELLIDO, TIPODOCUMENTO, NUMERODOCUMENTO, DIRECCION, TELEFONO, TIPOPERSONA)
		VALUES
        (Inombre, Iapellido, Itipodocumento, Inumerodocumento, Idireccion, Itelefono, ItipoPersona);
		set @res = @@identity;
	end;
    end if;
	select @res;
END!

CREATE PROCEDURE spActualizarPersona(
	IN Inombre VARCHAR(150),
    IN Iapellido VARCHAR(150),
    IN Itipodocumento int,
    IN Inumerodocumento int,
    IN Idireccion VARCHAR(200),
    IN Itelefono bigint,
    IN ItipoPersona int,
    IN Iidpersona int
)
BEGIN
	set @res = -1;
    if exists (SELECT 1 FROM PERSONA WHERE IDPERSONA = Iidpersona)
	then begin
		UPDATE PERSONA
		SET NOMBRE = Inombre,
			APELLIDO = Iapellido,
            TIPODOCUMENTO = Itipodocumento,
            NUMERODOCUMENTO = Inumerodocumento,
            DIRECCION = Idireccion,
            TELEFONO = Itelefono,
            TIPOPERSONA = ItipoPersona
		WHERE TIPODOCUMENTO = Itipodocumento AND NUMERODOCUMENTO = Inumerodocumento AND TIPOPERSONA = ItipoPersona;
		set @res = Iidpersona;
	end;
    end if;
	select @res;
END!

CREATE PROCEDURE spConsultarPersona(
    IN Itipodocumento int,
    IN Inumerodocumento int,
    IN ItipoPersona int
)
BEGIN
	SELECT IDPERSONA, NOMBRE, APELLIDO, TIPODOCUMENTO, NUMERODOCUMENTO, DIRECCION, TELEFONO, TIPOPERSONA
    FROM PERSONA
    WHERE TIPODOCUMENTO = Itipodocumento AND NUMERODOCUMENTO = Inumerodocumento AND TIPOPERSONA = ItipoPersona;
END!


CREATE PROCEDURE spConsultarVehiculo(
    IN id char(6)
)
BEGIN
	SELECT IDVEHICULO, MARCA, IDTIPO, IDPERSONA, PLACA
    FROM VEHICULO
    WHERE PLACA = id;
END!

CREATE PROCEDURE spCrearVehiculo(
	IN Imarca VARCHAR(20),
    IN Iidtipo int,
    IN Iidpersona int,
    IN Iplaca CHAR(6)
)
BEGIN
	set @res = -1;
    if NOT (exists (SELECT 1 FROM VEHICULO WHERE PLACA = Iplaca))
	then begin
		INSERT INTO VEHICULO
		(MARCA, IDTIPO, IDPERSONA, PLACA)
		VALUES
        (Imarca, Iidtipo, Iidpersona, Iplaca);
		set @res = @@identity;
	end;
    end if;
	select @res;
END!

CREATE PROCEDURE spActualizarVehiculo(
	IN IidVehiculo int,
	IN Imarca VARCHAR(20),
    IN Iidtipo int,
    IN Iidpersona int,
    IN Iplaca CHAR(6)
)
BEGIN
	set @res = -1;
    if exists (SELECT 1 FROM VEHICULO WHERE PLACA = Iplaca)
	then begin
		UPDATE VEHICULO
		SET MARCA = Imarca,
			IDTIPO = Iidtipo,
            IDPERSONA = Iidpersona,
            PLACA = Iplaca
		WHERE PLACA = Iplaca;
		set @res = IidVehiculo;
	end;
    end if;
	select @res;
END!

CREATE PROCEDURE spConsultarPago (
	IN IidVehiculo int,
    IN Ifecha datetime
)
BEGIN
	SELECT IDPAGO, IDBAHIA, IDVEHICULO, TIEMPO, COSTO, FECHA
    FROM PAGO
    WHERE IDVEHICULO = IidVehiculo AND FECHA = Ifecha;
END!
delimiter ;
