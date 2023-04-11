using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace INTEX2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mummies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FieldBookExcavationYear = table.Column<string>(type: "text", nullable: true),
                    FieldBookPage = table.Column<string>(type: "text", nullable: true),
                    DataExpertInitials = table.Column<string>(type: "text", nullable: true),
                    SquareNorthSouth = table.Column<string>(type: "text", nullable: true),
                    NorthSouth = table.Column<string>(type: "text", nullable: true),
                    SquareEastWest = table.Column<string>(type: "text", nullable: true),
                    EastWest = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    BurialNumber = table.Column<string>(type: "text", nullable: true),
                    WestToHead = table.Column<string>(type: "text", nullable: true),
                    WestToFeet = table.Column<string>(type: "text", nullable: true),
                    SouthToHead = table.Column<string>(type: "text", nullable: true),
                    SouthToFeet = table.Column<string>(type: "text", nullable: true),
                    Depth = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<string>(type: "text", nullable: true),
                    HeadDirection = table.Column<string>(type: "text", nullable: true),
                    Preservation = table.Column<string>(type: "text", nullable: true),
                    Wrapping = table.Column<string>(type: "text", nullable: true),
                    AdultSubadult = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    AgeAtDeath = table.Column<string>(type: "text", nullable: true),
                    HairColor = table.Column<string>(type: "text", nullable: true),
                    SamplesCollected = table.Column<string>(type: "text", nullable: true),
                    Goods = table.Column<string>(type: "text", nullable: true),
                    FaceBundles = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    BurialId = table.Column<string>(type: "text", nullable: true),
                    Photos = table.Column<string>(type: "text", nullable: true),
                    DateOfExcavation = table.Column<string>(type: "text", nullable: true),
                    ShaftNumber = table.Column<string>(type: "text", nullable: true),
                    ClusterNumber = table.Column<string>(type: "text", nullable: true),
                    BurialMaterials = table.Column<string>(type: "text", nullable: true),
                    ExcavationRecorder = table.Column<string>(type: "text", nullable: true),
                    Hair = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mummies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mummies");
        }
    }
}
