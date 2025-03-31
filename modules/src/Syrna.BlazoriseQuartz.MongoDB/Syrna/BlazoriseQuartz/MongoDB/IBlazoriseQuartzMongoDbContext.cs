using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Syrna.BlazoriseQuartz.MongoDB
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public interface IBlazoriseQuartzMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
