using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SR.Propertynator.Model.Branches;

namespace SR.Propertynator.Model.Tests
{
    [TestClass]
    public class BuildSourceTests
    {
        private const string ProjectName = "TestProjectName";

        [TestMethod]
        public void WriteBuildModeStage()
        {
            BuildSource buildSource = BuildSource.Stage;

            string propertyFileTestLine = WriteToString(buildSource, ProjectName);

            propertyFileTestLine.Trim().Should().Be($"{ProjectName}.branch=stage");
        }

        [TestMethod]
        public void WriteBuildIntegration()
        {
            BuildSource buildSource = BuildSource.Integration;

            string propertyFileTestLine = WriteToString(buildSource, ProjectName);

            propertyFileTestLine.Trim().Should().Be($"{ProjectName}.branch=integration");
        }

        [TestMethod]
        public void WriteBuildModeFixedVersion()
        {
            BuildVersion buildVersion = new BuildVersion(12, 16, 7, 27);
            BuildSource buildSource = BuildSource.CreateFixedVersion(buildVersion);

            string propertyFileTestLine = WriteToString(buildSource, ProjectName);

            propertyFileTestLine.Trim().Should().Be($"{ProjectName}.tag={buildVersion}");
        }

        [TestMethod]
        public void WriteBuildModeCustomFork()
        {
            string BranchName = "BranchName";
            string ForkName = "ForkName";

            BuildSource buildSource = BuildSource.CreateCustomFork(BranchName, ForkName);

            string propertyFileTestLine = WriteToString(buildSource, ProjectName);

            propertyFileTestLine.Trim().Should().Be($"{ProjectName}.fork={ForkName}{Environment.NewLine}{ProjectName}.branch={BranchName}");
        }

        private string WriteToString(BuildSource buildSource, string projectName)
        {
            using StringWriter target = new StringWriter();

            buildSource.Write(target, projectName);

            return target.ToString();
        }
    }
}