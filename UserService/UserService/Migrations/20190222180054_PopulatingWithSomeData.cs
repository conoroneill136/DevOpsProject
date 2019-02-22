using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class PopulatingWithSomeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "_RegestrationDb",
                columns: new[] { "Email", "FirstName", "LastName", "Password" },
                values: new object[] { "conor@version1.com", "Conor", "ONeill", "conor123" });

            migrationBuilder.InsertData(
                table: "_RegestrationDb",
                columns: new[] { "Email", "FirstName", "LastName", "Password" },
                values: new object[] { "uncle.bob@gmail.com", "Uncle", "Bob", "bob123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "_RegestrationDb",
                keyColumn: "Email",
                keyValue: "conor@version1.com");

            migrationBuilder.DeleteData(
                table: "_RegestrationDb",
                keyColumn: "Email",
                keyValue: "uncle.bob@gmail.com");
        }
    }
}
