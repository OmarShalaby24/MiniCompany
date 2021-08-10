using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniCompnay.Models;

namespace MiniCompnay.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<SkillModel> Skills { get; set; }
        public DbSet<EmployeeSkillModel> EmployeeSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().ToTable("Employees");
            modelBuilder.Entity<EmployeeModel>().HasData(
                    new EmployeeModel { ID = 1, Name = "John", Email = "John@gmail.com" }
                );
            modelBuilder.Entity<SkillModel>().ToTable("Skills");
            modelBuilder.Entity<SkillModel>().HasData(
                    new SkillModel { ID = 1, Name = "ASP" },
                    new SkillModel { ID = 2, Name = "PHP" },
                    new SkillModel { ID = 3, Name = "Database" }
                );
            modelBuilder.Entity<EmployeeSkillModel>().ToTable("EmployeeSkills");
            modelBuilder.Entity<EmployeeSkillModel>().HasData(
                    new EmployeeSkillModel { ID = 1, EmployeeID = 1, SkillID = 1 }
                );

        }
    }
}
