namespace ProjectManager.Domain;

/// <summary>
/// Entidad Project del diagrama (ProjectManager.dll).
///   Id : Guid, Name : string, OwnerId : Guid, Status : string
/// </summary>
public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }

    // "Open" | "Closed". IsOpen/CloseProject operan sobre este campo.
    public string Status { get; set; } = "Open";
}
