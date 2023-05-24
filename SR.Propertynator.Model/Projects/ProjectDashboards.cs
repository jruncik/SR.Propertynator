namespace SR.Propertynator.Model.Projects;

public sealed class ProjectDashboards : ProjectBase
{
    public const string ProjectName = "dashboards";

    public ProjectDashboards(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Dashboards;

    public override string Name => ProjectName;
}