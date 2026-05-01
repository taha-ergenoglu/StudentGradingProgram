using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradingProgram.Migrations
{
    /// <inheritdoc />
    public partial class StudentNumber_Added_To_StudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StundenNo",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StundenNo",
                table: "Students");
        }
    }
}
