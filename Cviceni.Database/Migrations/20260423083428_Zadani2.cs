using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cviceni.Database.Migrations
{
    /// <inheritdoc />
    public partial class Zadani2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassEntityId",
                table: "Student",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeacherSubject",
                columns: table => new
                {
                    SubjectsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TeachersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubject", x => new { x.SubjectsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_TeacherSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassEntityId",
                table: "Student",
                column: "ClassEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_TeachersId",
                table: "TeacherSubject",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClassEntityId",
                table: "Student",
                column: "ClassEntityId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClassEntityId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "TeacherSubject");

            migrationBuilder.DropIndex(
                name: "IX_Student_ClassEntityId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ClassEntityId",
                table: "Student");
        }
    }
}
