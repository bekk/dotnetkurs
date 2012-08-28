using Bekk.dotnetintro.TDD.Logging.Output;

namespace Bekk.dotnetintro.TDD.Logging
{
    public class Logger
    {
        private readonly IFileWriter _fileWriter;

        public Logger(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Log(string message)
        {
            _fileWriter.Write(message);
        }
    }
}
