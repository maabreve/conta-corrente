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
    public class ClientService: IBaseService <Client> 
    {
        protected IUnitOfWork Uow { get; set; }

        public ClientService(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("unit of work");

            Uow = uow;
        }

        public async Task<int> AddAsync(ContaCorrente.Model.Client client)
        {
            var newClient = await Uow.Clients.AddAsync(client);
            Uow.Commit();

            return newClient;
        }

        public async Task<int> RemoveAsync(int id)
        {
            Client clientToUpdate = await Uow.Clients.FindAsync(p => p.Id == id);
            if (clientToUpdate == null)
            {
                throw new ArgumentNullException("Client");
            }

            var newCLients = await Uow.Clients.RemoveAsync(await Uow.Clients.FindAsync(p => p.Id == id));
            Uow.Commit();
            return newCLients;
        }

        public async Task<int> UpdateAsync(ContaCorrente.Model.Client client)
        {
            Client clientToUpdate = await Uow.Clients.FindAsync(c => c.Id == client.Id);
            if (clientToUpdate == null)
            {
                throw new ArgumentNullException("Client");
            }

            var newClient = await Uow.Clients.UpdateAsync(client);
            this.Uow.Commit();
            return newClient;
        }

        public async Task<List<ContaCorrente.Model.Client>> GetAllAsync()
        {
            return await Uow.Clients.GetAllAsync();
        }

        public async Task<ContaCorrente.Model.Client> FindAsync(Expression<Func<ContaCorrente.Model.Client, bool>> match)
        {
            return await Uow.Clients.FindAsync(match);
        }

        public async Task<List<ContaCorrente.Model.Client>> FindAllAsync(Expression<Func<ContaCorrente.Model.Client, bool>> match)
        {
            return await Uow.Clients.FindAllAsync(match);
        }

        public async Task<int> CountAsync()
        {
            return await Uow.Clients.CountAsync();
        }

    }
}
