using Syrna.BlazoriseQuartz.PrivateMessageNotifications;
using Syrna.BlazoriseQuartz.PrivateMessages;
using System;
using Microsoft.EntityFrameworkCore;
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

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureFullAuditedAggregateRoot();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            builder.Entity<PrivateMessage>(b =>
            {
                b.ToTable(options.TablePrefix + "PrivateMessages", options.Schema);
                b.ConfigureByConvention(); 
                /* Configure more properties here */
                b.HasIndex(m => m.ToUserId);
                b.HasIndex(m => m.FromUserId);
            });

            builder.Entity<PrivateMessageNotification>(b =>
            {
                b.ToTable(options.TablePrefix + "PrivateMessageNotifications", options.Schema);
                b.ConfigureByConvention();
                /* Configure more properties here */
                b.HasIndex(n => n.UserId);
                b.HasIndex(n => n.PrivateMessageId);
            });
        }
    }
}
