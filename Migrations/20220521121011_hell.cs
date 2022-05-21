using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Workshop.Migrations
{
    public partial class hell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Job_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Job_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Min_Salary = table.Column<int>(type: "int", nullable: false),
                    Max_Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Job_ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Street_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postal_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Province = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Location_Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_ID = table.Column<int>(type: "int", nullable: false),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager_ID = table.Column<int>(type: "int", nullable: false),
                    Location_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_ID);
                    table.ForeignKey(
                        name: "FK_Departments_Locations_Location_ID",
                        column: x => x.Location_ID,
                        principalTable: "Locations",
                        principalColumn: "Location_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hire_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Job_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    salary = table.Column<float>(type: "real", nullable: false),
                    Commission_PCT = table.Column<float>(type: "real", nullable: false),
                    Manager_ID = table.Column<int>(type: "int", nullable: false),
                    Department_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Department_ID",
                        column: x => x.Department_ID,
                        principalTable: "Departments",
                        principalColumn: "Department_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_Job_Id",
                        column: x => x.Job_Id,
                        principalTable: "Jobs",
                        principalColumn: "Job_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Location_ID",
                table: "Departments",
                column: "Location_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department_ID",
                table: "Employees",
                column: "Department_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Job_Id",
                table: "Employees",
                column: "Job_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
