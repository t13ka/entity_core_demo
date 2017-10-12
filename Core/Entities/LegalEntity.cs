namespace Core.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class LegalEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public LegalEntityTypes LegalEntityType { get; set; }
    }
}
