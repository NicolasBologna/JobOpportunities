using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class ImproveUserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"), "3", "CompanyAgent", "Company Agent" },
                    { new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), "2", "Candidate", "Candidate" },
                    { new Guid("fab4fac1-c546-41de-aebc-a14da6895711"), "1", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c57d3c30-a666-404f-90c9-5fc9db11e75a", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "18fc2382-3be6-4c36-b655-5fa551a5a6f5", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                column: "ConcurrencyStamp",
                value: "12c7de69-ac21-47f0-9d53-4602cec7fff4");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2022, 12, 11, 14, 47, 27, 328, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "CreatedBy", "Description", "Discriminator", "LastModifiedBy", "LastModifiedByAt", "Title", "ValidUntil" },
                values: new object[] { new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"), new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"), null, null, "Posición ma o meno", "JobOffer", null, null, "Node Backend", new DateTime(2022, 12, 11, 14, 47, 27, 328, DateTimeKind.Local).AddTicks(3460) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"), new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), new Guid("f29d1608-f324-4432-8e44-5ee320909b9d") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fab4fac1-c546-41de-aebc-a14da6895711"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"), new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), new Guid("f29d1608-f324-4432-8e44-5ee320909b9d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"), new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de") });

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c1373b0-88f2-4197-97d2-b3df48f58833", "320909b967uythgfd@434$%&" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8d80dd5-d0ce-4b89-9034-547eb614ddf6", "123456UltraSecure" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                column: "ConcurrencyStamp",
                value: "4d0d8229-6fa2-4812-a9a6-2d51b18045c1");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2022, 12, 5, 16, 19, 4, 473, DateTimeKind.Local).AddTicks(4929));
        }
    }
}
