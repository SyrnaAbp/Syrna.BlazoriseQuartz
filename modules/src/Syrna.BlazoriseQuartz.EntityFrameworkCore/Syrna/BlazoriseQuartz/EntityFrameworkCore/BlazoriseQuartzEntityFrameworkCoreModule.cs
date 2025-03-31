using Syrna.BlazoriseQuartz.PrivateMessageNotifications;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    [DependsOn(
        typeof(BlazoriseQuartzDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class BlazoriseQuartzEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BlazoriseQuartzDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<PrivateMessage, PrivateMessageRepository>();
                options.AddRepository<PrivateMessageNotification, PrivateMessageNotificationRepository>();
            });
        }
    }
}
