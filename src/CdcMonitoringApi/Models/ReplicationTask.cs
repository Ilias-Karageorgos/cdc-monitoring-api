namespace CdcMonitoringApi.Models;

public record ReplicationTask(
    int Id, string Name, string SourceDb, string TargetDb, ReplicationStatus Status, DateTime LastUpdateTime
);