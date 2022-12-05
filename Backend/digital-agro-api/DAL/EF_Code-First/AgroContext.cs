﻿using DAL.EF_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF_Code_First
{
    public class AgroContext : DbContext
    {
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<LeaseLands> LeaseLands { get; set; }
        public DbSet<InvestLands> InvestLands { get; set; }
        public DbSet<ConfirmInvestments> ConfirmInvestments { get; set; }
        public DbSet<ConfirmLease> ConfirmLeases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}
