using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogsZurich.Server.Migrations
{
    /// <inheritdoc />
    public partial class required : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthYear",
                table: "Dogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthYear",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dogs");
        }
    }
}
