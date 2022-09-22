using InterviewTestTask.Hubs;
using InterviewTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace InterviewTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CounterController : ControllerBase
{
    private readonly IHubContext<CounterHub> _counterHubContext;

    public CounterController(IHubContext<CounterHub> counterHubContext)
    {
        _counterHubContext = counterHubContext;
    }

    [HttpPut("AddGeneratedValue")]
    public async Task<IActionResult> AddGeneratedValue(GeneratedValueModel generatedValueModel)
    {
        Interlocked.Add(ref GlobalVariables.CounterAmount, generatedValueModel.Value);
        await _counterHubContext.Clients.All.SendAsync("GetCurrentCounterAmount", GlobalVariables.CounterAmount);
        return Ok();
    }
}