using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Escuela_Deportiva_Code_First.Startup))]
namespace Escuela_Deportiva_Code_First
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
