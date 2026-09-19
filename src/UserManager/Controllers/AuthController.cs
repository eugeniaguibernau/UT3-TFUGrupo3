using Microsoft.AspNetCore.Mvc;
using UserManager.Interfaces;

namespace UserManager.Controllers;

/// <summary>
/// Publica IAutenticacion como endpoints REST (registro y login).
/// Estos endpoints son públicos (no requieren token).
/// </summary>
[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAutenticacion _auth;

    public AuthController(IAutenticacion auth) => _auth = auth;

    [HttpPost("register")]
    public ActionResult<TokenResponse> Register([FromBody] RegisterRequest req)
    {
        // TODO: var token = _auth.Register(req.Name, req.Email, req.Password);
        //       return Ok(new TokenResponse(token));
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    public ActionResult<TokenResponse> Login([FromBody] LoginRequest req)
    {
        // TODO: var token = _auth.Authenticate(req.Email, req.Password);
        //       return Ok(new TokenResponse(token));
        throw new NotImplementedException();
    }
}
