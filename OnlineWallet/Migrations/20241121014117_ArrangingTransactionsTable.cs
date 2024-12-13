﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineWallet.Migrations
{
    /// <inheritdoc />
    public partial class ArrangingTransactionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptor",
                table: "Transactions");
        }
    }
}
