using ContaCorrente.Repository.Interfaces;
using ContaCorrente.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContaCorrente.Web.Controllers.WebApi
{
    public class ClientsController : BaseApiController
    {
        public ClientsController(IUnitOfWork uow)
        {
            Uow = uow;
        }

        // GET: api/clients
        [HttpGet]
        [Route("api/clients")]
        public async Task<List<Client>> Get()
        {
            return await Task.Run(() => Uow.Clients.GetAll().ToList());
        }

    }
}