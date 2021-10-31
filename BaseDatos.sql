/*==============================================================*/
/* DBMS name:      SAP SQL Anywhere 16                          */
/* Created on:     26/10/2021 2:23:49 p. m.                     */
/*==============================================================*/


if exists(select 1 from sys.sysforeignkey where role='FK_BAHIA_REFERENCE_PARQUEAD') then
    alter table BAHIA
       delete foreign key FK_BAHIA_REFERENCE_PARQUEAD
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PAGO_REFERENCE_BAHIA') then
    alter table PAGO
       delete foreign key FK_PAGO_REFERENCE_BAHIA
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PAGO_REFERENCE_VEHICULO') then
    alter table PAGO
       delete foreign key FK_PAGO_REFERENCE_VEHICULO
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_TIPOVEHI_REFERENCE_TARIFA') then
    alter table TIPOVEHICULO
       delete foreign key FK_TIPOVEHI_REFERENCE_TARIFA
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_VEHICULO_REFERENCE_PERSONA') then
    alter table VEHICULO
       delete foreign key FK_VEHICULO_REFERENCE_PERSONA
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_VEHICULO_REFERENCE_TIPOVEHI') then
    alter table VEHICULO
       delete foreign key FK_VEHICULO_REFERENCE_TIPOVEHI
end if;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='BAHIA')
   where
      k.constraint_type = 'P'
) then
    alter table BAHIA
   delete primary key
end if;

drop table if exists BAHIA;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='PAGO')
   where
      k.constraint_type = 'P'
) then
    alter table PAGO
   delete primary key
end if;

drop table if exists PAGO;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='PARQUEADERO')
   where
      k.constraint_type = 'P'
) then
    alter table PARQUEADERO
   delete primary key
end if;

drop table if exists PARQUEADERO;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='PERSONA')
   where
      k.constraint_type = 'P'
) then
    alter table PERSONA
   delete primary key
end if;

drop table if exists PERSONA;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='TARIFA')
   where
      k.constraint_type = 'P'
) then
    alter table TARIFA
   delete primary key
end if;

drop table if exists TARIFA;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='TIPOVEHICULO')
   where
      k.constraint_type = 'P'
) then
    alter table TIPOVEHICULO
   delete primary key
end if;

drop table if exists TIPOVEHICULO;

if exists(
   select 1 from sys.sysconstraint k
      join sys.systab t on (t.object_id = k.table_object_id and t.table_name='VEHICULO')
   where
      k.constraint_type = 'P'
) then
    alter table VEHICULO
   delete primary key
end if;

drop table if exists VEHICULO;

/*==============================================================*/
/* Table: BAHIA                                                 */
/*==============================================================*/
create table BAHIA 
(
   IDBAHIA              integer                        not null,
   IDPARQUEADERO        char(30)                       null,
   DISPONIBLE           smallint                       null
);

alter table BAHIA
   add constraint PK_BAHIA primary key clustered (IDBAHIA);

/*==============================================================*/
/* Table: PAGO                                                  */
/*==============================================================*/
create table PAGO 
(
   IDPAGO               char(10)                       not null,
   IDBAHIA              integer                        null,
   IDVEHICULO           char(10)                       null,
   TIEMPO               integer                        null,
   COSTO                integer                        null,
   FECHA                date                           null
);

alter table PAGO
   add constraint PK_PAGO primary key clustered (IDPAGO);

/*==============================================================*/
/* Table: PARQUEADERO                                           */
/*==============================================================*/
create table PARQUEADERO 
(
   IDPARQUEADERO        char(30)                       not null,
   NOMBRE               char(50)                       null,
   UBICACION            char(50)                       null
);

alter table PARQUEADERO
   add constraint PK_PARQUEADERO primary key clustered (IDPARQUEADERO);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA 
(
   IDPERSONA            integer                        not null,
   NOMBRE               char(100)                      null
);

alter table PERSONA
   add constraint PK_PERSONA primary key clustered (IDPERSONA);

/*==============================================================*/
/* Table: TARIFA                                                */
/*==============================================================*/
create table TARIFA 
(
   IDTARIFA             char(30)                       not null,
   COSTO                integer                        null,
   IDTIPO               char(30)                       null
);

alter table TARIFA
   add constraint PK_TARIFA primary key clustered (IDTARIFA);

/*==============================================================*/
/* Table: TIPOVEHICULO                                          */
/*==============================================================*/
create table TIPOVEHICULO 
(
   IDTIPO               char(30)                       not null,
   IDTARIFA             char(30)                       null,
   CLASE                char(30)                       null
);

alter table TIPOVEHICULO
   add constraint PK_TIPOVEHICULO primary key clustered (IDTIPO);

/*==============================================================*/
/* Table: VEHICULO                                              */
/*==============================================================*/
create table VEHICULO 
(
   IDVEHICULO           char(10)                       not null,
   MARCA                char(20)                       null,
   IDTIPO               char(30)                       null,
   IDPERSONA            integer                        null
);

alter table VEHICULO
   add constraint PK_VEHICULO primary key clustered (IDVEHICULO);

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

