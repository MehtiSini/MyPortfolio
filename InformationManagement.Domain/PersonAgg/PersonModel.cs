﻿using MyFramework.Domain;

namespace InformationManagement.Domain.PersonAgg
{
    public class PersonModel : PersonEntityBase
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public bool IsFreelancer { get; private set; }
        public string? Address { get; private set; }
        public DateTime CreationDate { get; private set; }


        public PersonModel(string? fullName, string? picturePath, string? email, string? mobile, string? shortDescription, 
            bool isFreelancer, string? address, string? description)
        {
            FullName = fullName;
            PicturePath = picturePath;
            Email = email;
            Mobile = mobile;
            ShortDescription = shortDescription;
            IsFreelancer = isFreelancer;
            Address = address;
            CreationDate = DateTime.Now;
            Description = description;
        }
        public void Edit(string? fullName, string? picturePath, string? email, string? mobile, string? shortDescription,
            bool isFreelancer, string? address, string? description)
        {
            FullName = fullName;
            PicturePath = picturePath;
            Email = email;
            Mobile = mobile;
            ShortDescription = shortDescription;
            IsFreelancer = isFreelancer;
            Address = address;
            CreationDate = DateTime.Now;
            Description = description;
        }
    }
}