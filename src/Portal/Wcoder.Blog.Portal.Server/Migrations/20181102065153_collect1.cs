using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wcoder.Blog.Portal.Server.Migrations
{
    public partial class collect1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "LogoId", "LogoUri", "Name", "Updated", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2018, 11, 2, 6, 51, 53, 735, DateTimeKind.Utc), 0L, false, 0L, "", "", "wcoder.com", new DateTime(2018, 11, 2, 6, 51, 53, 735, DateTimeKind.Utc), 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "LogoId", "LogoUri", "Name", "Updated", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2018, 11, 2, 6, 49, 54, 678, DateTimeKind.Utc), 0L, false, 0L, "", "", "wcoder.com", new DateTime(2018, 11, 2, 6, 49, 54, 678, DateTimeKind.Utc), 0L });
        }
    }
}
