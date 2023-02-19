using MyFramework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class AccountModel : EntityBase
    {
        public string? FullName { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public string? Mobile { get; private set; }

        public AccountModel(string? username, string? password, string? mobile, string? fullName)
        {
            Username = username;
            Password = password;
            Mobile = mobile;
            FullName = fullName;
        }

        public void Edit(string? username, string? mobile, string? fullName)
        {
            Username = username;
            Mobile = mobile;
            FullName = fullName;
        }
        public void ChangePassword(string? password)
        {
            Password = password;
        }

    }
}
