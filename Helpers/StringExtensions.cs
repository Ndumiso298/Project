namespace Project.Helpers
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }

        public static string ToShortDate(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }
    }
}

