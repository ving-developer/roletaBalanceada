/*
Created		08/01/2020
Modified		15/01/2020
Project		
Model			
Company		
Author		
Version		
Database		PostgreSQL 8.1 
*/


/* Create Domains */


/* Create Tables */


Create table "atomo"
(
	"id" Integer NOT NULL,
	"grupo_id" Integer,
	"nome" Text NOT NULL,
	"sigla" Text NOT NULL,
	"numero_atomico" Integer NOT NULL,
	"peso_atomico" Real,
 primary key ("id")
) Without Oids;


Create table "grupo"
(
	"id" Integer NOT NULL,
	"nome" Text NOT NULL,
 primary key ("id")
) Without Oids;


Create table "molecula"
(
	"id" Integer primary key autoincrement  NOT NULL,
	"nome" Text NOT NULL,
 primary key ("id")
) Without Oids;


Create table "atomo_quantificado"
(
	"id"  "autoincrement" NOT NULL,
	"molecula_id" Integer NOT NULL,
	"atomo_id" Integer NOT NULL,
	"quantidade" Integer NOT NULL Default 1,
	"sequencia" Integer NOT NULL,
 primary key ("id")
) Without Oids;


Create table "molecula_forma"
(
	"id" Integer autoincrement NOT NULL,
	"molecula_id" Integer primary key autoincrement  NOT NULL,
	"equacao_id" Integer autoincrement NOT NULL,
	"tipo" Text NOT NULL,
	"sequencia" Integer NOT NULL,
 primary key ("id")
) Without Oids;


Create table "Equacao"
(
	"id" Integer autoincrement NOT NULL,
	"tipo" Text NOT NULL,
 primary key ("id")
) Without Oids;


Create table "molecula_compoe"
(
	"id" Integer NOT NULL,
	"molecula_secundaria_id" Integer primary key autoincrement  NOT NULL,
	"molecula_principal_id" Integer primary key autoincrement  NOT NULL,
	"sequencia" Integer NOT NULL,
	"quantidade" Integer NOT NULL,
 primary key ("id")
) Without Oids;


/* Create Foreign Keys */

Alter table "atomo_quantificado" add  foreign key ("atomo_id") references "atomo" ("id") on update restrict on delete restrict;

Alter table "atomo" add  foreign key ("grupo_id") references "grupo" ("id") on update restrict on delete restrict;

Alter table "atomo_quantificado" add  foreign key ("molecula_id") references "molecula" ("id") on update restrict on delete restrict;

Alter table "molecula_compoe" add  foreign key ("molecula_principal_id") references "molecula" ("id") on update restrict on delete restrict;

Alter table "molecula_compoe" add  foreign key ("molecula_secundaria_id") references "molecula" ("id") on update restrict on delete restrict;

Alter table "molecula_forma" add  foreign key ("molecula_id") references "molecula" ("id") on update restrict on delete restrict;

Alter table "molecula_forma" add  foreign key ("equacao_id") references "Equacao" ("id") on update restrict on delete restrict;


