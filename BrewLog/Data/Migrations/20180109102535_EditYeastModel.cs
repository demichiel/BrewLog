using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrewLog.Data.Migrations
{
    public partial class EditYeastModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yeasts_YeastForms_FormId",
                table: "Yeasts");

            migrationBuilder.DropForeignKey(
                name: "FK_Yeasts_YeastTypes_TypeId",
                table: "Yeasts");

            migrationBuilder.DropIndex(
                name: "IX_Yeasts_FormId",
                table: "Yeasts");

            migrationBuilder.DropIndex(
                name: "IX_Yeasts_TypeId",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "AmountIsWeight",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Yeasts");

            migrationBuilder.AddColumn<string>(
                name: "Form",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Laboratory",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductID",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Yeasts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Form",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "Laboratory",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Yeasts");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Yeasts");

            migrationBuilder.AddColumn<bool>(
                name: "AmountIsWeight",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormId",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Yeasts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yeasts_FormId",
                table: "Yeasts",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Yeasts_TypeId",
                table: "Yeasts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yeasts_YeastForms_FormId",
                table: "Yeasts",
                column: "FormId",
                principalTable: "YeastForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Yeasts_YeastTypes_TypeId",
                table: "Yeasts",
                column: "TypeId",
                principalTable: "YeastTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
