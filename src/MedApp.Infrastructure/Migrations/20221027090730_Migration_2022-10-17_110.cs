﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedApp.Infrastructure.Migrations
{
    public partial class Migration_20221017_110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId1",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Patients_PatientId1",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_ConsultationRoomId1",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_PatientId1",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ConsultationRoomId1",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ConsultationRoomId1",
                table: "Visits",
                column: "ConsultationRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId1",
                table: "Visits",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_ConsultationRooms_ConsultationRoomId1",
                table: "Visits",
                column: "ConsultationRoomId1",
                principalTable: "ConsultationRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Patients_PatientId1",
                table: "Visits",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Users_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
