using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.Infrastructure.Migrations
{
    public partial class Migration_20221017_1043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultationRoomId1",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId1",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ConsultationRoomId1",
                table: "Visits",
                column: "ConsultationRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId1",
                table: "Visits",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId",
                table: "Visits",
                column: "ConsultationRoomId",
                principalTable: "ConsultationRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId1",
                table: "Visits",
                column: "ConsultationRoomId1",
                principalTable: "ConsultationRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_PatientId1",
                table: "Visits",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_DoctorId",
                table: "Visits",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId1",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_PatientId1",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_DoctorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_ConsultationRoomId1",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PatientId1",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ConsultationRoomId1",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Visits");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId",
                table: "Visits",
                column: "ConsultationRoomId",
                principalTable: "ConsultationRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_PatientId",
                table: "Visits",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
