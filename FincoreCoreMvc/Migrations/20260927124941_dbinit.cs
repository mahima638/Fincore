using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FincoreCoreMvc.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Companies_CompanyId",
                table: "Vendors");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Vendors",
                newName: "company_id");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_CompanyId",
                table: "Vendors",
                newName: "IX_Vendors_company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Companies_company_id",
                table: "Vendors",
                column: "company_id",
                principalTable: "Companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Companies_company_id",
                table: "Vendors");

            migrationBuilder.RenameColumn(
                name: "company_id",
                table: "Vendors",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendors_company_id",
                table: "Vendors",
                newName: "IX_Vendors_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Companies_CompanyId",
                table: "Vendors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
