using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpAssignment.Startup))]
namespace CSharpAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
