using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LockerManagementSystem
{
    class LockerContext : DbContext
    {
        public DbSet<Locker> Lockers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locker>(entity =>
           {
               entity.HasKey(l => l.LockerID).HasName("PK_Lockers");

               entity.Property(l => l.LockerID).ValueGeneratedOnAdd();

               entity.Property(l => l.LockerSize).IsRequired();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog=Lockers;Integrated Security = True; Connect Timeout = 30;");        }
        }
}
