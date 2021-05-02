using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MovieCast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movieCrews_Crew_CrewId",
                table: "movieCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_movieCrews_Movies_MovieId",
                table: "movieCrews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movieCrews",
                table: "movieCrews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crew",
                table: "Crew");

            migrationBuilder.RenameTable(
                name: "movieCrews",
                newName: "MovieCrews");

            migrationBuilder.RenameTable(
                name: "Crew",
                newName: "Crews");

            migrationBuilder.RenameIndex(
                name: "IX_movieCrews_CrewId",
                table: "MovieCrews",
                newName: "IX_MovieCrews_CrewId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePath",
                table: "Crews",
                type: "nvarchar(2084)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2084)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCrews",
                table: "MovieCrews",
                columns: new[] { "MovieId", "CrewId", "Department", "Job" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crews",
                table: "Crews",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TmdbUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(2084)", maxLength: 2084, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCasts",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CastId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCasts", x => new { x.CastId, x.MovieId, x.Character });
                    table.ForeignKey(
                        name: "FK_MovieCasts_Casts_CastId",
                        column: x => x.CastId,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCasts_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCasts_MovieId",
                table: "MovieCasts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrews_Crews_CrewId",
                table: "MovieCrews",
                column: "CrewId",
                principalTable: "Crews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrews_Movies_MovieId",
                table: "MovieCrews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrews_Crews_CrewId",
                table: "MovieCrews");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrews_Movies_MovieId",
                table: "MovieCrews");

            migrationBuilder.DropTable(
                name: "MovieCasts");

            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCrews",
                table: "MovieCrews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crews",
                table: "Crews");

            migrationBuilder.RenameTable(
                name: "MovieCrews",
                newName: "movieCrews");

            migrationBuilder.RenameTable(
                name: "Crews",
                newName: "Crew");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCrews_CrewId",
                table: "movieCrews",
                newName: "IX_movieCrews_CrewId");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePath",
                table: "Crew",
                type: "nvarchar(2084)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2084)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_movieCrews",
                table: "movieCrews",
                columns: new[] { "MovieId", "CrewId", "Department", "Job" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crew",
                table: "Crew",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movieCrews_Crew_CrewId",
                table: "movieCrews",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movieCrews_Movies_MovieId",
                table: "movieCrews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
