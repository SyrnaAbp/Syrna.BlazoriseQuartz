using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.Authorization;
using Syrna.BlazoriseQuartz.PrivateMessageNotifications.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Syrna.BlazoriseQuartz.PrivateMessageNotifications
{
    [Authorize]
    public class PrivateMessageNotificationAppService : ApplicationService, IPrivateMessageNotificationAppService
    {
        private readonly IPrivateMessageNotificationRepository _repository;

        public PrivateMessageNotificationAppService(
            IPrivateMessageNotificationRepository repository)
        {
            _repository = repository;
        }

        [Authorize(BlazoriseQuartzPermissions.PrivateMessageNotifications.Default)]
        public virtual async Task<long> CountAsync()
        {
            return await _repository.CountByUserIdAsync(CurrentUser.GetId());
        }

        [Authorize(BlazoriseQuartzPermissions.PrivateMessageNotifications.Delete)]
        public virtual async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            foreach (var id in ids)
            {
                var notification = await _repository.GetAsync(id);

                await AuthorizationService.CheckAsync(notification,
                    BlazoriseQuartzPermissions.PrivateMessageNotifications.Delete);

                await _repository.DeleteAsync(notification, true);
            }
        }

        [Authorize(BlazoriseQuartzPermissions.PrivateMessageNotifications.Default)]
        public virtual async Task<PagedResultDto<PrivateMessageNotificationDto>> GetListAsync(PagedResultRequestDto input)
        {
            var count = await _repository.CountByUserIdAsync(CurrentUser.GetId());

            var list = await _repository.GetListByUserIdAsync(CurrentUser.GetId(), input.SkipCount,
                input.MaxResultCount);

            return new PagedResultDto<PrivateMessageNotificationDto>(count,
                ObjectMapper.Map<IReadOnlyList<PrivateMessageNotification>, IReadOnlyList<PrivateMessageNotificationDto>>(list));
        }
    }
}