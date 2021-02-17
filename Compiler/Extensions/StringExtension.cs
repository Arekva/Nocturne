namespace Nocturne.Extensions
{
    public static class StringExtension
    {
        public static bool HasContents(this string str) => !(string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || str.Length < 1);
    }
}