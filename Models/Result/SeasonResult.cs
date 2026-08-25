using football_draw_api.Models.Predictions;

namespace football_draw_api.Models.Result
{
    public class SeasonResult
    {
        public int Id { get; set; }
        public int? ChampionsLeagueWinnerId { get; set; }
        public string? ChampionsLeagueWinnerName { get; set; } 

        public int? LaLigaWinnerId { get; set; }
        public string? LaLigaWinnerName { get; set; } 

        public int? CopaReyWinnerId { get; set; }
        public string? CopaReyWinnerName { get; set; } 

        public int? SuperCopaWinnerId { get; set; }
        public string? SuperCopaWinnerName { get; set; } 

        public int? TopScorerId { get; set; }
        public string? TopScorerName { get; set; } 

        public int? StandOutPlayerId { get; set; }
        public string? StandOutPlayerName { get; set; } 

        public int? DisappointmentPlayerId { get; set; }
        public string? DisappointmentPlayerName { get; set; } 

        public int? BallondOrId { get; set; }
        public string? BallondOrName { get; set; } 

        public int? GoldenBootId { get; set; }
        public string? GoldenBootName { get; set; } 

        public int? ZamoraWinnerId { get; set; }
        public string? ZamoraWinnerName { get; set; } 
    }
}
