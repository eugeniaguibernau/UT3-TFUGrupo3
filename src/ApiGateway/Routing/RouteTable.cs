namespace ApiGateway.Routing;

/// <summary>
/// Mapea el prefijo de la ruta entrante al componente de destino.
/// La URL destino es el NOMBRE DE SERVICIO de Docker: cuando hay varias réplicas,
/// el DNS interno de Docker reparte las conexiones → balanceo horizontal.
///
///   /auth/**      → UserManager     (endpoints públicos, sin token)
///   /users/**     → UserManager
///   /projects/**  → ProjectManager
///   /tasks/**     → TaskManager
/// </summary>
public class RouteTable
{
    private readonly IConfiguration _config;

    public RouteTable(IConfiguration config) => _config = config;

    /// <summary>Base URL del componente destino, o null si la ruta no existe.</summary>
    public string? ResolveTarget(PathString path)
    {
        // TODO: según el primer segmento del path, devolver:
        //   Services:Users / Services:Projects / Services:Tasks (desde config).
        throw new NotImplementedException();
    }

    /// <summary>True si la ruta es pública (no exige JWT), p. ej. /auth/*.</summary>
    public bool IsPublic(PathString path)
    {
        // TODO: true para /auth/register y /auth/login.
        throw new NotImplementedException();
    }
}
