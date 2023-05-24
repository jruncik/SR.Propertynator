namespace SR.Propertynator.Model.Projects;

public sealed class ProjectFramework : ProjectBase
{
    public const string ProjectName = "Framework";

    public ProjectFramework(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Framework;

    public override string Name => ProjectName;
}