using Seba.Dto;
using Seba.Entities;
using Seba.Global;
using System.Linq;

namespace Seba.Services
{
	public interface IAccountService
	{
		bool CreateAccount(AccountDto accountDto);
        bool LoginAccount(AccountLogin accountLogin);
	}


	public class AccountService : IAccountService
	{
		AppContext appContext;

		public AccountService(AppContext appContext)
		{
			this.appContext = appContext;
		}

		public bool CreateAccount(AccountDto accountDto)
		{
			if (appContext.Accounts.Any(x => x.Email == accountDto.Email || x.Login == accountDto.Login))
			{
				return false;
			}

            Account newAccount = new Account
            {
                Email = accountDto.Email,
                Login = accountDto.Login,
                FirstName = accountDto.FirstName,
                LastName = accountDto.LastName,
				PasswordHash = accountDto.Password,
				PasswordSalt = accountDto.Password,
			};

			appContext.Accounts.Add(newAccount);
			appContext.SaveChanges();

			return true;
		}

        public bool LoginAccount(AccountLogin accountLogin)
        {
            if(appContext.Accounts.Any(x => x.Login == accountLogin.Login && x.PasswordHash == accountLogin.Password))
            {
                return true;
            } else {
                return false;
            }
        }
	}
}
