namespace CdcMonitoringApi.Models.Dtos;

public record ReplicationTaskDto(
    int Id,
    string Name,
    string SourceDb,
    string TargetDb,
    ReplicationStatus Status,
    DateTime LastUpdateTime
)
{
    public static ReplicationTaskDto FromEntity(ReplicationTask task) =>
        new(
            task.Id,
            task.Name,
            task.SourceDb,
            task.TargetDb,
            task.Status,
            task.LastUpdateTime
        );
}
