using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity.Infrastructure;
using ContaCorrente.Model;
using ContaCorrente.Repository.Interfaces;
using ContaCorrente.Repository.Services;

namespace ContaCorrente.Web.Controllers.WebApi
{
    public class AccountTransactionsApiController : BaseApiController
    {
        IBaseService<AccountTransaction> _service;
        public AccountTransactionsApiController(AccountTransactionService service)
        {
            _service = service;
        }

        // GET: api/tracking
        [System.Web.Http.HttpGet]
        [Route("api/accountTransactions")]
        public async Task<List<AccountTransaction>> Get()
        {
            return await Task.Run(() => _service.GetAllAsync());
        }

        [Route("{id:int}")]
        [System.Web.Http.HttpGet]
        public async Task<AccountTransaction> Get(int id)
        {
            var accountTransaction = await _service.FindAsync(p => p.Id == id);
            if (accountTransaction == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return accountTransaction;
        }

        [Route("api/accountTransactions")]
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> Post(AccountTransaction accountTransaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newAccountTransaction = await _service.AddAsync(accountTransaction);
                    var response = Request.CreateResponse(HttpStatusCode.Created, newAccountTransaction);
                    return response;
                }
                else
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
