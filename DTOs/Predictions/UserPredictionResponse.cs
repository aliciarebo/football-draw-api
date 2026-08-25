using football_draw_api.DTOs.Users;
using football_draw_api.Models.Predictions;

namespace football_draw_api.DTOs.Predictions
{
    public class UserPredictionResponse
    {
        public int Id { get; set; }
        public UserResponse User {  get; set; } = null!;
        public SeasonPrediction SeasonPrediction { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
