using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentGradingProgram.Migrations
{
    /// <inheritdoc />
    public partial class ExamTableColumnsHeading_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamTableColumnsHeadings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Header1Name = table.Column<int>(type: "INTEGER", nullable: false),
                    Header2Name = table.Column<int>(type: "INTEGER", nullable: false),
                    Header3Name = table.Column<int>(type: "INTEGER", nullable: false),
                    Header4Name = table.Column<int>(type: "INTEGER", nullable: false),
                    Header5Name = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTableColumnsHeadings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTableColumnsHeadings_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamTableColumnsHeadings_ExamId",
                table: "ExamTableColumnsHeadings",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamTableColumnsHeadings");
        }
    }
}
