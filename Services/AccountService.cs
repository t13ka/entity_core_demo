using System;
using System.Collections.Generic;

namespace Services
{
    using System.Linq;

    using Core;
    using Core.Entities;

    using Microsoft.EntityFrameworkCore;

    public class AccountService : IAccountService
    {
        public IEnumerable<Account> GetAccounts()
        {
            using (var database = new Context())
            {
                var allAccounts = database.Accounts
                    .Include(t => t.Person)
                    .Include(t => t.LegalEntity)
                    .ToList();
                return allAccounts;
            }
        }

        public void SwapAccounts()
        {
            using (var database = new Context())
            {
                var account5678 = database.Accounts.FirstOrDefault(t => t.Number == "5678");
                var account7876 = database.Accounts.FirstOrDefault(t => t.Number == "7876");

                if (account5678 != null && account7876 != null)
                {
                    Swap(account5678, account7876);

                    database.SaveChanges();
                }
                else
                {
                    throw new Exception("Can't change account owner");
                }
            }
        }

        private void Swap(Account from, Account to)
        {
            if (from.LegalEntityId.HasValue && to.LegalEntityId.HasValue == false)
            {
                to.LegalEntityId = from.LegalEntityId.Value;
                from.LegalEntityId = null;
            }
            else if (from.LegalEntityId.HasValue == false && to.LegalEntityId.HasValue)
            {
                from.LegalEntityId = to.LegalEntityId.Value;
                to.LegalEntityId = null;
            }

            if (from.PersonId.HasValue && to.PersonId.HasValue == false)
            {
                to.PersonId = from.PersonId.Value;
                from.PersonId = null;
            }
            else if (from.PersonId.HasValue == false && to.PersonId.HasValue)
            {
                from.PersonId = to.PersonId.Value;
                to.PersonId = null;
            }
        }
    }
}