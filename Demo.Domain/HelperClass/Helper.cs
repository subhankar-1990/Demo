namespace Demo.Domain.HelperClass
{
    public static class Helper
    {
        public static DateTime GetIndianDateTime()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }
    }
}
