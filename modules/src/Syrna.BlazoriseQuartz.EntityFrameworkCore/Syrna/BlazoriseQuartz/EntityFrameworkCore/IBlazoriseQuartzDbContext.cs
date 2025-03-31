using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public interface IBlazoriseQuartzDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
