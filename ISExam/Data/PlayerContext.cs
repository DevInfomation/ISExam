using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISExam.Models;
using Microsoft.EntityFrameworkCore;

namespace ISExam.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(account =>
            {
                account.Property(q => q.Id).IsRequired();
                account.HasKey(q => q.Id);
                account.Property(q => q.FirstName).HasMaxLength(200).IsRequired();
                account.Property(q => q.LastName).HasMaxLength(400).IsRequired();
            });
        }
    }
}
