namespace SR.Propertynator.Model.Helpers
{
    public class EnumHelperLower<T> where T : Enum, IComparable
    {
        private static readonly Lazy<EnumHelperFromString<T>> _fromString;
        private static readonly Lazy<EnumHelperToString<T>> _toString;

        private static readonly Func<T, string> GetName = item => item.ToString().ToLower();

        static EnumHelperLower()
        {
            _fromString = new Lazy<EnumHelperFromString<T>>(() =>
                new EnumHelperFromString<T>(GetName));

            _toString = new Lazy<EnumHelperToString<T>>(() =>
                EnumHelperToString<T>.Create(GetName));
        }

        public static string ToString(T item)
        {
            return _toString.Value.ToString(item);
        }

        public static IList<string> ToStringAll()
        {
            return _toString.Value.ToStringAll();
        }

        public static IList<string> ToStrings(IEnumerable<T> items)
        {
            return _toString.Value.ToStrings(items);
        }

        public static T FromString(string itemName)
        {
            return _fromString.Value.FromString(itemName);
        }

        public static IList<T> FromStrings(IEnumerable<string> items)
        {
            return _fromString.Value.FromStrings(items);
        }

        public static T GetOrDefaultFromString(string itemName)
        {
            return _fromString.Value.GetOrDefaultFromString(itemName);
        }

        public static IList<T> FromStringsOrDefault(IEnumerable<string> items)
        {
            return _fromString.Value.FromStringsOrDefault(items);
        }
    }
}