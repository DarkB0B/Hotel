Use Hotel;

--Za³o¿enia--




--Klient wykupuje miejsce parkingowe na ca³y okres pobytu

--Klient wykupuje œniadanie na ca³y okres pobytu

--Œniadanie wykupywane jest przy wynajmie pokoju

--Parking wykupywany jest przy wynajmie pokoju

--Pokój po opuszczeniu przez poprzednich lokatorów wolny bêdzie dopiero nastêpnego dnia


--Wykaz wolnych pokoi--


select IdPokoju as WolnePokoje from Pokoje

except

select IdPokoju from Pobyty where DataWyjazdu > GETDATE()


--W którym pokoju nikt nigdy nie nocowa³--


select IdPokoju as 'Nie Uzyte' from Pokoje

except

select IdPokoju from Pobyty 

--Kto gdzie nocowa³ i ile zap³aci³ w ostatnim tygodniu--

select CenaPokoju*(DATEDIFF(day,DataPrzyjazdu,DataWyjazdu))+u.CenaUslugi as 'Cena Pobytu' from Pobyty m 

inner join pokoje p on m.IdPokoju = P.IdPokoju
inner join CenaPokoju c on p.IdCenyPokoju = c.IdCenyPokoju
inner join Klienci k on m.IdKlienta = k.IdKlienta
inner join Uslugi u on m.IdUslugi = u.IdUslugi

where DataPrzyjazdu Between GETDATE() and (GETDATE() - 7) or DataWyjazdu Between GETDATE() and (GETDATE() - 7) or GETDATE() between DataPrzyjazdu and DataWyjazdu



