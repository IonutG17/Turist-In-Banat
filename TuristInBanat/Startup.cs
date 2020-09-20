using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuristInBanat.Startup))]
namespace TuristInBanat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
