namespace ProjectManager.Contracts;

/// <summary>
/// Implementación de IUsuarios que consume el componente UserManager vía REST.
/// La URL base (Services:Users) apunta al nombre de servicio de Docker, por lo
/// que el DNS interno reparte entre las réplicas de UserManager.
/// </summary>
public class UsuariosHttpClient : IUsuarios
{
    private readonly HttpClient _http;

    public UsuariosHttpClient(HttpClient http) => _http = http;

    public bool Exist(Guid id)
    {
        // TODO: GET {Services:Users}/users/{id}/exists  → bool
        throw new NotImplementedException();
    }

    public UserDto? GetById(Guid id)
    {
        // TODO: GET {Services:Users}/users/{id}  → UserDto (null si 404)
        throw new NotImplementedException();
    }
}
