﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentElora.Migrations
{
    /// <inheritdoc />
    public partial class int0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Treatments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Treatments");
        }
    }
}
