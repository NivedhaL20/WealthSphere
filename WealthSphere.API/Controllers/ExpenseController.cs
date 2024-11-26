using Microsoft.AspNetCore.Mvc;
using WealthSphere.Model;
using WealthSphere.Services.Interface;

namespace WealthSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;
        public readonly IExpenseService _expenseService;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService)
        {
            _logger = logger;
            _expenseService = expenseService;
        }

        //Table
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var result = await _expenseService.GetAll(userId);
            return Ok(result);
        }

        //Open for edit
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _expenseService.GetById(id);
            return Ok(result);
        }

        //Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ExpenseModel expense)
        {
            var result = await _expenseService.AddAsync(expense);
            return Ok(result);
        }

        //Update
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExpenseModel expense)
        {
            var result = await _expenseService.UpdateAsync(expense);
            return Ok(result);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var result = await _expenseService.DeleteAsync(id);
            return Ok(result);
        }

        //Dashboard Overview - Bar graph
        [HttpGet("year")]
        public async Task<IActionResult> GetExpenseByYear(int year, Guid userId)
        {
            var result = await _expenseService.GetExpenseByYear(year, userId);
            return Ok(result);
        }

        //Dashboard Overview - Card
        [HttpGet("currentMonth")]
        public async Task<IActionResult> GetExpenseByCurrentMonth(Guid userId)
        {
            var result = await _expenseService.GetExpenseByCurrentMonth(userId);
            return Ok(result);
        }

        [HttpGet("debts/currentMonth")]
        public async Task<IActionResult> GetDebtsByCurrentMonth(Guid userId)
        {
            var result = await _expenseService.GetDebtsByCurrentMonth(userId);
            return Ok(result);
        }
    }
}
