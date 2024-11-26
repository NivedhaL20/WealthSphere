using Microsoft.AspNetCore.Mvc;
using WealthSphere.Model;
using WealthSphere.Services.Interface;

namespace WealthSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalSettingsController : ControllerBase
    {
        private readonly ILogger<GoalSettingsController> _logger;
        public readonly IGoalSettingService _goalSettingService;

        public GoalSettingsController(ILogger<GoalSettingsController> logger, IGoalSettingService goalSettingService)
        {
            _logger = logger;
            _goalSettingService = goalSettingService;
        }

        //Open for edit
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var userId = Guid.Parse(id);
            var result = await _goalSettingService.GetById(userId);
            return Ok(result);
        }

        //Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GoalSettingModel goalSettingModel)
        {
            var result = await _goalSettingService.AddAsync(goalSettingModel);
            return Ok(result);
        }

        //Update
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] GoalSettingModel goalSettingModel)
        {
            var result = await _goalSettingService.UpdateAsync(goalSettingModel);
            return Ok(result);
        }        
    }
}
