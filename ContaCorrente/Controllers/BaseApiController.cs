using ContaCorrente.Model;
using ContaCorrente.Repository.Interfaces;
using System.Web;
using System.Web.Http;
using System.Net.Http;

namespace ContaCorrente.Web.Controllers.WebApi
{
    public class BaseApiController : ApiController
    {
        protected IUnitOfWork Uow { get; set; }

        public BaseApiController()
        {
        }

    }
}
