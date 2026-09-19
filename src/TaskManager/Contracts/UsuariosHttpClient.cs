namespace TaskManager.Contracts;

/// <summary>
/// Implementación de IUsuarios que consume UserManager vía REST.
/// </summary>
public class UsuariosHttpClient : IUsuarios
{
    private readonly HttpClient _http;

    public UsuariosHttpClient(HttpClient http) => _http = http;

    public bool Exist(Guid id)
    {
        // TODO: GET {Services:Users}/users/{id}/exists → bool
        throw new NotImplementedException();
    }

    public UserDto? GetById(Guid id)
    {
        // TODO: GET {Services:Users}/users/{id} → UserDto (null si 404)
        throw new NotImplementedException();
    }
}
