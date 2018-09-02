using ContaCorrente.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContaCorrente.Repository.Mappings
{
    internal partial class ClientMappings : EntityTypeConfiguration<Client>
    {
        public ClientMappings()
        {
            ToTable("Client");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Name").IsUnicode(false).HasMaxLength(128).IsRequired();
        }
    }
}
