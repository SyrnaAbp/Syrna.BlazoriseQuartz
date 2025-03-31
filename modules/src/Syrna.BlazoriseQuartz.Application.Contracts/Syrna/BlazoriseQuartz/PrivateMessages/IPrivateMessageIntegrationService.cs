using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Syrna.BlazoriseQuartz.PrivateMessages;

[IntegrationService]
public interface IPrivateMessageIntegrationService : IApplicationService
{
    Task<PrivateMessageDto> CreateAsync(CreatePrivateMessageInfoModel input);
}