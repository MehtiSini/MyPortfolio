using Microsoft.AspNetCore.Http;

namespace InformationManagement.Contracts.Person
{
    public class CreatePerson
    {
        public string? FullName { get; set; }
        public IFormFile? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public bool IsFreelancer { get; set; }
        public string? Address { get; set; }
    }
}
