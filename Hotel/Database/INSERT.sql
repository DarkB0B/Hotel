Use HotelDb;

--Za³o¿enia--




--Klient wykupuje miejsce parkingowe na ca³y okres pobytu

--Klient wykupuje œniadanie na ca³y okres pobytu

--Œniadanie wykupywane jest przy wynajmie pokoju

--Parking wykupywany jest przy wynajmie pokoju

--Pokój po opuszczeniu przez poprzednich lokatorów wolny bêdzie dopiero nastêpnego dnia

--Klienci--

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Tomasz', 'Kowalski', '12117732724', '666555444');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Ryszard', 'Baran', '11227648654', '654363443');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Katarzyna', 'Dziuba', '12336655472', '552234413');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Adam', 'Bystroñ', '12789655472', '552897713');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Pawe³', 'Boruc', '13789656122', '596145713');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('£ukasz', 'Danielak', '11334537865', '837254819');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Mateusz', 'Chmiel', '11739268931', '997583291');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Jakub', 'Cielecki', '11946283967', '756273957');

insert into Klienci(Imie, Nazwisko, Pesel, NrKlienta)
values ('Sebastian', 'Jab³oñski', '14523456784', '772534768');


--Pracownicy--

insert into Pracownicy(ImiePracownika, NazwiskoPracownika, PeselPracownika, NrPracownika)
values ('Anna', 'Ig³a', '12346577986', '337685432');

insert into Pracownicy(ImiePracownika, NazwiskoPracownika, PeselPracownika, NrPracownika)
values ('Joanna', 'Gawron', '84627463926', '324242121');

insert into Pracownicy(ImiePracownika, NazwiskoPracownika, PeselPracownika, NrPracownika)
values ('Pawe³', 'Gawrysiak', '89674392818', '113463853');

insert into Pracownicy(ImiePracownika, NazwiskoPracownika, PeselPracownika, NrPracownika)
values ('Piotr', 'Godlewski', '12357648927', '326634275');

insert into Pracownicy(ImiePracownika, NazwiskoPracownika, PeselPracownika, NrPracownika)
values ('Artur', 'Cichy', '11249528346', '996436281');


--TypPokoju--

--typ="pojemnoœæ" ³ó¿ek

insert into TypPokoju(Typ)
values ('2')

insert into TypPokoju(Typ, Detale)
values ('2', 'Balkon')

insert into TypPokoju(Typ, Detale)
values ('2', 'Lozko Dzieciece')

insert into TypPokoju(Typ)
values ('2+1')

insert into TypPokoju(Typ, Detale)
values ('2+1', 'Balkon')

insert into TypPokoju(Typ)
values ('2+2')

insert into TypPokoju(Typ, Detale)
values ('2+2', 'Balkon')


--Cena Pokoju--

insert into CenaPokoju(CenaPokoju)
values ('110')

insert into CenaPokoju(CenaPokoju)
values ('125')

insert into CenaPokoju(CenaPokoju)
values ('115')

insert into CenaPokoju(CenaPokoju)
values ('220')

insert into CenaPokoju(CenaPokoju)
values ('235')

insert into CenaPokoju(CenaPokoju)
values ('420')

insert into CenaPokoju(CenaPokoju)
values ('435')


--Pokoje--

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('1', '1','1')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('2', '1','1')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('3', '6','6')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('4', '4','4')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('5', '1','1')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('11', '2','2')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('12', '3','3')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('13', '5','5')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('14', '6','6')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('15', '7','7')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('21', '1','1')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('22', '5','5')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('23', '6','6')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('24', '7','7')

insert into Pokoje(IdPokoju, IdTypu, IdCenyPokoju)
values ('25', '1','1')



--Uslugi--

Insert into Uslugi(Usluga, CenaUslugi)
values ('Nic', '0')

Insert into Uslugi(Usluga, CenaUslugi)
values ('Parking', '20')

Insert into Uslugi(Usluga, CenaUslugi)
values ('Sniadanie', '12')

Insert into Uslugi(Usluga, CenaUslugi)
values ('Parking + Sniadanie', '30')

--Pobyty--

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-29', '2022-07-11', '22', '2', '2', '1')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-01', '2022-06-14', '21', '2', '4', '2')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-01', '2022-06-03', '11', '3', '4', '3')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-03', '2022-06-15', '15', '4', '3', '4')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-05', '2022-06-20', '4', '4', '1', '5')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-06', '2022-06-19', '3', '2', '1', '6')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-08', '2021-06-24', '5', '2', '2', '7')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-08', '2022-06-11', '23', '1', '2', '8')

insert into Pobyty(DataPrzyjazdu, DataWyjazdu, IdPokoju, IdPracownika, IdUslugi, IdKlienta)
values ('2022-06-08', '2022-06-19', '11', '5', '1', '9')

