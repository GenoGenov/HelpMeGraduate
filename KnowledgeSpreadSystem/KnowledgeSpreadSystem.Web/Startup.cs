using KnowledgeSpreadSystem.Web;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace KnowledgeSpreadSystem.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
