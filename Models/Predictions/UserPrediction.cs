using football_draw_api.Models.Users;

namespace football_draw_api.Models.Predictions
{
    public class UserPrediction
    {
        public int Id { get; set; }
        public User User { get; set; }
        public SeasonPrediction SeasonPrediction {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
