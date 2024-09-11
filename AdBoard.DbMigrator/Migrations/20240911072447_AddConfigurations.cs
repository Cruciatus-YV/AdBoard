using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryEntityId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryEntityId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Stores",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "StoreId1",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Feedbacks",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserEntityId",
                table: "Stores",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId1",
                table: "Products",
                column: "StoreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId1",
                table: "Products",
                column: "StoreId1",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_UserEntityId",
                table: "Stores",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_UserEntityId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_UserEntityId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Products_StoreId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Feedbacks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "CategoryEntityId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryEntityId",
                table: "Categories",
                column: "CategoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryEntityId",
                table: "Categories",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
