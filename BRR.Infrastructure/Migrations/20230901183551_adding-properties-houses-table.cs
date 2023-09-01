using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BRR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingpropertieshousestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Inmuebles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "en_venta",
                table: "Inmuebles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "en_venta",
                table: "Inmuebles");
        }
    }
}
