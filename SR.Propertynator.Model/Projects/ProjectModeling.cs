namespace SR.Propertynator.Model.Projects;

public sealed class ProjectModeling : ProjectBase
{
    public const string ProjectName = "modeling";

    public ProjectModeling(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Modeling;

    public override string Name => ProjectName;
}