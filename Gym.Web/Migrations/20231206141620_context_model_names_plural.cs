using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.Web.Migrations
{
    /// <inheritdoc />
    public partial class context_model_names_plural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClasses_GymClass_GymClassId",
                table: "ApplicationUserGymClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymClass",
                table: "GymClass");

            migrationBuilder.RenameTable(
                name: "GymClass",
                newName: "GymClasses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymClasses",
                table: "GymClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClasses_GymClasses_GymClassId",
                table: "ApplicationUserGymClasses",
                column: "GymClassId",
                principalTable: "GymClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGymClasses_GymClasses_GymClassId",
                table: "ApplicationUserGymClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymClasses",
                table: "GymClasses");

            migrationBuilder.RenameTable(
                name: "GymClasses",
                newName: "GymClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymClass",
                table: "GymClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGymClasses_GymClass_GymClassId",
                table: "ApplicationUserGymClasses",
                column: "GymClassId",
                principalTable: "GymClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
