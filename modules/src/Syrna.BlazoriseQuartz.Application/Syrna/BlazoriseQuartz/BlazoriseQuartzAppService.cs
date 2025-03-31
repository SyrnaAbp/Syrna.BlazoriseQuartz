using Syrna.BlazoriseQuartz.Localization;
using Volo.Abp.Application.Services;

namespace Syrna.BlazoriseQuartz
{
    public abstract class BlazoriseQuartzAppService : ApplicationService
    {
        protected BlazoriseQuartzAppService()
        {
            LocalizationResource = typeof(BlazoriseQuartzResource);
            ObjectMapperContext = typeof(BlazoriseQuartzApplicationModule);
        }
    }
}
