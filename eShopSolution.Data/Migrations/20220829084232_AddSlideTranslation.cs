using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddSlideTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Languages_LanguageId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides");

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Slides");

            migrationBuilder.CreateTable(
                name: "SlideTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlideId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    LanguageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlideTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlideTranslation_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlideTranslation_Slides_SlideId",
                        column: x => x.SlideId,
                        principalTable: "Slides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "60ecf1b1-55ae-4a28-b01d-9ff641d6bfd4");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "321eb9ff-a63c-4f6d-bd7d-5c0be4b866e4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0f29-f012-411a-970e-97835c440947"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bde6ee2-bffa-4607-8118-c8d23a88af15", "AQAAAAEAACcQAAAAEB+QPGDvU0+wXcoEBiZE9o+jQfDhnUhTzjaAwuipwgaXaPO2A8jJBW/aSFdBWJlB5g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a15dc7ac-d9ec-4c60-914a-17ed55d857a0", "AQAAAAEAACcQAAAAEOfBFgObApM0OpC+P/lUfZCFTGs7S5fnatbT/HUPOc5nQoeVswHKeK/65qvy75D+Dg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82258281-8b55-4450-af7c-25d072b03a6f", "AQAAAAEAACcQAAAAEGCfIYbuyhCy/RtoOYnIfasiFM52UGG47NvhlM4tuuPK9C9ZyNvfE94ctXnieWiEKg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a79ea47-d31a-4d2a-a194-6e4e611b98b9", "AQAAAAEAACcQAAAAEAnyaKrXNg4h3AGzJg1kuDt4jwebb0GQj9SOiyriWVVfiH2aEjC3+GGWcBxNag476A==" });

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
                values: new object[] { new DateTime(2022, 8, 29, 15, 42, 31, 935, DateTimeKind.Local).AddTicks(3171), 100000m, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_SlideTranslation_LanguageId",
                table: "SlideTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SlideTranslation_SlideId",
                table: "SlideTranslation",
                column: "SlideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlideTranslation");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "Slides",
                type: "varchar(5)",
                unicode: false,
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Slides",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("44ca662a-68e3-410d-85db-72c4e70e2d48"),
                column: "ConcurrencyStamp",
                value: "4daccbd1-7e08-4612-a72f-816fcb885dbc");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "4fd2ac94-9119-4f7c-8b73-2b317dc7b58b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0f29-f012-411a-970e-97835c440947"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1144b58a-e100-4705-8711-303529038922", "AQAAAAEAACcQAAAAEEOZru62jelm4BFQq8mPXZzyfXEZgZ5wkXlmRiIjZ70QmNy5TymcJx+c0V8LbjeXMQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c0e9767-4655-4df7-940d-fdc462607d46"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "539dbbb9-6a95-4961-a481-36378930b3a5", "AQAAAAEAACcQAAAAEP34zE8Z1GFdDPevjLKRBtFFF6vAqczlFfLZ0MWeGSWNKee7ZQiiHpu6mRg7FM1/8w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("7c6187f4-1973-4ece-aa42-f298219bb27d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c81847fe-4c50-466b-af54-565ebae3c995", "AQAAAAEAACcQAAAAEO3JCq2q5+LOZZMAj+Ik2fm0F2HMPqVJ6rCcT3wOwDNa4zQEwr7uvi6HTboyDCLPMw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2dea42f-162e-4ce9-a2d2-f3bfb44af01d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17289a0f-dc28-4450-9679-2818a6f58991", "AQAAAAEAACcQAAAAECmsiApspv9rBA8cHwNT1zkd2OoNaLAArZjdlmmUykgXEi3z2SrYsz0bxDc0+w+wyg==" });

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
                values: new object[] { new DateTime(2022, 8, 27, 23, 33, 20, 689, DateTimeKind.Local).AddTicks(4764), 100000m, 10 });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "ImagePath", "LanguageId", "Name", "SortOrder", "Status", "Url" },
                values: new object[,]
                {
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/1.png", null, "Second Thumbnail label", 1, 1, "#" },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/2.png", null, "Second Thumbnail label", 2, 1, "#" },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/3.png", null, "Second Thumbnail label", 3, 1, "#" },
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/4.png", null, "Second Thumbnail label", 4, 1, "#" },
                    { 5, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/5.png", null, "Second Thumbnail label", 5, 1, "#" },
                    { 6, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", "/themes/images/carousel/6.png", null, "Second Thumbnail label", 6, 1, "#" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Languages_LanguageId",
                table: "Slides",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
