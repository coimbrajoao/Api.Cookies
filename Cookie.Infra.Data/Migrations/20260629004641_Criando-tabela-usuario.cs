using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Cookie.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Criandotabelausuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movement_Movement_idMaster",
                table: "Movement");

            migrationBuilder.RenameColumn(
                name: "idMaster",
                table: "Movement",
                newName: "IdMaster");

            migrationBuilder.RenameIndex(
                name: "IX_Movement_idMaster",
                table: "Movement",
                newName: "IX_Movement_IdMaster");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "IdMaster",
                table: "Movement",
                newName: "idMaster");

            migrationBuilder.RenameIndex(
                name: "IX_Movement_IdMaster",
                table: "Movement",
                newName: "IX_Movement_idMaster");

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_Movement_idMaster",
                table: "Movement",
                column: "idMaster",
                principalTable: "Movement",
                principalColumn: "Id");
        }
    }
}
