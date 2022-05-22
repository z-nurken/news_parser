using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class DateTimeFormatter
    {
        public static DateTime Format(string dateTimeStr, string dateTimeFormat, CultureInfo cultureInfo)
        {
            DateTime dateTime = new DateTime();

            dateTimeStr = dateTimeStr.ToLower().Trim()?
                .Replace("/n", "")
                .Replace("сегодня", DateTime.Now.Date.ToString(dateTimeFormat).Replace(", 00:00", ""))
                .Replace("вчера", DateTime.Now.AddDays(-1).Date.ToString(dateTimeFormat).Replace(", 00:00", ""));

            if (DateTime.TryParseExact(dateTimeStr, dateTimeFormat, cultureInfo, DateTimeStyles.None, out DateTime outDateTime))
                dateTime = outDateTime;

            return dateTime;
        }
    }
}
