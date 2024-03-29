﻿// <auto-generated />
using System;
using Job_task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jobtask.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230730185330_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksBorrowers", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowersId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "BorrowersId");

                    b.HasIndex("BorrowersId");

                    b.ToTable("BooksBorrowers");
                });

            modelBuilder.Entity("Job_task.Models.Book.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BorrowersId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumOfCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BorrowersId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Job_task.Models.Borrower.Borrowers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BooksId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BooksId");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("BooksBorrowers", b =>
                {
                    b.HasOne("Job_task.Models.Book.Books", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Job_task.Models.Borrower.Borrowers", null)
                        .WithMany()
                        .HasForeignKey("BorrowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Job_task.Models.Book.Books", b =>
                {
                    b.HasOne("Job_task.Models.Borrower.Borrowers", null)
                        .WithMany()
                        .HasForeignKey("BorrowersId");
                });

            modelBuilder.Entity("Job_task.Models.Borrower.Borrowers", b =>
                {
                    b.HasOne("Job_task.Models.Book.Books", null)
                        .WithMany()
                        .HasForeignKey("BooksId");
                });
#pragma warning restore 612, 618
        }
    }
}
