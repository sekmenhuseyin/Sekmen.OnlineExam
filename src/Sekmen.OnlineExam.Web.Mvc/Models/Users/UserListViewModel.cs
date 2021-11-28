using System.Collections.Generic;
using Sekmen.OnlineExam.Roles.Dto;

namespace Sekmen.OnlineExam.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
