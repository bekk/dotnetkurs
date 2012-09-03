using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.TDD.Logging.UnitTest
{
    [TestClass]
    public class LogFormatterTest
    {
        [TestMethod]
        public void Format_MessageIsNotNull_CurrentDateIsFirstThingInMessage()
        {
            var timeService = new FakeTimeService();
            var current = new DateTime(2012, 08, 28, 12, 0, 0);
            timeService.CurrentDateTime = current;
            var message = new InfoMessage("infomessage");
            var formatter = new LogFormater(timeService);

            var formattedMessage = formatter.Format(message);

            Assert.IsTrue(formattedMessage.StartsWith("[28.08.2012 12:00]"));
        }

        [TestMethod]
        public void Format_MessageIsInfo_InfoIsWrittenAfterDateInMessage()
        {
            var timeService = new FakeTimeService();
            var current = new DateTime(2012, 08, 28, 12, 0, 0);
            timeService.CurrentDateTime = current;
            var message = new InfoMessage("infomessage");
            var formatter = new LogFormater(timeService);

            var formattedMessage = formatter.Format(message);

            Assert.IsTrue(formattedMessage.StartsWith("[28.08.2012 12:00][Info]"));
        }

        [TestMethod]
        public void Format_MessageIsWarning_InfoIsWrittenAfterDateInMessage()
        {
            var timeService = new FakeTimeService();
            var current = new DateTime(2012, 08, 28, 12, 0, 0);
            timeService.CurrentDateTime = current;
            var message = new WarningMessage();
            var formatter = new LogFormater(timeService);

            var formattedMessage = formatter.Format(message);

            Assert.IsTrue(formattedMessage.StartsWith("[28.08.2012 12:00][Warning]"));
        }

        [TestMethod]
        public void Format_MessageIsException_InfoIsWrittenAfterDateInMessage()
        {
            var timeService = new FakeTimeService();
            var current = new DateTime(2012, 08, 28, 12, 0, 0);
            timeService.CurrentDateTime = current;
            var message = new ExceptionMessage();
            var formatter = new LogFormater(timeService);

            var formattedMessage = formatter.Format(message);

            Assert.IsTrue(formattedMessage.StartsWith("[28.08.2012 12:00][Exception]"));
        }

        [TestMethod]
        public void Format_MessageIsInfo_MessageContainsExplanatoryMessage()
        {
            var timeService = new FakeTimeService();
            var current = new DateTime(2012, 08, 28, 12, 0, 0);
            timeService.CurrentDateTime = current;
            var message = new InfoMessage("User Arthur Dent just logged into his account");
            var formatter = new LogFormater(timeService);

            var formattedMessage = formatter.Format(message);

            Assert.IsTrue(formattedMessage.StartsWith("[28.08.2012 12:00][Info] User Arthur Dent just logged into his account"));
        }
    }

    public class FakeTimeService : ITimeService
    {
        public DateTime CurrentDateTime { get; set; }

        public DateTime Current()
        {
            return CurrentDateTime;
        }
    }
}
