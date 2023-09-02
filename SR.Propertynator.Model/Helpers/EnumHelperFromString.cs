namespace SR.Propertynator.Model.Helpers
{
    internal sealed class EnumHelperFromString<T> where T : Enum
    {
        private readonly IDictionary<string, T> _fromString = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);

        public EnumHelperFromString(Func<T, string> getItemName)
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                _fromString.Add(getItemName(item), item);
            }
        }

        public T FromString(string itemName)
        {
            if (!_fromString.TryGetValue(itemName, out T? resVal))
            {
                throw new ArgumentOutOfRangeException($"Item '{itemName}' doesn't exist in Enum.");
            }

            return resVal;
        }

        public IList<T> FromStrings(IEnumerable<string> items)
        {
            IList<T> listOfItems = new List<T>();
            foreach (string item in items)
            {
                if (!_fromString.TryGetValue(item, out T? resVal))
                {
                    throw new ArgumentOutOfRangeException($"Item '{item}' doesn't exist in Enum.");
                }

                listOfItems.Add(resVal);
            }

            return listOfItems;
        }

        public T GetOrDefaultFromString(string itemName)
        {
            if (_fromString.TryGetValue(itemName, out T? resVal))
            {
                return resVal;
            }

#pragma warning disable CS8603 // Possible null reference return.
            return default(T);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IList<T> FromStringsOrDefault(IEnumerable<string> items)
        {
            IList<T> listOfItems = new List<T>();
            foreach (string item in items)
            {
                if (!_fromString.TryGetValue(item, out T? resVal))
                {
                    resVal = default(T);
                }
#pragma warning disable CS8604 // Possible null reference argument.
                listOfItems.Add(resVal);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            return listOfItems;
        }
    }
}