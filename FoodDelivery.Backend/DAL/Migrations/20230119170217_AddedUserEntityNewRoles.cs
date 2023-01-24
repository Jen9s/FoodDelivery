using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDelivery.Backennd.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserEntityNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersUserId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_UsersUserId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "RoleUser",
                newName: "RoleUsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "RoleUsersUserId", "RolesRoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_RolesRoleId",
                table: "RoleUser",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_RoleUsersUserId",
                table: "RoleUser",
                column: "RoleUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_RoleUsersUserId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropIndex(
                name: "IX_RoleUser_RolesRoleId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "RoleUsersUserId",
                table: "RoleUser",
                newName: "UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "RolesRoleId", "UsersUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersUserId",
                table: "RoleUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersUserId",
                table: "RoleUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
