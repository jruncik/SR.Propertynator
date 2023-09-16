using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model.Tests
{
    [TestClass]
    public class BuildSourceTests
    {
        private static readonly IProject Project = new ProjectMoc { Name = "TestProjectName" };

        [TestMethod]
        public void WriteBuildModeStage()
        {
            BuildSource buildSource = BuildSource.Stage;

            string propertyFileTestLine = WriteToString(buildSource, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.branch=stage");
        }

        [TestMethod]
        public void WriteBuildIntegration()
        {
            BuildSource buildSource = BuildSource.Integration;

            string propertyFileTestLine = WriteToString(buildSource, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.branch=integration");
        }

        [TestMethod]
        public void WriteBuildModeFixedVersion()
        {
            BuildVersion buildVersion = new BuildVersion(12, 16, 7, 27);
            BuildSource buildSource = BuildSource.CreateFixedVersion(buildVersion);

            string propertyFileTestLine = WriteToString(buildSource, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.tag={buildVersion}");
        }

        [TestMethod]
        public void WriteBuildModeCustomFork()
        {
            const string branchName = "BranchName";
            const string forkName = "ForkName";

            BuildSource buildSource = BuildSource.CreateCustomFork(branchName, forkName);

            string propertyFileTestLine = WriteToString(buildSource, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.fork={forkName}{Environment.NewLine}{Project.Name}.branch={branchName}");
        }

        private static string WriteToString(BuildSource buildSource, IProject project)
        {
            using StringWriter target = new StringWriter();

            buildSource.Write(target, project);

            return target.ToString();
        }
    }
}