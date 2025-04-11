using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseEnrollmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitorIdentityUserLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Visitors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_IdentityUserId",
                table: "Visitors",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_AspNetUsers_IdentityUserId",
                table: "Visitors",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_AspNetUsers_IdentityUserId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_IdentityUserId",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Visitors");
        }
    }
}
