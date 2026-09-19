namespace TaskManager.Domain;

/// <summary>
/// Entidad Task del diagrama (TaskManager.dll).
///   Id : Guid, ProjectId : Guid, Assignee : Guid, Title : string, Status : string
///
/// Se llama TaskItem para no chocar con System.Threading.Tasks.Task.
/// </summary>
public class TaskItem
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }

    // Usuario asignado. Guid.Empty mientras la tarea no tiene responsable.
    public Guid Assignee { get; set; }

    public string Title { get; set; } = string.Empty;

    // "Todo" | "InProgress" | "Done".
    public string Status { get; set; } = "Todo";
}
