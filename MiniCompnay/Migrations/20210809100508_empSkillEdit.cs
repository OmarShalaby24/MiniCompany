using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniCompnay.Migrations
{
    public partial class empSkillEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeModelEmployeeSkillModel");

            migrationBuilder.DropTable(
                name: "EmployeeSkillModelSkillModel");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesID",
                table: "EmployeeSkills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillsID",
                table: "EmployeeSkills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeesID",
                table: "EmployeeSkills",
                column: "EmployeesID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillsID",
                table: "EmployeeSkills",
                column: "SkillsID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Employees_EmployeesID",
                table: "EmployeeSkills",
                column: "EmployeesID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Skills_SkillsID",
                table: "EmployeeSkills",
                column: "SkillsID",
                principalTable: "Skills",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Employees_EmployeesID",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Skills_SkillsID",
                table: "EmployeeSkills");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_EmployeesID",
                table: "EmployeeSkills");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_SkillsID",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "EmployeesID",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "SkillsID",
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
    }
}
