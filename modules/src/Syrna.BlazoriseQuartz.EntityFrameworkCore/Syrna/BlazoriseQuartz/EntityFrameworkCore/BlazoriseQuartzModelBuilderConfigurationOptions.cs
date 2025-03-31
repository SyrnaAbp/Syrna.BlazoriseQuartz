using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    public class BlazoriseQuartzModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public BlazoriseQuartzModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}