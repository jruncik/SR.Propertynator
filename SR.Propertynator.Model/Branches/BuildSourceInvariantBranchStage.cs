namespace SR.Propertynator.Model.Branches;

public sealed class BuildSourceInvariantBranchStage : BuildSourceInvariantBranch
{
    private BuildSourceInvariantBranchStage() :
        base("stage")
    { }

    static public BuildSource Instance { get; } = new BuildSourceInvariantBranchStage();
}