using Microsoft.EntityFrameworkCore.Migrations;

namespace DinkAndGoDemo.Migrations
{
    public partial class EditImportDetailsaddforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetails_Categories_CategoryId",
                table: "ImportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetails_Imports_ImportId",
                table: "ImportDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ImportId",
                table: "ImportDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ImportDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetails_Categories_CategoryId",
                table: "ImportDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetails_Imports_ImportId",
                table: "ImportDetails",
                column: "ImportId",
                principalTable: "Imports",
                principalColumn: "ImportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetails_Categories_CategoryId",
                table: "ImportDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImportDetails_Imports_ImportId",
                table: "ImportDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ImportId",
                table: "ImportDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ImportDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetails_Categories_CategoryId",
                table: "ImportDetails",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ImportDetails_Imports_ImportId",
                table: "ImportDetails",
                column: "ImportId",
                principalTable: "Imports",
                principalColumn: "ImportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
