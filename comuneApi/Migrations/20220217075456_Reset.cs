using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comuneApi.Migrations
{
    public partial class Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "beneficies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beneficies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "factures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Num_facture = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Date_facture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FournisseurId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    RC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compte = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titre = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    beneficieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Matricul = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    productType = table.Column<int>(type: "int", nullable: false),
                    Prix_unitaire = table.Column<string>(type: "varchar(100)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facturesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    beneficieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    operationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beneficies");

            migrationBuilder.DropTable(
                name: "factures");

            migrationBuilder.DropTable(
                name: "fournisseurs");

            migrationBuilder.DropTable(
                name: "operations");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
