Use Hotel;

--Za�o�enia--




--Klient wykupuje miejsce parkingowe na ca�y okres pobytu

--Klient wykupuje �niadanie na ca�y okres pobytu

--�niadanie wykupywane jest przy wynajmie pokoju

--Parking wykupywany jest przy wynajmie pokoju

--Pok�j po opuszczeniu przez poprzednich lokator�w wolny b�dzie dopiero nast�pnego dnia


--Wykaz wolnych pokoi--


select IdPokoju as WolnePokoje from Pokoje

except

select IdPokoju from Pobyty where DataWyjazdu > GETDATE()


--W kt�rym pokoju nikt nigdy nie nocowa�--


select IdPokoju as 'Nie Uzyte' from Pokoje

except

select IdPokoju from Pobyty 

--Kto gdzie nocowa� i ile zap�aci� w ostatnim tygodniu--

select CenaPokoju*(DATEDIFF(day,DataPrzyjazdu,DataWyjazdu))+u.CenaUslugi as 'Cena Pobytu' from Pobyty m 

inner join pokoje p on m.IdPokoju = P.IdPokoju
inner join CenaPokoju c on p.IdCenyPokoju = c.IdCenyPokoju
inner join Klienci k on m.IdKlienta = k.IdKlienta
inner join Uslugi u on m.IdUslugi = u.IdUslugi

where DataPrzyjazdu Between GETDATE() and (GETDATE() - 7) or DataWyjazdu Between GETDATE() and (GETDATE() - 7) or GETDATE() between DataPrzyjazdu and DataWyjazdu



