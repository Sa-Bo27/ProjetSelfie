﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;

#nullable disable

namespace SelfieAWookies.Core.Selfies.Infrastructures.Migrations
{
    [DbContext(typeof(SelfiesContext))]
    [Migration("20220213130239_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Selfie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WookieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WookieId");

                    b.ToTable("Selfie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("WookieName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wookie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Selfie", b =>
                {
                    b.HasOne("SelfieAWookies.Core.Selfies.Domain.Wookie", "Wookie")
                        .WithMany("Selfies")
                        .HasForeignKey("WookieId");

                    b.Navigation("Wookie");
                });

            modelBuilder.Entity("SelfieAWookies.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Navigation("Selfies");
                });
#pragma warning restore 612, 618
        }
    }
}