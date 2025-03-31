using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Syrna.BlazoriseQuartz.PrivateMessageNotifications;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public interface IBlazoriseQuartzDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<PrivateMessage> PrivateMessages { get; set; }
        DbSet<PrivateMessageNotification> PrivateMessageNotifications { get; set; }
    }
}
