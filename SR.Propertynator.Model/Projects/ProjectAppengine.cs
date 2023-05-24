namespace SR.Propertynator.Model.Projects;

public sealed class ProjectAppengine : ProjectBase
{
    public const string ProjectName = "appengine";

    public ProjectAppengine(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Appengine;

    public override string Name => ProjectName;
}