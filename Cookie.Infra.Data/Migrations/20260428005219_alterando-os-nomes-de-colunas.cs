using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookie.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterandoosnomesdecolunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Stock",
                newName: "UnitPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Stock",
                newName: "Price");
        }
    }
}
