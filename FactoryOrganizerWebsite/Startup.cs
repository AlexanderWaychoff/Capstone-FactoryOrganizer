using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FactoryOrganizerWebsite.Startup))]
namespace FactoryOrganizerWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
