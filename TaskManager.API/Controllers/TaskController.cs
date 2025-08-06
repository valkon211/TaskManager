using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces.Services;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController: ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTaskAsync([FromBody] string title, [FromBody] string description)
    {
        await _taskService.CreateTaskAsync(title, description);
        return Ok();
    }
}