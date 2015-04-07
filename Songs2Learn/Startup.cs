using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Songs2Learn.Startup))]
namespace Songs2Learn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
