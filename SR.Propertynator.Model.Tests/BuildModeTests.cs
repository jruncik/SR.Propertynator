using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SR.Propertynator.Model.BuildModes;
using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model.Tests
{
    [TestClass]
    public class BuildModeTests
    {
        private static readonly IProject Project = new ProjectMoc { Name = "TestProjectName" };

        [TestMethod]
        public void CreateModelBinary()
        {
            BuildMode model = BuildMode.Binary;
            model.Should().BeSameAs(BuildMode.Binary);
        }

        [TestMethod]
        public void CreateModelSource()
        {
            BuildMode model = BuildMode.Source;
            model.Should().BeSameAs(BuildMode.Source);
        }

        [TestMethod]
        public void CreateModelIgnore()
        {
            BuildMode model = BuildMode.Ignore;
            model.Should().BeSameAs(BuildMode.Ignore);
        }

        [TestMethod]
        public void WriteModelBinary()
        {
            BuildMode model = BuildMode.Binary;
            string propertyFileTestLine = WriteToString(model, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.mode=binary");
        }

        [TestMethod]
        public void WriteModelSource()
        {
            BuildMode model = BuildMode.Source;
            string propertyFileTestLine = WriteToString(model, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.mode=source");
        }

        [TestMethod]
        public void WriteModelIgnore()
        {
            BuildMode model = BuildMode.Ignore;
            string propertyFileTestLine = WriteToString(model, Project);

            propertyFileTestLine.Trim().Should().Be($"{Project.Name}.mode=ignore");
        }

        private static string WriteToString(BuildMode buildMode, IProject project)
        {
            using StringWriter target = new StringWriter();

            buildMode.Write(target, project);

            return target.ToString();
        }
    }
}