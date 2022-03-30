using Abp.Auditing;
using Abp.Extensions;
using Sekmen.OnlineExam.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.Web.Models.Account
{
    public class RegisterViewModel : IValidatableObject
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisableAuditing]
        public string Password { get; set; }

        public bool IsExternalLogin { get; set; }

        public string ExternalLoginAuthSchema { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!UserName.IsNullOrEmpty())
            {
                if (!UserName.Equals(EmailAddress) && ValidationHelper.IsEmail(UserName))
                {
                    yield return new ValidationResult("Username cannot be an email address unless it's the same as your email address!");
                }
            }
        }
    }
}
