namespace SR.Propertynator.Model.Branches;

public sealed class BuildSourceInvariantBranchIntegration : BuildSourceInvariantBranch
{
    private BuildSourceInvariantBranchIntegration() :
        base("integration")
    { }

    static public BuildSource Instance { get; } = new BuildSourceInvariantBranchIntegration();
}