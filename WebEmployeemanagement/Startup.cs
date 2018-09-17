using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEmployeemanagement.Startup))]
namespace WebEmployeemanagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
