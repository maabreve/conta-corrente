using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContaCorrente.Web.Startup))]
namespace ContaCorrente.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
        }
    }
}
