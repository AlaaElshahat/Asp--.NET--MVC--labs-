using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationlab09.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursesDepartment",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    deptsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesDepartment", x => new { x.CoursesId, x.deptsId });
                    table.ForeignKey(
                        name: "FK_CoursesDepartment_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesDepartment_Departments_deptsId",
                        column: x => x.deptsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesDepartment_deptsId",
                table: "CoursesDepartment",
                column: "deptsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesDepartment");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
