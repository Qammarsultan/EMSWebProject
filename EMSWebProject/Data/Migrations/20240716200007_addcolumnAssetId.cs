using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnAssetId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "tblEmployeeInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "tblEmployeeInfo");
        }
    }
}
