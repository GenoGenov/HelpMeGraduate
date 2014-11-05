using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelpMeGraduate.Web.Startup))]
namespace HelpMeGraduate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
