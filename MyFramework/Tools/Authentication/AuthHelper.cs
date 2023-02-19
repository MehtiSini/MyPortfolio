using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MyFramework.Tools.Authentication
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var Account = new AuthViewModel();

            if (!IsAuthenticated())
                return Account;

            //below Code helps us To Access the cliams To set data for Current User
            var claims = _contextAccessor.HttpContext.User.Claims.ToList();

            Account.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            Account.Username = claims.FirstOrDefault(x => x.Type == "Username").Value;
            Account.Fullname = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            Account.Mobile = claims.FirstOrDefault(x => x.Type == "Mobile").Value;
            return Account;
        }

        public long GetCurrentAccountId()
        {
            if (IsAuthenticated())
            {
                return long.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            }
            return 0;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            //return claims.Count > 0;
        }

        public void SignIn(AuthViewModel account)
        {
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim("Username", account.Username), // Or Use ClaimTypes.NameIdentifier
                new Claim("Mobile", account.Mobile),
            };

            //So by using the below code we are actually Passing the claims to the cookie 
            //So We Can use the Real time Datas in the Cookies

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //Here We can Choose Some Situations For The Tokens (like ExpireDate)
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        //The Below Codes is actually Remove The Cookies untill we signup Again
        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}