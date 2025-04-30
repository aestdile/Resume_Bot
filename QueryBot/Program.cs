using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

public class Program
{
    private static TelegramBotClient telegramBot;
    private const string startCommand = "/start";
    private const string aboutMeCommand = "About Me";
    private const string skillsCommand = "Skills";
    private const string languagesCommand = "Languages";
    private const string contactMeCommand = "Contact Me";
    private static void Main(string[] args)
    {
        string token = @"Your_Token";
        telegramBot = new TelegramBotClient(token);
        telegramBot.StartReceiving(HandleUpdate, HandleError);
        Console.ReadLine();
    }

    private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.Message?.Type is MessageType.Text)
        {
            if (update.Message.Text is startCommand)
            {
                var markup = MenuMarkup();

                await client.SendMessage(
                    chatId: update.Message.Chat.Id,
                    text: "Welcome to Resume Bot!",
                    replyMarkup: markup);
            }
            if (update.Message.Text is aboutMeCommand)
            {
                var photoPath = @"C:\Users\aestd\Downloads\Telegram Desktop\aboutMeImage.jpg";

                using (var photoStream = new FileStream(photoPath, FileMode.Open, FileAccess.Read))
                {
                    await client.SendPhoto(
                        chatId: update.Message.Chat.Id,
                        photo: new InputOnlineFile(photoStream, "aboutMeImage.jpg"),
                        caption: "Junior C#.Net Backend Developer."
                        );
                }
            }
            if (update.Message.Text is skillsCommand)
            {
                await client.SendMessage(
                    chatId: update.Message.Chat.Id,
                    text: "C#\nHTML\nCSS\nMSSQL");
            }
            if (update.Message.Text is languagesCommand)
            {
                await client.SendMessage(
                    chatId: update.Message.Chat.Id,
                    text: "English 🇬🇧\nRussian 🇷🇺\nUzbek 🇺🇿");
            }
            if (update.Message.Text is contactMeCommand)
            {
                await client.SendMessage(
                    chatId: update.Message.Chat.Id,
                    text:   "t.me/aestdile\r\n\r\n" +
                            "github.com/aestdile\r\n\r\n" +
                            "leetcode.com/aestdile\r\n\r\n" +
                            "linkedin.com/in/aestdile\r\n\r\nyoutube.com/@aestdile" +
                            "\r\n\r\ninstagram.com/aestdile\r\n\r\n" +
                            "facebook.com/aestdile\r\n\r\n" +
                            "e-mail: aestdile@gmail.com");
            }
        }
        else
        {
            await client.SendMessage(
            chatId: update.Message?.Chat.Id,
            $"Please, send only text message!");
        }
    }

    private static ReplyKeyboardMarkup MenuMarkup()
    {
        return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {  
               new KeyboardButton[]{new KeyboardButton("About Me"), new KeyboardButton("Skills") },
               new  KeyboardButton[]{new KeyboardButton("Languages"), new KeyboardButton("Contact Me")} 
            })
        {
            ResizeKeyboard = true
        };
    }
    
    private static async Task HandleError(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
    {
        await client.SendMessage(
            chatId: 6421409546,
            $"Error: {exception.Message}");
    }
}











