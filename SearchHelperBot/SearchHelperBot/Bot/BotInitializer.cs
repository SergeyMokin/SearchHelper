using System;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SearchHelperBot.Bot
{
    public static class BotInitializer
    {
        private static string _apiKey {
            get
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String("Njk0NjQwODE2OkFBR0ZwUWY2VFQ4TEowcXdNbDgyOXZUbG4taVNZYjh2UC1r"));
            }
        }

        private static TelegramBotClient _bot;

        static BotInitializer()
        {
            _bot = new TelegramBotClient(_apiKey);

            Initialize();
        }

        public static void Start()
        {
            _bot.StartReceiving();
        }

        public static void Stop()
        {
            _bot.StopReceiving();
        }

        private static void Initialize()
        {
            _bot.OnUpdate += SendAnswer;
        }

        private static async void SendAnswer(object su, UpdateEventArgs evu)
        {
            if (evu.Update.CallbackQuery != null 
                || evu.Update.InlineQuery != null
                || evu.Update.Message == null
                || evu.Update.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return;
            }

            var message = evu.Update.Message;

            await _bot.SendTextMessageAsync(message.Chat.Id,
                message.Text.GetAnswer());
        }
    }
}