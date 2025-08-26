using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
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
    public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest request)
    {
        await _taskService.CreateTaskAsync(request.Title, request.Description);
        return Ok();
    }
}