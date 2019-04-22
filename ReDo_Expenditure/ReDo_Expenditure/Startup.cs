using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReDo_Expenditure.Startup))]
namespace ReDo_Expenditure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
