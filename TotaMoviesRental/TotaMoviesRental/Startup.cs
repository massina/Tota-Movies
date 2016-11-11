using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotaMoviesRental.Startup))]
namespace TotaMoviesRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
