using Syrna.BlazoriseQuartz.PrivateMessages;
using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using Syrna.BlazoriseQuartz.PrivateMessageNotifications;
using Syrna.BlazoriseQuartz.PrivateMessageNotifications.Dtos;
using AutoMapper;
using Syrna.BlazoriseQuartz.Users;
using Syrna.BlazoriseQuartz.Users.Dtos;
using Volo.Abp.Users;

namespace Syrna.BlazoriseQuartz
{
    public class BlazoriseQuartzApplicationAutoMapperProfile : Profile
    {
        public BlazoriseQuartzApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PrivateMessage, PrivateMessageDto>();
            CreateMap<CreateOrUpdatePrivateMessageDto, PrivateMessage>(MemberList.Source);
            CreateMap<PrivateMessageNotification, PrivateMessageNotificationDto>();
            CreateMap<IUserData, PmUserDto>();
        }
    }
}
