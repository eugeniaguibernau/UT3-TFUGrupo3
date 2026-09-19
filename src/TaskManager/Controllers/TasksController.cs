using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Interfaces;
using TaskManager.Services;

namespace TaskManager.Controllers;

/// <summary>
/// Publica ITareas como endpoints REST.
/// </summary>
[ApiController]
[Route("tasks")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITareas _tareas;
    private readonly TaskService _service; // para el endpoint transaccional crear+asignar

    public TasksController(ITareas tareas, TaskService service)
    {
        _tareas = tareas;
        _service = service;
    }

    [HttpPost]
    public ActionResult<TaskResponse> Create([FromBody] CreateTaskRequest req)
    {
        // TODO: _tareas.CreateTask(req.ProjectId, req.Title) → TaskResponse (201).
        throw new NotImplementedException();
    }

    [HttpPost("create-and-assign")]
    public ActionResult<TaskResponse> CreateAndAssign([FromBody] CreateAndAssignRequest req)
    {
        // TODO: _service.CreateAndAssign(...) → demuestra la transacción ACID atómica.
        throw new NotImplementedException();
    }

    [HttpPost("{id:guid}/assign")]
    public ActionResult<TaskResponse> Assign(Guid id, [FromBody] AssignTaskRequest req)
    {
        // TODO: _tareas.AssignTask(id, req.UserId) → TaskResponse.
        throw new NotImplementedException();
    }

    [HttpPost("{id:guid}/status")]
    public ActionResult<TaskResponse> ChangeStatus(Guid id, [FromBody] ChangeStatusRequest req)
    {
        // TODO: _tareas.ChangeStatus(id, req.Status) → TaskResponse.
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<List<TaskResponse>> GetByProject([FromQuery] Guid projectId)
    {
        // TODO: _tareas.GetTasksByProject(projectId) → List<TaskResponse>.
        throw new NotImplementedException();
    }
}
