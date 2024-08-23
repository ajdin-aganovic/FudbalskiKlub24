# APLIKACIJA FUDBALSKOG KLUBA
Aplikacija fudbalskog kluba osmišljena je kako bi pomogla svim vrstama fudbalskih klubova u pokretanju i održavanju njihovih aktivnosti. Ova intuitivna i vizuelno privlačna aplikacija pokriva administrativni i interni dio (Administracija, Stručni štab, Medicinsko osoblje, Članovi) i omogućava jednostavnu interakciju sa fanovima i kupcima. Ova aplikacija je dizajnirana da bude korisna, fleksibilna i prilagodljiva, čime pomaže klubovima da efikasnije upravljaju svojim poslovanjem i jačaju vezu sa svojim navijačima.

## Kredencijali za prijavu - Desktop aplikacija
- Administrator
```
Korisničko ime: ajdo
Lozinka: string
```
- Stručni štab
```
Korisničko ime: trener1
Lozinka: string
```
- Medicinsko osoblje
```
Korisničko ime: doktor1
Lozinka: string
```
- Član
```
Korisničko ime: igrac1
Lozinka: string
```
## Kredencijali za prijavu - Mobilna aplikacija
- Administrator
```
Korisničko ime: ajdo
Lozinka: string
```
- Kupac
```
Korisničko ime: kupac1
Lozinka: string
```

## Pokretanje aplikacije
1. Klonirajte repozitorij
```
https://github.com/ajdin-aganovic/FudbalskiKlub24
```
2. Otvara se FudbalskiKlub u Konzoli
3. Pokreće se dokerizacija API-ja i Baze podataka
```
  docker-compose build
  docker-compose up
```
odnosno
```
docker compose up --build
```
4. Pokretanje Desktop aplikacije kroz Visual Studio Code

- Otvorite FudbalskiKlub folder

- Otvorite UI folder

- Unutar UI foldera, odaberite afk_admin

- Dobavljanje dependency-a (Fetch dependencies)
```
  flutter clean
  flutter pub get
```
 Pokretanje same desktop aplikacije pomoću komande 
```
 flutter run -d windows
```
 
5. Pokretanje mobilne aplikacije kroz Visual Studio Code

- Otvorite FudbalskiKlub folder

- Otvorite UI folder
  
- Unutar UI foldera, odaberite afk_android
 
- Dobavljanje dependency-a (Fetch dependencies)
```
  flutter clean
  flutter pub get
```
- Pokrenite mobilni emulator
- Bonus: Ako želite da aplikaciju instalirate na svome mobilnom uređaju, umjesto emulatora, možete jednostavno pratiti ove korake:
-  Unutar .env fajla, na mjestu MOBILNA_LOKALNA, unijeti adresu svoje IPv4 mreže u sljedećem formatu: http://{adresa}:7181/

- Pokrenuti mobilnu aplikaciju bez debugiranja putem komande CTRL + F5 ili u Terminalu pokrenuti sljedeću komandu
```
flutter run
```

6. Korištenje RabbitMQ-a kroz Visual Studio
- RabbitMQ servis je konfigurisan tako da radi automatski čim pokrenete funkciju docker compose up --build

7. Polje zaboravljena lozinka - Gmail email servis
- Na ekranu za Prijavu, ispod polja Prijavi se, nalazi se i opcija Zaboravljena lozinka. Klikom na nju ulazi se u formu za slanje zahtjeva administratoru za ponovnim postavljanjem lozinke.
- Prijedlog: Koristiti odvojene adrese za testiranje ovoga dijela u poljima Vaš email (odlazna pošta) i Email administratora (dolazna pošta).

8. Korištenje SMTP servera
- SMTP Google mail server je konfigurisan na stranicama "Plata" i "Proizvod", po principu StateMachine-a, te na stranicama "Trening" i "Termin", po principu uloga. U slučaju kada je neki proizvod dostupan na web trgovini, svi kupci i članovi dobijaju odgovarajući mail. Email obavještenja će se dobiti i u slučaju kada je proizvod uklonjen sa web trgovine. U slučaju Plata, kada je plata puštena, korisnik će dobiti obavijest o istoj. Za Treninge i Termine, svi uvezani Igrači, Stručno i Medicinsko osoblje, dobija mail obavještenja o novokreiranoj/uređenoj aktivnosti.
