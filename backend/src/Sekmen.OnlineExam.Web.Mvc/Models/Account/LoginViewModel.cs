﻿using System.ComponentModel.DataAnnotations;
using Abp.Auditing;

namespace Sekmen.OnlineExam.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        [DisableAuditing]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
