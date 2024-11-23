using Microsoft.AspNetCore.Mvc;
using WealthSphere.Model;
using WealthSphere.Services.Interface;

namespace WealthSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly ILogger<IncomeController> _logger;
        public readonly IIncomeService _incomeService;

        public IncomeController(ILogger<IncomeController> logger, IIncomeService incomeService)
        {
            _logger = logger;
            _incomeService = incomeService;
        }

        //Table
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var result = await _incomeService.GetAll(userId);
            return Ok(result);
        }

        //Open for edit
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {                        
            var result = await _incomeService.GetById(id);
            return Ok(result);
        }

        //Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IncomeModel income)
        {
            var result = await _incomeService.AddAsync(income);
            return Ok(result);
        }

        //Update
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IncomeModel income)
        {
            var result = await _incomeService.UpdateAsync(income);
            return Ok(result);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _incomeService.DeleteAsync(id);
            return Ok(result);
        }

        //Dashboard Overview - Bar graph
        [HttpGet("year")]
        public async Task<IActionResult> GetIncomeByYear(int year, Guid userId)
        {
            var result = await _incomeService.GetIncomeByYear(year, userId);
            return Ok(result);
        }        

        //Dashboard Overview - Card
        [HttpGet("currentMonth")]
        public async Task<IActionResult> GetIncomeByCurrentMonth(Guid userId)
        {
            var result = await _incomeService.GetIncomeByCurrentMonth(userId);
            return Ok(result);
        }
    }
}
