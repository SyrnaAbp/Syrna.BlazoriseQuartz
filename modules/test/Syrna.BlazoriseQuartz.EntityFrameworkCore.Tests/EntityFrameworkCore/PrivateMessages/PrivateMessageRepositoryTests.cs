using System;
using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore.PrivateMessages
{
    public class PrivateMessageRepositoryTests : BlazoriseQuartzEntityFrameworkCoreTestBase
    {
        private readonly IRepository<PrivateMessage, Guid> _privateMessageRepository;

        public PrivateMessageRepositoryTests()
        {
            _privateMessageRepository = GetRequiredService<IRepository<PrivateMessage, Guid>>();
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
