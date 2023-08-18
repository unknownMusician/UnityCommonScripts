using System.Collections;
using System.Text;

namespace AreYouFruits.ToStringGeneration
{
    public static class ToStringExtensions
    {
        public static string ToStringUniversal<T>(this T value)
        {
            if (!typeof(T).IsValueType && value is IEnumerable enumerable)
            {
                return ToStringUniversal(enumerable);
            }
        
            return value?.ToString() ?? "Null";
        }

        private static string ToStringUniversal(IEnumerable enumerable)
        {
            IEnumerator enumerator = enumerable.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                return "[ ]";
            }
            
            var stringBuilder = new StringBuilder();
            
            stringBuilder.Append("[ ");

            stringBuilder.Append(ToStringUniversal(enumerator.Current));

            while (enumerator.MoveNext())
            {
                stringBuilder.Append(", ");
                stringBuilder.Append(ToStringUniversal(enumerator.Current));
            }

            stringBuilder.Append(" ]");

            return stringBuilder.ToString();
        }
    }
}
