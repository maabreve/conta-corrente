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
    public class ClientsApiController : BaseApiController
    {
        IBaseService<Client> _service;
        public ClientsApiController(ClientService service)
        {
            _service = service;
        }

        // GET: api/tracking
        [System.Web.Http.HttpGet]
        [Route("api/clients")]
        public async Task<List<Client>> Get()
        {
            return await Task.Run(() => _service.GetAllAsync());
        }

        [Route("{id:int}")]
        [System.Web.Http.HttpGet]
        public async Task<Client> Get(int id)
        {
            var client = await _service.FindAsync(p => p.Id == id);
            if (client == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return client;
        }

        [Route("api/clients")]
        [System.Web.Http.HttpPost]
        public async Task<int> Post(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await _service.AddAsync(client);
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid model"));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [Route("api/clients")]
        [System.Web.Http.HttpPut]
        public async Task<int> Put(Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid model"));
                }

                return await _service.UpdateAsync(client);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }

        [Route("{id:int}")]
        [System.Web.Http.HttpDelete]
        public async Task<int> Delete(int id)
        {
            try
            {
                return await _service.RemoveAsync(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }

        }
    }
}
