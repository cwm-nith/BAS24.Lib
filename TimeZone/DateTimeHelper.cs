using TimeZoneConverter;

namespace BAS24.Libs.TimeZone;

public static class DateTimeHelper
{
    public static DateTime CambodiaNow
    {
        get
        {
            var utcTime = DateTime.UtcNow;
            var tzi = TZConvert.GetTimeZoneInfo("Asia/Phnom_Penh");
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
        }
    }

    public static bool IsCambodiaToday(this DateTime d)
        => d.Date.Equals(CambodiaNow.Date);
}