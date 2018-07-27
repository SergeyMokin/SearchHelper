using System;
using System.Collections.Generic;

namespace SearchHelperBot.Bot
{
    public static class AnswersContainer
    {
        private static Dictionary<string, string> _container = new Dictionary<string, string>
        {
            {
                "/help",
                "SearchHelper - help\n\n" +
                "(/s /search) <text to search here> - search for a response at stackoverflow;\n"
            },
            {
                "/h",
                "SearchHelper - help\n\n" +
                "(/s /search) <text to search here> - search for a response at stackoverflow;\n"
            },
            {
                "/start",
                "(/h /help) - help in using;\n" +
                "(/s /search) <text to search here> - search for a response at stackoverflow;\n"
            }
        };

        public static string GetAnswer(this string message)
        {
            try
            {
                message = message?.ToLower()
                    ?? throw new ArgumentNullException();

                if (message.Contains("/search")
                    || message.Contains("/s "))
                {
                    message = 
                        message
                            .Replace("/search", "")
                            .Replace("/s", "");

                    return SearchGoogle.Search(message);
                }

                message = message.Replace(" ", "");

                return _container[message];
            }
            catch
            {
                return "I can not recognize the command.";
            }
        }
    }
}