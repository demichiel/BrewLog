﻿// <auto-generated />
using BrewLog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BrewLog.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180105144959_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrewLog.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BrewLog.Models.Fermentable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AddAfterBoil");

                    b.Property<double>("Amount");

                    b.Property<float>("Color");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<Guid?>("RecipeId");

                    b.Property<Guid?>("TypeId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TypeId");

                    b.ToTable("Fermentables");
                });

            modelBuilder.Entity("BrewLog.Models.FermentableType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("FermentableTypes");
                });

            modelBuilder.Entity("BrewLog.Models.Hop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Alpha");

                    b.Property<double>("Amount");

                    b.Property<double?>("Beta");

                    b.Property<Guid?>("FormId");

                    b.Property<int>("Minutes");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<Guid?>("RecipeId");

                    b.Property<Guid?>("TypeId");

                    b.Property<Guid?>("UseId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UseId");

                    b.ToTable("Hops");
                });

            modelBuilder.Entity("BrewLog.Models.HopForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Form");

                    b.HasKey("Id");

                    b.ToTable("HopForms");
                });

            modelBuilder.Entity("BrewLog.Models.HopType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("HopTypes");
                });

            modelBuilder.Entity("BrewLog.Models.HopUse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Use");

                    b.HasKey("Id");

                    b.ToTable("HopUses");
                });

            modelBuilder.Entity("BrewLog.Models.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BoilSize");

                    b.Property<int>("BoilTime");

                    b.Property<string>("Brewery");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Efficiency");

                    b.Property<string>("FinalGravity");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("OriginalGravity");

                    b.Property<int>("Version");

                    b.Property<double>("Volume");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("BrewLog.Models.Yeast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("AmountIsWeight");

                    b.Property<Guid?>("FormId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("RecipeId");

                    b.Property<Guid?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TypeId");

                    b.ToTable("Yeasts");
                });

            modelBuilder.Entity("BrewLog.Models.YeastForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Form");

                    b.HasKey("Id");

                    b.ToTable("YeastForms");
                });

            modelBuilder.Entity("BrewLog.Models.YeastType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("YeastTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BrewLog.Models.Fermentable", b =>
                {
                    b.HasOne("BrewLog.Models.Recipe")
                        .WithMany("Fermentables")
                        .HasForeignKey("RecipeId");

                    b.HasOne("BrewLog.Models.FermentableType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("BrewLog.Models.Hop", b =>
                {
                    b.HasOne("BrewLog.Models.HopForm", "Form")
                        .WithMany()
                        .HasForeignKey("FormId");

                    b.HasOne("BrewLog.Models.Recipe")
                        .WithMany("Hops")
                        .HasForeignKey("RecipeId");

                    b.HasOne("BrewLog.Models.HopType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("BrewLog.Models.HopUse", "Use")
                        .WithMany()
                        .HasForeignKey("UseId");
                });

            modelBuilder.Entity("BrewLog.Models.Yeast", b =>
                {
                    b.HasOne("BrewLog.Models.YeastForm", "Form")
                        .WithMany()
                        .HasForeignKey("FormId");

                    b.HasOne("BrewLog.Models.Recipe")
                        .WithMany("Yeasts")
                        .HasForeignKey("RecipeId");

                    b.HasOne("BrewLog.Models.YeastType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BrewLog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BrewLog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrewLog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BrewLog.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
