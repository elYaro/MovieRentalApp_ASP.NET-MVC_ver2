using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRentalApp_ASP.NET_MVC_ver2._1.Startup))]
namespace MovieRentalApp_ASP.NET_MVC_ver2._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
