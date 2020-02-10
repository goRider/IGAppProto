using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IgnAppTestSQL.Migrations
{
    public partial class UpdatedFieldMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HRApproved",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "AspNetUsers",
                newName: "TermDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsQualificationQuestionComplete",
                table: "IgniteUserApplications",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationApprovalDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HiredDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsQualificationQuestionComplete",
                table: "IgniteUserApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationApprovalDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HiredDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TermDate",
                table: "AspNetUsers",
                newName: "StartDate");

            migrationBuilder.AddColumn<bool>(
                name: "HRApproved",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }
    }
}
