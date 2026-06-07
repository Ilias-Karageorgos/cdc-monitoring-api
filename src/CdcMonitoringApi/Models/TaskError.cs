namespace CdcMonitoringApi.Models;

public class TaskError
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string Message { get; set; } = string.Empty;
    public ErrorSeverity Severity { get; set; }
    public DateTime Timestamp { get; set; }

    // Navigation property to the related replication task
    public ReplicationTask? Task { get; set; }
}
