using Microsoft.EntityFrameworkCore;

namespace SoccerAPI.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relationships
            //relationships start here
            //team-coach
            modelBuilder.Entity<Team>().HasOne(t => t.Coach)
                .WithOne(c => c.Team)
                .HasForeignKey<Coach>(c => c.TeamId);

            //Team-Player Relationship
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);


            //Cup-Match Relationship
            modelBuilder.Entity<Cup>()
                .HasMany(c => c.Matches)
                .WithOne(m => m.Cup)
                .HasForeignKey(m => m.CupId);


            //Match-Team Relationships
            modelBuilder.Entity<Match>()
                .HasMany(m => m.Teams)
                .WithMany(t => t.Matches)
                .UsingEntity<MatchTeam>(
                j => j
                    .HasOne(mt => mt.Team)
                    .WithMany(t => t.MatchTeams)
                    .HasForeignKey(mt => mt.TeamId),
                j => j
                    .HasOne(mt => mt.Match)
                    .WithMany(m => m.MatchTeams)
                    .HasForeignKey(mt => mt.MatchId),
                j =>
                {
                    j.HasKey(k => new { k.MatchId, k.TeamId, k.Status });
                }
                );






            //Cup - Team  many to many Relationship
            modelBuilder.Entity<Cup>()
                .HasMany(c => c.Teams)
                .WithMany(t => t.Cups)
                .UsingEntity<CupTeam>(
                j => j
                    .HasOne(ct => ct.Team)
                    .WithMany(t => t.CupTeams)
                    .HasForeignKey(ct => ct.TeamId),
                j => j
                    .HasOne(ct => ct.Cup)
                    .WithMany(c => c.CupTeams)
                    .HasForeignKey(ct => ct.Cupid),

                j =>
                {
                    j.HasKey(k => new { k.Cupid, k.TeamId });
                }
                );

            #endregion

        }
        #region DbSet
        //Dbsets
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Cup> Cups { get; set; }
        #endregion
    }
}

