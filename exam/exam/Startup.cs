using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(exam.Startup))]
namespace exam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
