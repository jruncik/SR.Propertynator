namespace SR.Propertynator.Model.Helpers;

public sealed class EnumHelper<T> where T : struct, IComparable // when .NET 7.3 will be available use 'Enum'
{
    static private readonly IDictionary<string, T> _fromString   = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
    static private readonly IDictionary<T, string> _toString     = new Dictionary<T, string>();
    static private readonly T                      _defaultValue = default(T);

    static EnumHelper()
    {
        foreach (T item in Enum.GetValues(typeof(T)))
        {
            string itemName = item.ToString() ?? string.Empty;

            _fromString.Add(itemName, item);
            _toString.Add(item, itemName);
        }
    }

    static public string ToString(T item)
    {
        _toString.TryGetValue(item, out string? resVal);

        return resVal ?? string.Empty;
    }

    static public IList<string> ToStrings(IEnumerable<T> items)
    {
        IList<string> listOfEnumsAsString = new List<string>();
        foreach (T item in items)
        {
            if (!_toString.TryGetValue(item, out string? resVal))
            {
                throw new ArgumentOutOfRangeException($"Item '{item}' doesn't exist in Enum.");
            }

            listOfEnumsAsString.Add(resVal);
        }

        return listOfEnumsAsString;
    }

    static public T FromString(string itemName)
    {
        if (!_fromString.TryGetValue(itemName, out T resVal))
        {
            throw new ArgumentOutOfRangeException($"Item '{itemName}' doesn't exist in Enum.");
        }

        return resVal;
    }

    static public IList<T> FromStrings(IEnumerable<string> items)
    {
        IList<T> listOfItems = new List<T>();
        foreach (string item in items)
        {
            if (!_fromString.TryGetValue(item, out T resVal))
            {
                throw new ArgumentOutOfRangeException($"Item '{item}' doesn't exist in Enum.");
            }

            listOfItems.Add(resVal);
        }

        return listOfItems;
    }

    static public T GetOrDefaultFromString(string itemName)
    {
        if (!_fromString.TryGetValue(itemName, out T resVal))
        {
            return _defaultValue;
        }

        return resVal;
    }

    static public IList<T> FromStringsOrDefault(IEnumerable<string> items)
    {
        IList<T> listOfItems = new List<T>();
        foreach (string item in items)
        {
            if (!_fromString.TryGetValue(item, out T resVal))
            {
                resVal = _defaultValue;
            }

            listOfItems.Add(resVal);
        }

        return listOfItems;
    }
}