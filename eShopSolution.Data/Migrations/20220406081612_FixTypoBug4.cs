using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class FixTypoBug4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "17cf2964-e3eb-4346-8534-73de7b64d299");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0ca73e81-6275-4e68-9bfc-05e570b534b0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0f29-f012-411a-970e-97835c440947"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b88d2fe1-9662-4cc2-8436-f67e1595c182", "AQAAAAEAACcQAAAAECHKNGqRgoIaoqDHXH7eW19FSSpMzgo8EXpT/CH8RR5If+ojnwDX/rMZIKURvY9mFQ==", "" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "444793ea-b28f-4eeb-ba40-3468544f4229", "AQAAAAEAACcQAAAAEPDoGCJNFsRuL0NWQbxHy0sQaOsZ/C4pUiwae/pCwQ6Dgw3RgRG+XGgn8sP38wO+ZQ==", "" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc934daf-a231-4f47-a7eb-bd0ec72767eb", "AQAAAAEAACcQAAAAEI9lwle7ltKx/0WnkmxCvCFvCqC78XaOvbNtQI/yT8eOb27xrl47OY6y8Z3SAR9Smg==", "" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f5c7a40-ebee-45da-922c-1d6af603a010", "AQAAAAEAACcQAAAAEF5FV7WtyrLx7a53kfAPiF4CMYFWywxPoH5I0+g6SLe9NBIDvtQgjrcHkBbD5TQv8w==", "" });

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
                values: new object[] { new DateTime(2022, 4, 6, 15, 16, 11, 384, DateTimeKind.Local).AddTicks(780), 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0f29-f012-411a-970e-97835c440947"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40c24d90-08e6-4fe7-b005-4d51c5917191", "AQAAAAEAACcQAAAAEA5200z/KZuCdHVz1heNPtn2lo893ST5LTNeXKGOs2PxhsEsAo4aAt8DoVyZ/07DLw==", null });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba1db2ed-8006-4a22-80f6-2cab6b5eddea", "AQAAAAEAACcQAAAAEBVaPz9KMvBD+ndN+Ds4AY/SJEQ+qfJyjWvQbd3FBfQ3KJ0ILId4bv9DMIgKJKSquQ==", null });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6162214-6565-4cde-b1c7-0a17bb7fdc43", "AQAAAAEAACcQAAAAENTOioCwV+5O9ay0tegGGE4wnzM/USg9EckSCGHggeKm42fstk8s/+tTB+ZvCLcvJQ==", null });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2dbe8be-b15d-408b-ad24-b2f52d62367e", "AQAAAAEAACcQAAAAEAr3h9k1BxEgDjWghqgzUOq8uVE3COiu5/8ZUnONr0PDE0H/LrfL/KscsVLrTV9+wg==", null });

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
    }
}
