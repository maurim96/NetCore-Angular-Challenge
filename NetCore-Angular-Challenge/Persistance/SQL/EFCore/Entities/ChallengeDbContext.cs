using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.SQL.EFCore.Entities
{
    public partial class ChallengeDbContext : DbContext
    {

        public ChallengeDbContext()
        {
        }

        public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Competitions> Competitions { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ChallengeDB;Trusted_Connection=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Competitions>(entity =>
            {
            });

            modelBuilder.Entity<Teams>(entity =>
            {
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property<int>("TeamId");

                entity.HasOne(e => e.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey("TeamId")
                    .HasConstraintName("FK_Players_Teams");
            });

            modelBuilder.Entity<CompetitionTeam>()
                .HasKey(x => new { x.CompetitionId, x.TeamId });

            modelBuilder.Entity<CompetitionTeam>()
                .HasOne(e => e.Competition)
                .WithMany(x => x.TeamsLink)
                .HasForeignKey(z => z.CompetitionId);

            modelBuilder.Entity<CompetitionTeam>()
                .HasOne(e => e.Team)
                .WithMany(x => x.CompetitionsLink)
                .HasForeignKey(z => z.TeamId);
        }
    }
}
