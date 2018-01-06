using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrewLog.Data.Migrations
{
    public partial class UpdateRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Efficiency",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "BoilTime",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "BoilSize",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "ABV",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "IBU",
                table: "Recipes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABV",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IBU",
                table: "Recipes");

            migrationBuilder.AlterColumn<double>(
                name: "Volume",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Efficiency",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BoilTime",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BoilSize",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
