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
    public class AccountTransactionService : IBaseService<AccountTransaction>
    {
        protected IUnitOfWork Uow { get; set; }

        public AccountTransactionService(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("unit of work");

            Uow = uow;
        }

        public async Task<int> AddAsync(ContaCorrente.Model.AccountTransaction accountTransaction)
        {
            Account accountToUpdate = await Uow.Accounts.FindAsync(a => a.Id == accountTransaction.AccountId);
            if (accountToUpdate == null)
            {
                throw new ArgumentNullException("Account");
            }

            try
            {
                accountToUpdate.CurrentBalance = accountToUpdate.CurrentBalance + accountTransaction.TransactionValue;
                Uow.Accounts.Detach(accountToUpdate);
                var accountUpdated = await Uow.Accounts.UpdateAsync(accountToUpdate);
                var newAccountTransaction = await Uow.AccountTransactions.AddAsync(accountTransaction);

                this.Uow.Commit();
                return newAccountTransaction;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            throw new Exception("Not implemented");
        }

        public async Task<int> UpdateAsync(ContaCorrente.Model.AccountTransaction accountTransaction)
        {
            throw new Exception("Not implemented");
        }

        public async Task<List<ContaCorrente.Model.AccountTransaction>> GetAllAsync()
        {
            return await Uow.AccountTransactions.GetAllAsync();
        }

        public async Task<ContaCorrente.Model.AccountTransaction> FindAsync(Expression<Func<ContaCorrente.Model.AccountTransaction, bool>> match)
        {
            return await Uow.AccountTransactions.FindAsync(match);
        }

        public async Task<List<ContaCorrente.Model.AccountTransaction>> FindAllAsync(Expression<Func<ContaCorrente.Model.AccountTransaction, bool>> match)
        {
            return await Uow.AccountTransactions.FindAllAsync(match);
        }

        public async Task<int> CountAsync()
        {
            return await Uow.AccountTransactions.CountAsync();
        }

    }
}
