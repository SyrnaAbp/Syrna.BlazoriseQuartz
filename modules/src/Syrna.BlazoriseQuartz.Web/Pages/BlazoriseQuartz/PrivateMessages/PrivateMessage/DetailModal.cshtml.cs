using System;
using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.PrivateMessages;
using Syrna.BlazoriseQuartz.PrivateMessages.Dtos;
using Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage.InfoModels;

namespace Syrna.BlazoriseQuartz.Web.Pages.BlazoriseQuartz.PrivateMessages.PrivateMessage
{
    public class DetailModalModel : BlazoriseQuartzPageModel
    {
        public bool IsSystemUserMessage { get; set; }
        
        public PrivateMessageInfoModel PrivateMessage { get; set; }

        private readonly IPrivateMessageAppService _service;

        public DetailModalModel(IPrivateMessageAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync(Guid id)
        {
            PrivateMessage = ObjectMapper.Map<PrivateMessageDto, PrivateMessageInfoModel>(await _service.GetAsync(id));

            if (PrivateMessage.FromUserName.IsNullOrEmpty())
            {
                PrivateMessage.FromUserName = L["SystemUserName"];
                IsSystemUserMessage = true;
            }
        }
    }
}