using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SR.Propertynator.Model.Helpers;

namespace SR.Propertynator.Model.Tests
{
    internal enum FirstOk
    {
        a,
        b,
        c,
        d
    }

    internal enum SecondOk
    {
        a,
        b,
        c,
        d
    }

    internal static class SecondOkExtension
    {
        static SecondOkExtension()
        {
            FastEnumsRuntimeChecker<FirstOk, SecondOk> enumChecker = new FastEnumsRuntimeChecker<FirstOk, SecondOk>();
        }

        public static SecondOk AsSecondOk(this FirstOk type)
        {
            return (SecondOk)type;
        }
    }

    internal enum SecondUnderlyingByte : byte
    {
        a,
        b,
        c,
        d
    }

    internal static class SecondUnderlyingByteExtension
    {
        static SecondUnderlyingByteExtension()
        {
            FastEnumsRuntimeChecker<FirstOk, SecondUnderlyingByte> enumChecker = new FastEnumsRuntimeChecker<FirstOk, SecondUnderlyingByte>();
        }

        public static SecondUnderlyingByte AsSecondUnderlyingByte(this FirstOk type)
        {
            return (SecondUnderlyingByte)type;
        }
    }

    internal enum SecondDifferentCount
    {
        a,
        b,
        c,
        d,
        e
    }

    internal static class SecondDifferentCountExtension
    {
        static SecondDifferentCountExtension()
        {
            FastEnumsRuntimeChecker<FirstOk, SecondDifferentCount> enumChecker = new FastEnumsRuntimeChecker<FirstOk, SecondDifferentCount>();
        }

        public static SecondDifferentCount AsSecondDifferentCount(this FirstOk type)
        {
            return (SecondDifferentCount)type;
        }
    }

    internal enum SecondDifferentName
    {
        a,
        bbb,
        c,
        d
    }

    internal static class SecondDifferentNameExtension
    {
        static SecondDifferentNameExtension()
        {
            FastEnumsRuntimeChecker<FirstOk, SecondDifferentName> enumChecker = new FastEnumsRuntimeChecker<FirstOk, SecondDifferentName>();
        }

        public static SecondDifferentName AsSecondDifferentName(this FirstOk type)
        {
            return (SecondDifferentName)type;
        }
    }

    internal enum SecondDifferentValue
    {
        a = 0,
        b = 1,
        c = 2,
        d = 16
    }

    internal static class SecondDifferentValueExtension
    {
        static SecondDifferentValueExtension()
        {
            FastEnumsRuntimeChecker<FirstOk, SecondDifferentValue> enumChecker = new FastEnumsRuntimeChecker<FirstOk, SecondDifferentValue>();
        }

        public static SecondDifferentValue AsSecondDifferentValue(this FirstOk type)
        {
            return (SecondDifferentValue)type;
        }
    }
    
    [Flags]
    internal enum SecondAreFlags
    {
        a,
        b,
        c,
        d
    }

    internal static class SecondAreFlagsExtension
    {
        static SecondAreFlagsExtension()
        {
            FastEnumsRuntimeChecker<FirstOk, SecondAreFlags> enumChecker = new FastEnumsRuntimeChecker<FirstOk, SecondAreFlags>();
        }

        public static SecondAreFlags AsSecondAreFlags(this FirstOk type)
        {
            return (SecondAreFlags)type;
        }
    }

    [TestClass]
    public class FastEnumsRuntimeCheckerTests
    {
        private const FirstOk FirstOkA = FirstOk.a;

        [TestMethod]
        public void EnumsAreOk()
        {
            Action create = () => FirstOkA.AsSecondOk();
            create.Should().NotThrow();
        }

        [TestMethod]
        public void EnumsHasDifferentUnderlyingType()
        {
            try
            {
                FirstOkA.AsSecondUnderlyingByte();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<TypeInitializationException>();

                Exception innerEx = ex.GetBaseException();
                innerEx.Should().BeOfType<InvalidCastException>();
                innerEx.Message.Should().Be("Underlying type FirstOk: (Int32) is different from SecondUnderlyingByte: (Byte).");
            }
        }

        [TestMethod]
        public void EnumsHasDifferentCountOfItems()
        {
            try
            {
                FirstOkA.AsSecondDifferentCount();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<TypeInitializationException>();

                Exception innerEx = ex.GetBaseException();
                innerEx.Should().BeOfType<InvalidCastException>();
                innerEx.Message.Should().Be("Enums FirstOk and SecondDifferentCount have different count of enum items.");
            }
        }

        [TestMethod]
        public void EnumsHasDifferentNameOfItems()
        {
            try
            {
                FirstOkA.AsSecondDifferentName();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<TypeInitializationException>();

                Exception innerEx = ex.GetBaseException();
                innerEx.Should().BeOfType<InvalidCastException>();
                innerEx.Message.Should().Be("FirstOk.b is different from SecondDifferentName.bbb.");
            }
        }

        [TestMethod]
        public void EnumsHasDifferentValueOfItems()
        {
            try
            {
                FirstOkA.AsSecondDifferentValue();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<TypeInitializationException>();

                Exception innerEx = ex.GetBaseException();
                innerEx.Should().BeOfType<InvalidCastException>();
                innerEx.Message.Should().Be("FirstOk.d = 3 is different from SecondDifferentValue.d = 16.");
            }
        }
        
        [TestMethod]
        public void EnumsHasDifferentValueOfItemsSecondIsFlag()
        {
            try
            {
                FirstOkA.AsSecondAreFlags();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<TypeInitializationException>();

                Exception innerEx = ex.GetBaseException();
                innerEx.Should().BeOfType<InvalidCastException>();
                innerEx.Message.Should().Be("FirstOk.d = 3 is different from SecondDifferentValue.d = 4.");
            }
        }
    }
}