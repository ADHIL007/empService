using empService.Entities;

namespace empService.Services
{
    public class UserPermissionCheckService
    {


        public bool HasPermission(User user, string permission)
        {

            return user.Permissions.Contains(permission);

        }
    }
}