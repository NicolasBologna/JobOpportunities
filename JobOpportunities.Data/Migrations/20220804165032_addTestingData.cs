using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class addTestingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "CreationDate", "Email", "LastUpdate", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"), new DateTime(2022, 8, 4, 13, 50, 32, 558, DateTimeKind.Local).AddTicks(429), "marcelo@endava.com", null, "Marcelo Reynoso", "320909b967uythgfd@434$%&" },
                    { new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"), new DateTime(2022, 8, 4, 13, 50, 32, 558, DateTimeKind.Local).AddTicks(417), "pepito@endava.com", null, "Pepito Juarez", "123456UltraSecure" }
                });

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

            migrationBuilder.InsertData(
                table: "CandidateSkill",
                columns: new[] { "CandidatesId", "SkillsId" },
                values: new object[] { new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"), new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") });

            migrationBuilder.InsertData(
                table: "CandidateSkill",
                columns: new[] { "CandidatesId", "SkillsId" },
                values: new object[] { new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"), new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkill",
                keyColumns: new[] { "CandidatesId", "SkillsId" },
                keyValues: new object[] { new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"), new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0") });

            migrationBuilder.DeleteData(
                table: "CandidateSkill",
                keyColumns: new[] { "CandidatesId", "SkillsId" },
                keyValues: new object[] { new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"), new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f") });

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                columns: new[] { "CreationDate", "ValidUntil" },
                values: new object[] { new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8956), new DateTime(2022, 11, 1, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8957) });

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8889));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 3, 9, 52, 30, 735, DateTimeKind.Local).AddTicks(8921));
        }
    }
}
