using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReverseEnginereeing.Migrations
{
    public partial class EditIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser<string>",
                table: "IdentityUser<string>");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "IdentityUser<string>",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser<string>",
                table: "IdentityUser<string>",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser<string>",
                table: "IdentityUser<string>");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "IdentityUser<string>",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser<string>",
                table: "IdentityUser<string>",
                columns: new[] { "Id", "UserName" });
        }
    }
}
