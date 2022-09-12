using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class ImproveUserSeeds2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"),
                column: "NormalizedName",
                value: "COMPANYAGENT");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"),
                column: "NormalizedName",
                value: "CANDIDATE");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fab4fac1-c546-41de-aebc-a14da6895711"),
                column: "NormalizedName",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ca14a87-aa23-4027-a0ba-d09addc4dd92", "AQAAAAEAACcQAAAAEANn1UczE0j7aXajH5kO6lUFGRdtdrve751LfFtedCWBh/uAdqT4NUOl+HHY4kvGHg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2487e0c0-4d7e-43f0-b8ab-bfd3f5db4d93", "AQAAAAEAACcQAAAAEHYjv69pzYvOQRtHxxRwjDRmYjtaA1AMymP1osTagAm7HtpAQEoOHQ4+GSDOdbD3JQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aed62408-5863-4074-8348-2c47450a57e8", "AQAAAAEAACcQAAAAEFaABQJSdnO1MlGK6Lr/bdvB3vomKV1BhWhcAvBs+s03yNtutkNyhSJ49hJAf0xCTQ==" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2022, 12, 11, 14, 59, 53, 170, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"),
                column: "ValidUntil",
                value: new DateTime(2022, 12, 11, 14, 59, 53, 170, DateTimeKind.Local).AddTicks(1461));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("30680485-8d48-4a7a-8f2b-8afdb1fc526c"),
                column: "NormalizedName",
                value: "Company Agent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"),
                column: "NormalizedName",
                value: "Candidate");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fab4fac1-c546-41de-aebc-a14da6895711"),
                column: "NormalizedName",
                value: "Admin");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12c7de69-ac21-47f0-9d53-4602cec7fff4", null });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2022, 12, 11, 14, 47, 27, 328, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"),
                column: "ValidUntil",
                value: new DateTime(2022, 12, 11, 14, 47, 27, 328, DateTimeKind.Local).AddTicks(3460));
        }
    }
}
