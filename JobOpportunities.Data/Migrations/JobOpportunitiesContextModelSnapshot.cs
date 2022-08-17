﻿// <auto-generated />
using System;
using JobOpportunities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    [DbContext(typeof(JobOpportunitiesContext))]
    partial class JobOpportunitiesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CandidateJobOffer", b =>
                {
                    b.Property<string>("CandidatesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OffersAppliedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CandidatesId", "OffersAppliedId");

                    b.HasIndex("OffersAppliedId");

                    b.ToTable("CandidateJobOffer");
                });

            modelBuilder.Entity("CandidateSkill", b =>
                {
                    b.Property<string>("CandidatesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("SkillsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CandidatesId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("CandidateSkill", (string)null);

                    b.HasData(
                        new
                        {
                            CandidatesId = "f47890b6-a3ce-4057-94a9-af862d2c01de",
                            SkillsId = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f")
                        },
                        new
                        {
                            CandidatesId = "f47890b6-a3ce-4057-94a9-af862d2c01de",
                            SkillsId = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0")
                        },
                        new
                        {
                            CandidatesId = "f29d1608-f324-4432-8e44-5ee320909b9d",
                            SkillsId = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0")
                        });
                });

            modelBuilder.Entity("JobOfferSkill", b =>
                {
                    b.Property<Guid>("JobOffersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequiredSkillsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JobOffersId", "RequiredSkillsId");

                    b.HasIndex("RequiredSkillsId");

                    b.ToTable("JobOfferSkill", (string)null);

                    b.HasData(
                        new
                        {
                            JobOffersId = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                            RequiredSkillsId = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f")
                        },
                        new
                        {
                            JobOffersId = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                            RequiredSkillsId = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0")
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("JobOpportunities.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedByAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                            Email = "company@endava.com",
                            Name = "Endava"
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedByAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("JobOffers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("JobOffer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                            CompanyId = new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                            Description = "Una posición para pasarla bien",
                            Title = ".NET FullStack FullTime",
                            ValidUntil = new DateTime(2022, 11, 14, 17, 52, 1, 882, DateTimeKind.Local).AddTicks(3806)
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.Knowledge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedByAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Knowleadges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                            Description = "Versión 6 + todo el ecosistema",
                            Title = ".NET"
                        },
                        new
                        {
                            Id = new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                            Description = "Versión 13",
                            Title = "Angular"
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("KnowleadgeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedByAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SkillLevelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("KnowleadgeId");

                    b.HasIndex("SkillLevelId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                            KnowleadgeId = new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                            SkillLevelId = new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7")
                        },
                        new
                        {
                            Id = new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                            KnowleadgeId = new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                            SkillLevelId = new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638")
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.SkillLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedByAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SkillLevels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                            Description = "Lower skills required",
                            Name = "Intern"
                        },
                        new
                        {
                            Id = new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                            Description = "Lower skills required, but can finish some tasks",
                            Name = "Junior"
                        },
                        new
                        {
                            Id = new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                            Description = "higher skills required, but less responsabilities",
                            Name = "Semi-Senior"
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.Users.RefreshToken", b =>
                {
                    b.Property<int>("RefreshTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefreshTokenId"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedByAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RefreshTokenValue")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RefreshTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobOpportunities.Domain.Candidate", b =>
                {
                    b.HasBaseType("JobOpportunities.Domain.ApplicationUser");

                    b.HasDiscriminator().HasValue("Candidate");

                    b.HasData(
                        new
                        {
                            Id = "f47890b6-a3ce-4057-94a9-af862d2c01de",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a09efd38-5d5f-4e28-bf15-7d6993170d51",
                            Email = "pepito@endava.com",
                            EmailConfirmed = false,
                            FirstName = "Pepito",
                            LastName = "Juarez",
                            LockoutEnabled = false,
                            PasswordHash = "123456UltraSecure",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7cec901b-c66d-4978-a7ef-1298456023ae",
                            TwoFactorEnabled = false,
                            UserName = "PepitoJuarez"
                        },
                        new
                        {
                            Id = "f29d1608-f324-4432-8e44-5ee320909b9d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9aade53a-1d48-415e-8fbc-8811ec80a86d",
                            Email = "marcelo@endava.com",
                            EmailConfirmed = false,
                            FirstName = "Marcelo",
                            LastName = "Reynoso",
                            LockoutEnabled = false,
                            PasswordHash = "320909b967uythgfd@434$%&",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2459415e-1edc-4502-aad6-06117a16ddcb",
                            TwoFactorEnabled = false,
                            UserName = "MarceloReynoso"
                        });
                });

            modelBuilder.Entity("JobOpportunities.Domain.FullTimeJob", b =>
                {
                    b.HasBaseType("JobOpportunities.Domain.JobOffer");

                    b.HasDiscriminator().HasValue("FullTimeJob");
                });

            modelBuilder.Entity("JobOpportunities.Domain.Intership", b =>
                {
                    b.HasBaseType("JobOpportunities.Domain.JobOffer");

                    b.HasDiscriminator().HasValue("Intership");
                });

            modelBuilder.Entity("CandidateJobOffer", b =>
                {
                    b.HasOne("JobOpportunities.Domain.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobOpportunities.Domain.JobOffer", null)
                        .WithMany()
                        .HasForeignKey("OffersAppliedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandidateSkill", b =>
                {
                    b.HasOne("JobOpportunities.Domain.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobOpportunities.Domain.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobOfferSkill", b =>
                {
                    b.HasOne("JobOpportunities.Domain.JobOffer", null)
                        .WithMany()
                        .HasForeignKey("JobOffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobOpportunities.Domain.Skill", null)
                        .WithMany()
                        .HasForeignKey("RequiredSkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobOpportunities.Domain.JobOffer", b =>
                {
                    b.HasOne("JobOpportunities.Domain.Company", "Company")
                        .WithMany("Offers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobOpportunities.Domain.Skill", b =>
                {
                    b.HasOne("JobOpportunities.Domain.Knowledge", "Knowleadge")
                        .WithMany()
                        .HasForeignKey("KnowleadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobOpportunities.Domain.SkillLevel", "SkillLevel")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Knowleadge");

                    b.Navigation("SkillLevel");
                });

            modelBuilder.Entity("JobOpportunities.Domain.Users.RefreshToken", b =>
                {
                    b.HasOne("JobOpportunities.Domain.ApplicationUser", "User")
                        .WithMany("AccessTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobOpportunities.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobOpportunities.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobOpportunities.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobOpportunities.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobOpportunities.Domain.ApplicationUser", b =>
                {
                    b.Navigation("AccessTokens");
                });

            modelBuilder.Entity("JobOpportunities.Domain.Company", b =>
                {
                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}
