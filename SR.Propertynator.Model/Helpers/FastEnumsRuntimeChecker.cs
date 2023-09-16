namespace SR.Propertynator.Model.Helpers
{
    public class FastEnumsRuntimeChecker<TEnumA, TEnumB>
        where TEnumA : struct
        where TEnumB : struct
    {
        static FastEnumsRuntimeChecker()
        {
            CheckUnderlyingTypes();
            CheckEnumsItemNames();
            CheckEnumsItemValues();
        }

        private static void CheckUnderlyingTypes()
        {
            Type aType = Enum.GetUnderlyingType(typeof(TEnumA));
            Type bType = Enum.GetUnderlyingType(typeof(TEnumB));

            if (aType != bType)
            {
                throw new InvalidCastException($"Underlying type {typeof(TEnumA).Name}: ({aType.Name}) is different from {typeof(TEnumB).Name}: ({bType.Name}).");
            }
        }

        private static void CheckEnumsItemNames()
        {
            string[] aNames = Enum.GetNames(typeof(TEnumA));
            string[] bNames = Enum.GetNames(typeof(TEnumB));

            if (aNames.Length != bNames.Length)
            {
                throw new InvalidCastException($"Enums {typeof(TEnumA).Name} and {typeof(TEnumB).Name} have different count of enum items.");
            }

            for (int i = 0; i < aNames.Length; ++i)
            {
                if (!aNames[i].Equals(bNames[i]))
                {
                    throw new InvalidCastException($"{typeof(TEnumA).Name}.{aNames[i]} is different from {typeof(TEnumB).Name}.{bNames[i]}.");
                }
            }
        }

        private static void CheckEnumsItemValues()
        {
            Type underlyingType = Enum.GetUnderlyingType(typeof(TEnumA));

            string[] aNames = Enum.GetNames(typeof(TEnumA));
            string[] bNames = Enum.GetNames(typeof(TEnumB));

            Array aItems = Enum.GetValues(typeof(TEnumA));
            Array bItems = Enum.GetValues(typeof(TEnumB));

            if (aItems.Length != bItems.Length)
            {
                throw new InvalidCastException($"Enums {typeof(TEnumA).Name} and {typeof(TEnumB).Name} have different count of enum items.");
            }

            for (int i = 0; i < aItems.Length; ++i)
            {
                object? valA = aItems.GetValue(i);
                object? valB = bItems.GetValue(i);

                object? valAAsBaseType = Convert.ChangeType(valA, underlyingType);
                object? valBAsBaseType = Convert.ChangeType(valB, underlyingType);

                if (valAAsBaseType != null && !valAAsBaseType.Equals(valBAsBaseType))
                {
                    throw new InvalidCastException($"{typeof(TEnumA).Name}.{aNames[i]} = {valAAsBaseType} is different from {typeof(TEnumB).Name}.{bNames[i]} = {valBAsBaseType}.");
                }
            }
        }
    }
}