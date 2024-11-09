using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.DAL.Data.Migrations
{
    public partial class StoreItemIDConstriant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStores",
                table: "ItemStores");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemStores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemStores",
                table: "ItemStores",
                columns: new[] { "ItemId", "StoreId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemStores",
                table: "ItemStores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemStores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemStores",
                table: "ItemStores",
                columns: new[] { "ItemId", "StoreId" });
        }
    }
}
