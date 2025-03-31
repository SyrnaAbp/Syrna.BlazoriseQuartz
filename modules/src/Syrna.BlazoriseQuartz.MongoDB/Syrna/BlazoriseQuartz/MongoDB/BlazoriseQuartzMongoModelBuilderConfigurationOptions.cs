using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Syrna.BlazoriseQuartz.MongoDB
{
    public class BlazoriseQuartzMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public BlazoriseQuartzMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}