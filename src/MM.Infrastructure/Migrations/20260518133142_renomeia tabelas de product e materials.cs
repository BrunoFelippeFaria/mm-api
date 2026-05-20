using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renomeiatabelasdeproductematerials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitItem_Product_KitId",
                table: "KitItem");

            migrationBuilder.DropForeignKey(
                name: "FK_KitItem_Product_ProductId",
                table: "KitItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaterialCategory_CategoryId",
                table: "Material");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipe_Material_MaterialId",
                table: "ProductRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipe_Product_ProductId",
                table: "ProductRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCategory",
                table: "MaterialCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "MaterialCategory",
                newName: "MaterialCategories");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "Materials");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_CategoryId",
                table: "Materials",
                newName: "IX_Materials_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCategories",
                table: "MaterialCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KitItem_Products_KitId",
                table: "KitItem",
                column: "KitId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitItem_Products_ProductId",
                table: "KitItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialCategories_CategoryId",
                table: "Materials",
                column: "CategoryId",
                principalTable: "MaterialCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipe_Materials_MaterialId",
                table: "ProductRecipe",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipe_Products_ProductId",
                table: "ProductRecipe",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitItem_Products_KitId",
                table: "KitItem");

            migrationBuilder.DropForeignKey(
                name: "FK_KitItem_Products_ProductId",
                table: "KitItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialCategories_CategoryId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipe_Materials_MaterialId",
                table: "ProductRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecipe_Products_ProductId",
                table: "ProductRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialCategories",
                table: "MaterialCategories");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "Material");

            migrationBuilder.RenameTable(
                name: "MaterialCategories",
                newName: "MaterialCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_CategoryId",
                table: "Material",
                newName: "IX_Material_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialCategory",
                table: "MaterialCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KitItem_Product_KitId",
                table: "KitItem",
                column: "KitId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitItem_Product_ProductId",
                table: "KitItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaterialCategory_CategoryId",
                table: "Material",
                column: "CategoryId",
                principalTable: "MaterialCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipe_Material_MaterialId",
                table: "ProductRecipe",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecipe_Product_ProductId",
                table: "ProductRecipe",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}