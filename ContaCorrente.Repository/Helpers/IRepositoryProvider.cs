using System;
using System.Data.Entity;
using ContaCorrente.Repository.Interfaces;

namespace ContaCorrente.Repository
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }
        IBaseRepository<T> GetRepositoryForEntityType<T>() where T : class;
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
        void SetRepository<T>(T repository);
    }
}
