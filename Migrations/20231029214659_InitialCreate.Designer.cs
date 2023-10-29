﻿// <auto-generated />
using System;
using Learn_ASP.NET_CRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Learn_ASP.NET_CRUD.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231029214659_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterFaction", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "FactionId");

                    b.HasIndex("FactionId");

                    b.ToTable("CharacterFaction");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Backpack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique()
                        .HasFilter("[CharacterId] IS NOT NULL");

                    b.ToTable("Backpacks");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BackpackId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("CharacterFaction", b =>
                {
                    b.HasOne("Learn_ASP.NET_CRUD.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_CharacterFaction_Characters_CharacterId");

                    b.HasOne("Learn_ASP.NET_CRUD.Models.Faction", null)
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_CharacterFaction_Factions_FactionId");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Backpack", b =>
                {
                    b.HasOne("Learn_ASP.NET_CRUD.Models.Character", "Character")
                        .WithOne("Backpack")
                        .HasForeignKey("Learn_ASP.NET_CRUD.Models.Backpack", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Weapon", b =>
                {
                    b.HasOne("Learn_ASP.NET_CRUD.Models.Character", "Character")
                        .WithMany("Weapons")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Learn_ASP.NET_CRUD.Models.Character", b =>
                {
                    b.Navigation("Backpack");

                    b.Navigation("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}