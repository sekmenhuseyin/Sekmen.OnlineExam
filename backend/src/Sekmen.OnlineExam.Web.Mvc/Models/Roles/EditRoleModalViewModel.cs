using Abp.AutoMapper;
using Sekmen.OnlineExam.Roles.Dto;
using Sekmen.OnlineExam.Web.Models.Common;

namespace Sekmen.OnlineExam.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
