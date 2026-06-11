using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CdcMonitoringApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedReplicationTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReplicationTasks",
                columns: new[] { "Id", "LastUpdateTime", "Name", "SourceDb", "Status", "TargetDb" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 11, 14, 0, 0, 0, DateTimeKind.Utc), "Oracle to Kafka", "Oracle", 0, "Kafka" },
                    { 2, new DateTime(2026, 6, 11, 13, 0, 0, 0, DateTimeKind.Utc), "SQL Server to Kafka", "SQL Server", 1, "Kafka" },
                    { 3, new DateTime(2026, 6, 11, 12, 0, 0, 0, DateTimeKind.Utc), "MySQL to Kafka", "MySQL", 2, "Kafka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReplicationTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReplicationTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReplicationTasks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
