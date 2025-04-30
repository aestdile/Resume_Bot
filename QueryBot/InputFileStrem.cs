using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


internal class InputFileStream : InputFile
{
    private FileStream photoStream;

    public InputFileStream(FileStream photoStream)
    {
        this.photoStream = photoStream;
    }

    public override FileType FileType => throw new NotImplementedException();
}

// 7910522113:AAFt7jwyzMfzV8x3QnS_YX1sKIikPZaRjno