using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace Syrna.BlazoriseQuartz.ObjectExtending;

public class BlazoriseQuartzModuleExtensionConfiguration : ModuleExtensionConfiguration
{
    public BlazoriseQuartzModuleExtensionConfiguration ConfigurePrivateMessage(
        Action<EntityExtensionConfiguration> configureAction)
    {
        return this.ConfigureEntity(
            BlazoriseQuartzModuleExtensionConsts.EntityNames.PrivateMessage,
            configureAction
        );
    }
}
