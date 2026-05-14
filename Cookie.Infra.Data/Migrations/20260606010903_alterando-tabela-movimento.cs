using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookie.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterandotabelamovimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMaster",
                table: "Movement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movement_IdMaster",
                table: "Movement",
                column: "IdMaster");

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_Movement_IdMaster",
                table: "Movement",
                column: "IdMaster",
                principalTable: "Movement",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movement_Movement_IdMaster",
                table: "Movement");

            migrationBuilder.DropIndex(
                name: "IX_Movement_IdMaster",
                table: "Movement");

            migrationBuilder.DropColumn(
                name: "IdMaster",
                table: "Movement");
        }
    }
}
