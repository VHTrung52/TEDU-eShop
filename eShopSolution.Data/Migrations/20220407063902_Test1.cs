using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "555d11e7-3f6b-44b9-bbc0-3261a3f60596");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c0394bed-928f-4ec7-adf9-28956362e52e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0f29-f012-411a-970e-97835c440947"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5443dba-fcbe-4447-9b25-3d28453fc343", "AQAAAAEAACcQAAAAEP0IK3MhuD92J4QSa3TVKvedhNYjzw8puV/1iLnLMEHoXFCEmMFAkYRX7jBpydZ15Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31fe60d9-d3bf-4738-8771-10c364225dda", "AQAAAAEAACcQAAAAEDBfA2sAIEi9USSJJ55ugfeLmU8hW5MqRPpTCASEF1DStHK3Ba6ItdQKaXvItSMmqQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ec6e86f-59ce-4a26-9685-62874f1d0fa8", "AQAAAAEAACcQAAAAEADs1WvJmKW7p+beoAvDOJBcnA+qTl0WxhASXmwkeUbMUDrUFu/7rSW0msHBHIA7dw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2236fb69-93f4-49b8-a1a1-9bd9b4cdbf77", "AQAAAAEAACcQAAAAEPlrq+Sg3Ev35Wk3Upyx2VzjJIwjj8BQL5zCz0yuEjomNdjfmS4M2E6oURz3OQOHUA==" });

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
                columns: new[] { "DateCreated", "OriginalPrice", "Stock" },
                values: new object[] { new DateTime(2022, 4, 7, 13, 39, 1, 889, DateTimeKind.Local).AddTicks(5832), 100000m, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b88d2fe1-9662-4cc2-8436-f67e1595c182", "AQAAAAEAACcQAAAAECHKNGqRgoIaoqDHXH7eW19FSSpMzgo8EXpT/CH8RR5If+ojnwDX/rMZIKURvY9mFQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "444793ea-b28f-4eeb-ba40-3468544f4229", "AQAAAAEAACcQAAAAEPDoGCJNFsRuL0NWQbxHy0sQaOsZ/C4pUiwae/pCwQ6Dgw3RgRG+XGgn8sP38wO+ZQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc934daf-a231-4f47-a7eb-bd0ec72767eb", "AQAAAAEAACcQAAAAEI9lwle7ltKx/0WnkmxCvCFvCqC78XaOvbNtQI/yT8eOb27xrl47OY6y8Z3SAR9Smg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f5c7a40-ebee-45da-922c-1d6af603a010", "AQAAAAEAACcQAAAAEF5FV7WtyrLx7a53kfAPiF4CMYFWywxPoH5I0+g6SLe9NBIDvtQgjrcHkBbD5TQv8w==" });

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
    }
}
