using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class dodanToDo4924 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "todo4924id",
                table: "Korisnik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ToDo4924",
                columns: table => new
                {
                    todo4924id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivaktivnosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    opisaktivnosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datumzavrsenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    korisnikid = table.Column<int>(type: "int", nullable: false),
                    statemachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo4924", x => x.todo4924id);
                    table.ForeignKey(
                        name: "FK_ToDo4924_Korisnik_korisnikid",
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
                value: new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd", "todo4924id" },
                values: new object[] { "DLTVRC7rk2DbL7H69ODEhZm/GJg=", "MXir7inCHafVwTmj1EemYQ==", new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(4805), null });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd", "todo4924id" },
                values: new object[] { "t0NkOr6eaWlqAqIjC0npSKn0bZ8=", "H2L2yABVgBj22I9P6B8fOw==", new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5119), null });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd", "todo4924id" },
                values: new object[] { "h5elpxCQ2EaTPijSOf+fUTISVmA=", "MyCHV/qDKxWM0ZyIVdv2Jw==", new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5159), null });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd", "todo4924id" },
                values: new object[] { "FB7XFm784ekpuM0pSFU7WI9JhcU=", "/4+xtcnxFOioF1zp4nIrDg==", new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5194), null });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt", "PodUgovoromOd", "todo4924id" },
                values: new object[] { "07ifQgfdUGIP0j69KCY9351rHHo=", "HtCL9yC8K2O4K4PrqL1p1Q==", new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5228), null });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaId",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "Plata",
                keyColumn: "PlataId",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "Plata",
                keyColumn: "PlataId",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "Termin",
                keyColumn: "TerminId",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "Trening",
                keyColumn: "TreningId",
                keyValue: 1,
                column: "DatumTreninga",
                value: new DateTime(2024, 9, 18, 3, 7, 30, 587, DateTimeKind.Local).AddTicks(5963));

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_todo4924id",
                table: "Korisnik",
                column: "todo4924id");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo4924_korisnikid",
                table: "ToDo4924",
                column: "korisnikid");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_ToDo4924_todo4924id",
                table: "Korisnik",
                column: "todo4924id",
                principalTable: "ToDo4924",
                principalColumn: "todo4924id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_ToDo4924_todo4924id",
                table: "Korisnik");

            migrationBuilder.DropTable(
                name: "ToDo4924");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_todo4924id",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "todo4924id",
                table: "Korisnik");

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
