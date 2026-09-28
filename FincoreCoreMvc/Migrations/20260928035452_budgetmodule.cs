using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoreCoreMvc.Migrations
{
    /// <inheritdoc />
    public partial class budgetmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<byte>(type: "tinyint", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.permission_id);
                    table.ForeignKey(
                        name: "FK_Permissions_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<byte>(type: "tinyint", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_User_Role_role_id",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountMasters",
                columns: table => new
                {
                    Account_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Modified_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMasters", x => x.Account_Id);
                    table.ForeignKey(
                        name: "FK_AccountMasters_User_Created_By",
                        column: x => x.Created_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_AccountMasters_User_Modified_By",
                        column: x => x.Modified_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetsCategories",
                columns: table => new
                {
                    Budget_Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Modified_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetsCategories", x => x.Budget_Category_Id);
                    table.ForeignKey(
                        name: "FK_BudgetsCategories_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetsCategories_User_Created_By",
                        column: x => x.Created_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_BudgetsCategories_User_Modified_By",
                        column: x => x.Modified_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Budget_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget_Category_Id = table.Column<int>(type: "int", nullable: false),
                    Financial_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Budget_Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Is_Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Modified_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Budget_Id);
                    table.ForeignKey(
                        name: "FK_Budgets_BudgetsCategories_Budget_Category_Id",
                        column: x => x.Budget_Category_Id,
                        principalTable: "BudgetsCategories",
                        principalColumn: "Budget_Category_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budgets_User_Created_By",
                        column: x => x.Created_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_Budgets_User_Modified_By",
                        column: x => x.Modified_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "BudgetLines",
                columns: table => new
                {
                    Budget_Line_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget_Id = table.Column<int>(type: "int", nullable: false),
                    Budget_Category_Id = table.Column<int>(type: "int", nullable: false),
                    Allocated_Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Utilized_Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Is_Active = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    BudgetsCategoriesBudget_Category_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetLines", x => x.Budget_Line_Id);
                    table.ForeignKey(
                        name: "FK_BudgetLines_BudgetsCategories_Budget_Category_Id",
                        column: x => x.Budget_Category_Id,
                        principalTable: "BudgetsCategories",
                        principalColumn: "Budget_Category_Id");
                    table.ForeignKey(
                        name: "FK_BudgetLines_BudgetsCategories_BudgetsCategoriesBudget_Category_Id",
                        column: x => x.BudgetsCategoriesBudget_Category_Id,
                        principalTable: "BudgetsCategories",
                        principalColumn: "Budget_Category_Id");
                    table.ForeignKey(
                        name: "FK_BudgetLines_Budgets_Budget_Id",
                        column: x => x.Budget_Id,
                        principalTable: "Budgets",
                        principalColumn: "Budget_Id");
                    table.ForeignKey(
                        name: "FK_BudgetLines_User_Created_By",
                        column: x => x.Created_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_BudgetLines_User_Modified_By",
                        column: x => x.Modified_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "CapexRequests",
                columns: table => new
                {
                    Capex_Request_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: false),
                    Budget_Line_Id = table.Column<int>(type: "int", nullable: false),
                    Requested_By = table.Column<int>(type: "int", nullable: false),
                    Approval_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved_By = table.Column<int>(type: "int", nullable: true),
                    Approved_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapexRequests", x => x.Capex_Request_Id);
                    table.ForeignKey(
                        name: "FK_CapexRequests_BudgetLines_Budget_Line_Id",
                        column: x => x.Budget_Line_Id,
                        principalTable: "BudgetLines",
                        principalColumn: "Budget_Line_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapexRequests_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapexRequests_User_Approved_By",
                        column: x => x.Approved_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_CapexRequests_User_Requested_By",
                        column: x => x.Requested_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "OpexRequests",
                columns: table => new
                {
                    Opex_Request_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget_Line_Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Requested_By = table.Column<int>(type: "int", nullable: false),
                    Approval_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved_By = table.Column<int>(type: "int", nullable: true),
                    Approved_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpexRequests", x => x.Opex_Request_Id);
                    table.ForeignKey(
                        name: "FK_OpexRequests_BudgetLines_Budget_Line_Id",
                        column: x => x.Budget_Line_Id,
                        principalTable: "BudgetLines",
                        principalColumn: "Budget_Line_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpexRequests_User_Approved_By",
                        column: x => x.Approved_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_OpexRequests_User_Requested_By",
                        column: x => x.Requested_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "ExpenseClaims",
                columns: table => new
                {
                    Expense_Claim_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Claim_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opex_Request_Id = table.Column<int>(type: "int", nullable: false),
                    Expense_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expense_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expense_Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Claim_By = table.Column<int>(type: "int", nullable: false),
                    Approval_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Approved_By = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseClaims", x => x.Expense_Claim_Id);
                    table.ForeignKey(
                        name: "FK_ExpenseClaims_OpexRequests_Opex_Request_Id",
                        column: x => x.Opex_Request_Id,
                        principalTable: "OpexRequests",
                        principalColumn: "Opex_Request_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseClaims_User_Approved_By",
                        column: x => x.Approved_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_ExpenseClaims_User_Claim_By",
                        column: x => x.Claim_By,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountMasters_Created_By",
                table: "AccountMasters",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_AccountMasters_Modified_By",
                table: "AccountMasters",
                column: "Modified_By");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Budget_Category_Id",
                table: "BudgetLines",
                column: "Budget_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Budget_Id",
                table: "BudgetLines",
                column: "Budget_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_BudgetsCategoriesBudget_Category_Id",
                table: "BudgetLines",
                column: "BudgetsCategoriesBudget_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Created_By",
                table: "BudgetLines",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetLines_Modified_By",
                table: "BudgetLines",
                column: "Modified_By");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_Budget_Category_Id",
                table: "Budgets",
                column: "Budget_Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_Created_By",
                table: "Budgets",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_Modified_By",
                table: "Budgets",
                column: "Modified_By");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetsCategories_Created_By",
                table: "BudgetsCategories",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetsCategories_Department_Id",
                table: "BudgetsCategories",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetsCategories_Modified_By",
                table: "BudgetsCategories",
                column: "Modified_By");

            migrationBuilder.CreateIndex(
                name: "IX_CapexRequests_Approved_By",
                table: "CapexRequests",
                column: "Approved_By");

            migrationBuilder.CreateIndex(
                name: "IX_CapexRequests_Budget_Line_Id",
                table: "CapexRequests",
                column: "Budget_Line_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CapexRequests_Department_Id",
                table: "CapexRequests",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CapexRequests_Requested_By",
                table: "CapexRequests",
                column: "Requested_By");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseClaims_Approved_By",
                table: "ExpenseClaims",
                column: "Approved_By");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseClaims_Claim_By",
                table: "ExpenseClaims",
                column: "Claim_By");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseClaims_Opex_Request_Id",
                table: "ExpenseClaims",
                column: "Opex_Request_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OpexRequests_Approved_By",
                table: "OpexRequests",
                column: "Approved_By");

            migrationBuilder.CreateIndex(
                name: "IX_OpexRequests_Budget_Line_Id",
                table: "OpexRequests",
                column: "Budget_Line_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OpexRequests_Requested_By",
                table: "OpexRequests",
                column: "Requested_By");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_role_id",
                table: "Permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountMasters");

            migrationBuilder.DropTable(
                name: "CapexRequests");

            migrationBuilder.DropTable(
                name: "ExpenseClaims");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "OpexRequests");

            migrationBuilder.DropTable(
                name: "BudgetLines");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "BudgetsCategories");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
