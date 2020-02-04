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
INSERT INTO grupo (id, nome) VALUES (4, 'Metais de Transi��o');
INSERT INTO grupo (id, nome) VALUES (5, 'Metais de Transi��o Interna Lantan�deos');
INSERT INTO grupo (id, nome) VALUES (6, 'Metais de Transi��o Interna Actin�deos');
INSERT INTO grupo (id, nome) VALUES (7, 'Ametais ou N�o metais:');
INSERT INTO grupo (id, nome) VALUES (8, 'Semimetais');
INSERT INTO grupo (id, nome) VALUES (9, 'Gases Nobres');
INSERT INTO grupo (id, nome) VALUES (10, 'Halog�nios');
INSERT INTO grupo (id, nome) VALUES (11, 'Desconhecidos');

INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (1, 7, 'Hidrog�nio', 'H', 1, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (2, 9, 'H�lio', 'He', 2, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (3, 1, 'L�tio', 'Li', 3, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (4, 2, 'Ber�lio', 'Be', 4, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (5, 8, 'Boro', 'B', 5, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (6, 7, 'Carbono', 'C', 6, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (7, 7, 'Nitrog�nio', 'N', 7, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (8, 7, 'Oxig�nio', 'O', 8, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (9, 10, 'Fl�or', 'F', 9, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (10, 9, 'Ne�nio', 'Ne', 10, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (11, 1, 'S�dio', 'Na', 11, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (12, 2, 'Magn�sio', 'Mg', 12, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (13, 3, 'Alum�nio', 'Al', 13, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (14, 8, 'Sil�cio', 'Si', 14, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (15, 7, 'F�sforo', 'P', 15, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (16, 7, 'Enxofre', 'S', 16, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (17, 10, 'Cloro', 'Cl', 17, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (18, 9, 'Arg�nio', 'Ar', 18, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (19, 1, 'Pot�ssio', 'K', 19, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (20, 2, 'C�lcio', 'Ca', 20, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (21, 4, 'Esc�ndio', 'Sc', 21, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (22, 4, 'Tit�nio', 'Ti', 22, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (23, 4, 'Van�dio', 'V', 23, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (24, 4, 'Cr�mio', 'Cr', 24, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (25, 4, 'Mangan�s', 'Mn', 25, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (26, 4, 'Ferro', 'Fe', 26, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (27, 4, 'Cobalto', 'Co', 27, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (28, 4, 'N�quel', 'Ni', 28, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (29, 4, 'Cobre', 'Cu', 29, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (30, 4, 'Zinco', 'Zn', 30, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (31, 3, 'G�lio', 'Ga', 31, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (32, 8, 'Germ�nio', 'Ge', 32, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (33, 8, 'Ars�nio', 'As', 33, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (34, 7, 'Sel�nio', 'Se', 34, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (35, 10, 'Bromo', 'Br', 35, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (36, 9, 'Cript�nio', 'Kr', 36, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (37, 1, 'Rub�dio', 'Rb', 37, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (38, 2, 'Estr�ncio', 'Sr', 38, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (39, 4, '�trio', 'Y', 39, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (40, 4, 'Zirc�nio', 'Zr', 40, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (41, 4, 'Ni�bio', 'Nb', 41, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (42, 4, 'Molibd�nio', 'Mo', 42, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (43, 4, 'Tecn�cio', 'Tc', 43, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (44, 4, 'Rut�nio', 'Ru', 44, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (45, 4, 'R�dio', 'Rh', 45, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (46, 4, 'Pal�dio', 'Pd', 46, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (47, 4, 'Prata', 'Ag', 47, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (48, 4, 'C�dmio', 'Cd', 48, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (49, 3, '�ndio', 'In', 49, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (50, 3, 'Estanho', 'Sn', 50, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (51, 8, 'Antim�nio', 'Sb', 51, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (52, 8, 'Tel�rio', 'Te', 52, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (53, 10, 'Iodo', 'I', 53, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (54, 9, 'Xen�nio', 'Xe', 54, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (55, 1, 'C�sio', 'Cs', 55, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (56, 2, 'B�rio', 'Ba', 56, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (57, 5, 'Lant�nio', 'La', 57, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (58, 5, 'C�rio', 'Ce', 58, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (59, 5, 'Praseod�mio', 'Pr', 59, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (60, 5, 'Neod�mio', 'Nd', 60, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (61, 5, 'Prom�cio', 'Pm', 61, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (62, 5, 'Sam�rio', 'Sm', 62, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (63, 5, 'Eur�pio', 'Eu', 63, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (64, 5, 'Gadol�nio', 'Gd', 64, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (65, 5, 'T�rbio', 'Tb', 65, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (66, 5, 'Dispr�sio', 'Dy', 66, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (67, 5, 'H�lmio', 'Ho', 67, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (68, 5, '�rbio', 'Er', 68, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (69, 5, 'T�lio', 'Tm', 69, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (70, 5, 'It�rbio', 'Yb', 70, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (71, 5, 'Lut�cio', 'Lu', 71, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (72, 4, 'H�fnio', 'Hf', 72, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (73, 4, 'T�ntalo', 'Ta', 73, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (74, 4, 'Tungst�nio', 'W', 74, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (75, 4, 'R�nio', 'Re', 75, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (76, 4, '�smio', 'Os', 76, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (77, 4, 'Ir�dio', 'Ir', 77, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (78, 4, 'Platina', 'Pt', 78, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (79, 4, 'Ouro', 'Au', 79, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (80, 4, 'Merc�rio', 'Hg', 80, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (81, 3, 'T�lio', 'Tl', 81, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (82, 3, 'Chumbo', 'Pb', 82, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (83, 3, 'Bismuto', 'Bi', 83, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (84, 10, 'Pol�nio', 'Po', 84, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (85, 10, 'Astato', 'At', 85, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (86, 9, 'Rad�nio', 'Rn', 86, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (87, 1, 'Fr�ncio', 'Fr', 87, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (88, 2, 'R�dio', 'Ra', 88, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (89, 6, 'Act�nio', 'Ac', 89, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (90, 6, 'T�rio', 'Th', 90, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (91, 6, 'Protact�nio', 'Pa', 91, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (92, 6, 'Ur�nio', 'U', 92, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (93, 6, 'Nept�nio', 'Np', 93, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (94, 6, 'Plut�nio', 'Pu', 94, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (95, 6, 'Amer�cio', 'Am', 95, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (96, 6, 'C�rio', 'Cm', 96, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (97, 6, 'Berqu�lio', 'Bk', 97, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (98, 6, 'Calif�rnio', 'Cf', 98, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (99, 6, 'Einst�nio', 'Es', 99, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (100, 6, 'F�rmio', 'Fm', 100, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (101, 6, 'Mendel�vio', 'Md', 101, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (102, 6, 'Nob�lio', 'No', 102, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (103, 6, 'Laur�ncio', 'Lr', 103, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (104, 4, 'Rutherf�rdio', 'Rf', 104, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (105, 4, 'D�bnio', 'Db', 105, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (106, 4, 'Seab�rgio', 'Sg', 106, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (107, 4, 'B�hrio', 'Bh', 107, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (108, 4, 'H�ssio', 'Hs', 108, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (109, 4, 'Meitn�rio', 'Mt', 109, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (110, 4, 'Darmst�dtio', 'Ds', 110, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (111, 4, 'Roentg�nio', 'Rg', 111, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (112, 4, 'Copern�cio', 'Cn', 112, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (113, 3, 'Nih�nio', 'Nh', 113, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (114, 3, 'Fler�vio', 'Fl', 114, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (115, 3, 'Mosc�vio', 'Mc', 115, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (116, 3, 'Liverm�rio', 'Lv', 116, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (117, 10, 'Tennesso', 'Ts', 117, null);
INSERT INTO atomo (id, grupo_id, nome, sigla, numero_atomico, peso_atomico) VALUES (118, 9, 'Oganess�nio', 'Og', 118, null);



