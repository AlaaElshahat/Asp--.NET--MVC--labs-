using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationlab09.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationshipcoursesanddepts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeptCourses",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptCourses", x => new { x.DeptId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_DeptCourses_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeptCourses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeptCourses_CoursesId",
                table: "DeptCourses",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_DeptCourses_DepartmentId",
                table: "DeptCourses",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeptCourses");
        }
    }
}
