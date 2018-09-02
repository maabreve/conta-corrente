using ContaCorrente.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContaCorrente.Repository.Mappings
{
    internal partial class AccountTransactionMappings : EntityTypeConfiguration<AccountTransaction>
    {
        public AccountTransactionMappings()
        {
            ToTable("AccountTransaction");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.AccountId).HasColumnName("AccountId").IsRequired();
            Property(t => t.TransactionDateTime).HasColumnName("TransactionDateTime").IsRequired();
            Property(t => t.TransactionType).HasColumnName("TransactionType").IsRequired();
            Property(t => t.TransactionValue).HasColumnName("TransactionValue").IsRequired();
        }

    }
}
