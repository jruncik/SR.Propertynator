namespace SR.Propertynator.Model.Projects;

public sealed class ProjectDepmservice : ProjectBase
{
    public const string ProjectName = "depmservice";

    public ProjectDepmservice(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Depmservice;

    public override string Name => ProjectName;
}