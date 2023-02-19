namespace AccountManagement.Contracts.AccountAgg
{
    public class EditAccount : LoginAccount
    {
        public long Id { get; set; }
    }


    public class ChangePassword
    { 
        public long Id { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
    }
}
