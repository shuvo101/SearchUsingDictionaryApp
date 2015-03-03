using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchUsingDictionaryApp.Startup))]
namespace SearchUsingDictionaryApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
