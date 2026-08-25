using football_draw_api.Data;
using football_draw_api.DTOs.Predictions;
using football_draw_api.Models.Predictions;
using football_draw_api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace football_draw_api.Services.Prediction
{
    public class PredictionService
    {
        private readonly AppDbContext context;

        public PredictionService(AppDbContext context)
        {
            this.context = context;
        }
        public List<UserPrediction> GetPredictions()
        {
            return GetPredictionsWithDetails().ToList();

        }

        public UserPrediction? FindUserPrediction(int userId)
        {
            return GetPredictionsWithDetails().FirstOrDefault(prediction => prediction.User.Id == userId);
        }

        public UserPrediction CreatePrediction(User user, CreateSeasonPredictionRequest request)
        {
            var prediction = new UserPrediction
            {
                User = user,
                SeasonPrediction = MapToSeasonPrediction(request),
                CreatedAt = DateTime.UtcNow
            };

            context.UserPredictions.Add(prediction);
            context.SaveChanges();

            return prediction;
        }

        public UserPrediction? UpdatePrediction(User user, CreateSeasonPredictionRequest request) {

            var prediction = GetPredictionsWithDetails().FirstOrDefault(prediction => prediction.User.Id == user.Id);

            if (prediction == null)
            {
                return null;
            }

            prediction.SeasonPrediction =
                MapToSeasonPrediction(request);

            prediction.UpdatedAt = DateTime.UtcNow;

            context.SaveChanges();

            return prediction;
        }

        private IQueryable<UserPrediction> GetPredictionsWithDetails()
        {
            return context.UserPredictions
                .Include(prediction => prediction.User);
        }
        private SeasonPrediction MapToSeasonPrediction(CreateSeasonPredictionRequest request)
        {
            return new SeasonPrediction
            {
               ChampionsLeagueWinnerId = request.ChampionsLeagueWinnerId,
               ChampionsLeagueWinnerName = request.ChampionsLeagueWinnerName,
               LaLigaWinnerId = request.LaLigaWinnerId,
               LaLigaWinnerName = request.LaLigaWinnerName,
               CopaReyWinnerId = request.CopaReyWinnerId,
               CopaReyWinnerName = request.CopaReyWinnerName,
               SuperCopaWinnerId = request.SuperCopaWinnerId,
               SuperCopaWinnerName = request.SuperCopaWinnerName,
               TopScorerId = request.TopScorerId,
               TopScorerName = request.TopScorerName,
               StandOutPlayerId = request.StandOutPlayerId,
               StandOutPlayerName = request.StandOutPlayerName,
               DisappointmentPlayerId = request.DisappointmentPlayerId,
               DisappointmentPlayerName = request.DisappointmentPlayerName,
               BallondOrId = request.BallondOrId,
               BallondOrName = request.BallondOrName,
               GoldenBootId = request.GoldenBootId,
               GoldenBootName = request.GoldenBootName,
               ZamoraWinnerId = request.ZamoraWinnerId,
               ZamoraWinnerName = request.ZamoraWinnerName,
            };
        }
    }
}
