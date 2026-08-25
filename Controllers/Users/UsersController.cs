using football_draw_api.DTOs.Users;
using football_draw_api.Models.Users;
using football_draw_api.Services.Jwt;
using football_draw_api.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace football_draw_api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        private readonly JwtService jwtService;

        public UsersController(UserService userService, JwtService jwtService)
        {
            this.userService = userService;
            this.jwtService = jwtService;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            var user = userService.Login(
                request.UserName,
                request.Password
            );

            if (user == null)
            {
                return Unauthorized();
            }
            
            var token = jwtService.GenerateToken(user);
            var refreshToken = jwtService.GenerateRefreshToken();

            userService.SaveRefreshToken(user,refreshToken, DateTime.UtcNow.AddDays(30));

            var response = new LoginResponse
            {
                User = new UserResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Role = user.Role.ToString()
                },
                Token = token,
                RefreshToken = refreshToken
            }; ;

            return Ok(response);
        }

        [HttpPost("refresh")]
        public ActionResult<LoginResponse> Refresh(RefreshTokenRequest request)
        {
            var user = userService.GetUserByRefreshToken(
                request.RefreshToken
            );

            if (user == null)
            {
                return Unauthorized();
            }

            if (
                user.RefreshTokenExpiresAt == null ||
                user.RefreshTokenExpiresAt <= DateTime.UtcNow
            )
            {
                return Unauthorized();
            }

            var token = jwtService.GenerateToken(user);
            var refreshToken = jwtService.GenerateRefreshToken();

            userService.SaveRefreshToken(
                user,
                refreshToken,
                DateTime.UtcNow.AddDays(30)
            );

            var response = new LoginResponse
            {
                User = new UserResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Role = user.Role.ToString()
                },
                Token = token,
                RefreshToken = refreshToken
            };

            return Ok(response);
        }
        [HttpGet]
        [Authorize]
        public ActionResult<List<UserResponse>> GetUsers()
        {
            var users = userService.GetUsers();
            if(users == null)
            {
                return NotFound();
            }
            var response = users.Select(user => new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role.ToString()
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id) {

            var user = userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var response = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role.ToString()
            };
            
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(CreateUserRequest user) {
            var newUser = userService.CreateUser(user);
            var response = new UserResponse
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Role = newUser.Role.ToString()
            };
            return Ok(response);
        }
    }
}
