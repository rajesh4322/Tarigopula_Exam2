using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Tarigopula_Exam02.Models;

namespace Tarigopula_Exam02.Hospital
{
    public class PhysicianContext : DbContext
    {
        public PhysicianContext() : base("PhysicianContext")
        {
        }

        public DbSet<Physician> Physician { get; set; }
        public DbSet<Patient_Treatment> Patient_Treatment { get; set; }
        public DbSet<Treatment> Treatment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}