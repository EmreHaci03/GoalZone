using GoalZone.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Context
{
    public class GoalZoneContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"//Server;Database=GoalZoneDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FootballMatch>()
                .HasOne(x=>x.HomeTeam)
                .WithMany(x=>x.HomeMatches)
                .HasForeignKey(x=>x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FootballMatch>()
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayMatches)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<News>()
                .HasOne(x => x.RelatedTeam)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.RelatedTeamId)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<FootballMatch> FootballMatches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<MatchStatistic> MatchStatistics { get; set; }
        public DbSet<News> News { get; set; }
    }
}
