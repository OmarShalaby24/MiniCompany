using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniCompnay.Migrations
{
    public partial class initialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    EmployeeModelID = table.Column<int>(type: "int", nullable: true),
                    SkillModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeModelID",
                        column: x => x.EmployeeModelID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillModelID",
                        column: x => x.SkillModelID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "ID", "EmployeeID", "EmployeeModelID", "SkillID", "SkillModelID" },
                values: new object[] { 1, 1, null, 1, null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Email", "Name" },
                values: new object[] { 1, "John@gmail.com", "John" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "ASP" },
                    { 2, "PHP" },
                    { 3, "Database" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeModelID",
                table: "EmployeeSkills",
                column: "EmployeeModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillModelID",
                table: "EmployeeSkills",
                column: "SkillModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
