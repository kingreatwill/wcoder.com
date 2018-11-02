using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wcoder.Blog.Portal.Server.Migrations
{
    public partial class collectAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.CreateTable(
                name: "Collects",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Uri = table.Column<string>(maxLength: 50, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Importance = table.Column<int>(nullable: false),
                    TenantId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    DeletedBy = table.Column<long>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "LogoId", "LogoUri", "Name", "Updated", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2018, 11, 2, 6, 54, 25, 680, DateTimeKind.Utc), 0L, false, 0L, "", "", "wcoder.com", new DateTime(2018, 11, 2, 6, 54, 25, 680, DateTimeKind.Utc), 0L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collects");

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.InsertData(
                table: "Tenant",
                columns: new[] { "Id", "Created", "CreatedBy", "Deleted", "DeletedBy", "LogoId", "LogoUri", "Name", "Updated", "UpdatedBy" },
                values: new object[] { 1L, new DateTime(2018, 11, 2, 6, 51, 53, 735, DateTimeKind.Utc), 0L, false, 0L, "", "", "wcoder.com", new DateTime(2018, 11, 2, 6, 51, 53, 735, DateTimeKind.Utc), 0L });
        }
    }
}
