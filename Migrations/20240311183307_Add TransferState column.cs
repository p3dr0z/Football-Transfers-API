using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTransfersAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTransferStatecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransferState",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferState",
                table: "Transfers");
        }
    }
}
