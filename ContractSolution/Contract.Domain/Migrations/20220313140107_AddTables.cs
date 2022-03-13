using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contract.Domain.Migrations
{
    public partial class AddTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuaranteeAmountValue = table.Column<double>(type: "float", nullable: false),
                    GuaranteeAmountCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhaseOfContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalAmountValue = table.Column<double>(type: "float", nullable: false),
                    OriginalAmountCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallmentAmountValue = table.Column<double>(type: "float", nullable: false),
                    InstallmentAmountCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentBalanceValue = table.Column<double>(type: "float", nullable: false),
                    CurrentBalanceCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverdueBalanceValue = table.Column<double>(type: "float", nullable: false),
                    OverdueBalanceCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfLastPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAccountOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractModels_Amounts_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Amounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualRoleRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IndividualId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualRoleRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualRoleRelation_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualRoleRelation_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualRoleRelationContractRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IndividualRoleRelationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualRoleRelationContractRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualRoleRelationContractRelation_ContractModels_ContractModelId",
                        column: x => x.ContractModelId,
                        principalTable: "ContractModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualRoleRelationContractRelation_IndividualRoleRelation_IndividualRoleRelationId",
                        column: x => x.IndividualRoleRelationId,
                        principalTable: "IndividualRoleRelation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractModels_AmountId",
                table: "ContractModels",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualRoleRelation_IndividualId",
                table: "IndividualRoleRelation",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualRoleRelation_RoleId",
                table: "IndividualRoleRelation",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualRoleRelationContractRelation_ContractModelId",
                table: "IndividualRoleRelationContractRelation",
                column: "ContractModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualRoleRelationContractRelation_IndividualRoleRelationId",
                table: "IndividualRoleRelationContractRelation",
                column: "IndividualRoleRelationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualRoleRelationContractRelation");

            migrationBuilder.DropTable(
                name: "ContractModels");

            migrationBuilder.DropTable(
                name: "IndividualRoleRelation");

            migrationBuilder.DropTable(
                name: "Amounts");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
