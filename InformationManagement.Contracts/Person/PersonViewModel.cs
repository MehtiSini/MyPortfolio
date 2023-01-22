﻿using Microsoft.AspNetCore.Http;

namespace InformationManagement.Contracts.Person
{
    public class PersonViewModel
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public IFormFile? PicturePath { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? ShortDescription { get; set; }
        public bool IsFreelancer { get; set; }
        public string? Address { get; set; }
        public string? CreationDate { get; set; }
    }

}
