using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SR.Propertynator.Model.Tests
{
    [TestClass]
    public class BuildVersionTests
    {
        [TestMethod]
        public void BuildVersionMajorMinorBuildRevisionTest()
        {
            BuildVersion buildVersion = new BuildVersion(12, 16, 7, 27);
            buildVersion.ToString().Trim().Should().Be("Build_12.16.7.27");
        }

        [TestMethod]
        public void BuildVersionMajorMinorBuildTest()
        {
            BuildVersion buildVersion = new BuildVersion(12, 16, 7);
            buildVersion.ToString().Trim().Should().Be("Build_12.16.7");
        }

        [TestMethod]
        public void BuildVersionMajorMinorTest()
        {
            BuildVersion buildVersion = new BuildVersion(12, 16);
            buildVersion.ToString().Trim().Should().Be("Build_12.16");
        }

        [TestMethod]
        public void BuildVersionFromMajorMinorBuildRevisionStringTest()
        {
            BuildVersion buildVersion = new BuildVersion("12.16.7.27");
            buildVersion.ToString().Trim().Should().Be("Build_12.16.7.27");
        }

        [TestMethod]
        public void BuildVersionFromMajorMinorBuildStringTest()
        {
            BuildVersion buildVersion = new BuildVersion("12.16.7");
            buildVersion.ToString().Trim().Should().Be("Build_12.16.7");
        }

        [TestMethod]
        public void BuildVersionFromMajorMinorStringTest()
        {
            BuildVersion buildVersion = new BuildVersion("12.16");
            buildVersion.ToString().Trim().Should().Be("Build_12.16");
        }

        [TestMethod]
        public void BuildVersionFromEmptyStringTest()
        {
            Action create = () => new BuildVersion(String.Empty);

            create.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void BuildVersionFromNullStringTest()
        {
            Action create = () => new BuildVersion(null);

            create.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void BuildVersionFromInvalidStringTest()
        {
            Action create = () => new BuildVersion("xxxyyyzzz");

            create.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void BuildVersionFromPartiallyInvalidStringTest()
        {
            Action create = () => new BuildVersion("xxx.16.27.yyy");

            create.Should().Throw<FormatException>();
        }

        [TestMethod]
        public void BuildVersionEmpty()
        {
            BuildVersion buildVersion = new BuildVersion();
            buildVersion.ToString().Trim().Should().Be("Build_0.0");
        }
    }
}