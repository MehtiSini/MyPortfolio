using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQuery.Contracts.Person
{
    public class PersonQueryViewModel
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? PicturePath { get; set; }
        public string? PictureAlt { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
    }
}
