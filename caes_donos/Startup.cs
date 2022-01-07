using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(caes_donos.Startup))]
namespace caes_donos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
