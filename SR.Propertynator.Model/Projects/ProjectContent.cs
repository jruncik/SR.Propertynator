namespace SR.Propertynator.Model.Projects;

public sealed class ProjectContent : ProjectBase
{
    public const string ProjectName = "content";

    public ProjectContent(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Content;

    public override string Name => ProjectName;
}