using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Store_of__goods.Models;

[assembly: OwinStartupAttribute(typeof(Store_of__goods.Startup))]
namespace Store_of__goods
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
