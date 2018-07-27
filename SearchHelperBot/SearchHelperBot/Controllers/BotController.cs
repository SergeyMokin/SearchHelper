using SearchHelperBot.Bot;
using System.Web.Http;

namespace SearchHelperBot.Controllers
{
    public class BotController : ApiController
    {
        [HttpPost]
        public string Start()
        {
            return BotInitializer.Start();
        }


        [HttpPost]
        public string Stop()
        {
            return BotInitializer.Stop();
        }
    }
}
