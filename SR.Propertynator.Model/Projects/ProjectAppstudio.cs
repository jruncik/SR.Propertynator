namespace SR.Propertynator.Model.Projects;

public sealed class ProjectAppstudio : ProjectBase
{
    public const string ProjectName = "appstudio";

    public ProjectAppstudio(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Appstudio;

    public override string Name => ProjectName;
}