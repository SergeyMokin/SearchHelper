using GoogleApi;
using GoogleApi.Entities.Search.Web.Request;
using System;
using System.Linq;
using System.Text;

namespace SearchHelperBot.Bot
{
    public static class SearchGoogle
    {

        private static string _googleApiKey
        {
            get
            {
                return Encoding
                    .UTF8
                    .GetString(
                        Convert
                        .FromBase64String(
                            "QUl6YVN5QXdrMVhmTkNrN1p2OHZkdjBXVTZDSzhUcDAyWlpKSExB"));
            }
        }

        private static string _googleSearchEngineId
        {
            get
            {
                return Encoding
                    .UTF8
                    .GetString(
                        Convert
                        .FromBase64String(
                            "MDE1MTE2ODM2NDM3NTI1NjU4MTg2OmdfdDd5YXhqYnVj"));
            }
        }

        public static string Search(string keywords)
        {
            try
            {
                var response = GoogleSearch.WebSearch.Query(new WebSearchRequest
                {
                    SearchEngineId = _googleSearchEngineId,
                    Query = keywords,
                    Key = _googleApiKey
                });

                var result = "";
                var linkCounter = 1;

                var items = response.Items.Count() > 3
                    ? response.Items.Take(3)
                    : response.Items;

                foreach (var item in items)
                {
                    result += linkCounter++ + ") " + item.Link + "\n";
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