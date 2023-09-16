using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.BuildModes;
using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model.Tests
{
    internal sealed class ProjectMoc : IProject
    {
        public ProjectType Type => ProjectType.Unknown;
        public string Name { get; set; } = string.Empty;
        public BuildMode BuildModeBuild { get; set; } = BuildMode.Source;
        public BuildMode BuildModeDeveloper { get; set; } = BuildMode.Source;
        public BuildSource BuildSource { get; set; } = BuildSource.Stage;
        public TestsConfig TestsConfig { get; set; } = new TestsConfig();
    }
}