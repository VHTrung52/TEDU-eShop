using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddLanguageIdToSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "Slides",
                unicode: false,
                maxLength: 5,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Languages_LanguageId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Slides");
        }
    }
}
