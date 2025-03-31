using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Syrna.BlazoriseQuartz.EntityFrameworkCore
{
    public static class BlazoriseQuartzDbContextModelCreatingExtensions
    {
        public static void ConfigureBlazoriseQuartz(
            this ModelBuilder builder,
            Action<BlazoriseQuartzModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BlazoriseQuartzModelBuilderConfigurationOptions(
                BlazoriseQuartzDbProperties.DbTablePrefix,
                BlazoriseQuartzDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

        }
    }
}
