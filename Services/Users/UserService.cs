using football_draw_api.Data;
using football_draw_api.DTOs.Users;
using football_draw_api.Models.Users;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace football_draw_api.Services.Users
{
    public class UserService
    {
        private readonly PasswordHasher<User> passwordHasher = new();
        private readonly AppDbContext context;

        public UserService(AppDbContext context)
        {
            this.context = context;
        }

        public User? Login(string userName, string password)
        {
            var user = context.Users.FirstOrDefault(user => user.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                password
            );

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return user;
        }

        public void SaveRefreshToken( User user, string refreshToken, DateTime expiresAt)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiresAt = expiresAt;

            context.SaveChanges();
        }
        public User? GetUserByRefreshToken(string refreshToken)
        {
            return context.Users.FirstOrDefault(user => user.RefreshToken == refreshToken);
        }
        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        public User CreateUser(CreateUserRequest request)
        {

            var user = new User
            {
                UserName = request.UserName,
                Role = UserRole.USER
            };

            user.PasswordHash = passwordHasher.HashPassword(
                user,
                request.Password
            );

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
    }
}
