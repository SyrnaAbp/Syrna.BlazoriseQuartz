using System;
using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.PrivateMessageNotifications;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore.PrivateMessageNotifications
{
    public class PrivateMessageNotificationRepositoryTests : BlazoriseQuartzEntityFrameworkCoreTestBase
    {
        private readonly IRepository<PrivateMessageNotification, Guid> _privateMessageNotificationRepository;

        public PrivateMessageNotificationRepositoryTests()
        {
            _privateMessageNotificationRepository = GetRequiredService<IRepository<PrivateMessageNotification, Guid>>();
        }

        [Fact]
        public virtual async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
