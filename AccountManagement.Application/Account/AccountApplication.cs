using AccountManagement.Contracts.AccountAgg;
using AccountManagement.Domain.AccountAgg;
using MyFramework.Tools.Authentication;
using MyFramework.Tools.Authentication.Password;
using MyFramework.Tools.Operations;

namespace AccountManagement.Application.Account
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher, IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
        }

        public OperationResult Register(RegisterAccount cmd)
        {
            var Operation = new OperationResult();

            if (cmd.Password != cmd.RePassword)
            {
                return Operation.Failed(OperationMessage.PasswordNotMatch);
            }

            var Password = _passwordHasher.Hash(cmd.Password);

            var Account = new AccountModel(cmd.Username, Password, cmd.Mobile, cmd.FullName);

            _accountRepository.Create(Account);
            _accountRepository.Save();

            return Operation.Succeed("ثبتنام شما با موفقیت انجام شد");
        }
        public OperationResult Login(LoginAccount Cmd)
        {
            var Operation = new OperationResult();

            var Account = _accountRepository.GetBy(Cmd.Username);

            if (Account is null) { return Operation.Failed(OperationMessage.UserNotFound); }

            (bool Verified, bool NeedsUpgrade) Result = _passwordHasher.Check(Account.Password, Cmd.Password);

            if (!Result.Verified)
            {
                return Operation.Failed(OperationMessage.UserNotFound);
            }

            var AccountId = Account.Id;
            var FullName = Account.FullName;
            var Mobile = Account.Mobile;

            var AuthViewModel = new AuthViewModel
            {
                Id = AccountId,
                Fullname = FullName,
                Username = Cmd.Username,
                Mobile = Mobile,
            };

            _authHelper.SignIn(AuthViewModel);

            return Operation.Succeed();
        }

        public OperationResult Edit(EditAccount Cmd)
        {
            var Operation = new OperationResult();

            var Account = _accountRepository.GetById(Cmd.Id);

            if (Account is null) { return Operation.Failed(OperationMessage.UserNotFound); }

            var FullName = Account.FullName;
            var Mobile = Account.Mobile;

            Account.Edit(Cmd.Username, Mobile, FullName);

            _accountRepository.Save();

            return Operation.Succeed();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public void SignOut()
        {
            _authHelper.SignOut();
        }

        public OperationResult ChangePassword(ChangePassword Cmd)
        {
            var Operation = new OperationResult();

            var Account = _accountRepository.GetById(Cmd.Id);

            if (Account is null) { return Operation.Failed(OperationMessage.UserNotFound); }

            if (Cmd.Password != Cmd.RePassword)
            {
                return Operation.Failed(OperationMessage.PasswordNotMatch);
            }

            var Password = _passwordHasher.Hash(Cmd.Password);

            Account.ChangePassword(Password);

            _accountRepository.Save();

            return Operation.Succeed("رمز عبور شما با موفقیت تغییر کرد");

        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
