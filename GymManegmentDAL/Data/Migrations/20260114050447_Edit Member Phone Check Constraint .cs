using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagementDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditMemberPhoneCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "GymUserValidPhone1",
                table: "Trainers");

            migrationBuilder.DropCheckConstraint(
                name: "GymUserValidPhone",
                table: "Members");

            migrationBuilder.AddCheckConstraint(
                name: "GymUserValidPhone1",
                table: "Trainers",
                sql: " Phone Like    '^01\\d{9}$'");

            migrationBuilder.AddCheckConstraint(
                name: "GymUserValidPhone",
                table: "Members",
                sql: " Phone Like    '^01\\d{9}$'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "GymUserValidPhone1",
                table: "Trainers");

            migrationBuilder.DropCheckConstraint(
                name: "GymUserValidPhone",
                table: "Members");

            migrationBuilder.AddCheckConstraint(
                name: "GymUserValidPhone1",
                table: "Trainers",
                sql: " Phone Like    '01[1205][0-9]{8}'");

            migrationBuilder.AddCheckConstraint(
                name: "GymUserValidPhone",
                table: "Members",
                sql: " Phone Like    '01[1205][0-9]{8}'");
        }
    }
}
