using ContaCorrente.Model;

namespace ContaCorrente.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        IBaseRepository<Account> Accounts { get; }
        IClientRepository Clients { get; }
        IBaseRepository<AccountTransaction> AccountTransactions { get; }
    }
}