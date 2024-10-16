using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdBoard.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class SomeConfigurationsFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId",
                table: "Stores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StoreId1",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserEntityId",
                table: "Stores",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId1",
                table: "Products",
                column: "StoreId1");

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
    }
}
