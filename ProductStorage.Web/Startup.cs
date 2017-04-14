using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductStorage.Startup))]
namespace ProductStorage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
