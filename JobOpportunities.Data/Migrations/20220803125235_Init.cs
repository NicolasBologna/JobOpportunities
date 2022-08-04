using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
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
                    CandidatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OffersAppliedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJobOffer", x => new { x.CandidatesId, x.OffersAppliedId });
                    table.ForeignKey(
                        name: "FK_CandidateJobOffer_Candidates_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "Candidates",
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
                    CandidatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkill", x => new { x.CandidatesId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_CandidateSkill_Candidates_CandidatesId",
                        column: x => x.CandidatesId,
                        principalTable: "Candidates",
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
                table: "Companies",
                columns: new[] { "Id", "CreationDate", "Email", "LastUpdate", "Name" },
                values: new object[] { new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8942), "company@endava.com", null, "Endava" });

            migrationBuilder.InsertData(
                table: "Knowleadges",
                columns: new[] { "Id", "CreationDate", "Description", "LastUpdate", "Title" },
                values: new object[,]
                {
                    { new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8909), "Versión 13", null, "Angular" },
                    { new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8901), "Versión 6 + todo el ecosistema", null, ".NET" }
                });

            migrationBuilder.InsertData(
                table: "SkillLevels",
                columns: new[] { "Id", "CreationDate", "Description", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8889), "higher skills required, but less responsabilities", null, "Semi-Senior" },
                    { new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8856), "Lower skills required", null, "Intern" },
                    { new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8881), "Lower skills required, but can finish some tasks", null, "Junior" }
                });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "CreationDate", "Description", "Discriminator", "LastUpdate", "Title", "ValidUntil" },
                values: new object[] { new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"), new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8956), "Una posición para pasarla bien", "JobOffer", null, ".NET FullStack FullTime", new DateTime(2022, 11, 1, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8957) });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreationDate", "KnowleadgeId", "LastUpdate", "SkillLevelId" },
                values: new object[] { new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8929), new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"), null, new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638") });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreationDate", "KnowleadgeId", "LastUpdate", "SkillLevelId" },
                values: new object[] { new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"), new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8921), new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"), null, new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7") });

            migrationBuilder.InsertData(
                table: "JobOfferSkill",
                columns: new[] { "JobOffersId", "RequiredSkillsId" },
                values: new object[] { new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"), new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") });

            migrationBuilder.InsertData(
                table: "JobOfferSkill",
                columns: new[] { "JobOffersId", "RequiredSkillsId" },
                values: new object[] { new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"), new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f") });

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
                name: "CandidateJobOffer");

            migrationBuilder.DropTable(
                name: "CandidateSkill");

            migrationBuilder.DropTable(
                name: "JobOfferSkill");

            migrationBuilder.DropTable(
                name: "Candidates");

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
