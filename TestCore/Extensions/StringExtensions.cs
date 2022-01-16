using System.Text.Json;

namespace TestCore.Extensions
{
    public static class StringExtensions
    {
        public static T Deserialize<T>(this string @this) => JsonSerializer.Deserialize<T>(@this);
    }
}
