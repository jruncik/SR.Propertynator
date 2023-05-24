namespace SR.Propertynator.Model.Projects;

public sealed class ProjectDesigner : ProjectBase
{
    public const string ProjectName = "designer";

    public ProjectDesigner(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Designer;

    public override string Name => ProjectName;
}