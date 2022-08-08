using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class InitAndAddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knowleadges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowleadges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KnowleadgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Knowleadges_KnowleadgeId",
                        column: x => x.KnowleadgeId,
                        principalTable: "Knowleadges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_SkillLevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateJobOffer",
                columns: table => new
                {
                    CandidatesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OffersAppliedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJobOffer", x => new { x.CandidatesId, x.OffersAppliedId });
                    table.ForeignKey(
                        name: "FK_CandidateJobOffer_AspNetUsers_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateJobOffer_JobOffers_OffersAppliedId",
                        column: x => x.OffersAppliedId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkill",
                columns: table => new
                {
                    CandidatesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkill", x => new { x.CandidatesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CandidateSkill_AspNetUsers_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferSkill",
                columns: table => new
                {
                    JobOffersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequiredSkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferSkill", x => new { x.JobOffersId, x.RequiredSkillsId });
                    table.ForeignKey(
                        name: "FK_JobOfferSkill_JobOffers_JobOffersId",
                        column: x => x.JobOffersId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOfferSkill_Skills_RequiredSkillsId",
                        column: x => x.RequiredSkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f29d1608-f324-4432-8e44-5ee320909b9d", 0, "89fd39fd-e04e-46cf-90aa-bb48a2513d46", "Candidate", "marcelo@endava.com", false, "Marcelo", "Reynoso", false, null, null, null, "320909b967uythgfd@434$%&", null, false, "0483801c-6bf9-4129-bab9-4e56a0fc6b2d", false, "MarceloReynoso" },
                    { "f47890b6-a3ce-4057-94a9-af862d2c01de", 0, "66f946b4-b63f-4f38-9514-ef3384f7683f", "Candidate", "pepito@endava.com", false, "Pepito", "Juarez", false, null, null, null, "123456UltraSecure", null, false, "e3f89708-86e5-42f0-bf3b-34e5bb42b940", false, "PepitoJuarez" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreationDate", "Email", "LastUpdate", "Name" },
                values: new object[] { new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7611), "company@endava.com", null, "Endava" });

            migrationBuilder.InsertData(
                table: "Knowleadges",
                columns: new[] { "Id", "CreationDate", "Description", "LastUpdate", "Title" },
                values: new object[,]
                {
                    { new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7565), "Versión 13", null, "Angular" },
                    { new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7555), "Versión 6 + todo el ecosistema", null, ".NET" }
                });

            migrationBuilder.InsertData(
                table: "SkillLevels",
                columns: new[] { "Id", "CreationDate", "Description", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7543), "higher skills required, but less responsabilities", null, "Semi-Senior" },
                    { new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7514), "Lower skills required", null, "Intern" },
                    { new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7535), "Lower skills required, but can finish some tasks", null, "Junior" }
                });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "Discriminator", "LastUpdate", "Title", "ValidUntil" },
                values: new object[] { new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"), new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7625), "Una posición para pasarla bien", "JobOffer", null, ".NET FullStack FullTime", new DateTime(2022, 11, 6, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7627) });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreationDate", "KnowleadgeId", "LastUpdate", "SkillLevelId" },
                values: new object[] { new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7596), new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"), null, new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638") });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreationDate", "KnowleadgeId", "LastUpdate", "SkillLevelId" },
                values: new object[] { new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"), new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7586), new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"), null, new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7") });

            migrationBuilder.InsertData(
                table: "CandidateSkill",
                columns: new[] { "CandidatesId", "SkillsId" },
                values: new object[,]
                {
                    { "f29d1608-f324-4432-8e44-5ee320909b9d", new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") },
                    { "f47890b6-a3ce-4057-94a9-af862d2c01de", new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") },
                    { "f47890b6-a3ce-4057-94a9-af862d2c01de", new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f") }
                });

            migrationBuilder.InsertData(
                table: "JobOfferSkill",
                columns: new[] { "JobOffersId", "RequiredSkillsId" },
                values: new object[,]
                {
                    { new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"), new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") },
                    { new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"), new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobOffer_OffersAppliedId",
                table: "CandidateJobOffer",
                column: "OffersAppliedId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkill_SkillsId",
                table: "CandidateSkill",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferSkill_RequiredSkillsId",
                table: "JobOfferSkill",
                column: "RequiredSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_KnowleadgeId",
                table: "Skills",
                column: "KnowleadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillLevelId",
                table: "Skills",
                column: "SkillLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CandidateJobOffer");

            migrationBuilder.DropTable(
                name: "CandidateSkill");

            migrationBuilder.DropTable(
                name: "JobOfferSkill");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Knowleadges");

            migrationBuilder.DropTable(
                name: "SkillLevels");
        }
    }
}
