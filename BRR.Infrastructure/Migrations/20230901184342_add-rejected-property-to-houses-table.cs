using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BRR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addrejectedpropertytohousestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRejected",
                table: "Inmuebles",
                newName: "rechazada");

            migrationBuilder.AlterColumn<bool>(
                name: "rechazada",
                table: "Inmuebles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rechazada",
                table: "Inmuebles",
                newName: "IsRejected");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRejected",
                table: "Inmuebles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
