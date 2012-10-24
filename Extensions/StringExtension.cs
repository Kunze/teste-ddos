using System.Linq;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class StringExtension
    {
        public static string[] ToArgs(this string source)
        {
            var regex = new Regex("([^\" ][^ ]*)|(\"[^\"]*\")");

            return regex
                .Matches(source)
                .OfType<Match>()
                .Select(m => m.Value)
                .ToArray();
        }
    }
}