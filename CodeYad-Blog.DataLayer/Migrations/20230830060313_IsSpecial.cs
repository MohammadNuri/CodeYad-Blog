﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeYad_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class IsSpecial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Posts");
        }
    }
}
