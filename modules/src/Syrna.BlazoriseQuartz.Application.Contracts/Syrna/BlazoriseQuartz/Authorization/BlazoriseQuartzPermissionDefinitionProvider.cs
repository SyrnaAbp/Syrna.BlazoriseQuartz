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
            
            var schedulePermissions = moduleGroup.AddPermission(BlazoriseQuartzPermissions.Schedules.Default, L("Permission:Schedules"));
            schedulePermissions.AddChild(BlazoriseQuartzPermissions.Schedules.Create, L("Permission:Schedules.Create"));
            schedulePermissions.AddChild(BlazoriseQuartzPermissions.Schedules.Update, L("Permission:Schedules.Update"));
            schedulePermissions.AddChild(BlazoriseQuartzPermissions.Schedules.Delete, L("Permission:Schedules.Delete"));
            
            var historyPermissions = moduleGroup.AddPermission(BlazoriseQuartzPermissions.History.Default, L("Permission:History"));
            historyPermissions.AddChild(BlazoriseQuartzPermissions.History.Delete, L("Permission:History.Delete"));

            var overviewPermissions = moduleGroup.AddPermission(BlazoriseQuartzPermissions.Overview.Default, L("Permission:Overview"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlazoriseQuartzResource>(name);
        }
    }
}