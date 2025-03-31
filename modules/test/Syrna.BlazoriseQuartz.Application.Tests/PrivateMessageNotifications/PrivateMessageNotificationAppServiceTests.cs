using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Syrna.BlazoriseQuartz.PrivateMessageNotifications
{
    public class PrivateMessageNotificationAppServiceTests : BlazoriseQuartzApplicationTestBase
    {
        private readonly IPrivateMessageNotificationAppService _privateMessageNotificationAppService;

        public PrivateMessageNotificationAppServiceTests()
        {
            _privateMessageNotificationAppService = GetRequiredService<IPrivateMessageNotificationAppService>();
        }

        [Fact]
        public virtual async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
