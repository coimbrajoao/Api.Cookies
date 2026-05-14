using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookie.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterandotabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Movement");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Movement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Movement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movement_StockId",
                table: "Movement",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_Stock_StockId",
                table: "Movement",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movement_Stock_StockId",
                table: "Movement");

            migrationBuilder.DropIndex(
                name: "IX_Movement_StockId",
                table: "Movement");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Movement");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Movement");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Movement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
