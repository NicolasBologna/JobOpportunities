using JobOpportunities.Data.Identity;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace JobOpportunities.Data
{
    public class JobOpportunitiesContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly CurrentUser _user;

        public DbSet<JobOffer> JobOffers => Set<JobOffer>();
        public DbSet<FullTimeJob> FullTimeJobs => Set<FullTimeJob>();
        public DbSet<Intership> Interships => Set<Intership>();
        public DbSet<SkillLevel> SkillLevels => Set<SkillLevel>();
        public DbSet<CompanyAgent> Companies => Set<CompanyAgent>();
        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<Knowledge> Knowleadges => Set<Knowledge>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Admin> Admins => Set<Admin>();

        public JobOpportunitiesContext(DbContextOptions<JobOpportunitiesContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _user = currentUserService.User;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CompanyAgent>().HasMany(x => x.Offers).WithOne(y => y.Company).OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<CompanyAgent>().Navigation(ca => ca.Offers).AutoInclude();


            SeedData(builder);
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _user.Id;
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _user.Id;
                        entry.Entity.LastModifiedByAt = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        private static void SeedData(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedSkillLevels(builder);
            SeedKnowledge(builder);
            SeedSkills(builder);
            SeedCompanies(builder);
            SeedJobOffers(builder);
            SeedJobOfferRequiredSkills(builder);
            SeedCandidates(builder);
            SeedCandidateSkills(builder);
            SeedCandidatesJobOffers(builder);
            SeedUserRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>() { Id = new Guid("fab4fac1-c546-41de-aebc-a14da6895711"), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole<Guid>() { Id = new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), Name = "Candidate", ConcurrencyStamp = "2", NormalizedName = "CANDIDATE" },
                new IdentityRole<Guid>() { Id = new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"), Name = "CompanyAgent", ConcurrencyStamp = "3", NormalizedName = "COMPANYAGENT" }
                );
        }
        private static void SeedSkillLevels(ModelBuilder builder)
        {
            builder.Entity<SkillLevel>().HasData(
                new SkillLevel
                {
                    Id = new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                    Description = "Lower skills required",
                    Name = "Intern"
                });

            builder.Entity<SkillLevel>().HasData(
                new SkillLevel
                {
                    Id = new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                    Description = "Lower skills required, but can finish some tasks",
                    Name = "Junior"
                });

            builder.Entity<SkillLevel>().HasData(
                new SkillLevel
                {
                    Id = new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
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
                });

            builder.Entity<Knowledge>().HasData(
                new Knowledge
                {
                    Id = new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                    Title = "Angular",
                    Description = "Versión 13",
                });
        }
        private static void SeedSkills(ModelBuilder builder)
        {
            builder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                    KnowleadgeId = new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                    SkillLevelId = new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                });

            builder.Entity<Skill>().HasData(
                new Skill
                {
                    Id = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                    KnowleadgeId = new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                    SkillLevelId = new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                });
        }

        private static void SeedCompanies(ModelBuilder builder)
        {
            PasswordHasher<CompanyAgent> passwordHasher = new PasswordHasher<CompanyAgent>();
            var company1 = new CompanyAgent("José María", "endava", "34-523445345-4")
            {
                Id = new Guid("1B1D13DD-AFB4-474F-A60A-BF6AB3474898"),
            };

            company1.PasswordHash = passwordHasher.HashPassword(company1, "Candidate*123");

            builder.Entity<CompanyAgent>().HasData(company1);
        }

        private static void SeedJobOffers(ModelBuilder builder)
        {
            builder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                    CompanyId = new Guid("1B1D13DD-AFB4-474F-A60A-BF6AB3474898"),
                    Description = "Una posición para pasarla bien",
                    Title = ".NET FullStack FullTime",
                    ValidUntil = DateTime.Now.AddDays(90),
                });

            builder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = new Guid("FF414898-E070-4C52-BE2E-04CAE7A1AF1A"),
                    CompanyId = new Guid("1B1D13DD-AFB4-474F-A60A-BF6AB3474898"),
                    Description = "Posición ma o meno",
                    Title = "Node Backend",
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
            PasswordHasher<Candidate> passwordHasher = new PasswordHasher<Candidate>();
            var candidate1 = new Candidate("Pepito", "Juarez")
            {
                Id = new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                Email = "pepito@endava.com",
                UserName = "PepitoJuarez",
                Cuil = "20-45323443-3"
            };

            var candidate2 = new Candidate("Marcelo", "Reynoso")
            {
                Id = new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                Email = "marcelo@endava.com",
                UserName = "MarceloReynoso",
                Cuil = "20-65723443-3"
            };

            candidate1.PasswordHash = passwordHasher.HashPassword(candidate1, "Candidate*123");
            candidate2.PasswordHash = passwordHasher.HashPassword(candidate2, "Candidate*123");

            builder.Entity<Candidate>().HasData(new List<Candidate>()
            {
                candidate1,
                candidate2
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

        private static void SeedCandidatesJobOffers(ModelBuilder builder)
        {
            builder.Entity<Candidate>()
                .HasMany(c => c.JobOfferApplications)
                .WithMany(j => j.Candidates)
                .UsingEntity(x => x
                    .ToTable("CandidateJobOffer")
                    .HasData(new[]
                    {
                         new { CandidatesId = new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"), JobOfferApplicationsId = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027") },
                        new { CandidatesId = new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"), JobOfferApplicationsId = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027") }
                    })
                );
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>() { RoleId = new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"), UserId = new Guid("1B1D13DD-AFB4-474F-A60A-BF6AB3474898") },
                new IdentityUserRole<Guid>() { RoleId = new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), UserId = new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de") },
                new IdentityUserRole<Guid>() { RoleId = new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), UserId = new Guid("f29d1608-f324-4432-8e44-5ee320909b9d") }
                );
        }
    }
}
