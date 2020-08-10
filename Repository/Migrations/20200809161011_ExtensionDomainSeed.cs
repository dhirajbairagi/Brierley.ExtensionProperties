using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ExtensionDomainSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "extensionprops",
                table: "ExtensionDomains",
                columns: new[] { "ExtensionDomainId", "CreatedBy", "CreatedDate", "Description", "DisplayText", "Id", "IsActive", "OwnerId", "TargetTableName", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, new Guid("6a8b4aae-db55-4bb7-bd20-c06d1976059f"), new DateTimeOffset(new DateTime(2020, 8, 9, 16, 10, 11, 59, DateTimeKind.Unspecified).AddTicks(375), new TimeSpan(0, 0, 0, 0, 0)), "Products Table", "Products Table", new Guid("6a8b4aae-db55-4bb7-bd20-c06d1976059f"), true, 1, "Products", new Guid("6a8b4aae-db55-4bb7-bd20-c06d1976059f"), new DateTimeOffset(new DateTime(2020, 8, 9, 16, 10, 11, 59, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "extensionprops",
                table: "ExtensionDomains",
                keyColumn: "ExtensionDomainId",
                keyValue: 1);
        }
    }
}
