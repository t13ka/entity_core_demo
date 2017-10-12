namespace Core
{
    using System.Collections.Generic;

    using Core.Entities;

    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void SwapAccounts();
    }
}