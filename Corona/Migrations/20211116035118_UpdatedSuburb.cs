using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Migrations
{
    public partial class UpdatedSuburb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e867a628-9a62-4531-9737-e0ab299afee3", "7809b774-3556-42a6-b02a-63d8a66fdf7a" });

            migrationBuilder.InsertData(
                table: "tblSuburb",
                columns: new[] { "SuburbId", "CityId", "SuburbName" },
                values: new object[] { "117", "1", "Sherwood" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblSuburb",
                keyColumn: "SuburbId",
                keyValue: "117");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "314815af-8a4b-47ce-8d08-83e711ded346", "59138d12-e099-46c7-a5c2-481de6f2ac8f" });
        }
    }
}
