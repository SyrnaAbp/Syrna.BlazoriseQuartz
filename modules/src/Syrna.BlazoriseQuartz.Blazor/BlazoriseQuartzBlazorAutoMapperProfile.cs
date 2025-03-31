using AutoMapper;
using Syrna.BlazoriseQuartz.Blazor.Pages.BlazoriseQuartz.InfoModels;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using Volo.Abp.AutoMapper;

namespace Syrna.BlazoriseQuartz.Blazor
{
    public class BlazoriseQuartzBlazorAutoMapperProfile : Profile
    {
        public BlazoriseQuartzBlazorAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PrivateMessageDto, CreatePrivateMessageDto>().Ignore(x => x.ExtraProperties);
            CreateMap<PrivateMessageDto, DetailsPrivateMessageViewModel>().Ignore(x => x.ExtraProperties);
            CreateMap<CreatePrivateMessageViewModel, CreatePrivateMessageDto>().Ignore(x => x.ExtraProperties);
            CreateMap<PrivateMessageDto, PrivateMessageViewModel>().Ignore(x => x.ExtraProperties);
        }
    }
}