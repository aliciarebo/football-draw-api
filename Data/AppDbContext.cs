using football_draw_api.Models.Predictions;
using football_draw_api.Models.Result;
using football_draw_api.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace football_draw_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPrediction> UserPredictions { get; set; }

        public DbSet<SeasonResult> SeasonResults { get; set; }
    }
}
