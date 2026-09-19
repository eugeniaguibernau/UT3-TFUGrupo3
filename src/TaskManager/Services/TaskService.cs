using TaskManager.Contracts;
using TaskManager.Domain;
using TaskManager.Interfaces;
using TaskManager.Persistence;
using TaskManager.Repositories;

namespace TaskManager.Services;

/// <summary>
/// Lógica de negocio de tareas (diagrama: TaskService).
/// Depende de TaskRepository (persiste/consulta), IProyectos (valida proyecto
/// abierto) e IUsuarios (valida asignado).
///
/// Aquí se demuestra la propiedad ACID: crear una tarea y asignarla debe ser
/// atómico — si algo falla, se deshace todo (rollback de la transacción).
/// </summary>
public class TaskService : ITareas
{
    private readonly TaskRepository _repository;
    private readonly IProyectos _proyectos;
    private readonly IUsuarios _usuarios;
    private readonly TasksDbContext _db; // para abrir transacciones explícitas

    public TaskService(
        TaskRepository repository,
        IProyectos proyectos,
        IUsuarios usuarios,
        TasksDbContext db)
    {
        _repository = repository;
        _proyectos = proyectos;
        _usuarios = usuarios;
        _db = db;
    }

    public TaskItem CreateTask(Guid projectId, string title)
    {
        // TODO:
        //   1. Validar que el proyecto esté abierto: _proyectos.IsOpen(projectId)
        //      (arista "valida proyecto abierto"); si no, rechazar.
        //   2. Crear TaskItem { Id nuevo, ProjectId, Title, Status = "Todo",
        //      Assignee = Guid.Empty } y guardarlo.
        throw new NotImplementedException();
    }

    public TaskItem AssignTask(Guid taskId, Guid userId)
    {
        // TODO:
        //   1. Validar que el usuario exista: _usuarios.Exist(userId)
        //      (arista "valida asignado").
        //   2. Cargar la tarea, setear Assignee = userId, guardar y devolverla.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Ejemplo del enunciado: "si se crea la tarea y se la asigna a un usuario,
    /// ambas operaciones deben realizarse; si alguna falla, se deshacen todos los
    /// cambios". Crear + asignar como UNA sola transacción atómica.
    /// </summary>
    public TaskItem CreateAndAssign(Guid projectId, string title, Guid userId)
    {
        // TODO:
        //   using var tx = _db.Database.BeginTransaction();
        //   try {
        //       validar proyecto abierto y usuario existente;
        //       crear tarea + asignar (dos escrituras);
        //       _db.SaveChanges();
        //       tx.Commit();
        //   } catch { tx.Rollback(); throw; }   // atomicidad
        throw new NotImplementedException();
    }

    public TaskItem ChangeStatus(Guid taskId, string status)
    {
        // TODO:
        //   1. Validar 'status' contra los permitidos ("Todo"/"InProgress"/"Done").
        //   2. Cargar tarea, setear Status, guardar.
        //   NOTA (aislamiento): dos usuarios podrían cambiar el estado a la vez;
        //   usar transacción / control de concurrencia para no perder cambios.
        throw new NotImplementedException();
    }

    public List<TaskItem> GetTasksByProject(Guid projectId)
    {
        // TODO: _repository.FindByProject(projectId).
        throw new NotImplementedException();
    }
}
