using Microsoft.AspNetCore.Mvc;
using WealthSphere.Model;
using WealthSphere.Services.Implementation;
using WealthSphere.Services.Interface;

namespace WealthSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly ILogger<InvestmentController> _logger;
        public readonly InvestmentService _investmentService;

        public InvestmentController(ILogger<InvestmentController> logger, IInvestmentService investmentService)
        {
            _logger = logger;
            _investmentService = investmentService;
        }

        //Table
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var result = await _investmentService.GetAll(userId);
            return Ok(result);
        }

        //Open for edit
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _investmentService.GetById(id);
            return Ok(result);
        }

        //Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InvestmentModel Investment)
        {
            var result = await _investmentService.AddAsync(Investment);
            return Ok(result);
        }

        //Update
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InvestmentModel Investment)
        {
            var result = await _investmentService.UpdateAsync(Investment);
            return Ok(result);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _investmentService.DeleteAsync(id);
            return Ok(result);
        }

        //Dashboard Overview - Bar graph
        [HttpGet("year")]
        public async Task<IActionResult> GetInvestmentByYear(int year, Guid userId)
        {
            var result = await _investmentService.GetInvestmentByYear(year, userId);
            return Ok(result);
        }

        //Dashboard Overview - Card
        [HttpGet("currentMonth")]
        public async Task<IActionResult> GetInvestmentByCurrentMonth(Guid userId)
        {
            var result = await _InvestmentService.GetInvestmentByCurrentMonth(userId);
            return Ok(result);

        }
    }
}