using System.ComponentModel.DataAnnotations;

namespace Sekmen.OnlineExam.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}