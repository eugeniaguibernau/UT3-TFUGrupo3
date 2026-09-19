using ProjectManager.Domain;
using ProjectManager.Persistence;

namespace ProjectManager.Repositories;

/// <summary>
/// Persistencia de proyectos (diagrama: ProjectRepository).
///   Save / FindById / FindByOwner
/// </summary>
public class ProjectRepository
{
    private readonly ProjectsDbContext _db;

    public ProjectRepository(ProjectsDbContext db) => _db = db;

    public void Save(Project project)
    {
        // TODO: insertar o actualizar el proyecto y persistir.
        throw new NotImplementedException();
    }

    public Project? FindById(Guid id)
    {
        // TODO: buscar por PK.
        throw new NotImplementedException();
    }

    public List<Project> FindByOwner(Guid ownerId)
    {
        // TODO: proyectos cuyo OwnerId == ownerId.
        throw new NotImplementedException();
    }
}
