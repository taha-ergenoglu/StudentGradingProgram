using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradingProgram.Migrations
{
    /// <inheritdoc />
    public partial class Tarih_column_was_changed_to_ExamDate_from_Exam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tarih",
                table: "Exams",
                newName: "ExamDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExamDate",
                table: "Exams",
                newName: "Tarih");
        }
    }
}
