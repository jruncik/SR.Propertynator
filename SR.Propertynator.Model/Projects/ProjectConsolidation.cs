namespace SR.Propertynator.Model.Projects;

public class ProjectConsolidation : ProjectBase
{
    public const string ProjectName = "consolidation";

    public ProjectConsolidation(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Consolidation;

    public override string Name => ProjectName;
}