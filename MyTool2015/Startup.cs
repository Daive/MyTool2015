using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTool2015.Startup))]
namespace MyTool2015
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
