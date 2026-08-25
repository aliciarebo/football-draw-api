using football_draw_api.DTOs.Result;
using football_draw_api.Models.Result;
using football_draw_api.Services.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace football_draw_api.Controllers.Result
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonResultController : ControllerBase
    {
        SeasonResultService seasonResultService;

        public SeasonResultController(SeasonResultService seasonResultService)
        {
            this.seasonResultService = seasonResultService;
        }

        [HttpGet]
        public ActionResult<SeasonResult> GetSeasonResult()
        {
            var result = seasonResultService.GetSeasonResult();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ActionResult<SeasonResult> CreateSeasonResult(SeasonResultRequest seasonResult) {
            var result = seasonResultService.CreateSeasonResult(seasonResult);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ActionResult<SeasonResult> UpdateSeasonResult(SeasonResultRequest seasonResult) {
            var result = seasonResultService.UpdateSeasonResult(seasonResult);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
