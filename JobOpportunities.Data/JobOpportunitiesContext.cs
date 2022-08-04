using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobOpportunities.Data
{
    public class JobOpportunitiesContext : DbContext
    {

        public DbSet<JobOffer> JobOffers => Set<JobOffer>();
        public DbSet<FullTimeJob> FullTimeJobs => Set<FullTimeJob>();
        public DbSet<Intership> Interships => Set<Intership>();
        public DbSet<SkillLevel> SkillLevels => Set<SkillLevel>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<Knowledge> Knowleadges => Set<Knowledge>();
        public DbSet<Skill> Skills => Set<Skill>();

        public JobOpportunitiesContext(DbContextOptions<JobOpportunitiesContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedData(builder);
            base.OnModelCreating(builder);
        }

        private static void SeedData(ModelBuilder builder)
        {
            SeedSkillLevels(builder);
            SeedKnowledge(builder);
            SeedSkills(builder);
            SeedCompanies(builder);
            SeedJobOffers(builder);
            SeedJobOfferRequiredSkills(builder);
            SeedCandidates(builder);
            SeedCandidateSkills(builder);
        }

        private static void SeedSkillLevels(ModelBuilder builder)
        {
            builder.Entity<SkillLevel>().HasData(
                new SkillLevel
                {
                    Id = new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                    CreationDate = DateTime.Now,
                    Description = "Lower skills required",
                    Name = "Intern"
                });

            builder.Entity<SkillLevel>().HasData(
                new SkillLevel
                {
                    Id = new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                    CreationDate = DateTime.Now,
                    Description = "Lower skills required, but can finish some tasks",
                    Name = "Junior"
                });

            builder.Entity<SkillLevel>().HasData(
                new SkillLevel
                {
                    Id = new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                    CreationDate = DateTime.Now,
                    Description = "higher skills required, but less responsabilities",
                    Name = "Semi-Senior"
                });
        }
        private static void SeedKnowledge(ModelBuilder builder)
        {
            builder.Entity<Knowledge>().HasData(
                new Knowledge
                {
                    Id = new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                    Title = ".NET",
                    Description = "Versión 6 + todo el ecosistema",
                    CreationDate = DateTime.Now
                });

            builder.Entity<Knowledge>().HasData(
                new Knowledge
                {
                    Id = new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                    Title = "Angular",
                    Description = "Versión 13",
                    CreationDate = DateTime.Now
                });
        }
        private static void SeedSkills(ModelBuilder builder)
        {
            builder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                    CreationDate = DateTime.Now,
                    KnowleadgeId = new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                    SkillLevelId = new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                });

            builder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                    CreationDate = DateTime.Now,
                    KnowleadgeId = new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                    SkillLevelId = new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                });
        }
        private static void SeedCompanies(ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(
                            new Company
                            {
                                Id = new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                                CreationDate = DateTime.Now,
                                Email = "company@endava.com",
                                Name = "Endava"
                            });
        }
        private static void SeedJobOffers(ModelBuilder builder)
        {
            builder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                    CreationDate = DateTime.Now,
                    CompanyId = new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                    Description = "Una posición para pasarla bien",
                    Title = ".NET FullStack FullTime",
                    ValidUntil = DateTime.Now.AddDays(90),
                });
        }
        private static void SeedJobOfferRequiredSkills(ModelBuilder builder)
        {
            builder.Entity<JobOffer>()
            .HasMany(x => x.RequiredSkills)
            .WithMany(x => x.JobOffers)
            .UsingEntity(j => j
                .ToTable("JobOfferSkill")
                .HasData(new[]
                    {
                                    new { RequiredSkillsId = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"), JobOffersId = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027")},
                                    new { RequiredSkillsId = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"), JobOffersId = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027")},
                    }));
        }
        private static void SeedCandidates(ModelBuilder builder)
        {
            builder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                    CreationDate = DateTime.Now,
                    Email = "pepito@endava.com",
                    Name = "Pepito Juarez",
                    Password = "123456UltraSecure",
                });

            builder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                    CreationDate = DateTime.Now,
                    Email = "marcelo@endava.com",
                    Name = "Marcelo Reynoso",
                    Password = "320909b967uythgfd@434$%&",
                });
        }
        private static void SeedCandidateSkills(ModelBuilder builder)
        {
            builder.Entity<Candidate>()
                .HasMany(x => x.Skills)
                .WithMany(x => x.Candidates)
                .UsingEntity(j => j
                    .ToTable("CandidateSkill")
                    .HasData(new[]
                        {
                            new { SkillsId = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"), CandidatesId = new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de")},
                            new { SkillsId = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"), CandidatesId = new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de")},
                            new { SkillsId = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"), CandidatesId = new Guid("f29d1608-f324-4432-8e44-5ee320909b9d")},
                        }
                    ));
        }
    }
}
