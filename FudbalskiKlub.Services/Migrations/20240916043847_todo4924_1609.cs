using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class todo4924_1609 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo4924",
                columns: table => new
                {
                    todo4924id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivaktivnosti = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    opisaktivnosti = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    datumzavrsenja = table.Column<DateTime>(type: "datetime", nullable: false),
                    korisnikid = table.Column<int>(type: "int", nullable: false),
                    statemachine = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TODO4924_askdaskdj", x => x.todo4924id);
                    table.ForeignKey(
                        name: "FK_ToDo4924Korisnik",
                        column: x => x.korisnikid,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Clanarina",
                keyColumn: "ClanarinaId",
                keyValue: 1,
                column: "DatumPlacanja",
                value: new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "A8p5Z0J5Vpk3+xijG+CIEWHHclU=", "WPF5nHZxfUk1ewO0N0qBPA==", new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(3038) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "HTDgpKHNsBM5C0i9i9nkXnbOXxk=", "ZMafeiMJmeJzqEJwNeYG6g==", new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "vraCTh2U92Oh6Vn/HMpccpLICbM=", "m3hm584IVgX1DS4IQIekSA==", new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "NFMrVzEpb/DnvxH0lRZyjfzmRag=", "tuIaDWPEdQSOEVwNrpQFSA==", new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(3590) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "nrPagCSgYHf3U9oNMoflRQFOva4=", "FTpVTGzhfJunpqzEKHCrlA==", new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(3629) });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaId",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "Plata",
                keyColumn: "PlataId",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "Plata",
                keyColumn: "PlataId",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminId",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4401));

            migrationBuilder.InsertData(
                table: "ToDo4924",
                columns: new[] { "todo4924id", "datumzavrsenja", "korisnikid", "nazivaktivnosti", "opisaktivnosti", "statemachine" },
                values: new object[] { 1, new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4002), 1, "prva aktivnost", "opis prve aktivnosti", "U toku" });

            migrationBuilder.UpdateData(
                table: "Trening",
                keyColumn: "TreningId",
                keyValue: 1,
                column: "DatumTreninga",
                value: new DateTime(2024, 9, 16, 6, 38, 46, 694, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.CreateIndex(
                name: "IX_ToDo4924_korisnikid",
                table: "ToDo4924",
                column: "korisnikid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo4924");

            migrationBuilder.UpdateData(
                table: "Clanarina",
                keyColumn: "ClanarinaId",
                keyValue: 1,
                column: "DatumPlacanja",
                value: new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "Oa4rx7+qcloIktHHPDpw8b81XA8=", "IM7WzlHgXOgfq91wFu7WoA==", new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(121) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "Std8QmPLz3h+a2jBEP0bkPmWOXI=", "tPUEJCbWXnbPbOuO3qPUQA==", new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "ePGBJ/x27uOkdSqDzzhvQ3u4550=", "4TNlW/LENlovWxtQ1YlEfQ==", new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(583) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "UziO86wljvMdfmbwvGRrqRE6GFE=", "hvmvzCoKklCU4gtJVPKiow==", new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(624) });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd" },
                values: new object[] { "VDNx7QjEhNesT0sEJMcLyMeordU=", "/UyWVOB7LDKVu75v1Js4VQ==", new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaId",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Plata",
                keyColumn: "PlataId",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Plata",
                keyColumn: "PlataId",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminId",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Trening",
                keyColumn: "TreningId",
                keyValue: 1,
                column: "DatumTreninga",
                value: new DateTime(2024, 8, 23, 8, 43, 14, 205, DateTimeKind.Local).AddTicks(1612));
        }
    }
}
