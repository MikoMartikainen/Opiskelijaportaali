# Opiskelijaportaali
Projekti_Ryhmä_1

11.11.2025 Yhdistetty kirjautumis- / rekisteröintisivut
Tiedostoja korvattu allaolevasti:
- Data\ApplicationDbContext -> Data\AppDbContext
- Models\ApplicationUser -> Models\Profile

Valmiita storeja käyttäviä asioita kommentoitu pois, koska rikkovat buildin:
- Program.cs, rivi 27
- Program.cs, rivit 34-39

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

