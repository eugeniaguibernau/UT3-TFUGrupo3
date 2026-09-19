using UserManager.Auth;
using UserManager.Domain;
using UserManager.Interfaces;
using UserManager.Repositories;

namespace UserManager.Services;

/// <summary>
/// Lógica de negocio de usuarios y autenticación (diagrama: UserService).
/// Implementa las dos interfaces expuestas por el componente.
///
/// NOTA sobre el diagrama: allí UserService.Register aparece como ": User".
/// Para respetar el contrato de IAutenticacion (Register : string) devolvemos el
/// JWT recién emitido; el User igualmente se persiste. Si se prefiere devolver el
/// User, el endpoint puede volver a consultarlo con GetById.
/// </summary>
public class UserService : IUsuarios, IAutenticacion
{
    private readonly UserRepository _repository;
    private readonly JwtTokenIssuer _tokens;

    public UserService(UserRepository repository, JwtTokenIssuer tokens)
    {
        _repository = repository;
        _tokens = tokens;
    }

    // ── IAutenticacion ──────────────────────────────────────────────────────
    public string Register(string name, string email, string password)
    {
        // TODO:
        //   1. Verificar que no exista otro usuario con ese email (FindByEmail).
        //   2. Crear User con Id nuevo y PasswordHash = BCrypt.HashPassword(password).
        //   3. Save.
        //   4. Devolver _tokens.Issue(user).
        throw new NotImplementedException();
    }

    public string Authenticate(string email, string password)
    {
        // TODO:
        //   1. FindByEmail; si no existe → credenciales inválidas.
        //   2. BCrypt.Verify(password, user.PasswordHash); si falla → inválidas.
        //   3. Devolver _tokens.Issue(user).
        throw new NotImplementedException();
    }

    // ── IUsuarios ───────────────────────────────────────────────────────────
    public User GetById(Guid id)
    {
        // TODO: _repository.FindById(id) (o lanzar NotFound si es null).
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        // TODO: devolver todos los usuarios (para asignar tareas / listar equipo).
        throw new NotImplementedException();
    }

    public bool Exist(Guid id)
    {
        // TODO: true si _repository.FindById(id) != null.
        throw new NotImplementedException();
    }
}
