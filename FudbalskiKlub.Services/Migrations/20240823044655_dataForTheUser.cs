using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class dataForTheUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "KorisnikId", "DatumRodjenja", "Email", "Ime", "Izbrisan", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "PodUgovorom", "PodUgovoromDo", "PodUgovoromOd", "Prezime", "StrucnaSprema", "Uloga" },
                values: new object[] { 1, new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ajdinaganovic23@gmail.com", "Ajdin", false, "ajdo", "X9daZgUPNFHXBUsvXLpS9NlOgU8=", "+UEXRUzOUBzegZPmlU9P3g==", true, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 6, 46, 53, 757, DateTimeKind.Local).AddTicks(9224), "Admin", "VSS", "Administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "KorisnikId",
                keyValue: 1);
        }
    }
}
