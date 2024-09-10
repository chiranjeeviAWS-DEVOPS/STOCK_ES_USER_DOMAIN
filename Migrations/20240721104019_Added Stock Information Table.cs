using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApplication_UserDomain.Migrations
{
    /// <inheritdoc />
    public partial class AddedStockInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockInfo",
                columns: table => new
                {
                    StockID = table.Column<string>(type: "text", nullable: false),
                    StockName = table.Column<string>(type: "text", nullable: true),
                    StockCategory = table.Column<string>(type: "text", nullable: true),
                    OutstandingShares = table.Column<long>(type: "bigint", nullable: false),
                    WatchList = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockInfo", x => x.StockID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockInfo");
        }
    }
}
