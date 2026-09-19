using TaskManager.Domain;
using TaskManager.Persistence;

namespace TaskManager.Repositories;

/// <summary>
/// Persistencia de tareas (diagrama: TaskRepository).
///   Save / FindById / FindByProject / CountInProjectByUser
/// </summary>
public class TaskRepository
{
    private readonly TasksDbContext _db;

    public TaskRepository(TasksDbContext db) => _db = db;

    public void Save(TaskItem task)
    {
        // TODO: insertar o actualizar la tarea y persistir.
        throw new NotImplementedException();
    }

    public TaskItem? FindById(Guid id)
    {
        // TODO: buscar por PK.
        throw new NotImplementedException();
    }

    public List<TaskItem> FindByProject(Guid projectId)
    {
        // TODO: tareas del proyecto (para pintar el dashboard).
        throw new NotImplementedException();
    }

    public int CountInProjectByUser(Guid userId)
    {
        // TODO: cantidad de tareas asignadas a un usuario.
        //       Útil para reglas de negocio (p. ej. límite de carga por persona).
        throw new NotImplementedException();
    }
}
