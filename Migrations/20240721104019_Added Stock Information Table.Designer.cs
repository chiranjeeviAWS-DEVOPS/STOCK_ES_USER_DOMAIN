﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StockApplication_UserDomain.Data;

#nullable disable

namespace StockApplication_UserDomain.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240721104019_Added Stock Information Table")]
    partial class AddedStockInformationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StockApplication_UserDomain.Models.AccountInfo", b =>
                {
                    b.Property<long>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("AccountNumber"));

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<string>("BranchName")
                        .HasColumnType("text");

                    b.Property<string>("HolderName")
                        .HasColumnType("text");

                    b.Property<string>("IFSCCode")
                        .HasColumnType("text");

                    b.Property<string>("PanNumber")
                        .HasColumnType("text");

                    b.HasKey("AccountNumber");

                    b.ToTable("AccountInfo");
                });

            modelBuilder.Entity("StockApplication_UserDomain.Models.StockInfo", b =>
                {
                    b.Property<string>("StockID")
                        .HasColumnType("text");

                    b.Property<long>("OutstandingShares")
                        .HasColumnType("bigint");

                    b.Property<string>("StockCategory")
                        .HasColumnType("text");

                    b.Property<string>("StockName")
                        .HasColumnType("text");

                    b.Property<List<string>>("WatchList")
                        .HasColumnType("text[]");

                    b.HasKey("StockID");

                    b.ToTable("StockInfo");
                });

            modelBuilder.Entity("StockApplication_UserDomain.Models.Users", b =>
                {
                    b.Property<string>("PanNumber")
                        .HasColumnType("text");

                    b.Property<bool?>("AddedPaymentMethod")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool?>("EmailVerified")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastlyModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<long?>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.Property<bool?>("PhoneNumberVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("PanNumber");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
