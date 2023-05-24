namespace SR.Propertynator.Model.Branches;

public abstract class BuildSourceInvariantBranch : BuildSource
{
    private readonly string _branchName;

    protected BuildSourceInvariantBranch(string branchName)
    {
        _branchName = branchName;
    }

    public override void Write(TextWriter stream, string projectName)
    {
        stream.WriteLine($"{projectName}.{Tags.Branch}={_branchName}");
    }
}