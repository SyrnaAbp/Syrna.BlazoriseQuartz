using Syrna.BlazoriseQuartz.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Syrna.BlazoriseQuartz.Authorization
{
    public class BlazoriseQuartzPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(BlazoriseQuartzPermissions.GroupName, L("Permission:BlazoriseQuartz"));
            
            var privateMessages = moduleGroup.AddPermission(BlazoriseQuartzPermissions.PrivateMessages.Default, L("Permission:PrivateMessage"));
            privateMessages.AddChild(BlazoriseQuartzPermissions.PrivateMessages.Create, L("Permission:Create"));
            privateMessages.AddChild(BlazoriseQuartzPermissions.PrivateMessages.SetRead, L("Permission:SetRead"));
            privateMessages.AddChild(BlazoriseQuartzPermissions.PrivateMessages.Delete, L("Permission:Delete"));
            
            var privateMessageNotifications = moduleGroup.AddPermission(BlazoriseQuartzPermissions.PrivateMessageNotifications.Default, L("Permission:PrivateMessageNotification"));
            privateMessageNotifications.AddChild(BlazoriseQuartzPermissions.PrivateMessageNotifications.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlazoriseQuartzResource>(name);
        }
    }
}