using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HomeSeek.Web.Startup))]
namespace HomeSeek.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
    
}
