using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace Syrna.BlazoriseQuartz.ObjectExtending;

public static class BlazoriseQuartzModuleExtensionConfigurationDictionaryExtensions
{
    public static ModuleExtensionConfigurationDictionary ConfigureBlazoriseQuartz(
        this ModuleExtensionConfigurationDictionary modules,
        Action<BlazoriseQuartzModuleExtensionConfiguration> configureAction)
    {
        return modules.ConfigureModule(
            BlazoriseQuartzModuleExtensionConsts.ModuleName,
            configureAction
        );
    }
}
