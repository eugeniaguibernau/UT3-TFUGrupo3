using UserManager.Domain;
using UserManager.Persistence;

namespace UserManager.Repositories;

/// <summary>
/// Persistencia de usuarios (diagrama: UserRepository).
///   Save / FindById / FindByEmail
/// </summary>
public class UserRepository
{
    private readonly UsersDbContext _db;

    public UserRepository(UsersDbContext db) => _db = db;

    public void Save(User user)
    {
        // TODO: insertar o actualizar el usuario y persistir (SaveChanges).
        throw new NotImplementedException();
    }

    public User? FindById(Guid id)
    {
        // TODO: buscar por clave primaria.
        throw new NotImplementedException();
    }

    public User? FindByEmail(string email)
    {
        // TODO: buscar por email (único). Se usa en el login.
        throw new NotImplementedException();
    }
}
