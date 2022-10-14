using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class AddCVFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Curriculum",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f29d1608-f324-4432-8e44-5ee320909b9d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b0874a8-2f72-4a2d-b11c-2c318adf1de0", "AQAAAAEAACcQAAAAEGH2b2dWPUIcY7GZLzZMUxb5eUt6n/uK/kB2Orhj1OzMYsFCyu5ZnmA5PVwkIk6+SQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f47890b6-a3ce-4057-94a9-af862d2c01de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a357f48a-af26-4639-988b-fe73275d8c54", "AQAAAAEAACcQAAAAEBTmtfkLEvCTCTHbZZHcRUiWiFADp+qPvVrlhj/XQp1X16MsNVyujWLRy5+LflwqaQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b1d13dd-afb4-474f-a60a-bf6ab3474898"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c90329d-ca30-44c7-a5e8-d65022776ff3", "AQAAAAEAACcQAAAAEIRv/epiGukyqi/Gs/yaqwKysFnWt6FmrRnuvxZcME6vHyh2TiKXHm5Eugv/CyvyIg==" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2023, 1, 8, 18, 2, 23, 994, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("ff414898-e070-4c52-be2e-04cae7a1af1a"),
                column: "ValidUntil",
                value: new DateTime(2023, 1, 8, 18, 2, 23, 994, DateTimeKind.Local).AddTicks(6189));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "AspNetUsers");

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
    }
}
