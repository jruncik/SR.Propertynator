namespace SR.Propertynator.Model.Projects;

public sealed class ProjectAdministration : ProjectBase
{
    public const string ProjectName = "administration";

    public ProjectAdministration(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Administration;

    public override string Name => ProjectName;
}