using System;
using System.Threading;
using System.Threading.Tasks;

namespace Syrna.BlazoriseQuartz.ExecutionLog
{
    public interface IExecutionLogStore
    {
        Task<bool> ExistsAsync(ExecutionLog log);
        bool Exists(ExecutionLog log);
        Task<int> DeleteLogsByDays(int daysToKeep, CancellationToken cancelToken = default);
        Task AddExecutionLog(ExecutionLog log, CancellationToken cancelToken = default);
        ValueTask UpdateExecutionLog(ExecutionLog log);
        Task SaveChangesAsync(CancellationToken cancelToken = default);
        Task MarkExecutingJobAsIncomplete(CancellationToken cancellToken = default);
    }
}

