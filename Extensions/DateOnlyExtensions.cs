namespace Pharmatic.Extensions
{
    public static class DateOnlyExtensions
    {
        public static string ToIsoString(this DateOnly date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
