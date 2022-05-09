using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstructionalMaterials.Startup))]
namespace InstructionalMaterials
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
