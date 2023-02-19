using System.Collections.Generic;

namespace MyFramework.Tools.Authentication
{
    public class AuthViewModel
    {
        // These Are our Users Data
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string ProfilePhoto { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, string fullname, string username, string mobile)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
        }
    }
}