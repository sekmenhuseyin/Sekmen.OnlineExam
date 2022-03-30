using System.Collections.Generic;
using Sekmen.OnlineExam.Roles.Dto;

namespace Sekmen.OnlineExam.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}