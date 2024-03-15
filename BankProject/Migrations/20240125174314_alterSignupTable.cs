using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankProject.Migrations
{
    /// <inheritdoc />
    public partial class alterSignupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SignUPModels",
                table: "SignUPModels");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SignUPModels",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignUPModels",
                table: "SignUPModels",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SignUPModels",
                table: "SignUPModels");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SignUPModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignUPModels",
                table: "SignUPModels",
                column: "ID");
        }
    }
}
