namespace football_draw_api.DTOs.Users
{
    public class LoginResponse
    {
        public UserResponse User { get; set; } = null!;

        public string Token { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;
    }
}
