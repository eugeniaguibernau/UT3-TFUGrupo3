using ApiGateway.Auth;
using ApiGateway.Interfaces;

namespace ApiGateway.Routing;

/// <summary>
/// Implementa IApiRest (diagrama: GatewayRouter).
/// Responsabilidades:
///   - "valida token": rechaza la request si el JWT no es válido (salvo rutas públicas).
///   - "enruta / balancea": reenvía la request al componente destino; al usar el
///     nombre de servicio de Docker, el balanceo entre réplicas es automático.
/// </summary>
public class GatewayRouter : IApiRest
{
    // En el diagrama: 'autenticacion : IAutenticacion'. Aquí validamos el JWT
    // localmente (servicios sin estado) → ITokenValidator.
    private readonly ITokenValidator _autenticacion;
    private readonly RouteTable _routes;
    private readonly IHttpClientFactory _httpFactory;

    public GatewayRouter(
        ITokenValidator autenticacion,
        RouteTable routes,
        IHttpClientFactory httpFactory)
    {
        _autenticacion = autenticacion;
        _routes = routes;
        _httpFactory = httpFactory;
    }

    public async Task Route(HttpContext context)
    {
        // TODO:
        //   1. Si !_routes.IsPublic(path) y !_autenticacion.IsValid(Authorization):
        //          context.Response.StatusCode = 401; return;
        //   2. target = _routes.ResolveTarget(path); si null → 404.
        //   3. Reenviar método + headers + body a {target}{path}{query} con HttpClient.
        //   4. Copiar status + headers + body de la respuesta del backend al cliente.
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}
