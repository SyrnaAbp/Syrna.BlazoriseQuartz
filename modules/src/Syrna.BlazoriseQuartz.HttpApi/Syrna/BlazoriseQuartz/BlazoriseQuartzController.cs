using Syrna.BlazoriseQuartz.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Syrna.BlazoriseQuartz
{
    [Area(BlazoriseQuartzRemoteServiceConsts.ModuleName)]
    public abstract class BlazoriseQuartzController : AbpController
    {
        protected BlazoriseQuartzController()
        {
            LocalizationResource = typeof(BlazoriseQuartzResource);
        }
    }
}
