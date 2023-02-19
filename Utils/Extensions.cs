using System.Linq.Expressions;
using System.Reflection;

namespace BAS24.Libs.Utils;

public static class Extensions
{
    public static T Field<T, TValue>(this T target, Expression<Func<T, TValue>> memberLamda, TValue value) where T : class, new()
    {
        if (memberLamda.Body is not MemberExpression memberSelectorExpression) return target;
        var property = memberSelectorExpression.Member as PropertyInfo;
        if (property != null)
        {
            property.SetValue(target, value, null);
        }
        return target;
    }

    public static DateTime GetLastDayOfMonth(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
    }
    public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, 1);
    }
}