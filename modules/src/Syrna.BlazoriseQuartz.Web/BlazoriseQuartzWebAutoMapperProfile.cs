using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using AutoMapper;
using Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage.InfoModels;
using Volo.Abp.AutoMapper;

namespace Syrna.BlazoriseQuartz.Web
{
    public class BlazoriseQuartzWebAutoMapperProfile : Profile
    {
        public BlazoriseQuartzWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PrivateMessageDto, CreateOrUpdatePrivateMessageDto>();
            CreateMap<PrivateMessageDto, PrivateMessageInfoModel>();
            CreateMap<CreatePrivateMessageInfoModel, CreateOrUpdatePrivateMessageDto>().Ignore(x => x.ExtraProperties);
        }
    }
}
