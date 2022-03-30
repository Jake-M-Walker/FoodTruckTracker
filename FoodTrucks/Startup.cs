using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodTrucks.Startup))]
namespace FoodTrucks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
