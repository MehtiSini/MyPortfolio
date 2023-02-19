namespace MyFramework.Tools.Authentication
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void SignIn(AuthViewModel account);
        AuthViewModel CurrentAccountInfo();
    }
}
