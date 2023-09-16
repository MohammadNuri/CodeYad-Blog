using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeYad_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class fix_posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "Users",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "Posts",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "PostComments",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "Categories",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<int>(
                name: "Visit",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Posts",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts",
                column: "SubCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SubCategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Users",
                newName: "CreationData");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Posts",
                newName: "CreationData");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "PostComments",
                newName: "CreationData");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Categories",
                newName: "CreationData");

            migrationBuilder.AlterColumn<string>(
                name: "Visit",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400);
        }
    }
}
