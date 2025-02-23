using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Migrations
{
    /// <inheritdoc />
    public partial class AddCitiesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (1, 'Sarajevo');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (1, 'Banja Luka');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (1, 'Mostar');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (2, 'New York');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (2, 'Los Angeles');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (2, 'Chicago');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (3, 'Berlin');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (3, 'Munich');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (3, 'Hamburg');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (4, 'Paris');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (4, 'Lyon');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (4, 'Marseille');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (5, 'Tokyo');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (5, 'Osaka');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (5, 'Kyoto');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (6, 'Sydney');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (6, 'Melbourne');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (6, 'Brisbane');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (7, 'Rio de Janeiro');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (7, 'Sao Paulo');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (7, 'Brasilia');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (8, 'Toronto');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (8, 'Vancouver');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (8, 'Montreal');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (9, 'Stockholm');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (9, 'Gothenburg');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (9, 'Malmö');");

            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (10, 'New Delhi');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (10, 'Mumbai');");
            migrationBuilder.Sql("INSERT INTO Cities (CountryId, [Name]) VALUES (10, 'Bangalore');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cities WHERE CountryId BETWEEN 1 AND 10;");
        }
    }
}
