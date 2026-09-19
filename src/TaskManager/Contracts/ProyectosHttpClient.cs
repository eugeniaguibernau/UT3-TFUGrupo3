namespace TaskManager.Contracts;

/// <summary>
/// Implementación de IProyectos que consume ProjectManager vía REST.
/// </summary>
public class ProyectosHttpClient : IProyectos
{
    private readonly HttpClient _http;

    public ProyectosHttpClient(HttpClient http) => _http = http;

    public bool IsOpen(Guid projectId)
    {
        // TODO: GET {Services:Projects}/projects/{projectId}/is-open → bool
        throw new NotImplementedException();
    }

    public ProjectDto? GetById(Guid projectId)
    {
        // TODO: GET {Services:Projects}/projects/{projectId} → ProjectDto (null si 404)
        throw new NotImplementedException();
    }
}
