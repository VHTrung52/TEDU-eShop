using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f020dfae-a27b-4da6-8fa9-d26851e235d9");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"), "fff93408-8031-4d26-865b-283698ccc371", "Administrator role", "user", "user" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") },
                    { new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") }
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "588a1007-7175-4740-a7f0-dbe04bccbcbb", "admin1", "AQAAAAEAACcQAAAAEPcbsiy0By5eYh09G2VUq7LcWKQjONk6rtNZmE6+B4pdydyx2RHXrjBw6cVTtVyUjA==", "1234567890", null, "admin1" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"), 0, "1898fd73-54df-422f-bfe4-d052ce81afdc", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vhtrung52@gmail.com", true, "Hoang", "Trung", false, null, "vhtrung52@gmail.com", "admin2", "AQAAAAEAACcQAAAAEK7zdyy6thEnEoprbFwhfg+CFHaHj4vnUZY9SCtbTO05/Sq1j1/IZjP8FCOqd1Jk3w==", "1234567890", false, null, false, "admin2" },
                    { new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"), 0, "fc0624ce-7bd5-49bf-bf3f-1616efac207f", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Toan", "Bach", false, null, "tedu.international@gmail.com", "user1", "AQAAAAEAACcQAAAAEI7DrkOV914yPC58Dqn/q2DORGcJ3V7wo4If7nLHrpVXek6LVeou4+rDMKadxTsj6A==", "1234567890", false, null, false, "user1" },
                    { new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"), 0, "b6130998-47d5-4307-930a-aae9e029d675", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vhtrung52@gmail.com", true, "Hoang", "Trung", false, null, "vhtrung52@gmail.com", "user2", "AQAAAAEAACcQAAAAEPDb+iyOltjyeMeQuN9YJOyYSlnXa4UPzScHswsRw71STR5G3pV4sSAKjyxdAffnSA==", "1234567890", false, null, false, "user2" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c7195fc3-0039-4226-a3ce-4e226c491be0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhoneNumber", "SecurityStamp", "UserName" },
                values: new object[] { "ea67f719-246d-40d5-8e2c-b9fd5d59984a", "admin", "AQAAAAEAACcQAAAAEEWwkazDSFAxrGB3A82vVHQ8PwB24OS4xYfY9Wf0Ny6ToSJ8ozJjaO3IzaAUWOfqZw==", null, "", "admin" });

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
                values: new object[] { new DateTime(2022, 2, 9, 16, 15, 34, 653, DateTimeKind.Local).AddTicks(1543), 100000m });
        }
    }
}
