using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modify_foriegnKey_in_StudentSubjects_tbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId1",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentId1",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "StudentSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentSubjects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "StudentId1",
                table: "StudentSubjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId1",
                table: "StudentSubjects",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId1",
                table: "StudentSubjects",
                column: "StudentId1",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
