namespace ApiGateway.Auth;

/// <summary>
/// Valida el JWT usando el secreto/issuer/audience compartidos (config Jwt:*).
/// </summary>
public class JwtTokenValidator : ITokenValidator
{
    private readonly IConfiguration _config;

    public JwtTokenValidator(IConfiguration config) => _config = config;

    public bool IsValid(string? bearerToken)
    {
        // TODO:
        //   1. Extraer el token del header "Authorization: Bearer <token>".
        //   2. Validarlo con JwtSecurityTokenHandler.ValidateToken(...) usando
        //      TokenValidationParameters { IssuerSigningKey = Jwt:Secret, ValidIssuer,
        //      ValidAudience, ValidateLifetime = true }.
        //   3. Devolver true/false.
        throw new NotImplementedException();
    }
}
