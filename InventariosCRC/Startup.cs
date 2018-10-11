using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventariosCRC.Startup))]
namespace InventariosCRC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
