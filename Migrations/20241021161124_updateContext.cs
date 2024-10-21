using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace core.Migrations
{
    /// <inheritdoc />
    public partial class updateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayrollID",
                table: "Members",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payroll",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>(type: "integer", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payroll", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payroll_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_PayrollID",
                table: "Members",
                column: "PayrollID");

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_MemberID",
                table: "Payroll",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Payroll_PayrollID",
                table: "Members",
                column: "PayrollID",
                principalTable: "Payroll",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Payroll_PayrollID",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Payroll");

            migrationBuilder.DropIndex(
                name: "IX_Members_PayrollID",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "PayrollID",
                table: "Members");
        }
    }
}
