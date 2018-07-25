using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleApi;

namespace SearchHelperBot.Bot
{
    public static class AnswersContainer
    {
        private static string _googleApiKey
        {
            get
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String("QUl6YVN5QXdrMVhmTkNrN1p2OHZkdjBXVTZDSzhUcDAyWlpKSExB"));
            }
        }

        private static string _googleSearchEngineId
        {
            get
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String("MDE1MTE2ODM2NDM3NTI1NjU4MTg2OmdfdDd5YXhqYnVj"));
            }
        }

        private static Dictionary<string, string> _container = new Dictionary<string, string>
        {
            {
                "/help",
                "SearchHelper - help\n\n" +
                "/search <text to search here> - search for a response at stackoverflow;\n"
            },
            {
                "/start",
                "/help - help in using;\n" +
                "/search <text to search here> - search for a response at stackoverflow;\n"
            },
            {
                "/wtf",
                "Vodka only first expensive, then its price does not matter."
            },
            {
                "/nakatim",
                "Better deal with the matter."
            }
        };

        public static string GetAnswer(this string message)
        {
            try
            {
                message = message?.ToLower() 
                    ?? throw new ArgumentNullException();

                if (message.Contains("/search"))
                {
                    return Search(message.Replace("/search", ""));
                }

                return _container[message];
            }
            catch
            {
                return "I can not recognize the command.";
            }
        }

        private static string Search(string keywords)
        {
            try
            {
                var response = GoogleSearch.WebSearch.Query(new GoogleApi.Entities.Search.Web.Request.WebSearchRequest
                {
                    SearchEngineId = _googleSearchEngineId,
                    Query = keywords,
                    Key = _googleApiKey
                });

                var result = "";
                var i = 1;

                var items = response.Items.Count() > 3
                    ? response.Items.Take(3)
                    : response.Items;

                foreach (var item in items)
                {
                    result += i++ + ") " + item.Link + "\n";
                }

                return result;
            }
            catch
            {
                return "I can not find the answer.";
            }
        }
    }
}