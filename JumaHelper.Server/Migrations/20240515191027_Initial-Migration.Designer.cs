﻿// <auto-generated />
using System;
using JumaHelper.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JumaDayHelperWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240515191027_Initial-Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("JumaDayHelperWeb.Models.DuaRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(3000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("DuaRequestOwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DuaRequestTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DuaRequestOwnerId");

                    b.HasIndex("DuaRequestTypeId");

                    b.ToTable("DuaRequests");
                });

            modelBuilder.Entity("JumaDayHelperWeb.Models.DuaRequestOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FatherName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DuaRequestOwners");
                });

            modelBuilder.Entity("JumaDayHelperWeb.Models.DuaRequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("DuaRequestTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kesellikke shıpa"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ata-anası haqqına jaqsılıq"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Jumisının' júrisiwin"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Qarızınan qutılıw"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Perzent sorap"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Basqa sebeb benen"
                        });
                });

            modelBuilder.Entity("JumaDayHelperWeb.Models.DuaRequest", b =>
                {
                    b.HasOne("JumaDayHelperWeb.Models.DuaRequestOwner", "Owner")
                        .WithMany("DuaRequests")
                        .HasForeignKey("DuaRequestOwnerId");

                    b.HasOne("JumaDayHelperWeb.Models.DuaRequestType", "RequestType")
                        .WithMany("DuaRequests")
                        .HasForeignKey("DuaRequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("JumaDayHelperWeb.Models.DuaRequestTo", "RequestTo", b1 =>
                        {
                            b1.Property<int>("DuaRequestId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Affiliation")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasMaxLength(250)
                                .HasColumnType("TEXT");

                            b1.HasKey("DuaRequestId");

                            b1.ToTable("DuaRequests");

                            b1.WithOwner()
                                .HasForeignKey("DuaRequestId");
                        });

                    b.Navigation("Owner");

                    b.Navigation("RequestTo")
                        .IsRequired();

                    b.Navigation("RequestType");
                });

            modelBuilder.Entity("JumaDayHelperWeb.Models.DuaRequestOwner", b =>
                {
                    b.Navigation("DuaRequests");
                });

            modelBuilder.Entity("JumaDayHelperWeb.Models.DuaRequestType", b =>
                {
                    b.Navigation("DuaRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
