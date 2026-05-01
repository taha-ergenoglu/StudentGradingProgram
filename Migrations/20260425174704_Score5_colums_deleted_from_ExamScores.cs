using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradingProgram.Migrations
{
    /// <inheritdoc />
    public partial class Score5_colums_deleted_from_ExamScores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score5",
                table: "ExamScores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Score5",
                table: "ExamScores",
                type: "TEXT",
                nullable: true);
        }
    }
}
