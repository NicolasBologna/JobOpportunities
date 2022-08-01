using JobOpportunities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobOpportunities.Data
{
    public class JobOpportunitiesContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<JobOffer> JobOffers => Set<JobOffer>();
        public DbSet<FullTimeJob> FullTimeJobs => Set<FullTimeJob>();
        public DbSet<Intership> Interships => Set<Intership>();
        public DbSet<SkillLevel> SkillLevels => Set<SkillLevel>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<Knowleadge> Knowleadges => Set<Knowleadge>();
        public DbSet<Skill> Skills => Set<Skill>();

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
