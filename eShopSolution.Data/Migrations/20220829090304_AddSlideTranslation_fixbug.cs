using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddSlideTranslation_fixbug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideTranslation_Languages_LanguageId",
                table: "SlideTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_SlideTranslation_Slides_SlideId",
                table: "SlideTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideTranslation",
                table: "SlideTranslation");

            migrationBuilder.RenameTable(
                name: "SlideTranslation",
                newName: "SlideTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_SlideTranslation_SlideId",
                table: "SlideTranslations",
                newName: "IX_SlideTranslations_SlideId");

            migrationBuilder.RenameIndex(
                name: "IX_SlideTranslation_LanguageId",
                table: "SlideTranslations",
                newName: "IX_SlideTranslations_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SlideTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SlideTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "SlideTranslations",
                unicode: false,
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "SlideTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SlideTranslations",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideTranslations",
                table: "SlideTranslations",
                column: "Id");     

            migrationBuilder.AddForeignKey(
                name: "FK_SlideTranslations_Languages_LanguageId",
                table: "SlideTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SlideTranslations_Slides_SlideId",
                table: "SlideTranslations",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlideTranslations_Languages_LanguageId",
                table: "SlideTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_SlideTranslations_Slides_SlideId",
                table: "SlideTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlideTranslations",
                table: "SlideTranslations");

            migrationBuilder.RenameTable(
                name: "SlideTranslations",
                newName: "SlideTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_SlideTranslations_SlideId",
                table: "SlideTranslation",
                newName: "IX_SlideTranslation_SlideId");

            migrationBuilder.RenameIndex(
                name: "IX_SlideTranslations_LanguageId",
                table: "SlideTranslation",
                newName: "IX_SlideTranslation_LanguageId");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SlideTranslation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SlideTranslation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageId",
                table: "SlideTranslation",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "SlideTranslation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SlideTranslation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlideTranslation",
                table: "SlideTranslation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SlideTranslation_Languages_LanguageId",
                table: "SlideTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SlideTranslation_Slides_SlideId",
                table: "SlideTranslation",
                column: "SlideId",
                principalTable: "Slides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
