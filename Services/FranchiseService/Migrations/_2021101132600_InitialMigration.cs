using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FranchiseService.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("_2021061131800_InitialMigration")]
    internal class _2021061131800_InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Franchise",
                columns: table =>
                new
                {
                    FranchiseID = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: consts =>
                {
                    consts.PrimaryKey("PK_Franchise", x => x.FranchiseID);
                });

            migrationBuilder.CreateTable(name: "Movie",
                columns: table =>
                new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FranchiseName = table.Column<string>(nullable: false)
                },
                constraints: consts =>
                {
                    consts.PrimaryKey("PK_Movie", x => x.ID);
                    consts.ForeignKey("FK_Franchise", x => x.FranchiseName, "Franchise", "Name");
                });
        }
    }
}

