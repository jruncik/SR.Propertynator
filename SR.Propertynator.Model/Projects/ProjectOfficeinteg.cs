namespace SR.Propertynator.Model.Projects;

public sealed class ProjectOfficeinteg : ProjectBase
{
    public const string ProjectName = "officeinteg";

    public ProjectOfficeinteg(IProject defaultProject)
        : base(defaultProject)
    { }

    public override ProjectType Type => ProjectType.Officeinteg;

    public override string Name => ProjectName;
}