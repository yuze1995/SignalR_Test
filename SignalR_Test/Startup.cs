using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalR_Test.Startup))]
namespace SignalR_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
