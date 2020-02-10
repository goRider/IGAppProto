using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgnAppTestSQL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IgnAppTestSQL.Data
{
    public class IgniteContext : IdentityDbContext<IgniteUser, IgniteRole, int>
    {
        public IgniteContext(DbContextOptions<IgniteContext> options)
            : base(options)
        {

        }


        public DbSet<IgniteUser> IgniteUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<IgniteUserApplication> IgniteUserApplications { get; set; }
        public DbSet<QuestionToAnswer> QuestionsToAnswers { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Database Structure

            #region IgniteUser

            builder.Entity<IgniteUser>(e =>
            {
                e.HasIndex(i => i.IgniteEmail).IsUnique();
                e.HasIndex(i => i.Email).IsUnique();

                // Set Default
                e.Property(p => p.FKDepartmentId).HasDefaultValueSql("2");
                e.Property(p => p.FKTitleId).HasDefaultValueSql("0");
                e.Property(p => p.FKLocationId).HasDefaultValueSql("0");
                e.Property(p => p.FKBUID).HasDefaultValueSql("1");
            });

            #endregion

            #region Department

            builder.Entity<Department>(e =>
            {
                e.HasKey(k => k.DepartmentId);
                e.Property(p => p.DepartmentId).ValueGeneratedNever();

                e.HasMany(iu => iu.IgniteUsers).WithOne(d => d.Department).HasForeignKey(f => f.FKDepartmentId);

                #region Department Seed Data
                //add Department Values
                e.HasData(
                    new Department
                    {
                        DepartmentId = 0,
                        DepartmentName = "N/A"
                    },
                    new Department
                    {
                        DepartmentId = 1,
                        DepartmentName = "App Dev"
                    },
                    new Department
                    {
                        DepartmentId = 2,
                        DepartmentName = "Behavioral Science and Innovation"
                    },
                    new Department
                    {
                        DepartmentId = 3,
                        DepartmentName = "Creative Services"
                    },
                    new Department
                    {
                        DepartmentId = 4,
                        DepartmentName = "Creative QA"
                    },
                    new Department
                    {
                        DepartmentId = 5,
                        DepartmentName = "Finance Systems"
                    },
                    new Department
                    {
                        DepartmentId = 6,
                        DepartmentName = "Ford"
                    },
                    new Department
                    {
                        DepartmentId = 7,
                        DepartmentName = "Insurance and Card"
                    });
                #endregion
            });

            #endregion

            #region Location

            builder.Entity<Location>(e =>
            {
                e.HasKey(k => k.LocationId);
                e.Property(p => p.LocationId).ValueGeneratedNever();

                #region Location Seed Data

                e.HasData(
                    new Location
                    {
                        LocationId = 0,
                        CityLocation = "N/A",
                        StateLocation = "N/A"
                    },
                    new Location
                    {
                        LocationId = 1,
                        CityLocation = "Fenton",
                        StateLocation = "MO"
                    },
                    new Location
                    {
                        LocationId = 2,
                        CityLocation = "Maumee",
                        StateLocation = "OH"
                    },
                    new Location
                    {
                        LocationId = 3,
                        CityLocation = "Twinsburg",
                        StateLocation = "OH"
                    },
                    new Location
                    {
                        LocationId = 4,
                        CityLocation = "Lehi",
                        StateLocation = "UT"
                    });
                #endregion
            });
            #endregion

            #region Title

            builder.Entity<Title>(e =>
            {
                e.HasKey(k => k.TitleId);

                e.HasMany(iu => iu.IgniteUsers).WithOne(t => t.UserTitle).HasForeignKey(f => f.FKTitleId);

                #region Title Seed Data

                e.HasData(
                    new Title
                    {
                        TitleId = 0,
                        TitleName = "N/A"
                    },
                    new Title
                    {
                        TitleId = 1,
                        TitleName = "IT Developer Analyst I"
                    },
                    new Title
                    {
                        TitleId = 2,
                        TitleName = "IT Developer Analyst I"
                    },
                    new Title
                    {
                        TitleId = 3,
                        TitleName = "IT Developer Analyst II"
                    },
                    new Title
                    {
                        TitleId = 4,
                        TitleName = "Lead Developer"
                    },
                    new Title
                    {
                        TitleId = 5,
                        TitleName = "Spec Developer"
                    },
                    new Title
                    {
                        TitleId = 6,
                        TitleName = "Business Analyst I"
                    },
                    new Title
                    {
                        TitleId = 7,
                        TitleName = "Director"
                    },
                    new Title
                    {
                        TitleId = 8,
                        TitleName = "N/A"
                    },
                    new Title
                    {
                        TitleId = 9,
                        TitleName = "Frontend Developer"
                    },
                    new Title
                    {
                        TitleId = 10,
                        TitleName = "Business Analyst II"
                    },
                    new Title
                    {
                        TitleId = 11,
                        TitleName = "Database Admin II"
                    },
                    new Title
                    {
                        TitleId = 12,
                        TitleName = "Graphics Designer"
                    },
                    new Title
                    {
                        TitleId = 13,
                        TitleName = "Network Engineer (Sr)"
                    });

                #endregion
            });

            #endregion

            #endregion
        }
    }
}
