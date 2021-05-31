using System.Text.RegularExpressions;

namespace MSDN_Magazine_To_PDF.Util
{
    public class RegexUtil
    {
        public static int ExtractNumber(string input)
        {
            var pattern = "[0-9]+";
            var match = Regex.Match(input, pattern);

            if(match.Success)
            {
                return System.Convert.ToInt32(match.Value);
            }
            else
            {
                return -1;
            }
        }
    }
}
