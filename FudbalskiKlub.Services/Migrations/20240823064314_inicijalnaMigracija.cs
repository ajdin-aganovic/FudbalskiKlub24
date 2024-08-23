using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class inicijalnaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bolest",
                columns: table => new
                {
                    BolestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraPovrede = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipPovrede = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TrajanjePovredeDani = table.Column<int>(type: "int", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bolest__345EDD63C1FF3573", x => x.BolestId);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KorisnickoIme = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LozinkaHash = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LozinkaSalt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StrucnaSprema = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "date", nullable: true),
                    PodUgovorom = table.Column<bool>(type: "bit", nullable: true),
                    PodUgovoromOd = table.Column<DateTime>(type: "datetime", nullable: true),
                    PodUgovoromDo = table.Column<DateTime>(type: "datetime", nullable: true),
                    Uloga = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__80B06D41D28B3EED", x => x.KorisnikId);
                });

            migrationBuilder.CreateTable(
                name: "Pozicija",
                columns: table => new
                {
                    PozicijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivPozicije = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KategorijaPozicije = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pozicija__C25169AEA95BEC4D", x => x.PozicijaId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Sifra = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Kategorija = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Cijena = table.Column<double>(type: "float", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proizvod__21A8BFF81155EE96", x => x.ProizvodId);
                });

            migrationBuilder.CreateTable(
                name: "Stadion",
                columns: table => new
                {
                    StadionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivStadiona = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KapacitetStadiona = table.Column<int>(type: "int", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stadion__DDB3F389E8282FAE", x => x.StadionId);
                });

            migrationBuilder.CreateTable(
                name: "Trening",
                columns: table => new
                {
                    TreningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTreninga = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipTreninga = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DatumTreninga = table.Column<DateTime>(type: "datetime", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trening__3B04A8D37D605210", x => x.TreningId);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivUloge = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PodtipUloge = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloga__DCAB23CBA0BD3CE4", x => x.UlogaId);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    ClanarinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    IznosClanarine = table.Column<double>(type: "float", nullable: true),
                    Dug = table.Column<double>(type: "float", nullable: true),
                    Placena = table.Column<bool>(type: "bit", nullable: true),
                    DatumPlacanja = table.Column<DateTime>(type: "datetime", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clanarin__C51E3B9744FDF577", x => x.ClanarinaId);
                    table.ForeignKey(
                        name: "FK_KorisnikClanarina",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikBolest",
                columns: table => new
                {
                    KorisnikBolestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    BolestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__8ECF77DF3087028A", x => x.KorisnikBolestId);
                    table.ForeignKey(
                        name: "FK_BolestKorisnikBolest",
                        column: x => x.BolestId,
                        principalTable: "Bolest",
                        principalColumn: "BolestId");
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikBolest",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojNarudzba = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Narudzba__FBEC1377D43365F9", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "Statistika",
                columns: table => new
                {
                    StatistikaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Golovi = table.Column<int>(type: "int", nullable: true),
                    Asistencije = table.Column<int>(type: "int", nullable: true),
                    IgracMjeseca = table.Column<bool>(type: "bit", nullable: true),
                    BezPrimGola = table.Column<int>(type: "int", nullable: true),
                    ZutiKartoni = table.Column<int>(type: "int", nullable: true),
                    CrveniKartoni = table.Column<int>(type: "int", nullable: true),
                    ProsjecnaOcjena = table.Column<double>(type: "float", nullable: true),
                    OcjenaZadUtak = table.Column<double>(type: "float", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Statisti__B718DBB73CB4E6D2", x => x.StatistikaId);
                    table.ForeignKey(
                        name: "FK_KorisnikStatistika",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "TransakcijskiRacun",
                columns: table => new
                {
                    TransakcijskiRacunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    AdresaPrebivalista = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NazivBanke = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transakc__2F0E2ED1FF943D6E", x => x.TransakcijskiRacunId);
                    table.ForeignKey(
                        name: "FK_KorisnikTransakcijski",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikPozicija",
                columns: table => new
                {
                    KorisnikPozicijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    PozicijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__F374D25700F98E73", x => x.KorisnikPozicijaId);
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikPozicija",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_PozicijaKorisnikPozicija",
                        column: x => x.PozicijaId,
                        principalTable: "Pozicija",
                        principalColumn: "PozicijaId");
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    TerminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SifraTermina = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TipTermina = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StadionId = table.Column<int>(type: "int", nullable: true),
                    Rezultat = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Termin__42126C95BA3670B3", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_StadionTermin",
                        column: x => x.StadionId,
                        principalTable: "Stadion",
                        principalColumn: "StadionId");
                });

            migrationBuilder.CreateTable(
                name: "TreningStadion",
                columns: table => new
                {
                    TreningStadionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreningId = table.Column<int>(type: "int", nullable: true),
                    StadionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TreningS__83078871C7602F15", x => x.TreningStadionId);
                    table.ForeignKey(
                        name: "FK_StadionTreningStadion",
                        column: x => x.StadionId,
                        principalTable: "Stadion",
                        principalColumn: "StadionId");
                    table.ForeignKey(
                        name: "FK_TreningTreningStadion",
                        column: x => x.TreningId,
                        principalTable: "Trening",
                        principalColumn: "TreningId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisnikUlogaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__1608726E78CD53A3", x => x.KorisnikUlogaId);
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikUloga",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_UlogaKorisnikUloga",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "UlogaId");
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavke",
                columns: table => new
                {
                    NarudzbaStavkeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(type: "int", nullable: true),
                    ProizvodId = table.Column<int>(type: "int", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Narudzba__7DC8EFED3DA2E1FE", x => x.NarudzbaStavkeId);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavkeNarudzba",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaId");
                    table.ForeignKey(
                        name: "FK_NarudzbaStavkeProizvod",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodId");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikTransakcijskiRacun",
                columns: table => new
                {
                    KorisnikTransakcijskiRacunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    TransakcijskiRacunId = table.Column<int>(type: "int", nullable: false),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__1608726E51D03733", x => x.KorisnikTransakcijskiRacunId);
                    table.ForeignKey(
                        name: "FK_KorisnikKorisnikTransakcijskiRacun",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId");
                    table.ForeignKey(
                        name: "FK_TransakcijskiRacunKorisnikTransakcijskiRacun",
                        column: x => x.TransakcijskiRacunId,
                        principalTable: "TransakcijskiRacun",
                        principalColumn: "TransakcijskiRacunId");
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    PlataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransakcijskiRacunId = table.Column<int>(type: "int", nullable: true),
                    StateMachine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Iznos = table.Column<double>(type: "float", nullable: true),
                    DatumSlanja = table.Column<DateTime>(type: "datetime", nullable: true),
                    Izbrisan = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Plata__373F7313BACBD819", x => x.PlataId);
                    table.ForeignKey(
                        name: "FK_TransakcijskiRacunPlata",
                        column: x => x.TransakcijskiRacunId,
                        principalTable: "TransakcijskiRacun",
                        principalColumn: "TransakcijskiRacunId");
                });

            migrationBuilder.InsertData(
                table: "Bolest",
                columns: new[] { "BolestId", "Izbrisan", "SifraPovrede", "TipPovrede", "TrajanjePovredeDani" },
                values: new object[] { 1, false, "RK1", "Prijelom koljena", 30 });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "KorisnikId", "DatumRodjenja", "Email", "Ime", "Izbrisan", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "PodUgovorom", "PodUgovoromDo", "PodUgovoromOd", "Prezime", "StrucnaSprema", "Uloga" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ajdinaganovic23@gmail.com", "Ajdin", false, "ajdo", "Oa4rx7+qcloIktHHPDpw8b81XA8=", "IM7WzlHgXOgfq91wFu7WoA==", true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(121), "Admin", "VSS", "Administrator" },
                    { 2, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "trener1@gmail.com", "Glavni", false, "trener1", "Std8QmPLz3h+a2jBEP0bkPmWOXI=", "tPUEJCbWXnbPbOuO3qPUQA==", true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(499), "Trener", "VSS", "Glavni trener" },
                    { 3, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doktor1@gmail.com", "Glavni", false, "doktor1", "ePGBJ/x27uOkdSqDzzhvQ3u4550=", "4TNlW/LENlovWxtQ1YlEfQ==", true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(583), "Doktor", "VSS", "Doktor" },
                    { 4, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "igrac1@gmail.com", "Igrac", false, "igrac1", "UziO86wljvMdfmbwvGRrqRE6GFE=", "hvmvzCoKklCU4gtJVPKiow==", true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(624), "Prvi", "SSS", "Igrac" },
                    { 5, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kupac1@gmail.com", "Kupac", false, "kupac1", "VDNx7QjEhNesT0sEJMcLyMeordU=", "/UyWVOB7LDKVu75v1Js4VQ==", true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(664), "Prvi", "VSS", "Kupac" }
                });

            migrationBuilder.InsertData(
                table: "Pozicija",
                columns: new[] { "PozicijaId", "Izbrisan", "KategorijaPozicije", "NazivPozicije" },
                values: new object[,]
                {
                    { 1, false, "Napad", "Centarfor" },
                    { 2, false, "Vezni red", "Srednji vezni" },
                    { 3, false, "Odbrana", "Srednji stoper" },
                    { 4, false, "Vezni red", "Ofanzivni vezni" },
                    { 5, false, "Odbrana", "Golman" }
                });

            migrationBuilder.InsertData(
                table: "Proizvod",
                columns: new[] { "ProizvodId", "Cijena", "Izbrisan", "Kategorija", "Kolicina", "Naziv", "Sifra", "StateMachine" },
                values: new object[,]
                {
                    { 1, 55.0, false, "Dresovi", 50, "Gostujuci dres 24/25", "GD2425", "draft" },
                    { 2, 55.0, false, "Dresovi", 50, "Domaci dres 24/25", "DD2425", "draft" },
                    { 3, 25.0, false, "Dodaci", 150, "Sal", "Sal2425", "draft" },
                    { 4, 1.0, false, "Razno", 1000, "Fudbalske slicice (5 kom.)", "FS2425", "draft" }
                });

            migrationBuilder.InsertData(
                table: "Stadion",
                columns: new[] { "StadionId", "Izbrisan", "KapacitetStadiona", "NazivStadiona" },
                values: new object[,]
                {
                    { 1, false, 2000, "Podbrdo" },
                    { 2, false, 2000, "Uzbrdo" }
                });

            migrationBuilder.InsertData(
                table: "Trening",
                columns: new[] { "TreningId", "DatumTreninga", "Izbrisan", "NazivTreninga", "TipTreninga" },
                values: new object[] { 1, new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1612), false, "TPT", "Trening prvog tipa" });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "UlogaId", "Izbrisan", "NazivUloge", "PodtipUloge" },
                values: new object[,]
                {
                    { 1, false, "Administrator", "Administracija" },
                    { 2, false, "Glavni trener", "Strucni stab" },
                    { 3, false, "Glavni doktor", "Medicinsko osoblje" },
                    { 4, false, "Igrac", "Clan" },
                    { 5, false, "Kupac", "Navijac" },
                    { 6, false, "Bez uloge", "Bez uloge" }
                });

            migrationBuilder.InsertData(
                table: "Clanarina",
                columns: new[] { "ClanarinaId", "DatumPlacanja", "Dug", "Izbrisan", "IznosClanarine", "KorisnikId", "Placena" },
                values: new object[] { 1, new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1224), 0.0, false, 60.0, 4, false });

            migrationBuilder.InsertData(
                table: "KorisnikPozicija",
                columns: new[] { "KorisnikPozicijaId", "KorisnikId", "PozicijaId" },
                values: new object[] { 1, 4, 1 });

            migrationBuilder.InsertData(
                table: "Narudzba",
                columns: new[] { "NarudzbaId", "BrojNarudzba", "Datum", "KorisnikId", "Status" },
                values: new object[] { 1, "AJSDJWAIAfasfh1h23hs", new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1344), 5, "kreirano" });

            migrationBuilder.InsertData(
                table: "Statistika",
                columns: new[] { "StatistikaId", "Asistencije", "BezPrimGola", "CrveniKartoni", "Golovi", "IgracMjeseca", "Izbrisan", "KorisnikId", "OcjenaZadUtak", "ProsjecnaOcjena", "ZutiKartoni" },
                values: new object[] { 1, 5, 0, 1, 10, false, false, 4, 3.0, 8.0, 2 });

            migrationBuilder.InsertData(
                table: "Termin",
                columns: new[] { "TerminId", "Datum", "Izbrisan", "Rezultat", "SifraTermina", "StadionId", "TipTermina" },
                values: new object[] { 1, new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1581), null, "0:0", "UTK1", 1, "Domaca utakmica" });

            migrationBuilder.InsertData(
                table: "TransakcijskiRacun",
                columns: new[] { "TransakcijskiRacunId", "AdresaPrebivalista", "BrojRacuna", "Izbrisan", "KorisnikId", "NazivBanke" },
                values: new object[,]
                {
                    { 1, "Mahala b.b.", "12341234", false, 1, "Univerzitetskih kredita" },
                    { 2, "Alipasino polje 47", "47474747", false, 2, "Lipo halve hamdija" }
                });

            migrationBuilder.InsertData(
                table: "NarudzbaStavke",
                columns: new[] { "NarudzbaStavkeId", "Kolicina", "NarudzbaId", "ProizvodId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 1, 3 },
                    { 3, 20, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Plata",
                columns: new[] { "PlataId", "DatumSlanja", "Izbrisan", "Iznos", "StateMachine", "TransakcijskiRacunId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1477), false, 1200.0, "active", 1 },
                    { 2, new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1484), false, 900.0, "active", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanarina_KorisnikId",
                table: "Clanarina",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikBolest_BolestId",
                table: "KorisnikBolest",
                column: "BolestId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikBolest_KorisnikId",
                table: "KorisnikBolest",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikPozicija_KorisnikId",
                table: "KorisnikPozicija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikPozicija_PozicijaId",
                table: "KorisnikPozicija",
                column: "PozicijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTransakcijskiRacun_KorisnikId",
                table: "KorisnikTransakcijskiRacun",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikTransakcijskiRacun_TransakcijskiRacunId",
                table: "KorisnikTransakcijskiRacun",
                column: "TransakcijskiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_KorisnikId",
                table: "KorisnikUloga",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaId",
                table: "KorisnikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KorisnikId",
                table: "Narudzba",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_NarudzbaId",
                table: "NarudzbaStavke",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_ProizvodId",
                table: "NarudzbaStavke",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_TransakcijskiRacunId",
                table: "Plata",
                column: "TransakcijskiRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistika_KorisnikId",
                table: "Statistika",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_StadionId",
                table: "Termin",
                column: "StadionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransakcijskiRacun_KorisnikId",
                table: "TransakcijskiRacun",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_TreningStadion_StadionId",
                table: "TreningStadion",
                column: "StadionId");

            migrationBuilder.CreateIndex(
                name: "IX_TreningStadion_TreningId",
                table: "TreningStadion",
                column: "TreningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "KorisnikBolest");

            migrationBuilder.DropTable(
                name: "KorisnikPozicija");

            migrationBuilder.DropTable(
                name: "KorisnikTransakcijskiRacun");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "NarudzbaStavke");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "Statistika");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "TreningStadion");

            migrationBuilder.DropTable(
                name: "Bolest");

            migrationBuilder.DropTable(
                name: "Pozicija");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "TransakcijskiRacun");

            migrationBuilder.DropTable(
                name: "Stadion");

            migrationBuilder.DropTable(
                name: "Trening");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
