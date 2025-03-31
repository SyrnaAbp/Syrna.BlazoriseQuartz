using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Syrna.BlazoriseQuartz.MongoDB
{
    public static class BlazoriseQuartzMongoDbContextExtensions
    {
        public static void ConfigureBlazoriseQuartz(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BlazoriseQuartzMongoModelBuilderConfigurationOptions(
                BlazoriseQuartzDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}