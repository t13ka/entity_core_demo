namespace Core.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
    }
}
