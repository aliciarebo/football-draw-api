using football_draw_api.Models.Predictions;

namespace football_draw_api.DTOs.Predictions
{
    public class CreateSeasonPredictionRequest
    {
        public int ChampionsLeagueWinnerId { get; set; }
        public string ChampionsLeagueWinnerName { get; set; } = string.Empty;

        public int LaLigaWinnerId { get; set; }
        public string LaLigaWinnerName { get; set; } = string.Empty;

        public int CopaReyWinnerId { get; set; }
        public string CopaReyWinnerName { get; set; } = string.Empty;

        public int SuperCopaWinnerId { get; set; }
        public string SuperCopaWinnerName { get; set; } = string.Empty;

        public int TopScorerId { get; set; }
        public string TopScorerName { get; set; } = string.Empty;

        public int StandOutPlayerId { get; set; }
        public string StandOutPlayerName { get; set; } = string.Empty;

        public int DisappointmentPlayerId { get; set; }
        public string DisappointmentPlayerName { get; set; } = string.Empty;

        public int BallondOrId { get; set; }
        public string BallondOrName { get; set; } = string.Empty;

        public int GoldenBootId { get; set; }
        public string GoldenBootName { get; set; } = string.Empty;

        public int ZamoraWinnerId { get; set; }
        public string ZamoraWinnerName { get; set; } = string.Empty;
    }
}
