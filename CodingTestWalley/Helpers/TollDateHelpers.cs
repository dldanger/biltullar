namespace CodingTestWalley.Helpers;
public static class TollDateHelpers
{
    private static readonly Dictionary<int, int[]> _fixedTollFreeDays = new()
    {
        {1, [1, 5, 6]},
        {4, [30]},
        {5, [1]},
        {6, [5, 6]},
        {12, [24, 25, 26, 31]}
    };

    private static int _currentYear;

    private static DateTime[] _easterTollFreeDays = [];

    public static bool IsTollFreeDate(DateTime dateToCheck)
    {
        if (dateToCheck.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            return true;

        if (dateToCheck.Month is 7)
            return true;

        var isMonthWithFixedTollFreeDays = _fixedTollFreeDays.TryGetValue(dateToCheck.Month, out var fixedTollFreeDays);

        if (isMonthWithFixedTollFreeDays && fixedTollFreeDays.Contains(dateToCheck.Day))
            return true;

        var isFriday = dateToCheck.DayOfWeek is DayOfWeek.Friday;
        if (dateToCheck.Month is 6 && isFriday)
            return IsMidsummerTollFreeDay(dateToCheck);

        if (dateToCheck.Month is 10 or 11 && isFriday)
            return IsAllHallowsTollFreeDay(dateToCheck);

        if (dateToCheck.Month is 3 or 4 or 5 or 6)
            return IsEasterRelatedTollFreeDay(dateToCheck);

        return false;
    }

    private static bool IsMidsummerTollFreeDay(DateTime dateToCheck)
    {
        return dateToCheck.Day >= 19 && dateToCheck.Day <= 25;
    }

    private static bool IsAllHallowsTollFreeDay(DateTime dateToCheck)
    {
        var lowerBound = new DateTime(dateToCheck.Year, 10, 30);
        var upperBound = new DateTime(dateToCheck.Year, 11, 5);

        return dateToCheck >= lowerBound && dateToCheck <= upperBound;
    }

    private static bool IsEasterRelatedTollFreeDay(DateTime dateToCheck)
    {
        if (dateToCheck.Year != _currentYear || _easterTollFreeDays == default)
            CalculateEasterRelatedTollFreeDates(dateToCheck.Year);
        
        return _easterTollFreeDays.Contains(dateToCheck.Date);
    }

    private static void CalculateEasterRelatedTollFreeDates(int year)
    {
        _currentYear = year;
        /* This is a formula for calculating the Easter date that I found here:
         * https://www.drupal.org/project/nameday/issues/1180480
         * I can't verify it's complete accuracy, but for the test years I plugged in, it was correct
         */

        var a = year % 19;
        var b = year / 100;
        var c = year % 100;
        var d = b / 4;
        var e = b % 4;
        var f = (b + 8) / 25;
        var g = (b - f + 1) / 3;
        var h = (19 * a + b - d - g + 15) % 30;
        var i = c / 4;
        var k = c % 4;
        var l = (32 + 2 * e + 2 * i - h - k) % 7;
        var m = (a + 11 * h + 22 * l) / 451;
        var easterMonth = (h + l - 7 * m + 114) / 31;
        var p = (h + l - 7 * m + 114) % 31;
        var easterDay = p + 1;

        var easterSunday = new DateTime(year, easterMonth, easterDay);
        _easterTollFreeDays = [
            easterSunday.AddDays(-3),
            easterSunday.AddDays(-2),
            easterSunday.AddDays(1),
            easterSunday.AddDays(38),
            easterSunday.AddDays(39)];
    }
}
