using Syrna.BlazoriseQuartz.MainDemo.Localization;
using Volo.Abp.Application.Services;

namespace Syrna.BlazoriseQuartz.MainDemo;

/* Inherit your application services from this class.
 */
public abstract class MainDemoAppService : ApplicationService
{
    protected MainDemoAppService()
    {
        LocalizationResource = typeof(MainDemoResource);
    }
}
