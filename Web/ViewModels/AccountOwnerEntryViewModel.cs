namespace Web.ViewModels
{
    using Core;

    public class AccountOwnerEntryViewModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }

        public LegalEntityTypes LegalEntityType { get; set; }

        public string OwnerName { get; set; }
    }
}
