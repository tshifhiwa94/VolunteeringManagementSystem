using System.ComponentModel.DataAnnotations;

namespace VolunteeringManagementSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}