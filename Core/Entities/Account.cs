namespace Core.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Account
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Number { get; set; }

        public decimal Balance { get; set; }

        public int? PersonId { get; set; } 

        public Person Person { get; set; }

        public int? LegalEntityId { get; set; }

        public LegalEntity LegalEntity { get; set; }
    }
}
