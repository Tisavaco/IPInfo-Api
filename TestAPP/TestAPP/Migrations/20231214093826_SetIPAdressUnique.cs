using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPP.Migrations
{
    public partial class SetIPAdressUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RequestHistorys_IPAddress",
                table: "RequestHistorys",
                column: "IPAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RequestHistorys_IPAddress",
                table: "RequestHistorys");
        }
    }
}
