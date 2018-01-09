using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrewLog.Data.Migrations
{
    public partial class EditModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fermentables_FermentableTypes_TypeId",
                table: "Fermentables");

            migrationBuilder.DropForeignKey(
                name: "FK_Hops_HopForms_FormId",
                table: "Hops");

            migrationBuilder.DropForeignKey(
                name: "FK_Hops_HopTypes_TypeId",
                table: "Hops");

            migrationBuilder.DropForeignKey(
                name: "FK_Hops_HopUses_UseId",
                table: "Hops");

            migrationBuilder.DropIndex(
                name: "IX_Hops_FormId",
                table: "Hops");

            migrationBuilder.DropIndex(
                name: "IX_Hops_TypeId",
                table: "Hops");

            migrationBuilder.DropIndex(
                name: "IX_Hops_UseId",
                table: "Hops");

            migrationBuilder.DropIndex(
                name: "IX_Fermentables_TypeId",
                table: "Fermentables");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Fermentables");

            migrationBuilder.AddColumn<string>(
                name: "DisplayAmount",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayTime",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Form",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Use",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayAmount",
                table: "Fermentables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayColor",
                table: "Fermentables",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Fermentables",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayAmount",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "DisplayTime",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Form",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "Use",
                table: "Hops");

            migrationBuilder.DropColumn(
                name: "DisplayAmount",
                table: "Fermentables");

            migrationBuilder.DropColumn(
                name: "DisplayColor",
                table: "Fermentables");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Fermentables");

            migrationBuilder.AddColumn<Guid>(
                name: "FormId",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UseId",
                table: "Hops",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Fermentables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hops_FormId",
                table: "Hops",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Hops_TypeId",
                table: "Hops",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hops_UseId",
                table: "Hops",
                column: "UseId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermentables_TypeId",
                table: "Fermentables",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fermentables_FermentableTypes_TypeId",
                table: "Fermentables",
                column: "TypeId",
                principalTable: "FermentableTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hops_HopForms_FormId",
                table: "Hops",
                column: "FormId",
                principalTable: "HopForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hops_HopTypes_TypeId",
                table: "Hops",
                column: "TypeId",
                principalTable: "HopTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hops_HopUses_UseId",
                table: "Hops",
                column: "UseId",
                principalTable: "HopUses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
