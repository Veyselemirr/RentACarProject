using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarPersistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_feature_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "CarFeatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_CarID",
                table: "CarFeatures",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Cars_CarID",
                table: "CarFeatures",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Cars_CarID",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_CarID",
                table: "CarFeatures");

            migrationBuilder.AlterColumn<string>(
                name: "CarID",
                table: "CarFeatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

        
        }
    }
}
