using football_draw_api.DTOs.Predictions;
using football_draw_api.DTOs.Users;
using football_draw_api.Models.Predictions;
using football_draw_api.Services.Prediction;
using football_draw_api.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace football_draw_api.Controllers.Prediction
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictionsController: ControllerBase
    {
        private PredictionService predictionService;
        private readonly UserService userService;

        public PredictionsController(PredictionService predictionService, UserService userService)
        {
            this.predictionService = predictionService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserPredictionResponse>> GetAllSeasonPrediction()
        {
            var predictions = predictionService.GetPredictions();

            var response = predictions
                .Select(MapToResponse)
                .ToList();

            return Ok(response);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<UserPredictionResponse> GetUserSeasonPrediction(int userId)
        {
            var prediction = predictionService.FindUserPrediction(userId);

            if (prediction == null)
            {
                return NotFound();
            }

            return Ok(MapToResponse(prediction));
        }

        [Authorize]
        [HttpGet("me")]
        public ActionResult<UserPredictionResponse> GetMyPrediction()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var prediction = predictionService.FindUserPrediction(userId);

            if (prediction == null)
            {
                return NotFound();
            }

            return Ok(MapToResponse(prediction));
        }

        [HttpPost]
        [Authorize]
        public ActionResult<UserPredictionResponse> CreateUserSeasonPrediction(CreateSeasonPredictionRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var user = userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = predictionService.CreatePrediction(user, request);
            return Ok(MapToResponse(result));
        }

        [HttpPut]
        [Authorize]
        public ActionResult<UserPredictionResponse> UpdateUserPrediction(CreateSeasonPredictionRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);
            var user = userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            };

            var result = predictionService.UpdatePrediction(user, request);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(MapToResponse(result));

        }

        private UserPredictionResponse MapToResponse(UserPrediction prediction)
        {
            return new UserPredictionResponse
            {
                Id = prediction.Id,

                User = new UserResponse
                {
                    Id = prediction.User.Id,
                    UserName = prediction.User.UserName,
                    Role = prediction.User.Role.ToString()
                },

                SeasonPrediction = prediction.SeasonPrediction,
                CreatedAt = prediction.CreatedAt,
                UpdatedAt = prediction.UpdatedAt
            };
        }
    }
}
