using System.Globalization;
using System.Text;

namespace Bekk.dotnetintro.TDD.Logging
{
    public class LogFormater
    {
        private readonly ITimeService _timeService;

        public LogFormater(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public string Format(IMessage message)
        {
            var currentTime = _timeService.Current();
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            stringBuilder.Append(PrependWithZeroIfNeeded(currentTime.Day));
            stringBuilder.Append(".");
            stringBuilder.Append(PrependWithZeroIfNeeded(currentTime.Month));
            stringBuilder.Append(".");
            stringBuilder.Append(currentTime.Year);
            stringBuilder.Append(" ");
            stringBuilder.Append(PrependWithZeroIfNeeded(currentTime.Hour));
            stringBuilder.Append(":");
            stringBuilder.Append(PrependWithZeroIfNeeded(currentTime.Minute));
            stringBuilder.Append("]");
            stringBuilder.Append("[");
            stringBuilder.Append(message);
            stringBuilder.Append("] ");
            stringBuilder.Append(message.Message);

            return stringBuilder.ToString();
        }

        private string PrependWithZeroIfNeeded(int value)
        {
            if (value < 10)
            {
                return "0" + value;
            }
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}