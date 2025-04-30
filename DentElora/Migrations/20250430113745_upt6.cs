using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentElora.Migrations
{
    /// <inheritdoc />
    public partial class upt6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "İcon",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "İcon",
                table: "Treatments");
        }
    }
}
