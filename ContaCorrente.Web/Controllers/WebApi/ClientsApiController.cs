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
        public async Task<HttpResponseMessage> Post(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newClient = await _service.AddAsync(client);
                    var response = Request.CreateResponse(HttpStatusCode.Created, newClient);
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

        [Route("api/clients")]
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> Put(Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var newClient = await _service.UpdateAsync(client);
                if (newClient > 0)
                {
                    return Request.
                        CreateResponse(HttpStatusCode.OK,
                        "{success:'true', verb:'PUT'}");
                }
                else
                {
                    return Request.
                        CreateErrorResponse(HttpStatusCode.NotFound, "Client");
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
                var newClient = await _service.RemoveAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, newClient);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

        }
    }
}
