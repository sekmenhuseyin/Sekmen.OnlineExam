using System.Collections.Generic;
using Sekmen.OnlineExam.Roles.Dto;

namespace Sekmen.OnlineExam.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
