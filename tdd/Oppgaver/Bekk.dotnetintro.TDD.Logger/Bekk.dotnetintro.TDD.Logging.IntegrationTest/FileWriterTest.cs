using System.Configuration;
using System.IO;
using Bekk.dotnetintro.TDD.Logging.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.TDD.Logging.IntegrationTest
{
    [TestClass]
    public class FileWriterTest
    {
        [TestInitialize]
        public void InitializeTest()
        {
            File.Delete(ConfigurationManager.AppSettings["LogFile"]);
        }

        [TestMethod]
        public void Write_StringToBeWrittenNotEmpty_StringWrittenToFile()
        {
            //arrange
            const string message = "This is going to be written to file";
            var fileWriter = new FileWriter();
            
            //act
            fileWriter.Write(message);

            var allLines = File.ReadAllLines(ConfigurationManager.AppSettings["LogFile"]);

            Assert.AreEqual(message, allLines[0]);
        }

        [TestMethod]
        public void Write_TwoMessages_BothWrittenToFile()
        {
            //arrange
            const string firstMessage = "FirstMessage";
            const string secondMessage = "SecondMessage";
            var fileWriter = new FileWriter();

            //act
            fileWriter.Write(firstMessage);
            fileWriter.Write(secondMessage);

            var allLines = File.ReadAllLines(ConfigurationManager.AppSettings["LogFile"]);

            Assert.AreEqual(firstMessage, allLines[0]);
            Assert.AreEqual(secondMessage, allLines[1]);
        }
    }
}
