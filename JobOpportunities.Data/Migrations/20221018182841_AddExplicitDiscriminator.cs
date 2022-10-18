using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class AddExplicitDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "AspNetUsers",
                newName: "UserType");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "AspNetUsers",
                newName: "Discriminator");

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
    }
}
