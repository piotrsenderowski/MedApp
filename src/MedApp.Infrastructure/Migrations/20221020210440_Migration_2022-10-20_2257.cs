using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.Infrastructure.Migrations
{
    public partial class Migration_20221020_2257 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_VisitDetail_VisitDetailId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "VisitDetail");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitDetailId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "VisitDetailId",
                table: "Visits");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Visits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTo",
                table: "Visits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcedureName",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ProcedureName",
                table: "Visits");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitDetailId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisitDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitDetail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitDetailId",
                table: "Visits",
                column: "VisitDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_VisitDetail_VisitDetailId",
                table: "Visits",
                column: "VisitDetailId",
                principalTable: "VisitDetail",
                principalColumn: "Id");
        }
    }
}
