using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Interfaces;

namespace ProjectManager.Controllers;

/// <summary>
/// Publica IProyectos como endpoints REST.
/// </summary>
[ApiController]
[Route("projects")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProyectos _proyectos;

    public ProjectsController(IProyectos proyectos) => _proyectos = proyectos;

    [HttpPost]
    public ActionResult<ProjectResponse> Create([FromBody] CreateProjectRequest req)
    {
        // TODO: _proyectos.CreateProject(req.OwnerId, req.Name) → ProjectResponse (201).
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ProjectResponse> GetById(Guid id)
    {
        // TODO: _proyectos.GetById(id) → ProjectResponse.
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<List<ProjectResponse>> GetByUser([FromQuery] Guid userId)
    {
        // TODO: _proyectos.GetProjectsByUser(userId) → List<ProjectResponse>.
        throw new NotImplementedException();
    }

    [HttpPost("{id:guid}/close")]
    public IActionResult Close(Guid id)
    {
        // TODO: _proyectos.CloseProject(id); return NoContent();
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}/is-open")]
    public ActionResult<bool> IsOpen(Guid id)
    {
        // TODO: return Ok(_proyectos.IsOpen(id));  (consumido por TaskManager)
        throw new NotImplementedException();
    }
}
