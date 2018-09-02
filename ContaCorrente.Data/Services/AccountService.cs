using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ContaCorrente.Model;
using ContaCorrente.Repository.Interfaces;

namespace ContaCorrente.Repository.Services
{
    public class AccountService : IBaseService<Account>
    {
        protected IUnitOfWork Uow { get; set; }

        public AccountService(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("unit of work");

            Uow = uow;
        }

        public async Task<int> AddAsync(ContaCorrente.Model.Account account)
        {
            var newAccount = await Uow.Accounts.AddAsync(account);
            Uow.Commit();

            return newAccount;
        }

        public async Task<int> RemoveAsync(int id)
        {
            Account accountToUpdate = await Uow.Accounts.FindAsync(p => p.Id == id);
            if (accountToUpdate == null)
            {
                throw new ArgumentNullException("Account");
            }

            var newCLients = await Uow.Accounts.RemoveAsync(await Uow.Accounts.FindAsync(p => p.Id == id));
            Uow.Commit();
            return newCLients;
        }

        public async Task<int> UpdateAsync(ContaCorrente.Model.Account account)
        {
            Account accountToUpdate = await Uow.Accounts.FindAsync(c => c.Id == account.Id);
            if (accountToUpdate == null)
            {
                throw new ArgumentNullException("Account");
            }

            var newAccount = await Uow.Accounts.UpdateAsync(account);
            this.Uow.Commit();
            return newAccount;
        }

        public async Task<List<ContaCorrente.Model.Account>> GetAllAsync()
        {
            return await Uow.Accounts.GetAllAsync();
        }

        public async Task<ContaCorrente.Model.Account> FindAsync(Expression<Func<ContaCorrente.Model.Account, bool>> match)
        {
            return await Uow.Accounts.FindAsync(match);
        }

        public async Task<List<ContaCorrente.Model.Account>> FindAllAsync(Expression<Func<ContaCorrente.Model.Account, bool>> match)
        {
            return await Uow.Accounts.FindAllAsync(match);
        }

        public async Task<int> CountAsync()
        {
            return await Uow.Accounts.CountAsync();
        }

    }
}
