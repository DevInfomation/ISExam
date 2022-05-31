using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISExam.Models;
using Microsoft.EntityFrameworkCore;

namespace ISExam.Data
{
    public class ClubContext : DbContext
    {
        public ClubContext(DbContextOptions<ClubContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Club> Clubs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>(account =>
            {
                account.Property(a => a.Id).IsRequired();
                account.HasKey(a => a.Id);
                account.Property(a => a.Name).HasMaxLength(200).IsRequired();
                account.Property(a => a.Country).HasMaxLength(200).IsRequired();
                account.Property(a => a.Owner).HasMaxLength(200).IsRequired();
            });
        }
    }
}
