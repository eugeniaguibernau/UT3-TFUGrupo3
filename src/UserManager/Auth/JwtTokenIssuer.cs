using UserManager.Domain;

namespace UserManager.Auth;

/// <summary>
/// Emite los JWT firmados con el secreto compartido (Jwt__Secret).
/// Como el secreto es el mismo en todos los componentes, cualquier réplica
/// puede validar el token sin consultar a UserManager → servicios sin estado.
/// </summary>
public class JwtTokenIssuer
{
    private readonly IConfiguration _config;

    public JwtTokenIssuer(IConfiguration config) => _config = config;

    /// <summary>Genera un JWT con el id y el email del usuario como claims.</summary>
    public string Issue(User user)
    {
        // TODO: construir el JwtSecurityToken con:
        //   - claim "sub" = user.Id, claim "email" = user.Email
        //   - Issuer / Audience desde config (Jwt__Issuer / Jwt__Audience)
        //   - firma HMAC-SHA256 con Jwt__Secret
        //   - expiración (p. ej. 1 hora)
        throw new NotImplementedException();
    }
}
