using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class deleteLessonIdInStudentLessTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentsLessons_LessonId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_LessonId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Lessons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonId",
                table: "Lessons",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_StudentsLessons_LessonId",
                table: "Lessons",
                column: "LessonId",
                principalTable: "StudentsLessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
