using ContaCorrente.Model;
using System.Data.Entity;
using System.Linq;

namespace ContaCorrente.Repository.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        IQueryable<Client> GetAll();
    }
}
