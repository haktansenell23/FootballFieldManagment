using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballFieldManagment.Repository.Migrations
{
    /// <inheritdoc />
    public partial class imagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "AspNetUsers");
        }
    }
}
