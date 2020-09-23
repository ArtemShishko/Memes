using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(memes.Startup))]
namespace memes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
