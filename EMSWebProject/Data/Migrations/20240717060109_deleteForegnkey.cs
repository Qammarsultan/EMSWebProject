using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSWebProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteForegnkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployeeAssets_tblAssets_assetsId",
                table: "tblEmployeeAssets");

            migrationBuilder.DropIndex(
                name: "IX_tblEmployeeAssets_assetsId",
                table: "tblEmployeeAssets");

            migrationBuilder.DropColumn(
                name: "assetsId",
                table: "tblEmployeeAssets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "assetsId",
                table: "tblEmployeeAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeeAssets_assetsId",
                table: "tblEmployeeAssets",
                column: "assetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployeeAssets_tblAssets_assetsId",
                table: "tblEmployeeAssets",
                column: "assetsId",
                principalTable: "tblAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
