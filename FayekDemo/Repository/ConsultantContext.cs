using FayekDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace FayekDemo.Repository
{
    public class ConsultantContext:DbContext
    {
        public ConsultantContext() : base("ConsultantContext")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}