using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Syrna.BlazoriseQuartz.MongoDB
{
    [ConnectionStringName(BlazoriseQuartzDbProperties.ConnectionStringName)]
    public class BlazoriseQuartzMongoDbContext : AbpMongoDbContext, IBlazoriseQuartzMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureBlazoriseQuartz();
        }
    }
}