using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagementDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_memberShips_Members_MemberId",
                table: "memberShips");

            migrationBuilder.DropForeignKey(
                name: "FK_memberShips_Plans_PlanId",
                table: "memberShips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memberShips",
                table: "memberShips");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "memberShips",
                newName: "MemberShips");

            migrationBuilder.RenameIndex(
                name: "IX_memberShips_PlanId",
                table: "MemberShips",
                newName: "IX_MemberShips_PlanId");

            migrationBuilder.RenameColumn(
                name: "bookingDay",
                table: "MemberSessions",
                newName: "BookingDay");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberShips",
                table: "MemberShips",
                columns: new[] { "MemberId", "PlanId" });

            migrationBuilder.CreateTable(
                name: "MembersHealthRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembersHealthRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembersHealthRecord_Members_Id",
                        column: x => x.Id,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShips_Members_MemberId",
                table: "MemberShips",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShips_Plans_PlanId",
                table: "MemberShips",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberShips_Members_MemberId",
                table: "MemberShips");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberShips_Plans_PlanId",
                table: "MemberShips");

            migrationBuilder.DropTable(
                name: "MembersHealthRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberShips",
                table: "MemberShips");

            migrationBuilder.RenameTable(
                name: "MemberShips",
                newName: "memberShips");

            migrationBuilder.RenameIndex(
                name: "IX_MemberShips_PlanId",
                table: "memberShips",
                newName: "IX_memberShips_PlanId");

            migrationBuilder.RenameColumn(
                name: "BookingDay",
                table: "MemberSessions",
                newName: "bookingDay");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_memberShips",
                table: "memberShips",
                columns: new[] { "MemberId", "PlanId" });

            migrationBuilder.AddForeignKey(
                name: "FK_memberShips_Members_MemberId",
                table: "memberShips",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_memberShips_Plans_PlanId",
                table: "memberShips",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
