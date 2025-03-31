using System.Security.Principal;
using System.Threading.Tasks;
using Syrna.BlazoriseQuartz.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.DependencyInjection;

namespace Syrna.BlazoriseQuartz.PrivateMessages
{
    public class PrivateMessageAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, PrivateMessage>, ISingletonDependency
    {
        private readonly IPermissionChecker _permissionChecker;

        public PrivateMessageAuthorizationHandler(
            IPermissionChecker permissionChecker)
        {
            _permissionChecker = permissionChecker;
        }
        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, PrivateMessage resource)
        {
            if (requirement.Name.Equals(BlazoriseQuartzPermissions.PrivateMessages.Default) &&
                await HasGetPermissionAsync(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
            
            if (requirement.Name.Equals(BlazoriseQuartzPermissions.PrivateMessages.Delete) &&
                await HasDeletePermissionAsync(context, resource))
            {
                context.Succeed(requirement);
                return;
            }

            if (requirement.Name.Equals(BlazoriseQuartzPermissions.PrivateMessages.SetRead) &&
                await HasSetReadPermissionAsync(context, resource))
            {
                context.Succeed(requirement);
                return;
            }
            
            context.Fail();
        }

        protected virtual async Task<bool> HasGetPermissionAsync(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            var currentUserId = context.User.FindUserId();
            
            return (resource.ToUserId == currentUserId || resource.FromUserId == currentUserId) &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       BlazoriseQuartzPermissions.PrivateMessages.Delete);
        }

        protected virtual async Task<bool> HasDeletePermissionAsync(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            return resource.ToUserId == context.User.FindUserId() &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       BlazoriseQuartzPermissions.PrivateMessages.Delete);
        }
        
        protected virtual async Task<bool> HasSetReadPermissionAsync(AuthorizationHandlerContext context, PrivateMessage resource)
        {
            return resource.ToUserId == context.User.FindUserId() &&
                   await _permissionChecker.IsGrantedAsync(context.User,
                       BlazoriseQuartzPermissions.PrivateMessages.SetRead);
        }
    }
}