using Volo.Abp.Reflection;

namespace Syrna.BlazoriseQuartz.Authorization
{
    public class BlazoriseQuartzPermissions
    {
        public const string GroupName = "Syrna.BlazoriseQuartz";
        
        public class PrivateMessages
        {
            public const string Default = GroupName + ".PrivateMessage";
            
            public const string Create = Default + ".Create";
            
            public const string SetRead = Default + ".SetRead";
            
            public const string Delete = Default + ".Delete";
        }
        
        public class PrivateMessageNotifications
        {
            public const string Default = GroupName + ".PrivateMessageNotification";
            
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BlazoriseQuartzPermissions));
        }
    }
}