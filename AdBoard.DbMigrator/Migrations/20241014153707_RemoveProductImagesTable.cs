using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdBoard.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.DropTable(
            //    name: "ProductImages");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Files_Products_ProductId",
            //    table: "Files");

            //migrationBuilder.DropIndex(
            //    name: "IX_Files_ProductId",
            //    table: "Files");

            //migrationBuilder.DropColumn(
            //    name: "ProductId",
            //    table: "Files");

            migrationBuilder.AddColumn<long>(
                name: "ProductEntityId",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProductEntityId",
                table: "Files",
                column: "ProductEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductEntityId",
                table: "Files",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductEntityId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ProductEntityId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "Files");

            //migrationBuilder.AddColumn<long>(
            //    name: "ProductId",
            //    table: "Files",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Files_ProductId",
            //    table: "Files",
            //    column: "ProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Files_Products_ProductId",
            //    table: "Files",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

        }
    }
}
