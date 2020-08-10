using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class ExtensionPropsFirst : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_ExtensionDomains_ExtensionDomainId_TargetTableName",
                schema: "extensionprops",
                table: "ExtensionDomains",
                columns: new[] { "ExtensionDomainId", "TargetTableName" },
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
