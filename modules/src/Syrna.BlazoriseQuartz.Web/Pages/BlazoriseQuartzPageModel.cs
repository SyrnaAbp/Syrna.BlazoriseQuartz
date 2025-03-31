using Syrna.BlazoriseQuartz.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Syrna.BlazoriseQuartz.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class BlazoriseQuartzPageModel : AbpPageModel
    {
        protected BlazoriseQuartzPageModel()
        {
            LocalizationResourceType = typeof(BlazoriseQuartzResource);
            ObjectMapperContext = typeof(BlazoriseQuartzWebModule);
        }
    }
}