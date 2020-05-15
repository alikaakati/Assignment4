using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment4_ALI_K_MOHAMAD.N.Startup))]
namespace Assignment4_ALI_K_MOHAMAD.N
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
