using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ContaCorrente.Model;
using ContaCorrente.Repository.Mappings;

namespace ContaCorrente.Repository
{
    public class ContaCorrenteDbContext : DbContext
    {
        public ContaCorrenteDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
           Configuration.ProxyCreationEnabled = false;
        }

        public static ContaCorrenteDbContext Create()
        {
            return new ContaCorrenteDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClientMappings());
            modelBuilder.Configurations.Add(new AccountMappings());
            modelBuilder.Configurations.Add(new AccountTransactionMappings());
            
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; }
    }
}