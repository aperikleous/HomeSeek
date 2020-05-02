using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeSeek.Web.Startup))]
namespace HomeSeek.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
