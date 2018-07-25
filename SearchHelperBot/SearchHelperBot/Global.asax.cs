using SearchHelperBot.Bot;

namespace SearchHelperBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BotInitializer.Start();
        }
    }
}
