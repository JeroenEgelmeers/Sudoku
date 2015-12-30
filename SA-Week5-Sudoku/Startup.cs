using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SA_Week5_Sudoku.Startup))]
namespace SA_Week5_Sudoku
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
