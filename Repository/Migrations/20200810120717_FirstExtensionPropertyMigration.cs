using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class FirstExtensionPropertyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "extensionprops");

            migrationBuilder.CreateTable(
                name: "ExtensionDomains",
                schema: "extensionprops",
                columns: table => new
                {
                    ExtensionDomainId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    TargetTableName = table.Column<string>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    DisplayText = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtensionDomains", x => x.ExtensionDomainId);
                });

            migrationBuilder.CreateTable(
                name: "ExtensionProperties",
                schema: "extensionprops",
                columns: table => new
                {
                    ExtensionPropertyId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    ColumnName = table.Column<string>(nullable: false),
                    ExtensionDomainId = table.Column<int>(nullable: false),
                    DisplayText = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DataType = table.Column<string>(nullable: true),
                    StringMinMax = table.Column<string>(nullable: false),
                    Encryption = table.Column<string>(nullable: false),
                    IsDsar = table.Column<bool>(nullable: false),
                    IsRtbf = table.Column<bool>(nullable: false),
                    DefaultValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtensionProperties", x => x.ExtensionPropertyId);
                    table.ForeignKey(
                        name: "FK_ExtensionProperties_ExtensionDomains_ExtensionDomainId",
                        column: x => x.ExtensionDomainId,
                        principalSchema: "extensionprops",
                        principalTable: "ExtensionDomains",
                        principalColumn: "ExtensionDomainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "extensionprops",
                table: "ExtensionDomains",
                columns: new[] { "ExtensionDomainId", "CreatedBy", "CreatedDate", "Description", "DisplayText", "Id", "IsActive", "OwnerId", "TargetTableName", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, new Guid("6a8b4aae-db55-4bb7-bd20-c06d1976059f"), new DateTimeOffset(new DateTime(2020, 8, 10, 12, 7, 17, 13, DateTimeKind.Unspecified).AddTicks(9599), new TimeSpan(0, 0, 0, 0, 0)), "Products Table", "Products Table", new Guid("6a8b4aae-db55-4bb7-bd20-c06d1976059f"), true, 1, "Products", new Guid("6a8b4aae-db55-4bb7-bd20-c06d1976059f"), new DateTimeOffset(new DateTime(2020, 8, 10, 12, 7, 17, 14, DateTimeKind.Unspecified).AddTicks(728), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_ExtensionDomains_OwnerId_TargetTableName",
                schema: "extensionprops",
                table: "ExtensionDomains",
                columns: new[] { "OwnerId", "TargetTableName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExtensionProperties_ExtensionDomainId_ColumnName",
                schema: "extensionprops",
                table: "ExtensionProperties",
                columns: new[] { "ExtensionDomainId", "ColumnName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtensionProperties",
                schema: "extensionprops");

            migrationBuilder.DropTable(
                name: "ExtensionDomains",
                schema: "extensionprops");
        }
    }
}
