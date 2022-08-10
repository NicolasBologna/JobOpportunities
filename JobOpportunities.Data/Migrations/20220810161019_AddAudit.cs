using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class AddAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "SkillLevels");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Knowleadges");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "Skills",
                newName: "LastModifiedByAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "SkillLevels",
                newName: "LastModifiedByAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "Knowleadges",
                newName: "LastModifiedByAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "JobOffers",
                newName: "LastModifiedByAt");

            migrationBuilder.RenameColumn(
                name: "LastUpdate",
                table: "Companies",
                newName: "LastModifiedByAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SkillLevels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SkillLevels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "SkillLevels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Knowleadges",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Knowleadges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Knowleadges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "JobOffers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f29d1608-f324-4432-8e44-5ee320909b9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "258ce5d2-fb49-4ed6-ae72-c383ddf81f08", "2106c013-8dac-4f07-8785-668faee35f71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f47890b6-a3ce-4057-94a9-af862d2c01de",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b25ca5e8-bda6-4b63-a69c-e81a97a92c81", "53e7fa52-5d70-47af-8fdb-e5c2fcdef35b" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2022, 11, 8, 13, 10, 18, 627, DateTimeKind.Local).AddTicks(8802));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SkillLevels");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SkillLevels");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SkillLevels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Knowleadges");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Knowleadges");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Knowleadges");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByAt",
                table: "Skills",
                newName: "LastUpdate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByAt",
                table: "SkillLevels",
                newName: "LastUpdate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByAt",
                table: "Knowleadges",
                newName: "LastUpdate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByAt",
                table: "JobOffers",
                newName: "LastUpdate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByAt",
                table: "Companies",
                newName: "LastUpdate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "SkillLevels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Knowleadges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "JobOffers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f29d1608-f324-4432-8e44-5ee320909b9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89fd39fd-e04e-46cf-90aa-bb48a2513d46", "0483801c-6bf9-4129-bab9-4e56a0fc6b2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f47890b6-a3ce-4057-94a9-af862d2c01de",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66f946b4-b63f-4f38-9514-ef3384f7683f", "e3f89708-86e5-42f0-bf3b-34e5bb42b940" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9ee1f9a2-201a-4351-abc1-c056932a1165"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                columns: new[] { "CreationDate", "ValidUntil" },
                values: new object[] { new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7625), new DateTime(2022, 11, 6, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("3f374542-7711-4581-80c3-6f1a0a7c1105"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "Knowleadges",
                keyColumn: "Id",
                keyValue: new Guid("b20501eb-5f36-4ed4-96ac-cf32817dce06"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("248b45b9-bf4a-4815-844d-ec02daaeb638"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("78867f5c-44fb-470d-9946-3da97e6ae2a7"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "SkillLevels",
                keyColumn: "Id",
                keyValue: new Guid("a9be5506-3f5e-403a-b113-73fba517f3c6"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2f8ce28b-8641-426e-98ba-eef98cc9f8a0"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("70068d37-d9e3-48d9-a390-e85a11f2f31f"),
                column: "CreationDate",
                value: new DateTime(2022, 8, 8, 17, 21, 57, 706, DateTimeKind.Local).AddTicks(7586));
        }
    }
}
