﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobilePark_TestApp.Infrastructure;

#nullable disable

namespace MobilePark_TestApp.Migrations
{
    [DbContext(typeof(NewsApiDbContext))]
    [Migration("20240520194646_Index")]
    partial class Index
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MobilePark_TestApp.Models.ArticleWithVowelsCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParametersAndResultId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VowelsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParametersAndResultId");

                    b.ToTable("ArticleWithVowelsCount");
                });

            modelBuilder.Entity("MobilePark_TestApp.Models.ParametersAndResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("SearchIn")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Keyword", "SearchIn", "Language");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("MobilePark_TestApp.Models.ArticleWithVowelsCount", b =>
                {
                    b.HasOne("MobilePark_TestApp.Models.ParametersAndResult", null)
                        .WithMany("Result")
                        .HasForeignKey("ParametersAndResultId");
                });

            modelBuilder.Entity("MobilePark_TestApp.Models.ParametersAndResult", b =>
                {
                    b.Navigation("Result");
                });
#pragma warning restore 612, 618
        }
    }
}
