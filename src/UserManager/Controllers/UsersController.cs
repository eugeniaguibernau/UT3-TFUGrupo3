using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManager.Interfaces;

namespace UserManager.Controllers;

/// <summary>
/// Publica IUsuarios como endpoints REST. Consumidos por ProjectManager
/// (valida dueño) y TaskManager (valida asignado), además del gateway.
/// </summary>
[ApiController]
[Route("users")]
[Authorize] // requiere JWT válido
public class UsersController : ControllerBase
{
    private readonly IUsuarios _usuarios;

    public UsersController(IUsuarios usuarios) => _usuarios = usuarios;

    [HttpGet("{id:guid}")]
    public ActionResult<UserResponse> GetById(Guid id)
    {
        // TODO: mapear _usuarios.GetById(id) → UserResponse (sin exponer el hash).
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<List<UserResponse>> GetAll()
    {
        // TODO: mapear _usuarios.GetAll() → List<UserResponse>.
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}/exists")]
    public ActionResult<bool> Exists(Guid id)
    {
        // TODO: return Ok(_usuarios.Exist(id));
        throw new NotImplementedException();
    }
}
