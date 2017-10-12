namespace Web.Controllers
{
    using Core;

    using Microsoft.AspNetCore.Mvc;

    public class EditOwnerController : Controller
    {
        private readonly IAccountService _accountService;

        public EditOwnerController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            _accountService.SwapAccounts();

            return RedirectToAction("Index", "Home");
        }
    }
}