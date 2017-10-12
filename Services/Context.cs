namespace Services
{
    using System;

    using Core;
    using Core.Entities;

    using Microsoft.EntityFrameworkCore;

    internal class Context : DbContext
    {
        static Context()
        {
            using (var client = new Context())
            {
                client.Database.EnsureCreated();
                client.Persons.Clear();
                client.LegalEntities.Clear();
                client.Accounts.Clear();
                client.SaveChanges();

                var p1 = new Person { BirthDate = new DateTime(1982, 3, 7), Name = "Andrey", Surname = "Ivanov" };
                var p2 = new Person { BirthDate = new DateTime(1975, 4, 13), Name = "Sergey", Surname = "Petrov" };
                client.Persons.Add(p1);
                client.Persons.Add(p2);

                var le1 = new LegalEntity { LegalEntityType = LegalEntityTypes.OOO, Name = "Microsoft" };
                var le2 = new LegalEntity { LegalEntityType = LegalEntityTypes.AO, Name = "Apple" };
                client.LegalEntities.Add(le1);
                client.LegalEntities.Add(le2);

                client.SaveChanges();

                client.Accounts.Add(new Account { Balance = 900, Number = "5678", Person = p1 });
                client.Accounts.Add(new Account { Balance = 100, Number = "7876", LegalEntity = le1 });
                client.Accounts.Add(new Account { Balance = 200, Number = "2534", LegalEntity = le2 });

                client.SaveChanges();
            }
        }

        public DbSet<LegalEntity> LegalEntities { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var yourSqlInstanceName = ".\\SQLEXPRESS";
            optionsBuilder.UseSqlServer(
                $"Server={yourSqlInstanceName};Database=EntityCoreTDatabase;Trusted_Connection=True;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
        }
    }
}