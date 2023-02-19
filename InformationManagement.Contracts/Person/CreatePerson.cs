using Microsoft.AspNetCore.Http;
using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace InformationManagement.Contracts.Person
{
    public class CreatePerson
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? FullName { get; set; }
        public IFormFile? PicturePath { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Email { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Description { get; set; }

        public bool IsFreelancer { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Address { get; set; }
    }
}
