namespace SR.Propertynator.Model.Branches;

public sealed class BuildSourceInvariantBranchStage : BuildSourceInvariantBranch
{
    private BuildSourceInvariantBranchStage() :
        base("stage")
    { }

    public static BuildSource Instance { get; } = new BuildSourceInvariantBranchStage();
}