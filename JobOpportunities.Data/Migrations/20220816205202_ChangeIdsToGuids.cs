using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOpportunities.Data.Migrations
{
    public partial class ChangeIdsToGuids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshTokenValue = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f29d1608-f324-4432-8e44-5ee320909b9d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9aade53a-1d48-415e-8fbc-8811ec80a86d", "2459415e-1edc-4502-aad6-06117a16ddcb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f47890b6-a3ce-4057-94a9-af862d2c01de",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a09efd38-5d5f-4e28-bf15-7d6993170d51", "7cec901b-c66d-4978-a7ef-1298456023ae" });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: new Guid("5cfe1935-3a8e-418a-a260-38d0551d5027"),
                column: "ValidUntil",
                value: new DateTime(2022, 11, 14, 17, 52, 1, 882, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

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
    }
}
