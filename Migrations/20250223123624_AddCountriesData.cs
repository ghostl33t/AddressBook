using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBook.Migrations
{
    /// <inheritdoc />
    public partial class AddCountriesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Bosnia and Herzegovina');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('United States');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Germany');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('France');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Japan');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Australia');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Brazil');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Canada');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('Sweden');");
            migrationBuilder.Sql("INSERT INTO Countries ([Name]) VALUES ('India');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
