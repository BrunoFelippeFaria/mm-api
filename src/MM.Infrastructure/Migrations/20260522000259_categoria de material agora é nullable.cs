using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class categoriadematerialagoraénullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategories_CategoryId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Materials",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialCategories_CategoryId",
                table: "Materials",
                column: "CategoryId",
                principalTable: "MaterialCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategories_CategoryId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Materials",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialCategories_CategoryId",
                table: "Materials",
                column: "CategoryId",
                principalTable: "MaterialCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
