using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectorCSharp.Startup))]
namespace ProjectorCSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
