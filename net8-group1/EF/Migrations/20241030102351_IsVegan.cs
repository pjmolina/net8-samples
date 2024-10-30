using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF1.Migrations
{
    /// <inheritdoc />
    public partial class IsVegan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "Pizza",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "Pizza");
        }
    }
}
