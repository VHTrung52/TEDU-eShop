using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class FixTypoBug2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "c24f55e6-416b-4ec7-b96b-af70801bcd00");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2e7b5809-02d3-40cd-b06c-e3e00febf93a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a84afd4-72b2-45fa-83f6-5431e5cd9d05", "AQAAAAEAACcQAAAAECtszVJoGfXJhbbMT7Tz1NzHzy2SZFNkQsbdtArxGiJvmaY28Zscoh6DSyADqKMQsg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4fe1acf-1617-482c-8f85-65e31952d4c3", "AQAAAAEAACcQAAAAEHgXZq4QzOtyuMjSYedk/tVKMNNcHb2SJGGV3ZSNrj8054IYtgBVJ2O0l7rA36WJOQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "83ecb938-94d9-488a-80b7-dcd495eca011", "AQAAAAEAACcQAAAAEBOpj0vIavBkowQKOU6sTp9wM9eugmHQWPTupgREsBx0qx6MsyYDYy6SY7JB/GMF3g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d3f5354-c059-47a2-a130-dc3aa36d4b56", "AQAAAAEAACcQAAAAEF/M0fUGLT5fEqMqRmggXhy3MliHr8ot7Viu85Mj188EhfD21ujejNoJemuNRQuWwQ==" });

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
                values: new object[] { new DateTime(2022, 4, 6, 15, 3, 49, 865, DateTimeKind.Local).AddTicks(3203), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "cb597cec-48bf-4c04-9748-acfb09a225e8");

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
    }
}
