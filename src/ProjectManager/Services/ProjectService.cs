using ProjectManager.Contracts;
using ProjectManager.Domain;
using ProjectManager.Interfaces;
using ProjectManager.Repositories;

namespace ProjectManager.Services;

/// <summary>
/// Lógica de negocio de proyectos (diagrama: ProjectService).
/// Depende de ProjectRepository (persiste/consulta) y de IUsuarios (valida dueño).
/// </summary>
public class ProjectService : IProyectos
{
    private readonly ProjectRepository _repository;
    private readonly IUsuarios _usuarios;

    public ProjectService(ProjectRepository repository, IUsuarios usuarios)
    {
        _repository = repository;
        _usuarios = usuarios;
    }

    public Project CreateProject(Guid ownerId, string name)
    {
        // TODO:
        //   1. Validar que el dueño exista: _usuarios.Exist(ownerId) (arista "valida dueño").
        //   2. Crear Project { Id nuevo, Name, OwnerId, Status = "Open" }.
        //   3. _repository.Save(project) y devolverlo.
        throw new NotImplementedException();
    }

    public Project GetById(Guid id)
    {
        // TODO: _repository.FindById(id) o NotFound.
        throw new NotImplementedException();
    }

    public List<Project> GetProjectsByUser(Guid userId)
    {
        // TODO: _repository.FindByOwner(userId).
        throw new NotImplementedException();
    }

    public void CloseProject(Guid id)
    {
        // TODO: cargar el proyecto, Status = "Closed", Save.
        throw new NotImplementedException();
    }

    public bool IsOpen(Guid id)
    {
        // TODO: true si el proyecto existe y Status == "Open".
        //       Lo consulta TaskManager antes de crear/mover tareas.
        throw new NotImplementedException();
    }
}
