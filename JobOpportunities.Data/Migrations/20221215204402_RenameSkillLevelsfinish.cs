using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class RenameSkillLevelsfinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Senirorities_SkillLevelId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SkillLevelId",
                table: "Skills",
                newName: "SeniorityId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SkillLevelId",
                table: "Skills",
                newName: "IX_Skills_SeniorityId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "186e13ac-69c5-44f8-b8c9-8457623abae2", "AQAAAAEAACcQAAAAEJMbWyBh3UGkWsrxZw4xN7jEE3AQfBi+gHIdI6E9HdSWJQzjTWee46+ipdFUpK5eXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1f1330c-321b-40e0-9349-bf648d814255", "AQAAAAEAACcQAAAAEJZEQ/bVsiS8g9VtZgcoVt78ItsekyMJQ8HQL+vosrX6ZuWV0EHki0Z2yVi3mdn0Ow==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c25275ee-3b18-417d-85a2-b9a7ac9a9a44", "AQAAAAEAACcQAAAAEDpmh4AcZAAEN0VBAMFRJBXLVw30uRmZTEhbOJhzZvadY3FKkl1ppoc/+cdQHe1kJw==" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2023, 3, 15, 17, 44, 1, 777, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"),
                column: "ValidUntil",
                value: new DateTime(2023, 3, 15, 17, 44, 1, 777, DateTimeKind.Local).AddTicks(3814));

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Senirorities_SeniorityId",
                table: "Skills",
                column: "SeniorityId",
                principalTable: "Senirorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Senirorities_SeniorityId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "SeniorityId",
                table: "Skills",
                newName: "SkillLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SeniorityId",
                table: "Skills",
                newName: "IX_Skills_SkillLevelId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Senirorities_SkillLevelId",
                table: "Skills",
                column: "SkillLevelId",
                principalTable: "Senirorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
