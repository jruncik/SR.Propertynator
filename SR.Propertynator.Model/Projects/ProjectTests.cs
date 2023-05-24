namespace SR.Propertynator.Model.Projects;

public sealed class ProjectTests : ProjectBase
{
    public const string ProjectName = "tests";

    public ProjectTests(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Tests;

    public override string Name => ProjectName;
}