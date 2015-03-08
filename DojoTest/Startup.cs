using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DojoTest.Startup))]
namespace DojoTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
