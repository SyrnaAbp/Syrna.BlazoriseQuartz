using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Syrna.BlazoriseQuartz.PrivateMessageNotifications;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public class BlazoriseQuartzDbContext : AbpDbContext<BlazoriseQuartzDbContext>, IBlazoriseQuartzDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<PrivateMessageNotification> PrivateMessageNotifications { get; set; }
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
