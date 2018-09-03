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
    public class AccountsApiController : BaseApiController
    {
        IBaseService<Account> _service;
        public AccountsApiController(AccountService service)
        {
            _service = service;
        }

        // GET: api/tracking
        [System.Web.Http.HttpGet]
        [Route("api/accounts")]
        public async Task<List<Account>> Get()
        {
            return await Task.Run(() => _service.GetAllAsync());
        }

        [Route("api/accounts/{id}")]
        [System.Web.Http.HttpGet]
        public async Task<Account> Get(int id)
        {
            var account = await _service.FindAsync(p => p.Id == id);
            if (account == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return account;
        }

        [Route("api/accounts")]
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> Post(Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newAccount = await _service.AddAsync(account);
                    var response = Request.CreateResponse(HttpStatusCode.Created, newAccount);
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

        [Route("api/accounts")]
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> Put(Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var newAccount = await _service.UpdateAsync(account);
                if (newAccount > 0)
                {
                    return Request.
                        CreateResponse(HttpStatusCode.OK,
                        "{success:'true', verb:'PUT'}");
                }
                else
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.NotFound, "Account");
                }
            }
            catch (Exception ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        [Route("{id:int}")]
        [System.Web.Http.HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                var newAccount = await _service.RemoveAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, newAccount);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

        }
    }
}
