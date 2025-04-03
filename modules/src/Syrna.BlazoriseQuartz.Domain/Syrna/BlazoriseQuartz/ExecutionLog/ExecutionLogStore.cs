using System;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Syrna.BlazoriseQuartz.ExecutionLog
{
    public class ExecutionLogStore(ILogger<ExecutionLogStore> logger,IExecutionLogRepository executionLogRepository) : IExecutionLogStore
    {
        public async Task AddExecutionLog(ExecutionLog log, CancellationToken cancelToken = default)
        {
            await executionLogRepository.InsertAsync(log,true, cancelToken);
        }

        public Task<bool> ExistsAsync(ExecutionLog log)
        {
            return executionLogRepository.AnyAsync(l => l.RunInstanceId == log.RunInstanceId);
        }

        public bool Exists(ExecutionLog log)
        {
            return ExistsAsync(log).Result;
        }

        public async Task<int> DeleteLogsByDays(int daysToKeep, CancellationToken cancelToken = default)
        {
            return await executionLogRepository.DeleteLogsByDays(daysToKeep,cancelToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancelToken = default)
        {
            await executionLogRepository.SaveChangesAsync(cancelToken);
        }

        public async ValueTask UpdateExecutionLog(ExecutionLog log)
        {
            var entry = await executionLogRepository.FirstOrDefaultAsync(l => l.RunInstanceId == log.RunInstanceId);

            if (entry != null)
            {
                entry.ExecutionLogDetail = log.ExecutionLogDetail;
                entry.ErrorMessage = log.ErrorMessage;
                entry.ExecutionLogDetail = log.ExecutionLogDetail;
                entry.IsVetoed = log.IsVetoed;
                entry.JobRunTime = log.JobRunTime;
                entry.Result = log.Result;
                entry.IsException = log.IsException;
                entry.IsSuccess = log.IsSuccess;
                entry.ReturnCode = log.ReturnCode;

                await executionLogRepository.UpdateAsync(entry);
            }
            else
            {
                logger.LogWarning("Failed to UpdateExecutionLog. Cannot find run instance id [{runInstanceId}]",
                    log.RunInstanceId);
            }

            await ValueTask.CompletedTask;
        }

        public async Task MarkExecutingJobAsIncomplete(CancellationToken cancellToken = default)
        {
            await executionLogRepository.MarkExecutingJobAsIncomplete(cancellToken);
        }
    }
}

