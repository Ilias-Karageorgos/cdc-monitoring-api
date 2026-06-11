using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CdcMonitoringApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaskMetrics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskMetrics",
                columns: new[] { "Id", "LagSeconds", "RowsPerSecond", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 0.5, 1200, 1, new DateTime(2026, 6, 11, 13, 57, 0, 0, DateTimeKind.Utc) },
                    { 2, 0.69999999999999996, 1100, 1, new DateTime(2026, 6, 11, 13, 58, 0, 0, DateTimeKind.Utc) },
                    { 3, 0.59999999999999998, 1300, 1, new DateTime(2026, 6, 11, 13, 59, 0, 0, DateTimeKind.Utc) },
                    { 4, 5.2000000000000002, 0, 2, new DateTime(2026, 6, 11, 12, 58, 0, 0, DateTimeKind.Utc) },
                    { 5, 5.7999999999999998, 0, 2, new DateTime(2026, 6, 11, 12, 59, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskMetrics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskMetrics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskMetrics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskMetrics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskMetrics",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
