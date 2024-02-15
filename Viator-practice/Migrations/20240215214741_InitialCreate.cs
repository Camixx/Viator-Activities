using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viator_practice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    destinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sortOrder = table.Column<int>(type: "int", nullable: false),
                    selectable = table.Column<bool>(type: "bit", nullable: false),
                    destinationUrlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    defaultCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lookupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: false),
                    timeZone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iataCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destinationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destinationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<float>(type: "real", nullable: false),
                    longitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.destinationId);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    productCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pricing = table.Column<float>(type: "real", nullable: false),
                    productUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destinationId = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.productCode);
                    table.ForeignKey(
                        name: "FK_Activities_Destinations_destinationId",
                        column: x => x.destinationId,
                        principalTable: "Destinations",
                        principalColumn: "destinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_destinationId",
                table: "Activities",
                column: "destinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
