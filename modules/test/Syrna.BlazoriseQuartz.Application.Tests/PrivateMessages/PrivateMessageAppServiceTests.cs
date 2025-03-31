using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Syrna.BlazoriseQuartz.PrivateMessages
{
    public class PrivateMessageAppServiceTests : BlazoriseQuartzApplicationTestBase
    {
        private readonly IPrivateMessageAppService _privateMessageAppService;

        public PrivateMessageAppServiceTests()
        {
            _privateMessageAppService = GetRequiredService<IPrivateMessageAppService>();
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
