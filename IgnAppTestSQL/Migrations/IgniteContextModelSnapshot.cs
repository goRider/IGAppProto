﻿// <auto-generated />
using System;
using IgnAppTestSQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IgnAppTestSQL.Migrations
{
    [DbContext(typeof(IgniteContext))]
    partial class IgniteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IgnAppTestSQL.Data.IgniteRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("IgnAppTestSQL.Data.IgniteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("CompleteUndergraduate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<bool>("EligibleForQualification")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("FKBUID")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int?>("FKDepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("2");

                    b.Property<int?>("FKLocationId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<int?>("FKTitleId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("14");

                    b.Property<string>("FirstName");

                    b.Property<bool>("HRApproved");

                    b.Property<string>("IgniteEmail");

                    b.Property<bool>("IsApplicationFilled");

                    b.Property<bool>("IsInternalUser");

                    b.Property<bool>("IsQualifiedForLongTermEmp");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<bool>("PreQualificationQuestionFilled");

                    b.Property<string>("SecurityStamp");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("WorkedOverOneYear");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("FKBUID");

                    b.HasIndex("FKDepartmentId");

                    b.HasIndex("FKLocationId");

                    b.HasIndex("FKTitleId");

                    b.HasIndex("IgniteEmail")
                        .IsUnique()
                        .HasFilter("[IgniteEmail] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("StatusId");

                    b.Property<string>("StatusName");

                    b.HasKey("StatusId");

                    b.ToTable("ApplicationStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusName = "No App"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusName = "Not Started"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusName = "Incomplete Prequalification"
                        },
                        new
                        {
                            StatusId = 4,
                            StatusName = "Incomplete Prequalification"
                        },
                        new
                        {
                            StatusId = 5,
                            StatusName = "Incomplete Qualification"
                        },
                        new
                        {
                            StatusId = 6,
                            StatusName = "Complete Qualification"
                        },
                        new
                        {
                            StatusId = 7,
                            StatusName = "Endorsed"
                        },
                        new
                        {
                            StatusId = 8,
                            StatusName = "Hold"
                        },
                        new
                        {
                            StatusId = 9,
                            StatusName = "Selected"
                        });
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.BusinessUnit", b =>
                {
                    b.Property<int>("BUID");

                    b.Property<string>("BusinessUnitName");

                    b.HasKey("BUID");

                    b.ToTable("BusinessUnits");

                    b.HasData(
                        new
                        {
                            BUID = 1,
                            BusinessUnitName = "Corporate"
                        },
                        new
                        {
                            BUID = 2,
                            BusinessUnitName = "MGE"
                        },
                        new
                        {
                            BUID = 3,
                            BusinessUnitName = "MM/Auto"
                        },
                        new
                        {
                            BUID = 4,
                            BusinessUnitName = "CX"
                        });
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId");

                    b.Property<string>("DepartmentName");

                    b.Property<int?>("IgniteUserId");

                    b.HasKey("DepartmentId");

                    b.HasIndex("IgniteUserId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 0,
                            DepartmentName = "N/A"
                        },
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "App Dev"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Behavioral Science and Innovation"
                        },
                        new
                        {
                            DepartmentId = 3,
                            DepartmentName = "Creative Services"
                        },
                        new
                        {
                            DepartmentId = 4,
                            DepartmentName = "Creative QA"
                        },
                        new
                        {
                            DepartmentId = 5,
                            DepartmentName = "Finance Systems"
                        },
                        new
                        {
                            DepartmentId = 6,
                            DepartmentName = "Ford"
                        },
                        new
                        {
                            DepartmentId = 7,
                            DepartmentName = "Insurance and Card"
                        });
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.IgniteUserApplication", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationCompletionDate");

                    b.Property<int?>("ApplicationStatusStatusId");

                    b.Property<int?>("FKApplicationStatusId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int?>("FkIgniteUserId");

                    b.Property<int>("FkQuestionToAnswerId");

                    b.Property<DateTime>("ManagerApplicationStatusChangeDate");

                    b.Property<DateTime>("UserApplicationCreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("ApplicationId");

                    b.HasIndex("ApplicationStatusStatusId");

                    b.HasIndex("FkIgniteUserId");

                    b.HasIndex("FkQuestionToAnswerId")
                        .IsUnique();

                    b.ToTable("IgniteUserApplications");
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.Location", b =>
                {
                    b.Property<int>("LocationId");

                    b.Property<string>("CityLocation");

                    b.Property<string>("CountryLocation");

                    b.Property<string>("StateLocation");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 0,
                            CityLocation = "N/A",
                            StateLocation = "N/A"
                        },
                        new
                        {
                            LocationId = 1,
                            CityLocation = "Fenton",
                            CountryLocation = "United States",
                            StateLocation = "MO"
                        },
                        new
                        {
                            LocationId = 2,
                            CityLocation = "Maumee",
                            CountryLocation = "United States",
                            StateLocation = "OH"
                        },
                        new
                        {
                            LocationId = 3,
                            CityLocation = "Twinsburg",
                            CountryLocation = "United States",
                            StateLocation = "OH"
                        },
                        new
                        {
                            LocationId = 4,
                            CityLocation = "Lehi",
                            CountryLocation = "United States",
                            StateLocation = "UT"
                        });
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.QuestionToAnswer", b =>
                {
                    b.Property<int>("QuestionAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstAnswer");

                    b.Property<string>("FirstQuestion");

                    b.Property<string>("FourthAnswer");

                    b.Property<string>("FourthQuestion");

                    b.Property<string>("SecondAnswer");

                    b.Property<string>("SecondQuestion");

                    b.Property<string>("ThirdAnswer");

                    b.Property<string>("ThirdQuestion");

                    b.HasKey("QuestionAnswerId");

                    b.ToTable("QuestionsToAnswers");
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TitleName");

                    b.HasKey("TitleId");

                    b.ToTable("Titles");

                    b.HasData(
                        new
                        {
                            TitleId = 1,
                            TitleName = "IT Developer Analyst I"
                        },
                        new
                        {
                            TitleId = 2,
                            TitleName = "IT Developer Analyst I"
                        },
                        new
                        {
                            TitleId = 3,
                            TitleName = "IT Developer Analyst II"
                        },
                        new
                        {
                            TitleId = 4,
                            TitleName = "Lead Developer"
                        },
                        new
                        {
                            TitleId = 5,
                            TitleName = "Spec Developer"
                        },
                        new
                        {
                            TitleId = 6,
                            TitleName = "Business Analyst I"
                        },
                        new
                        {
                            TitleId = 7,
                            TitleName = "Director"
                        },
                        new
                        {
                            TitleId = 8,
                            TitleName = "N/A"
                        },
                        new
                        {
                            TitleId = 9,
                            TitleName = "Frontend Developer"
                        },
                        new
                        {
                            TitleId = 10,
                            TitleName = "Business Analyst II"
                        },
                        new
                        {
                            TitleId = 11,
                            TitleName = "Database Admin II"
                        },
                        new
                        {
                            TitleId = 12,
                            TitleName = "Graphics Designer"
                        },
                        new
                        {
                            TitleId = 13,
                            TitleName = "Network Engineer (Sr)"
                        },
                        new
                        {
                            TitleId = 14,
                            TitleName = "N/A"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IgnAppTestSQL.Data.IgniteUser", b =>
                {
                    b.HasOne("IgnAppTestSQL.Models.BusinessUnit", "BU")
                        .WithMany("IgniteUsers")
                        .HasForeignKey("FKBUID");

                    b.HasOne("IgnAppTestSQL.Models.Department", "Department")
                        .WithMany("IgniteUsers")
                        .HasForeignKey("FKDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IgnAppTestSQL.Models.Location", "UserLocation")
                        .WithMany("IgniteUsers")
                        .HasForeignKey("FKLocationId");

                    b.HasOne("IgnAppTestSQL.Models.Title", "UserTitle")
                        .WithMany("IgniteUsers")
                        .HasForeignKey("FKTitleId");
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.Department", b =>
                {
                    b.HasOne("IgnAppTestSQL.Data.IgniteUser")
                        .WithMany("Departments")
                        .HasForeignKey("IgniteUserId");
                });

            modelBuilder.Entity("IgnAppTestSQL.Models.IgniteUserApplication", b =>
                {
                    b.HasOne("IgnAppTestSQL.Models.ApplicationStatus", "ApplicationStatus")
                        .WithMany("IgniteUserApplications")
                        .HasForeignKey("ApplicationStatusStatusId");

                    b.HasOne("IgnAppTestSQL.Data.IgniteUser", "IgniteUser")
                        .WithMany("IgniteUserApplications")
                        .HasForeignKey("FkIgniteUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IgnAppTestSQL.Models.QuestionToAnswer", "QuestionToAnswer")
                        .WithOne("IgniteUserApplication")
                        .HasForeignKey("IgnAppTestSQL.Models.IgniteUserApplication", "FkQuestionToAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("IgnAppTestSQL.Data.IgniteRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("IgnAppTestSQL.Data.IgniteUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("IgnAppTestSQL.Data.IgniteUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("IgnAppTestSQL.Data.IgniteRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IgnAppTestSQL.Data.IgniteUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("IgnAppTestSQL.Data.IgniteUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}