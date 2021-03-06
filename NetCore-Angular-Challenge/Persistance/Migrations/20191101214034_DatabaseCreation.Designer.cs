﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.SQL.EFCore.Entities;

namespace Persistance.Migrations
{
    [DbContext(typeof(ChallengeDbContext))]
    [Migration("20191101214034_DatabaseCreation")]
    partial class DatabaseCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistance.SQL.EFCore.Entities.Competitions", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AreaName");

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Persistance.SQL.EFCore.Entities.CompetitionsTeams", b =>
                {
                    b.Property<int>("CompetitionId");

                    b.Property<int>("TeamId");

                    b.HasKey("CompetitionId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("CompetitionsTeams");
                });

            modelBuilder.Entity("Persistance.SQL.EFCore.Entities.Players", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CountryOfBirth");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Position");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Persistance.SQL.EFCore.Entities.Teams", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("AreaName");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<string>("Tla");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Persistance.SQL.EFCore.Entities.CompetitionsTeams", b =>
                {
                    b.HasOne("Persistance.SQL.EFCore.Entities.Competitions", "Competition")
                        .WithMany("TeamsLink")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Persistance.SQL.EFCore.Entities.Teams", "Team")
                        .WithMany("CompetitionsLink")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Persistance.SQL.EFCore.Entities.Players", b =>
                {
                    b.HasOne("Persistance.SQL.EFCore.Entities.Teams", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_Players_Teams")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
