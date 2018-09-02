using System.Data.Entity;
using System.Linq;
using ContaCorrente.Model;
using ContaCorrente.Repository.Interfaces;
using System.Threading.Tasks;

namespace ContaCorrente.Repository
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable<Client> GetAll()
        {
            return DbSet;
        }
    }
}