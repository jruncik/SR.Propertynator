using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.BuildModes;

namespace SR.Propertynator.Model.Projects;

public sealed class ProjectDefault : IProject
{
    public ProjectType Type               => ProjectType.Default;
    public string      Name               => string.Empty;
    public BuildMode   BuildModeBuild     { get; set; } = BuildMode.Source;
    public BuildMode   BuildModeDeveloper { get; set; } = BuildMode.Source;
    public BuildSource BuildSource        { get; set; } = BuildSourceInvariantBranchStage.Instance;
    public TestsConfig TestsConfig        { get; set; } = new TestsConfig();
}