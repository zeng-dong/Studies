using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TablePerHierarchy.Migrations.ExplicitDerivedTypesDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    Charge = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DownloadSpeed = table.Column<int>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PackageType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");
        }
    }
}
