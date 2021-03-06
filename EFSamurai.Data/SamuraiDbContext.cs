using System;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.Data
{
    public class SamuraiDbContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB; " +
                "Database = EFSamurai; " +
                "Trusted_Connection = True;");
        }

        private DbSet<Quote> Quotes { get; set; }

        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(c => new { c.SamuraiId, c.BattleId });
        }
        public DbSet<Battle> Battles { get; set; }
        private DbSet<SamuraiBattle> SamuraiBattles { get; set; }
    }

}
