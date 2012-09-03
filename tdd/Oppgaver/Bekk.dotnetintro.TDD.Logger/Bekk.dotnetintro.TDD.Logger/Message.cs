namespace Bekk.dotnetintro.TDD.Logging
{
    public interface IMessage
    {
        string Message { get; }
    }

    public class InfoMessage : IMessage
    {
        public string Message { get; private set; }

        public InfoMessage(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return "Info";
        }
    }

    public class WarningMessage : IMessage
    {
        public string Message { get; private set; }

        public override string ToString()
        {
            return "Warning";
        }
    }

    public class ExceptionMessage : IMessage
    {
        public string Message { get; private set; }

        public override string ToString()
        {
            return "Exception";
        }
    }
}
