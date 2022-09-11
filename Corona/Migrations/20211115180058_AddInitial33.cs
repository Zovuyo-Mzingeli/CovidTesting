using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Migrations
{
    public partial class AddInitial33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblTestBooking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f334ed80-56d9-4876-932b-0e11196e081d", "6054961a-39d4-4f2e-904f-02c0b719c659" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblTestBooking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36a66641-9106-4043-b6f1-2c186e522ae5", "f7dd2886-8fcd-451a-8ab9-868ac940e41e" });
        }
    }
}
