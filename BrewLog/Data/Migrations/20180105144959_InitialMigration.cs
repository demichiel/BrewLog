using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BrewLog.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "FermentableTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FermentableTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HopForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Form = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HopTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HopUses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Use = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopUses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BoilSize = table.Column<double>(nullable: false),
                    BoilTime = table.Column<int>(nullable: false),
                    Brewery = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Efficiency = table.Column<double>(nullable: false),
                    FinalGravity = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OriginalGravity = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YeastForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Form = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeastForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YeastTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeastTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fermentables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddAfterBoil = table.Column<bool>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Color = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RecipeId = table.Column<Guid>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fermentables_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fermentables_FermentableTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "FermentableTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Alpha = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Beta = table.Column<double>(nullable: true),
                    FormId = table.Column<Guid>(nullable: true),
                    Minutes = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RecipeId = table.Column<Guid>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true),
                    UseId = table.Column<Guid>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hops_HopForms_FormId",
                        column: x => x.FormId,
                        principalTable: "HopForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hops_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hops_HopTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "HopTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hops_HopUses_UseId",
                        column: x => x.UseId,
                        principalTable: "HopUses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yeasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AmountIsWeight = table.Column<bool>(nullable: true),
                    FormId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RecipeId = table.Column<Guid>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yeasts_YeastForms_FormId",
                        column: x => x.FormId,
                        principalTable: "YeastForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yeasts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yeasts_YeastTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "YeastTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fermentables_RecipeId",
                table: "Fermentables",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermentables_TypeId",
                table: "Fermentables",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hops_FormId",
                table: "Hops",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Hops_RecipeId",
                table: "Hops",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hops_TypeId",
                table: "Hops",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hops_UseId",
                table: "Hops",
                column: "UseId");

            migrationBuilder.CreateIndex(
                name: "IX_Yeasts_FormId",
                table: "Yeasts",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Yeasts_RecipeId",
                table: "Yeasts",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Yeasts_TypeId",
                table: "Yeasts",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Fermentables");

            migrationBuilder.DropTable(
                name: "Hops");

            migrationBuilder.DropTable(
                name: "Yeasts");

            migrationBuilder.DropTable(
                name: "FermentableTypes");

            migrationBuilder.DropTable(
                name: "HopForms");

            migrationBuilder.DropTable(
                name: "HopTypes");

            migrationBuilder.DropTable(
                name: "HopUses");

            migrationBuilder.DropTable(
                name: "YeastForms");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "YeastTypes");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
