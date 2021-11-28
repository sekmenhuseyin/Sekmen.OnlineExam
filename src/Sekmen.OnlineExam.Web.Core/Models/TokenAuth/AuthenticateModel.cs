using Abp.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [DisableAuditing]
        public string Password { get; set; }

        public bool RememberClient { get; set; }
    }
}
