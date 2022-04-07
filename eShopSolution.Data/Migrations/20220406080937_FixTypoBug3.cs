using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class FixTypoBug3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

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
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

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
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "dec06654-7464-419d-b89d-9a7e6e3af56b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d6bdffb6-ab33-41db-93e2-d709f1230e6b");

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("5f5d0f29-f012-411a-970e-97835c440947"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") },
                    { new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"), 0, "b6162214-6565-4cde-b1c7-0a17bb7fdc43", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Toan", "Bach", false, null, "tedu.international@gmail.com", "admin1", "AQAAAAEAACcQAAAAENTOioCwV+5O9ay0tegGGE4wnzM/USg9EckSCGHggeKm42fstk8s/+tTB+ZvCLcvJQ==", "1234567890", false, null, false, "admin1" },
                    { new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"), 0, "b2dbe8be-b15d-408b-ad24-b2f52d62367e", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vhtrung52@gmail.com", true, "Hoang", "Trung", false, null, "vhtrung52@gmail.com", "admin2", "AQAAAAEAACcQAAAAEAr3h9k1BxEgDjWghqgzUOq8uVE3COiu5/8ZUnONr0PDE0H/LrfL/KscsVLrTV9+wg==", "1234567890", false, null, false, "admin2" },
                    { new Guid("5f5d0f29-f012-411a-970e-97835c440947"), 0, "40c24d90-08e6-4fe7-b005-4d51c5917191", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Toan", "Bach", false, null, "tedu.international@gmail.com", "user1", "AQAAAAEAACcQAAAAEA5200z/KZuCdHVz1heNPtn2lo893ST5LTNeXKGOs2PxhsEsAo4aAt8DoVyZ/07DLw==", "1234567890", false, null, false, "user1" },
                    { new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"), 0, "ba1db2ed-8006-4a22-80f6-2cab6b5eddea", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vhtrung52@gmail.com", true, "Hoang", "Trung", false, null, "vhtrung52@gmail.com", "user2", "AQAAAAEAACcQAAAAEBVaPz9KMvBD+ndN+Ds4AY/SJEQ+qfJyjWvQbd3FBfQ3KJ0ILId4bv9DMIgKJKSquQ==", "1234567890", false, null, false, "user2" }
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
                values: new object[] { new DateTime(2022, 4, 6, 15, 9, 36, 481, DateTimeKind.Local).AddTicks(4457), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5f5d0f29-f012-411a-970e-97835c440947"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0f29-f012-411a-970e-97835c440947"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"));

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

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") },
                    { new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") },
                    { new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"), new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "e4fe1acf-1617-482c-8f85-65e31952d4c3", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Toan", "Bach", false, null, "tedu.international@gmail.com", "admin1", "AQAAAAEAACcQAAAAEHgXZq4QzOtyuMjSYedk/tVKMNNcHb2SJGGV3ZSNrj8054IYtgBVJ2O0l7rA36WJOQ==", "1234567890", false, null, false, "admin1" },
                    { new Guid("76d96e6e-2cb1-4f95-a107-91a9f41a64ff"), 0, "83ecb938-94d9-488a-80b7-dcd495eca011", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vhtrung52@gmail.com", true, "Hoang", "Trung", false, null, "vhtrung52@gmail.com", "admin2", "AQAAAAEAACcQAAAAEBOpj0vIavBkowQKOU6sTp9wM9eugmHQWPTupgREsBx0qx6MsyYDYy6SY7JB/GMF3g==", "1234567890", false, null, false, "admin2" },
                    { new Guid("e6b7cca7-ca41-4d60-a85a-cc54aab13979"), 0, "1d3f5354-c059-47a2-a130-dc3aa36d4b56", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Toan", "Bach", false, null, "tedu.international@gmail.com", "user1", "AQAAAAEAACcQAAAAEF/M0fUGLT5fEqMqRmggXhy3MliHr8ot7Viu85Mj188EhfD21ujejNoJemuNRQuWwQ==", "1234567890", false, null, false, "user1" },
                    { new Guid("57c3a06d-c045-4630-9a38-ba4187d327c5"), 0, "7a84afd4-72b2-45fa-83f6-5431e5cd9d05", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "vhtrung52@gmail.com", true, "Hoang", "Trung", false, null, "vhtrung52@gmail.com", "user2", "AQAAAAEAACcQAAAAECtszVJoGfXJhbbMT7Tz1NzHzy2SZFNkQsbdtArxGiJvmaY28Zscoh6DSyADqKMQsg==", "1234567890", false, null, false, "user2" }
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
                values: new object[] { new DateTime(2022, 4, 6, 15, 3, 49, 865, DateTimeKind.Local).AddTicks(3203), 100000m });
        }
    }
}
