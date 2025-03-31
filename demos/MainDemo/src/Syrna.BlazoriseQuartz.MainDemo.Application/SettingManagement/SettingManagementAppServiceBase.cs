using Syrna.BlazoriseQuartz.MainDemo;
using Syrna.BlazoriseQuartz.MainDemo.Localization;
using Volo.Abp.Application.Services;

namespace Syrna.BlazoriseQuartz.MainDemo.SettingManagement;

public abstract class SettingManagementAppServiceBase : ApplicationService
{
    protected SettingManagementAppServiceBase()
    {
        ObjectMapperContext = typeof(MainDemoApplicationModule);
        LocalizationResource = typeof(MainDemoResource);
    }
}
