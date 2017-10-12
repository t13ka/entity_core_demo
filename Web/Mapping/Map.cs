namespace Web.Mapping
{
    using System.Collections.Generic;

    using AutoMapper;

    using Core.Entities;

    using Web.ViewModels;

    public static class Map
    {
        static Map()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Account, AccountOwnerEntryViewModel>());
        }

        public static AccountOwnerEntryViewModel TomViewModel(this Account item)
        {
            var model = Mapper.Map<Account, AccountOwnerEntryViewModel>(item);
            return model;
        }

        public static IEnumerable<AccountOwnerEntryViewModel> TomViewModel(this IEnumerable<Account> items)
        {
            var model = Mapper.Map<IEnumerable<Account>, IEnumerable<AccountOwnerEntryViewModel>>(items);
            return model;
        }
    }
}
