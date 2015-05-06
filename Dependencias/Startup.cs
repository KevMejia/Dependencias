using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dependencias.Startup))]
namespace Dependencias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
