namespace LeetCode.Tasks
{
    internal class ValidNumber
    {
        public static bool IsNumber(string s)
        {
            var parts = s.Split('e', 'E');
            if (parts.Length > 2) return false;
            var mantissa = parts[0];
            var exponent = parts.Length == 2 ? parts[1] : null;
            return IsDecimalNumber(mantissa) && (exponent is null || IsInteger(exponent));
        }

        private static bool IsDecimalNumber(string s)
        {
            if (s.Length == 0) return false;
            
            var hasDigits = s.Any(x => char.IsDigit(x));

            if (s[0] == '-' || s[0] == '+') s = s.Substring(1);

            s = new string(s.SkipWhile(x => char.IsDigit(x)).ToArray());

            if (s.Length > 0 && s[0] == '.') s = new string(s.Skip(1).SkipWhile(x => char.IsDigit(x)).ToArray());

            return hasDigits && s.Length == 0;
        }

        private static bool IsInteger(string s)
        {
            if (s.Length == 0) return false;

            var hasDigits = s.Any(x => char.IsDigit(x));

            if (s[0] == '-' || s[0] == '+') s = s.Substring(1);

            s = new string(s.SkipWhile(x => char.IsDigit(x)).ToArray());

            return hasDigits && s.Length == 0;
        }
    }
}
