using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class FixTypoBug1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                columns: new[] { "ConcurrencyStamp", "Description" },
                values: new object[] { "cb597cec-48bf-4c04-9748-acfb09a225e8", "User role" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ce3926f5-6458-43e2-b701-5fc9f32450b9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e573386c-d8b5-44ae-a6bd-2e415d41b2a4", "AQAAAAEAACcQAAAAEEjg22+JdUkARu1bGzPZV46oGQBJDmj8LrZd4E1dl2w/hc/tMqvqm66FskpCzb7OjQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aeda60a9-da55-40e3-8505-7b17d506c5e3", "AQAAAAEAACcQAAAAEKzqKUOpktRyEPbaxElb99Y2cPOk/pxMtFTpLOqPkdmboKNPS+zIQl0XSXNPS99qng==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22c5cdc6-e66e-4ea0-abe6-53b8410c6d4d", "AQAAAAEAACcQAAAAEKCqZYxYgRkFVG2z8HNCB1UI2p6KtwkP6YWNps5cGqta0qepUcJWrTBAke0H6HUvtQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f04ad911-8e37-404f-ba0e-f5518044d0d7", "AQAAAAEAACcQAAAAEFVrkuTXIU+qiRvBqvAfbBPNmh6OcZ98QoQD2qz96Xb597bsB5yVHEfbGdSrtREHIA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "OriginalPrice" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 51, 29, 12, DateTimeKind.Local).AddTicks(8720), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                columns: new[] { "ConcurrencyStamp", "Description" },
                values: new object[] { "fff93408-8031-4d26-865b-283698ccc371", "Administrator role" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f020dfae-a27b-4da6-8fa9-d26851e235d9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6130998-47d5-4307-930a-aae9e029d675", "AQAAAAEAACcQAAAAEPDb+iyOltjyeMeQuN9YJOyYSlnXa4UPzScHswsRw71STR5G3pV4sSAKjyxdAffnSA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "588a1007-7175-4740-a7f0-dbe04bccbcbb", "AQAAAAEAACcQAAAAEPcbsiy0By5eYh09G2VUq7LcWKQjONk6rtNZmE6+B4pdydyx2RHXrjBw6cVTtVyUjA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1898fd73-54df-422f-bfe4-d052ce81afdc", "AQAAAAEAACcQAAAAEK7zdyy6thEnEoprbFwhfg+CFHaHj4vnUZY9SCtbTO05/Sq1j1/IZjP8FCOqd1Jk3w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc0624ce-7bd5-49bf-bf3f-1616efac207f", "AQAAAAEAACcQAAAAEI7DrkOV914yPC58Dqn/q2DORGcJ3V7wo4If7nLHrpVXek6LVeou4+rDMKadxTsj6A==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "OriginalPrice" },
                values: new object[] { new DateTime(2022, 4, 6, 14, 47, 48, 603, DateTimeKind.Local).AddTicks(1410), 100000m });
        }
    }
}
