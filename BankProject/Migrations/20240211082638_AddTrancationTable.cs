using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankProject.Migrations
{
    /// <inheritdoc />
    public partial class AddTrancationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrancationHistorys",
                columns: table => new
                {
                    Trancation = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrancationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Totalamount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrancationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReciverUserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrancationHistorys", x => x.Trancation);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrancationHistorys");
        }
    }
}
