using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace football_draw_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeasonResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChampionsLeagueWinnerId = table.Column<int>(type: "integer", nullable: false),
                    ChampionsLeagueWinnerName = table.Column<string>(type: "text", nullable: false),
                    LaLigaWinnerId = table.Column<int>(type: "integer", nullable: false),
                    LaLigaWinnerName = table.Column<string>(type: "text", nullable: false),
                    CopaReyWinnerId = table.Column<int>(type: "integer", nullable: false),
                    CopaReyWinnerName = table.Column<string>(type: "text", nullable: false),
                    SuperCopaWinnerId = table.Column<int>(type: "integer", nullable: false),
                    SuperCopaWinnerName = table.Column<string>(type: "text", nullable: false),
                    TopScorerId = table.Column<int>(type: "integer", nullable: false),
                    TopScorerName = table.Column<string>(type: "text", nullable: false),
                    StandOutPlayerId = table.Column<int>(type: "integer", nullable: false),
                    StandOutPlayerName = table.Column<string>(type: "text", nullable: false),
                    DisappointmentPlayerId = table.Column<int>(type: "integer", nullable: false),
                    DisappointmentPlayerName = table.Column<string>(type: "text", nullable: false),
                    BallondOrId = table.Column<int>(type: "integer", nullable: false),
                    BallondOrName = table.Column<string>(type: "text", nullable: false),
                    GoldenBootId = table.Column<int>(type: "integer", nullable: false),
                    GoldenBootName = table.Column<string>(type: "text", nullable: false),
                    ZamoraWinnerId = table.Column<int>(type: "integer", nullable: false),
                    ZamoraWinnerName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPredictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_ChampionsLeagueWinnerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_ChampionsLeagueWinnerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_LaLigaWinnerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_LaLigaWinnerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_CopaReyWinnerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_CopaReyWinnerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_SuperCopaWinnerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_SuperCopaWinnerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_TopScorerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_TopScorerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_StandOutPlayerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_StandOutPlayerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_DisappointmentPlayerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_DisappointmentPlayerName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_BallondOrId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_BallondOrName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_GoldenBootId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_GoldenBootName = table.Column<string>(type: "text", nullable: false),
                    SeasonPrediction_ZamoraWinnerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonPrediction_ZamoraWinnerName = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPredictions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPredictions_UserId",
                table: "UserPredictions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeasonResults");

            migrationBuilder.DropTable(
                name: "UserPredictions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
