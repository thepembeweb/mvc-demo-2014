using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC.Demo.Startup))]
namespace MVC.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
