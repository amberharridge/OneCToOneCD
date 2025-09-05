using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneCToOneCD.Migrations
{
    /// <inheritdoc />
    public partial class _050925_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "CoursesDetails",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    DurationInWeeks = table.Column<int>(type: "int", nullable: false),
                    CourseCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesDetails", x => x.CourseCode);
                    table.ForeignKey(
                        name: "FK_CoursesDetails_Courses_CourseCode1",
                        column: x => x.CourseCode1,
                        principalTable: "Courses",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesDetails_CourseCode1",
                table: "CoursesDetails",
                column: "CourseCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CoursesDetails_CourseCode",
                table: "Courses",
                column: "CourseCode",
                principalTable: "CoursesDetails",
                principalColumn: "CourseCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CoursesDetails_CourseCode",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CoursesDetails");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
