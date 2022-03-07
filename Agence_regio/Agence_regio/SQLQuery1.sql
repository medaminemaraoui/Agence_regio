create database Agence_regio
use Agence_regio
use master
create table Appartement(Code_appt int primary key,Address varchar(401),Type varchar(40),Prix_loyer money)
create table Locataire(Code_loc int primary key, nom varchar(40),prenom varchar(50))
create table Locations(#Code_loc int foreign key references Locataire(Code_loc) on delete cascade,#Code_appt int foreign key references Appartement(Code_appt) on delete cascade primary key(#Code_appt,#Code_loc))
insert into Appartement values(10,'hay hassani','F1',11000),(20,'bernousi','F2',14000),(30,'anfa','F3',15000)
insert into Locataire values(77,'maraoui','medamine'),(88,'bouhraoua','nabiha'),(99,'ready','yassine'),(55,'saidi','meryem')
insert into Locations values(77,10),(88,20),(99,20),(55,10),(55,20),(88,10)
select * from Appartement where Type = 'F2'
select * from Appartement
