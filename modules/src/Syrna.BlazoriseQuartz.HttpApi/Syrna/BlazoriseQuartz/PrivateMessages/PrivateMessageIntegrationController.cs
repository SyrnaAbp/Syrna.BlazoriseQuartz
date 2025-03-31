using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Syrna.BlazoriseQuartz.PrivateMessages;

[RemoteService(Name = BlazoriseQuartzRemoteServiceConsts.RemoteServiceName)]
[Route("/integration-api/private-messaging/private-message")]
public class PrivateMessageIntegrationController : BlazoriseQuartzController, IPrivateMessageIntegrationService
{
    private readonly IPrivateMessageIntegrationService _service;

    public PrivateMessageIntegrationController(IPrivateMessageIntegrationService service)
    {
        _service = service;
    }

    [HttpPost]
    public virtual Task<PrivateMessageDto> CreateAsync(CreatePrivateMessageInfoModel input)
    {
        return _service.CreateAsync(input);
    }
}