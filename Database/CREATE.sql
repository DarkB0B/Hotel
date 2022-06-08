create database HotelDb
go
use HotelDb;

--Za³o¿enia--




--Klient wykupuje miejsce parkingowe na ca³y okres pobytu

--Klient wykupuje œniadanie na ca³y okres pobytu

--Œniadanie wykupywane jest przy wynajmie pokoju

--Parking wykupywany jest przy wynajmie pokoju

--Pokój po opuszczeniu przez poprzednich lokatorów wolny bêdzie dopiero nastêpnego dnia


--Drop--
if object_id('Klienci') IS NOT NULL
 drop table dbo.Klienci
 Go
-----------
if object_id('TypPokoju') IS NOT NULL
 drop table dbo.TypPokoju
 Go
-----------
if object_id('CenaPokoju') IS NOT NULL
 drop table dbo.CenaPokoju
 Go
 -----------
 if object_id('Pokoje') IS NOT NULL
 drop table dbo.Pokoje
 Go
 -----------
  if object_id('Pracownicy') IS NOT NULL
  drop table dbo.Pracownicy
  Go
 -----------
 if object_id('Uslugi') IS NOT NULL
 drop table dbo.Uslugi
 Go
 -----------
 if object_id('Pobyty') IS NOT NULL
 drop table dbo.Pobyty
 Go
 

 -------------------------------------------------------



 --Create--



create table Klienci (
      IdKlienta int constraint IdKlienta primary key identity(1,1),
      Imie nvarchar(30) not null,
      Nazwisko nvarchar(50) not null,
      Pesel nchar(11) UNIQUE,
      NrKlienta nchar(9) not null,
	  );



------------------------------------------------





 create table TypPokoju (
      IdTypu int constraint IdTypu primary key identity(1,1),
      Typ nvarchar(30) not null, --typ="pojemnoœæ" ³ó¿ek
	  Detale varchar(30)
	  );
						  


------------------------------------------------






 create table CenaPokoju (
      IdCenyPokoju int constraint IdCenyPokoju primary key identity(1,1),
	  CenaPokoju money,
	  );
                          


------------------------------------------------	




 create table Pokoje (
      IdPokoju int constraint IdPokoju primary key,
	  IdTypu int,
	  IdCenyPokoju int,
	  Foreign Key (IdTypu) References TypPokoju(IdTypu),
	  Foreign Key (IdCenyPokoju) References CenaPokoju(IdCenyPokoju),);


 ------------------------------------------------





create table Pracownicy (
      IdPracownika int constraint IdPracownika primary key identity(1,1),
      ImiePracownika nvarchar(30) not null,
      NazwiskoPracownika nvarchar(50) not null,
      PeselPracownika nchar(11) UNIQUE,
	  NrPracownika nchar(9) not null,
     
	  );   


------------------------------------------------




create table Uslugi (
      IdUslugi int constraint IdUslugi primary key identity(1,1),
      Usluga nvarchar(50) not null,
	  CenaUslugi money not null,
	  );


------------------------------------------------



create table  Pobyty (
	  IdPobytu int constraint IdPobytu primary key identity (1,1),
	  DataPrzyjazdu date not null,
	  DataWyjazdu date not null,
	  IdPokoju int,
	  IdPracownika int,
	  IdUslugi int,
	  IdKlienta int,
	  Foreign Key (IdPokoju) References Pokoje(IdPokoju),
	  Foreign Key (IdPracownika) References Pracownicy(IdPracownika),
	  Foreign Key (IdUslugi) References Uslugi(IdUslugi),
	  Foreign Key (IdKlienta) References Klienci(IdKlienta),

	  );




------------------------------------------------
