namespace SR.Propertynator.Model.Projects;

public sealed class ProjectRepository : ProjectBase
{
    public const string ProjectName = "repository";

    public ProjectRepository(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Repository;

    public override string Name => ProjectName;
}