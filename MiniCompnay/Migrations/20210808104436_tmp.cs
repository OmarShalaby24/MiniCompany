using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniCompnay.Migrations
{
    public partial class tmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Employees_EmployeeModelID",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Skills_SkillModelID",
                table: "EmployeeSkills");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_EmployeeModelID",
                table: "EmployeeSkills");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_SkillModelID",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "EmployeeModelID",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "SkillModelID",
                table: "EmployeeSkills");

            migrationBuilder.CreateTable(
                name: "EmployeeModelEmployeeSkillModel",
                columns: table => new
                {
                    EmployeeSkillsID = table.Column<int>(type: "int", nullable: false),
                    EmployeesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModelEmployeeSkillModel", x => new { x.EmployeeSkillsID, x.EmployeesID });
                    table.ForeignKey(
                        name: "FK_EmployeeModelEmployeeSkillModel_Employees_EmployeesID",
                        column: x => x.EmployeesID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeModelEmployeeSkillModel_EmployeeSkills_EmployeeSkillsID",
                        column: x => x.EmployeeSkillsID,
                        principalTable: "EmployeeSkills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkillModelSkillModel",
                columns: table => new
                {
                    EmployeeSkillsID = table.Column<int>(type: "int", nullable: false),
                    SkillsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkillModelSkillModel", x => new { x.EmployeeSkillsID, x.SkillsID });
                    table.ForeignKey(
                        name: "FK_EmployeeSkillModelSkillModel_EmployeeSkills_EmployeeSkillsID",
                        column: x => x.EmployeeSkillsID,
                        principalTable: "EmployeeSkills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkillModelSkillModel_Skills_SkillsID",
                        column: x => x.SkillsID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeModelEmployeeSkillModel_EmployeesID",
                table: "EmployeeModelEmployeeSkillModel",
                column: "EmployeesID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkillModelSkillModel_SkillsID",
                table: "EmployeeSkillModelSkillModel",
                column: "SkillsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeModelEmployeeSkillModel");

            migrationBuilder.DropTable(
                name: "EmployeeSkillModelSkillModel");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModelID",
                table: "EmployeeSkills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillModelID",
                table: "EmployeeSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeModelID",
                table: "EmployeeSkills",
                column: "EmployeeModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillModelID",
                table: "EmployeeSkills",
                column: "SkillModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Employees_EmployeeModelID",
                table: "EmployeeSkills",
                column: "EmployeeModelID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Skills_SkillModelID",
                table: "EmployeeSkills",
                column: "SkillModelID",
                principalTable: "Skills",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
