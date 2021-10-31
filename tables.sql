
CREATE DATABASE Transaccionales;
USE Transaccionales;

/*==============================================================*/
/* Table: BAHIA                                                 */
/*==============================================================*/
create table BAHIA 
(
   IDBAHIA              int  auto_increment primary key,
   IDPARQUEADERO        int                      not null,
   DISPONIBLE           smallint                       not null
);

/*==============================================================*/
/* Table: PAGO                                                  */
/*==============================================================*/
create table PAGO 
(
   IDPAGO               int   auto_increment      primary key,
   IDBAHIA              integer                        not null,
   IDVEHICULO           int                       not null,
   TIEMPO               integer                        not null,
   COSTO                integer                        not null,
   FECHA                date                           not null
);

/*==============================================================*/
/* Table: PARQUEADERO                                           */
/*==============================================================*/
create table PARQUEADERO 
(
   IDPARQUEADERO        int auto_increment        primary key,
   NOMBRE               char(50)                       not null,
   UBICACION            char(50)                       not null
);

CREATE TABLE TIPOSPERSONA
(
	ID 			int auto_increment primary key,
    DESCRIPCION varchar(50) NOT NULL
);

CREATE TABLE TIPOSDOCUMENTO
(
	ID			int auto_increment primary key,
    DESCRIPCION	varchar(50) not null
);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA 
(
   IDPERSONA            integer    auto_increment    	primary key,
   NOMBRE               varchar(150)                   	not null,
   APELLIDO				varchar(150)					not null,
   TIPODOCUMENTO		int								not null,
   NUMERODOCUMENTO		int								not null,
   DIRECCION			varchar(200)					null,
   TELEFONO				long							null,
   TIPOPERSONA			int								not null,
   constraint fk_Persona_tipoDocumento foreign key (TIPODOCUMENTO) references TIPOSDOCUMENTO(ID),
   constraint fk_Persona_tipoPersona foreign key (TIPOPERSONA) references TIPOSPERSONA(ID)
);

/*==============================================================*/
/* Table: TARIFA                                                */
/*==============================================================*/
create table TARIFA 
(
   IDTARIFA             int auto_increment    primary key,
   COSTO                integer                        not null
);

/*==============================================================*/
/* Table: TIPOVEHICULO                                          */
/*==============================================================*/
create table TIPOVEHICULO 
(
   IDTIPO               int    auto_increment      primary key,
   IDTARIFA             int                      not null,
   CLASE                char(30)                       not null
);

/*==============================================================*/
/* Table: VEHICULO                                              */
/*==============================================================*/
create table VEHICULO 
(
   IDVEHICULO           int  auto_increment       primary key,
   MARCA                char(20)                       not null,
   IDTIPO               int                       not null,
   IDPERSONA            integer                        not null,
   PLACA				char(6)					not null
);

alter table BAHIA
   add constraint FK_BAHIA_REFERENCE_PARQUEAD foreign key (IDPARQUEADERO)
      references PARQUEADERO (IDPARQUEADERO)
      on update restrict
      on delete restrict;

alter table PAGO
   add constraint FK_PAGO_REFERENCE_BAHIA foreign key (IDBAHIA)
      references BAHIA (IDBAHIA)
      on update restrict
      on delete restrict;

alter table PAGO
   add constraint FK_PAGO_REFERENCE_VEHICULO foreign key (IDVEHICULO)
      references VEHICULO (IDVEHICULO)
      on update restrict
      on delete restrict;

alter table TIPOVEHICULO
   add constraint FK_TIPOVEHI_REFERENCE_TARIFA foreign key (IDTARIFA)
      references TARIFA (IDTARIFA)
      on update restrict
      on delete restrict;

alter table VEHICULO
   add constraint FK_VEHICULO_REFERENCE_PERSONA foreign key (IDPERSONA)
      references PERSONA (IDPERSONA)
      on update restrict
      on delete restrict;

alter table VEHICULO
   add constraint FK_VEHICULO_REFERENCE_TIPOVEHI foreign key (IDTIPO)
      references TIPOVEHICULO (IDTIPO)
      on update restrict
      on delete restrict;

