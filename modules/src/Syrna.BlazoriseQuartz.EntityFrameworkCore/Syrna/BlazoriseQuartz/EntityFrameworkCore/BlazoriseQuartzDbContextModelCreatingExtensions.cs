using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    public static class BlazoriseQuartzDbContextModelCreatingExtensions
    {
        public static void ConfigureBlazoriseQuartz(
            this ModelBuilder builder,
            Action<BlazoriseQuartzModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BlazoriseQuartzModelBuilderConfigurationOptions(
                BlazoriseQuartzDbProperties.DbTablePrefix,
                BlazoriseQuartzDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<ExecutionLog.ExecutionLog>(b =>
            {
                b.ConfigureByConvention();
                b.ToTable($"{options.TablePrefix}ExecutionHistory", options.Schema);
                b.OwnsOne(l => l.ExecutionLogDetail, e =>
                {
                    e.ToTable($"{options.TablePrefix}ExecutionHistoryDetail", options.Schema);
                    e.WithOwner().HasForeignKey(x => x.LogId);
                });

                b.HasIndex(l => l.RunInstanceId).IsUnique();

                // for housekeeping or system log display
                b.HasIndex(l => new { l.DateAddedUtc, l.LogType });

                // joining with job
                b.HasIndex(l => new { l.TriggerName, l.TriggerGroup, l.JobName, l.JobGroup, l.DateAddedUtc });

                b.Property(e => e.LogType).HasConversion<string>();

            });
        }
    }
}
