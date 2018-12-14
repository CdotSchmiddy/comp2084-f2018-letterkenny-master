using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F2018Letterkenny.Startup))]
namespace F2018Letterkenny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
