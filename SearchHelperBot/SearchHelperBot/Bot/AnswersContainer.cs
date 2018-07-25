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
                "SearchHelper - помощь\n\n" +
                "/search <text to search here> - поиск ответа на stackoverflow;\n"
            },
            {
                "/start",
                "/help - помощь в использовании;\n" +
                "/search <text to search here> - поиск ответа на stackoverflow;\n"
            },
            {
                "/wtf",
                "Водка только сначала стоит дорого, потом ее цена не имеет значения."
            },
            {
                "/nakatim",
                "Лучше делом займись."
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
                return "Не могу распознать команду.";
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
                return "Не могу найти ответ.";
            }
        }
    }
}