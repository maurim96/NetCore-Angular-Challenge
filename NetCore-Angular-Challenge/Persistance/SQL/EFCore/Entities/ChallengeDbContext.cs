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
            : base(options)
        {
        }

        public virtual DbSet<Competitions> Competitions { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<CompetitionsTeams> CompetitionsTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging(true);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS01;Database=ChallengeDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitions>(entity =>
            {
                entity.Property(x => x.Id)
                .ValueGeneratedNever();
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(x => x.Id)
                .ValueGeneratedNever();
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(x => x.Id)
                .ValueGeneratedNever();

                entity.HasOne(e => e.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey("TeamId")
                    .HasConstraintName("FK_Players_Teams");
            });

            modelBuilder.Entity<CompetitionsTeams>()
                .HasKey(x => new { x.CompetitionId, x.TeamId });

            modelBuilder.Entity<CompetitionsTeams>()
                .HasOne(e => e.Competition)
                .WithMany(x => x.TeamsLink)
                .HasForeignKey(z => z.CompetitionId);

            modelBuilder.Entity<CompetitionsTeams>()
                .HasOne(e => e.Team)
                .WithMany(x => x.CompetitionsLink)
                .HasForeignKey(z => z.TeamId);
        }
    }
}
