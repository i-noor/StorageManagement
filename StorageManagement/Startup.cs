using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StorageManagement.Startup))]
namespace StorageManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
