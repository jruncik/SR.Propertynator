namespace SR.Propertynator.Model.Branches;

public sealed class BuildSourceInvariantBranchIntegration : BuildSourceInvariantBranch
{
    private BuildSourceInvariantBranchIntegration() :
        base("integration")
    { }

    public static BuildSource Instance { get; } = new BuildSourceInvariantBranchIntegration();
}