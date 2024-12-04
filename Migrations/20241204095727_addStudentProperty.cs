using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.net_core_Mvc.Migrations
{
    /// <inheritdoc />
    public partial class addStudentProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Students");
        }
    }
}
