using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Syrna.BlazoriseQuartz.ExecutionLog;

public interface IExecutionLogRepository : IBasicRepository<ExecutionLog, long>
{
    Task<IQueryable<ExecutionLog>> GetLatestExecutionLog(string jobName, string jobGroup, string triggerName, string triggerGroup, long firstLogId = 0, HashSet<LogType> logTypes = null);
    Task<IQueryable<ExecutionLog>> GetExecutionLogs(ExecutionLogFilter filter = null, long firstLogId = 0);
    Task<IList<string>> GetJobNames();
    Task<IList<string>> GetJobGroups();
    Task<IList<string>> GetTriggerNames();
    Task<IList<string>> GetTriggerGroups();
    Task<JobExecutionStatusSummaryModel> GetJobExecutionStatusSummary(DateTimeOffset? startTimeUtc, DateTimeOffset? endTimeUtc = null);
    Task MarkExecutingJobAsIncomplete(CancellationToken cancellToken = default);
    Task<bool> AnyAsync(Expression<Func<ExecutionLog, bool>> predicate);
    Task<ExecutionLog> FirstOrDefaultAsync(Expression<Func<ExecutionLog, bool>> predicate);
    Task<int> DeleteLogsByDays(int daysToKeep, CancellationToken cancelToken = default);
    Task SaveChangesAsync(CancellationToken cancelToken = default);
}