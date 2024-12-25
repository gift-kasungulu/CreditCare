﻿// <auto-generated />
using System;
using CreditCare.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CreditCare.App.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241224225800_appuser")]
    partial class appuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CreditCare.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubscriptionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TrialEndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CreditCare.Domain.Collateral", b =>
                {
                    b.Property<int>("CollateralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollateralId"), 1L, 1);

                    b.Property<int>("CollateralStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CollateralId");

                    b.HasIndex("CollateralStatusId");

                    b.HasIndex("LoanId");

                    b.ToTable("Collaterals");
                });

            modelBuilder.Entity("CreditCare.Domain.CollateralStatus", b =>
                {
                    b.Property<int>("CollateralStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollateralStatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollateralStatusId");

                    b.ToTable("CollateralStatus");
                });

            modelBuilder.Entity("CreditCare.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrcNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CreditCare.Domain.InterestRate", b =>
                {
                    b.Property<int>("InterestRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestRateId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Term")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestRateId");

                    b.ToTable("IRates");
                });

            modelBuilder.Entity("CreditCare.Domain.Loan", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InterestRateId")
                        .HasColumnType("int");

                    b.Property<string>("LoanNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanProductId")
                        .HasColumnType("int");

                    b.Property<int>("LoanStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PeriodType")
                        .HasColumnType("int");

                    b.Property<decimal>("PrincipalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ProcessingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RepaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepaymentCycles")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("InterestRateId");

                    b.HasIndex("LoanProductId");

                    b.HasIndex("LoanStatusId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("CreditCare.Domain.LoanProduct", b =>
                {
                    b.Property<int>("LoanProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanProductId"), 1L, 1);

                    b.Property<decimal>("DefaultInterestRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaximumAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinimumAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanProductId");

                    b.ToTable("LoanProducts");
                });

            modelBuilder.Entity("CreditCare.Domain.LoanStatus", b =>
                {
                    b.Property<int>("LoanStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanStatusId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanStatusId");

                    b.ToTable("LoanStatuses");
                });

            modelBuilder.Entity("CreditCare.Domain.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSms")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NotificationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("CreditCare.Domain.Repayment", b =>
                {
                    b.Property<int>("RepaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepaymentId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentReference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RepaymentId");

                    b.HasIndex("LoanId");

                    b.ToTable("Repayments");
                });

            modelBuilder.Entity("CreditCare.Domain.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MonthlyFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PlanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CreditCare.Domain.Collateral", b =>
                {
                    b.HasOne("CreditCare.Domain.CollateralStatus", "collateralStatus")
                        .WithMany()
                        .HasForeignKey("CollateralStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CreditCare.Domain.Loan", "Loan")
                        .WithMany("Collaterals")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Loan");

                    b.Navigation("collateralStatus");
                });

            modelBuilder.Entity("CreditCare.Domain.Loan", b =>
                {
                    b.HasOne("CreditCare.Domain.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CreditCare.Domain.InterestRate", "InterestRate")
                        .WithMany()
                        .HasForeignKey("InterestRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CreditCare.Domain.LoanProduct", "LoanProduct")
                        .WithMany("Loans")
                        .HasForeignKey("LoanProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CreditCare.Domain.LoanStatus", "Status")
                        .WithMany()
                        .HasForeignKey("LoanStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("InterestRate");

                    b.Navigation("LoanProduct");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("CreditCare.Domain.Notification", b =>
                {
                    b.HasOne("CreditCare.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CreditCare.Domain.Repayment", b =>
                {
                    b.HasOne("CreditCare.Domain.Loan", "Loan")
                        .WithMany("Repayments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("CreditCare.Domain.Subscription", b =>
                {
                    b.HasOne("CreditCare.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CreditCare.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CreditCare.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CreditCare.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CreditCare.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CreditCare.Domain.Customer", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("CreditCare.Domain.Loan", b =>
                {
                    b.Navigation("Collaterals");

                    b.Navigation("Repayments");
                });

            modelBuilder.Entity("CreditCare.Domain.LoanProduct", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
