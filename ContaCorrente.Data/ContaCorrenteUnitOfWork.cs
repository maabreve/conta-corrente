using System;
using ContaCorrente.Repository.Interfaces;
using ContaCorrente.Model;

namespace ContaCorrente.Repository
{
    public class ContaCorrenteUow : IUnitOfWork, IDisposable
    {
        public ContaCorrenteUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IBaseRepository<Account> Accounts { get { return GetStandardRepo<Account>(); } }
        public IBaseRepository<AccountTransaction> AccountTransactions { get { return GetStandardRepo<AccountTransaction>(); } }
        public IClientRepository Clients { get { return GetRepo<IClientRepository>(); } }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new ContaCorrenteDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IBaseRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private ContaCorrenteDbContext DbContext { get; set; }
        
        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}