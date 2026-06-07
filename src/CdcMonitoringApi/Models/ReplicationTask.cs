namespace CdcMonitoringApi.Models;

public class ReplicationTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SourceDb { get; set; } = string.Empty;
    public string TargetDb { get; set; } = string.Empty;
    public ReplicationStatus Status { get; set; }
    public DateTime LastUpdateTime { get; set; }

    // Navigation property for related metrics
    public ICollection<TaskMetric> Metrics { get; set; } = new List<TaskMetric>();
    public ICollection<TaskError> Errors { get; set; } = new List<TaskError>();

}