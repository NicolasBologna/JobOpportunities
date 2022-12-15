using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class RenameSkillLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillLevels_SkillLevelId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SkillLevels");

            migrationBuilder.CreateTable(
                name: "Senirorities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senirorities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "861f4ac5-d5dc-4a28-9a94-1071f4fc96a0", "AQAAAAEAACcQAAAAEFx8u792/tYfZQm8uaRVdbezS4pZll9S9neNuK7Pqwl4VAkpwEMn/9hVzyhcv5gBsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "568843a9-ecf3-48ab-8a25-ab6e89ef31e4", "AQAAAAEAACcQAAAAEPfoD+tbYaLNQMtRLbUfB/rHqWgUQYalmPRrbU3LWa5eKcKVHW6no3RILArlOaOw2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "464292d3-7643-4bcb-8705-632aeb11e46b", "AQAAAAEAACcQAAAAEIMYtEJwLNMXKxg7BIWck70mVIG4UThzWxd0cu511hhLTKndR99nZWnlNjHCPrYQ5w==" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2023, 3, 14, 15, 17, 8, 497, DateTimeKind.Local).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"),
                column: "ValidUntil",
                value: new DateTime(2023, 3, 14, 15, 17, 8, 497, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.InsertData(
                table: "Senirorities",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LastModifiedBy", "LastModifiedByAt", "Name" },
                values: new object[,]
                {
                    { new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"), null, null, "higher skills required, but less responsabilities", null, null, "Semi-Senior" },
                    { new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"), null, null, "Lower skills required", null, null, "Intern" },
                    { new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"), null, null, "Lower skills required, but can finish some tasks", null, null, "Junior" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Senirorities_SkillLevelId",
                table: "Skills",
                column: "SkillLevelId",
                principalTable: "Senirorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Senirorities_SkillLevelId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Senirorities");

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f4b7d925-cbc1-4d8f-835c-d64f9c52c61a", "AQAAAAEAACcQAAAAEGQGBHgeViCZ8y9/a2Tg6UUfRgWflA9G4qYePuPUa4K7a+Lx63YqNiZHyB+5Rj6O+g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b3377bfe-343c-48b7-9a17-f10dad9bb158", "AQAAAAEAACcQAAAAEOVfpQLCJT9P2a0nKrV0WFk2ru+YIJAZd4fNMuaHRAEHf/hLo4gyeneTMiuRuqNGBA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d67c2bdf-4705-48b2-800c-c8fe114b0a81", "AQAAAAEAACcQAAAAEHJuZO1wKKH04r/puhGwNgnLl91vemlXqqC2P6ooNVPxWJk2i5tB/u+EgyOoqP4S4Q==" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2023, 1, 16, 15, 28, 41, 149, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"),
                column: "ValidUntil",
                value: new DateTime(2023, 1, 16, 15, 28, 41, 149, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.InsertData(
                table: "SkillLevels",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "LastModifiedBy", "LastModifiedByAt", "Name" },
                values: new object[,]
                {
                    { new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"), null, null, "higher skills required, but less responsabilities", null, null, "Semi-Senior" },
                    { new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"), null, null, "Lower skills required", null, null, "Intern" },
                    { new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"), null, null, "Lower skills required, but can finish some tasks", null, null, "Junior" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillLevels_SkillLevelId",
                table: "Skills",
                column: "SkillLevelId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
