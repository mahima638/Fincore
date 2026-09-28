using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoreCoreMvc.Migrations
{
    /// <inheritdoc />
    public partial class FixUserSelfReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.permission_id);
                    table.ForeignKey(
                        name: "FK_permission_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    role_id1 = table.Column<int>(type: "int", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_user_role_role_id1",
                        column: x => x.role_id1,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_code = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.country_id);
                    table.ForeignKey(
                        name: "FK_Country_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.department_id);
                    table.ForeignKey(
                        name: "FK_department_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.state_id);
                    table.ForeignKey(
                        name: "FK_State_Country_country_id",
                        column: x => x.country_id,
                        principalTable: "Country",
                        principalColumn: "country_id");
                    table.ForeignKey(
                        name: "FK_State_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state_id = table.Column<int>(type: "int", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.city_id);
                    table.ForeignKey(
                        name: "FK_City_State_state_id",
                        column: x => x.state_id,
                        principalTable: "State",
                        principalColumn: "state_id");
                    table.ForeignKey(
                        name: "FK_City_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    company_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gstin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    country_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.company_id);
                    table.ForeignKey(
                        name: "FK_company_City_city_id",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                    table.ForeignKey(
                        name: "FK_company_Country_country_id",
                        column: x => x.country_id,
                        principalTable: "Country",
                        principalColumn: "country_id");
                    table.ForeignKey(
                        name: "FK_company_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_id1 = table.Column<int>(type: "int", nullable: false),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    department_id1 = table.Column<int>(type: "int", nullable: false),
                    designation_id = table.Column<int>(type: "int", nullable: false),
                    designationrole_id = table.Column<int>(type: "int", nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false),
                    company_id1 = table.Column<int>(type: "int", nullable: false),
                    joining_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_active = table.Column<byte>(type: "tinyint", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    ReportingManager = table.Column<int>(name: "Reporting Manager", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employee_company_company_id1",
                        column: x => x.company_id1,
                        principalTable: "company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_department_department_id1",
                        column: x => x.department_id1,
                        principalTable: "department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_employee_Reporting Manager",
                        column: x => x.ReportingManager,
                        principalTable: "employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_employee_role_designationrole_id",
                        column: x => x.designationrole_id,
                        principalTable: "role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_user_user_id1",
                        column: x => x.user_id1,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_state_id",
                table: "City",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_City_user_id",
                table: "City",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_city_id",
                table: "company",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_country_id",
                table: "company",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_company_user_id",
                table: "company",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Country_user_id",
                table: "Country",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_user_id",
                table: "department",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_company_id1",
                table: "employee",
                column: "company_id1");

            migrationBuilder.CreateIndex(
                name: "IX_employee_department_id1",
                table: "employee",
                column: "department_id1");

            migrationBuilder.CreateIndex(
                name: "IX_employee_designationrole_id",
                table: "employee",
                column: "designationrole_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_Reporting Manager",
                table: "employee",
                column: "Reporting Manager");

            migrationBuilder.CreateIndex(
                name: "IX_employee_user_id1",
                table: "employee",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_permission_role_id",
                table: "permission",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_State_country_id",
                table: "State",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_State_user_id",
                table: "State",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id1",
                table: "user",
                column: "role_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
