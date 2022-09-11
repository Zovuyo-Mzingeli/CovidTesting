using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Migrations
{
    public partial class AddInitial22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestedDate",
                table: "tblRequestTest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tblRequestTest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36a66641-9106-4043-b6f1-2c186e522ae5", "f7dd2886-8fcd-451a-8ab9-868ac940e41e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedDate",
                table: "tblRequestTest");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblRequestTest");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f9658cb-9407-4ad8-89d6-657bd8e1ce39", "70546a47-84ca-4df1-998f-50d94a27ab67" });
        }
    }
}
