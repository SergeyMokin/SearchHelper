using System;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace SearchHelperBot.Bot
{
    public static class BotInitializer
    {
        private static string _apiKey {
            get
            {
                return Encoding
                    .UTF8
                    .GetString(
                        Convert
                        .FromBase64String(
                            "Njk0NjQwODE2OkFBR0ZwUWY2VFQ4TEowcXdNbDgyOXZUbG4taVNZYjh2UC1r"
                            ));
            }
        }

        private static TelegramBotClient _bot;

        static BotInitializer()
        {
            _bot = new TelegramBotClient(_apiKey);

            Initialize();
        }

        private static void Initialize()
        {
            _bot.OnUpdate += SendAnswer;
        }

        public static string Start()
        {
            new Task(() => _bot.StartReceiving()).Start();

            return "Getting started successfully.";
        }

        public static string Stop()
        {
            new Task(() => _bot.StopReceiving()).Start();

            return "Ended successfullyy.";
        }

        private static async void SendAnswer(object su, UpdateEventArgs evu)
        {
            if (evu.Update.CallbackQuery != null 
                || evu.Update.InlineQuery != null
                || evu.Update.Message == null
                || evu.Update.Message.Type != MessageType.Text)
            {
                return;
            }

            var message = evu.Update.Message;

            await _bot.SendTextMessageAsync(message.Chat.Id,
                message.Text.GetAnswer());
        }
    }
}