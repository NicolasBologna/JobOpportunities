using JobOpportunities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobOpportunities.Data
{
    public class JobOpportunitiesContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<FullTimeJob> FullTimeJobs { get; set; }
        public DbSet<Intership> Interships { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Knowleadge> Knowleadges { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public JobOpportunitiesContext(DbContextOptions<JobOpportunitiesContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
