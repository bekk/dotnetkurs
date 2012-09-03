using System.Configuration;
using System.IO;

namespace Bekk.dotnetintro.TDD.Logging.Output
{
    public class FileWriter : IFileWriter
    {
        public void Write(string message)
        {
            using (var writer = new StreamWriter(ConfigurationManager.AppSettings["LogFile"], true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
