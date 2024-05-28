using System.Globalization;

namespace Pharmatic.Extensions;

public static class NumericExtensions
{
    private static readonly CultureInfo CultureEsNi = new ("es-NI");

    public static string ToCurrency(this decimal value)
    {
        return value.ToString("C$ #,##0.##");
    }
}