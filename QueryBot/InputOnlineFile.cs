using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

internal class InputOnlineFile : InputFile
{
    private FileStream photoStream;
    private string v;

    public InputOnlineFile(FileStream photoStream, string v)
    {
        this.photoStream = photoStream;
        this.v = v;
    }

    public override FileType FileType => throw new NotImplementedException();
}