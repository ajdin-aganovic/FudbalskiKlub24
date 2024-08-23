using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudbalskiKlub.Services.Migrations
{
    /// <inheritdoc />
    public partial class novaMigracija100824 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "Datum",
            //    table: "Termin",
            //    type: "datetime",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "KorisnikId",
            //    table: "Narudzba",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Narudzba_KorisnikId",
            //    table: "Narudzba",
            //    column: "KorisnikId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Narudzba_Korisnik_KorisnikId",
            //    table: "Narudzba",
            //    column: "KorisnikId",
            //    principalTable: "Korisnik",
            //    principalColumn: "KorisnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Narudzba_Korisnik_KorisnikId",
            //    table: "Narudzba");

            //migrationBuilder.DropIndex(
            //    name: "IX_Narudzba_KorisnikId",
            //    table: "Narudzba");

            //migrationBuilder.DropColumn(
            //    name: "Datum",
            //    table: "Termin");

            //migrationBuilder.DropColumn(
            //    name: "KorisnikId",
            //    table: "Narudzba");
        }
    }
}
