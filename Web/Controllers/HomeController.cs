namespace Web.Controllers
{
    using System.Linq;

    using Core;

    using Microsoft.AspNetCore.Mvc;

    using Web.ViewModels;

    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var accounts = _accountService.GetAccounts();

            // here we can also to use mapping. I not include this to demo code, but you may check in class Map.cs to get an idea
            var result = accounts.Select(
                t =>
                    {
                        if (t.LegalEntity != null)
                        {
                            return new AccountOwnerEntryViewModel
                                       {
                                           Id = t.Id,
                                           Balance = t.Balance,
                                           Number = t.Number,
                                           OwnerName = t.LegalEntity.Name,
                                           LegalEntityType = t.LegalEntity.LegalEntityType
                                       };
                        }

                        return new AccountOwnerEntryViewModel
                                   {
                                       Id = t.Id,
                                       Balance = t.Balance,
                                       Number = t.Number,
                                       OwnerName = $"{t.Person.Surname} {t.Person.Name}",
                                       LegalEntityType = LegalEntityTypes.Person
                                   };
                    });

            return View(result);
        }
    }
}