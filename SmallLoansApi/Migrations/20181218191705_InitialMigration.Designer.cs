﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmallLoansApi.Repositories;

namespace SmallLoansApi.Migrations
{
    [DbContext(typeof(SmallLoansContext))]
    [Migration("20181218191705_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmallLoansApi.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("BorrowerId");

                    b.Property<string>("Description");

                    b.Property<int>("LenderId");

                    b.Property<DateTime>("LoanDate");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("LenderId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("SmallLoansApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmallLoansApi.Models.Loan", b =>
                {
                    b.HasOne("SmallLoansApi.Models.User", "Borrower")
                        .WithMany("BorrowedLoans")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SmallLoansApi.Models.User", "Lender")
                        .WithMany("LendedLoans")
                        .HasForeignKey("LenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
