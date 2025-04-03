using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public class BlazoriseQuartzDbContext : AbpDbContext<BlazoriseQuartzDbContext>, IBlazoriseQuartzDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<ExecutionLog.ExecutionLog> ExecutionLogs { get; set; } = null!;
        public BlazoriseQuartzDbContext(DbContextOptions<BlazoriseQuartzDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureBlazoriseQuartz();
        }
    }
}
