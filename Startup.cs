using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMvcCrudService.Startup))]
namespace WebMvcCrudService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
