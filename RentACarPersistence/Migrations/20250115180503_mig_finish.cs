using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACarPersistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_finish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        


            migrationBuilder.DropColumn(
                name: "VideoDescription",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Banners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoDescription",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

         

           
        }
    }
}
