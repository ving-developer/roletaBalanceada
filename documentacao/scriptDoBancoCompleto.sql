drop table molecula_compoe;
drop table atomo_quantificado;
drop table molecula_forma;
drop table atomo;

drop table equacao;
drop table molecula;
drop table grupo;


Create table grupo
(
	id Integer NOT NULL,
	nome Text NOT NULL,
 primary key (id)
) ;

Create table molecula
(
	id Integer primary key autoincrement  NOT NULL,
	nome Text NOT NULL
) ;


Create table Equacao
(
	id Integer primary key autoincrement NOT NULL,
	tipo Text NOT NULL

) ;


Create table atomo
(
	id Integer NOT NULL,
	grupo_id Integer references grupo (id),
	nome Text NOT NULL,
	sigla Text NOT NULL,
	numero_atomico Integer NOT NULL,
	peso_atomico Real,
 primary key (id)
) ;


Create table atomo_quantificado
(
	id  integer primary key  autoincrement  NOT NULL,
	molecula_id   Integer NOT NULL references molecula (id),
	atomo_id   Integer NOT NULL references atomo (id),
	quantidade Integer NOT NULL Default 1,
	sequencia Integer NOT NULL

) ;

Create table molecula_forma
(
	id Integer primary key autoincrement NOT NULL,
	molecula_id Integer NOT NULL references molecula (id) ,
	equacao_id Integer NOT NULL references equacao (id) ,
	tipo Text NOT NULL,
	sequencia Integer NOT NULL,
	balanco integer not null
 
) ;


Create table molecula_compoe
(
	id Integer primary key autoincrement NOT NULL,
	molecula_secundaria_id Integer NOT NULL references molecula (id) ,
	molecula_principal_id Integer NOT NULL references molecula (id) ,
	sequencia Integer NOT NULL,
	quantidade Integer NOT NULL

) ;


INSERT INTO grupo (id, nome) VALUES (1, 'Metais Alcalinos');
INSERT INTO grupo (id, nome) VALUES (2, 'Metais Alcalinos Terrosos');
INSERT INTO grupo (id, nome) VALUES (3, 'Metais Representativos');
INSERT INTO grupo (id, nome) VALUES (4, 'Metais de Transição');
INSERT INTO grupo (id, nome) VALUES (5, 'Metais de Transição Interna Lantanídeos');
INSERT INTO grupo (id, nome) VALUES (6, 'Metais de Transição Interna Actinídeos');
INSERT INTO grupo (id, nome) VALUES (7, 'Ametais ou Não metais:');
INSERT INTO grupo (id, nome) VALUES (8, 'Semimetais');
INSERT INTO grupo (id, nome) VALUES (9, 'Gases Nobres');
INSERT INTO grupo (id, nome) VALUES (10, 'Halogênios');
INSERT INTO grupo (id, nome) VALUES (11, 'Desconhecidos');

INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (1, 7, 'Hidrogênio', 'H', 1, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (2, 9, 'Hélio', 'He', 2, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (3, 1, 'Lítio', 'Li', 3, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (4, 2, 'Berílio', 'Be', 4, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (5, 8, 'Boro', 'B', 5, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (6, 7, 'Carbono', 'C', 6, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (7, 7, 'Nitrogênio', 'N', 7, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (8, 7, 'Oxigênio', 'O', 8, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (9, 10, 'Flúor', 'F', 9, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (10, 9, 'Neônio', 'Ne', 10, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (11, 1, 'Sódio', 'Na', 11, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (12, 2, 'Magnésio', 'Mg', 12, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (13, 3, 'Alumínio', 'Al', 13, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (14, 8, 'Silício', 'Si', 14, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (15, 7, 'Fósforo', 'P', 15, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (16, 7, 'Enxofre', 'S', 16, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (17, 10, 'Cloro', 'Cl', 17, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (18, 9, 'Argônio', 'Ar', 18, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (19, 1, 'Potássio', 'K', 19, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (20, 2, 'Cálcio', 'Ca', 20, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (21, 4, 'Escândio', 'Sc', 21, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (22, 4, 'Titânio', 'Ti', 22, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (23, 4, 'Vanádio', 'V', 23, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (24, 4, 'Crômio', 'Cr', 24, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (25, 4, 'Manganês', 'Mn', 25, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (26, 4, 'Ferro', 'Fe', 26, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (27, 4, 'Cobalto', 'Co', 27, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (28, 4, 'Níquel', 'Ni', 28, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (29, 4, 'Cobre', 'Cu', 29, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (30, 4, 'Zinco', 'Zn', 30, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (31, 3, 'Gálio', 'Ga', 31, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (32, 8, 'Germânio', 'Ge', 32, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (33, 8, 'Arsênio', 'As', 33, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (34, 7, 'Selênio', 'Se', 34, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (35, 10, 'Bromo', 'Br', 35, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (36, 9, 'Criptônio', 'Kr', 36, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (37, 1, 'Rubídio', 'Rb', 37, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (38, 2, 'Estrôncio', 'Sr', 38, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (39, 4, 'Ítrio', 'Y', 39, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (40, 4, 'Zircônio', 'Zr', 40, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (41, 4, 'Nióbio', 'Nb', 41, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (42, 4, 'Molibdênio', 'Mo', 42, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (43, 4, 'Tecnécio', 'Tc', 43, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (44, 4, 'Rutênio', 'Ru', 44, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (45, 4, 'Ródio', 'Rh', 45, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (46, 4, 'Paládio', 'Pd', 46, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (47, 4, 'Prata', 'Ag', 47, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (48, 4, 'Cádmio', 'Cd', 48, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (49, 3, 'Índio', 'In', 49, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (50, 3, 'Estanho', 'Sn', 50, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (51, 8, 'Antimônio', 'Sb', 51, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (52, 8, 'Telúrio', 'Te', 52, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (53, 10, 'Iodo', 'I', 53, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (54, 9, 'Xenônio', 'Xe', 54, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (55, 1, 'Césio', 'Cs', 55, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (56, 2, 'Bário', 'Ba', 56, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (57, 5, 'Lantânio', 'La', 57, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (58, 5, 'Cério', 'Ce', 58, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (59, 5, 'Praseodímio', 'Pr', 59, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (60, 5, 'Neodímio', 'Nd', 60, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (61, 5, 'Promécio', 'Pm', 61, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (62, 5, 'Samário', 'Sm', 62, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (63, 5, 'Európio', 'Eu', 63, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (64, 5, 'Gadolínio', 'Gd', 64, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (65, 5, 'Térbio', 'Tb', 65, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (66, 5, 'Disprósio', 'Dy', 66, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (67, 5, 'Hôlmio', 'Ho', 67, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (68, 5, 'Érbio', 'Er', 68, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (69, 5, 'Túlio', 'Tm', 69, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (70, 5, 'Itérbio', 'Yb', 70, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (71, 5, 'Lutécio', 'Lu', 71, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (72, 4, 'Háfnio', 'Hf', 72, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (73, 4, 'Tântalo', 'Ta', 73, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (74, 4, 'Tungstênio', 'W', 74, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (75, 4, 'Rênio', 'Re', 75, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (76, 4, 'Ósmio', 'Os', 76, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (77, 4, 'Irídio', 'Ir', 77, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (78, 4, 'Platina', 'Pt', 78, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (79, 4, 'Ouro', 'Au', 79, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (80, 4, 'Mercúrio', 'Hg', 80, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (81, 3, 'Tálio', 'Tl', 81, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (82, 3, 'Chumbo', 'Pb', 82, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (83, 3, 'Bismuto', 'Bi', 83, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (84, 10, 'Polônio', 'Po', 84, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (85, 10, 'Astato', 'At', 85, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (86, 9, 'Radônio', 'Rn', 86, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (87, 1, 'Frâncio', 'Fr', 87, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (88, 2, 'Rádio', 'Ra', 88, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (89, 6, 'Actínio', 'Ac', 89, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (90, 6, 'Tório', 'Th', 90, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (91, 6, 'Protactínio', 'Pa', 91, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (92, 6, 'Urânio', 'U', 92, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (93, 6, 'Neptúnio', 'Np', 93, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (94, 6, 'Plutônio', 'Pu', 94, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (95, 6, 'Amerício', 'Am', 95, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (96, 6, 'Cúrio', 'Cm', 96, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (97, 6, 'Berquélio', 'Bk', 97, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (98, 6, 'Califórnio', 'Cf', 98, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (99, 6, 'Einstênio', 'Es', 99, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (100, 6, 'Férmio', 'Fm', 100, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (101, 6, 'Mendelévio', 'Md', 101, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (102, 6, 'Nobélio', 'No', 102, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (103, 6, 'Laurêncio', 'Lr', 103, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (104, 4, 'Rutherfórdio', 'Rf', 104, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (105, 4, 'Dúbnio', 'Db', 105, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (106, 4, 'Seabórgio', 'Sg', 106, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (107, 4, 'Bóhrio', 'Bh', 107, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (108, 4, 'Hássio', 'Hs', 108, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (109, 4, 'Meitnério', 'Mt', 109, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (110, 4, 'Darmstádtio', 'Ds', 110, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (111, 4, 'Roentgênio', 'Rg', 111, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (112, 4, 'Copernício', 'Cn', 112, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (113, 3, 'Nihônio', 'Nh', 113, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (114, 3, 'Fleróvio', 'Fl', 114, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (115, 3, 'Moscóvio', 'Mc', 115, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (116, 3, 'Livermório', 'Lv', 116, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (117, 10, 'Tennesso', 'Ts', 117, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (118, 9, 'Oganessônio', 'Og', 118, null);



