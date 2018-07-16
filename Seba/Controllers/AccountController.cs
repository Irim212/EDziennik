
using Microsoft.AspNetCore.Mvc;
using Seba.Dto;
using Seba.Entities;
using Seba.Global;
using Seba.Services;
using System.Linq;

namespace Seba.Controllers
{
	[Route("api/[controller]")]
	public class AccountController : Controller
	{
		AppContext appContext;
		IAccountService accountService;

		public AccountController(AppContext appContext, IAccountService accountService)
		{
			this.appContext = appContext;
			this.accountService = accountService;
		}

		[HttpGet("{id}")]
		public IActionResult GetAccount(long id)
		{
			return Ok(appContext.Accounts.Where(x => x.Id == id).FirstOrDefault());
		}

		[HttpGet]
		public IActionResult GetAccounts()
		{
			return Ok(appContext.Accounts.ToList());
		}

		[HttpPost("createaccount")]
		public IActionResult CreateAccount([FromBody] AccountDto accountDto)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if(accountService.CreateAccount(accountDto))
			{
				return Ok();
			} else
			{
				return BadRequest("Wystąpił błąd. Spróbuj ponownie później.");
			}
		}

        [HttpPost("login")]
        public IActionResult LoginAccount([FromBody] AccountLogin accountLogin)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(accountService.LoginAccount(accountLogin))
            {
                return Ok();
            } else
            {
                return BadRequest("Błąd logowania. Spróbuj ponownie.");
            }
        }
    }
}
