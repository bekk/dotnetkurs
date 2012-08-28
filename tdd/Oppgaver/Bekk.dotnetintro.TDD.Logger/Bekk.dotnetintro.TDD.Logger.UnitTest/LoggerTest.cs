using Bekk.dotnetintro.TDD.Logging.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Bekk.dotnetintro.TDD.Logging.UnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void Log_MessageNotEmpty_WriteCalledOnFileWriter()
        {
            var mockedFileWriter = MockRepository.GenerateMock<IFileWriter>();
            var logger = new Logger(mockedFileWriter);

            const string message = "Message to be logged";

            logger.Log(message);

            mockedFileWriter.AssertWasCalled(writer => writer.Write(message));
        }
    }
}
