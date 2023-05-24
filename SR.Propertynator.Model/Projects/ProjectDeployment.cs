namespace SR.Propertynator.Model.Projects;

public sealed class ProjectDeployment : ProjectBase
{
    public const string ProjectName = "deployment";

    public ProjectDeployment(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Deployment;

    public override string Name => ProjectName;
}