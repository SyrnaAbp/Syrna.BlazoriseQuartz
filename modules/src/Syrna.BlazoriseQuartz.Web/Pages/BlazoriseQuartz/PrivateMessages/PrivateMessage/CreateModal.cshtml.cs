using System;
using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using Microsoft.AspNetCore.Mvc;
using CreatePrivateMessageInfoModel = Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage.InfoModels.CreatePrivateMessageInfoModel;

namespace Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage
{
    public class CreateModalModel : BlazoriseQuartzPageModel
    {
        [BindProperty]
        public CreatePrivateMessageInfoModel PrivateMessage { get; set; } = new();

        private readonly IPrivateMessageAppService _service;

        public CreateModalModel(IPrivateMessageAppService service)
        {
            _service = service;
        }

        public virtual Task OnGetAsync(string toUserName)
        {
            PrivateMessage.ToUserName = toUserName;
            
            return Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreatePrivateMessageInfoModel, CreatePrivateMessageDto>(PrivateMessage));
            
            return NoContent();
        }
    }
}