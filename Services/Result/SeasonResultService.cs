
using football_draw_api.Data;
using football_draw_api.DTOs.Result;
using football_draw_api.Models.Result;
using Microsoft.EntityFrameworkCore;

namespace football_draw_api.Services.Result
{
    public class SeasonResultService
    {
        private readonly AppDbContext context;

        public SeasonResultService( AppDbContext context)
        {
            this.context = context;
        }

        public SeasonResult? GetSeasonResult()
        {
            return context.SeasonResults
            .FirstOrDefault();
        }

        public SeasonResult CreateSeasonResult(SeasonResultRequest result)
        {
            var seasonResult = new SeasonResult
                {
                ChampionsLeagueWinnerId = result.ChampionsLeagueWinnerId,
                ChampionsLeagueWinnerName = result.ChampionsLeagueWinnerName,
                LaLigaWinnerId = result.LaLigaWinnerId,
                LaLigaWinnerName = result.LaLigaWinnerName,
                CopaReyWinnerId = result.CopaReyWinnerId,
                CopaReyWinnerName = result.CopaReyWinnerName,
                SuperCopaWinnerId = result.SuperCopaWinnerId,
                SuperCopaWinnerName = result.SuperCopaWinnerName,
                TopScorerId = result.TopScorerId,
                TopScorerName = result.TopScorerName,
                StandOutPlayerId = result.StandOutPlayerId,
                StandOutPlayerName = result.StandOutPlayerName,
                DisappointmentPlayerId = result.DisappointmentPlayerId,
                DisappointmentPlayerName = result.DisappointmentPlayerName,
                BallondOrId = result.BallondOrId,
                BallondOrName = result.BallondOrName,
                GoldenBootId = result.GoldenBootId,
                GoldenBootName = result.GoldenBootName,
                ZamoraWinnerId = result.ZamoraWinnerId,
                ZamoraWinnerName = result.ZamoraWinnerName,

            };

            context.SeasonResults.Add(seasonResult);
            context.SaveChanges();

            return seasonResult;
        }

        public SeasonResult? UpdateSeasonResult(SeasonResultRequest result)
        {
            var season = context.SeasonResults.FirstOrDefault();

            if (season == null)
            {
                return null;
            }

            season.ChampionsLeagueWinnerId = result.ChampionsLeagueWinnerId;
            season.ChampionsLeagueWinnerName = result.ChampionsLeagueWinnerName;
            season.LaLigaWinnerId = result.LaLigaWinnerId;
            season.LaLigaWinnerName = result.LaLigaWinnerName;
            season.CopaReyWinnerId = result.CopaReyWinnerId;
            season.CopaReyWinnerName = result.CopaReyWinnerName;
            season.SuperCopaWinnerId = result.SuperCopaWinnerId;
            season.SuperCopaWinnerName = result.SuperCopaWinnerName;
            season.TopScorerId = result.TopScorerId;
            season.TopScorerName = result.TopScorerName;
            season.StandOutPlayerId = result.StandOutPlayerId;
            season.StandOutPlayerName = result.StandOutPlayerName;
            season.DisappointmentPlayerId = result.DisappointmentPlayerId;
            season.DisappointmentPlayerName = result.DisappointmentPlayerName;
            season.BallondOrId = result.BallondOrId;
            season.BallondOrName = result.BallondOrName;
            season.GoldenBootId = result.GoldenBootId;
            season.GoldenBootName = result.GoldenBootName;
            season.ZamoraWinnerId = result.ZamoraWinnerId;
            season.ZamoraWinnerName = result.ZamoraWinnerName;

            context.SaveChanges();

            return season;
        }
    }
}
