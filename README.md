# Opiskelijaportaali
Projekti_Ryhmä_1

TIETOKANNAN RAKENNUS
Tietokanta täytyy rakentaa paikallisesti, jotta data on saatavilla testivaiheessa.
Tietokanta on MySQL -pohjainen, joten kannattaa ladata MySQL Workbench 8 ensin
1. Avaa komentokehote projektin kansiossa
2. Aja "dotnet ef database update"
3. Käsky rakentaa tietokannan ja luo sinne pari testiriviä

OHJELMAN AJAMINEN
1. Avaa projekti Visual Studiossa
2. Klikkaa yläpalkista "Start" (projektin nimi), tai F5
3. Ohjelma avaa selaimen, lisää osoitteeseen "/swagger" (esim. https://localhost:51396/swagger/), niin näet tietokantakutsut

TO DO
1. Lisää profile table salasana-sarake
2. Lisää tietojen päivitys mahdollisuus tapahtumille
3. Lisää mahdollisuus päivittää ja poistaa profiileja
4. Lisää ilmoittautumiset
