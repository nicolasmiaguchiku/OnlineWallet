using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineWallet.Migrations
{
    /// <inheritdoc />
    public partial class ArrangingWalletsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Wallets",
                newName: "Investment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Investment",
                table: "Wallets",
                newName: "Balance");
        }
    }
}
