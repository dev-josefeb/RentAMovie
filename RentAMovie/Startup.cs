using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentAMovie.Startup))]
namespace RentAMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
