namespace SR.Propertynator.Model.Projects;

public sealed class ProjectOlap : ProjectBase
{
    public const string ProjectName = "olap";

    public ProjectOlap(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Olap;

    public override string Name => ProjectName;
}