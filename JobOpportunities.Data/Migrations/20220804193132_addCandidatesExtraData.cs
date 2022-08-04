using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class addCandidatesExtraData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CandidateSkill",
                columns: new[] { "CandidatesId", "SkillsId" },
                values: new object[] { new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"), new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1901));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                columns: new[] { "CreationDate", "ValidUntil" },
                values: new object[] { new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1921), new DateTime(2022, 11, 2, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 16, 31, 31, 903, DateTimeKind.Local).AddTicks(1872));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkill",
                keyColumns: new[] { "CandidatesId", "SkillsId" },
                keyValues: new object[] { new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"), new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") });

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 558, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 558, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                columns: new[] { "CreationDate", "ValidUntil" },
                values: new object[] { new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9876), new DateTime(2022, 11, 2, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9877) });

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 4, 13, 50, 32, 557, DateTimeKind.Local).AddTicks(9812));
        }
    }
}
