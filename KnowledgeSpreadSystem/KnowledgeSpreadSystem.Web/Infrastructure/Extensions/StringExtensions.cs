namespace KnowledgeSpreadSystem.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToShortString(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if (str.Length > maxLength)
            {
                return string.Concat(str.Substring(0, maxLength - 3), "...");
            }

            return str;
        }
    }
}