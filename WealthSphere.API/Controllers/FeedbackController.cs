using Microsoft.AspNetCore.Mvc;
using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Services.Implementation;
using WealthSphere.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WealthSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ILogger<FeedbackController> _logger;
        public readonly IFeedbackService _feedbackService;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackService feedbackService)
        {
            _logger = logger;
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FeedbackModel model)
        {
            var result = await _feedbackService.AddAsync(model);
            return Ok(result);
        }        
    }
}
