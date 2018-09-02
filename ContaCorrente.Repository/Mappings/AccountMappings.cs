using ContaCorrente.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContaCorrente.Repository.Mappings
{
    internal partial class AccountMappings : EntityTypeConfiguration<Account>
    {
        public AccountMappings()
        {
            ToTable("Account");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ClientId).HasColumnName("ClientId").IsRequired();
            Property(t => t.AccountCode).HasColumnName("AccountCode").IsUnicode(false).HasMaxLength(56).IsRequired();
        }
    }
}
