namespace SR.Propertynator.Model.Helpers
{
    internal abstract class EnumHelperToString<T> where T : Enum
    {
        protected EnumHelperToString(Func<T, string> getItemName)
        {
            GetItemName = getItemName;
        }

        private Func<T, string> GetItemName { get; }

        public static EnumHelperToString<T> Create(Func<T, string> getItemName)
        {
            return IsSequential() ? new EnumHelperToStringSequentialStrategy(getItemName) : new EnumHelperToStringHoleyStrategy(getItemName);
        }

        private static bool IsSequential()
        {
            int i = 0;
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (i != Convert.ToInt32(item))
                {
                    return false;
                }

                ++i;
            }

            return true;
        }

        public abstract string ToString(T item);

        public abstract IList<string> ToStringAll();

        public abstract IList<string> ToStrings(IEnumerable<T> items);

        private sealed class EnumHelperToStringSequentialStrategy : EnumHelperToString<T>
        {
            private readonly List<string> _toString;

            public EnumHelperToStringSequentialStrategy(Func<T, string> getItemName)
                : base(getItemName)
            {
                _toString = new List<string>();
                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    _toString.Add(GetItemName(item));
                }
            }

            public override IList<string> ToStringAll()
            {
                return _toString;
            }

            public override IList<string> ToStrings(IEnumerable<T> items)
            {
                IList<string> listOfEnumsAsString = new List<string>();
                foreach (T item in items)
                {
                    listOfEnumsAsString.Add(ToString(item));
                }

                return listOfEnumsAsString;
            }

            public override string ToString(T item)
            {
                int idx = Convert.ToInt32(item);

                if (idx >= 0 && idx < _toString.Count)
                {
                    return _toString[idx];
                }

                throw new ArgumentOutOfRangeException($"Item '{item.ToString()}' doesn't exist in Enum.");
            }
        }

        private sealed class EnumHelperToStringHoleyStrategy : EnumHelperToString<T>
        {
            private readonly IDictionary<T, string> _toString = new Dictionary<T, string>();

            public EnumHelperToStringHoleyStrategy(Func<T, string> getItemName)
                : base(getItemName)
            {
                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    _toString.Add(item, GetItemName(item));
                }
            }

            public override IList<string> ToStringAll()
            {
                IList<string> toStringAll = new List<string>(_toString.Values.Count);

                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    toStringAll.Add(GetItemName(item));
                }

                return toStringAll;
            }

            public override string ToString(T item)
            {
                if (_toString.TryGetValue(item, out string? resVal))
                {
                    return resVal;
                }

                throw new ArgumentOutOfRangeException($"Item '{item}' doesn't exist in Enum.");
            }

            public override IList<string> ToStrings(IEnumerable<T> items)
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
        }
    }
}