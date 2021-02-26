using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemsDbSet",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nameOfItem = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    imageName = table.Column<string>(type: "TEXT", nullable: true),
                    cost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemsDbSet", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ordersDbSet",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nameOfBuyer = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    timeOfOrder = table.Column<string>(type: "TEXT", nullable: false),
                    boughtItemid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDbSet", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_ordersDbSet_itemsDbSet_boughtItemid",
                        column: x => x.boughtItemid,
                        principalTable: "itemsDbSet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordersDbSet_boughtItemid",
                table: "ordersDbSet",
                column: "boughtItemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordersDbSet");

            migrationBuilder.DropTable(
                name: "itemsDbSet");
        }
    }
}
