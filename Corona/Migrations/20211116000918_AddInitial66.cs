using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Migrations
{
    public partial class AddInitial66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestTestRequestId",
                table: "tblTestBooking",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "314815af-8a4b-47ce-8d08-83e711ded346", "59138d12-e099-46c7-a5c2-481de6f2ac8f" });

            migrationBuilder.CreateIndex(
                name: "IX_tblTestBooking_RequestTestRequestId",
                table: "tblTestBooking",
                column: "RequestTestRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTestBooking_tblRequestTest_RequestTestRequestId",
                table: "tblTestBooking",
                column: "RequestTestRequestId",
                principalTable: "tblRequestTest",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTestBooking_tblRequestTest_RequestTestRequestId",
                table: "tblTestBooking");

            migrationBuilder.DropIndex(
                name: "IX_tblTestBooking_RequestTestRequestId",
                table: "tblTestBooking");

            migrationBuilder.DropColumn(
                name: "RequestTestRequestId",
                table: "tblTestBooking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc5e4799-c715-4fd2-94f8-10f6c850f267", "a34fdddc-9f73-4f20-aedc-f5a7db4ac982" });
        }
    }
}
