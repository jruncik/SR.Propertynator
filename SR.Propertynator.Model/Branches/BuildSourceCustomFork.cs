namespace SR.Propertynator.Model.Branches
{
    public sealed class BuildSourceCustomFork : BuildSource
    {
        public BuildSourceCustomFork(string branchName, string forkName)
        {
            BranchName = branchName;
            ForkName = forkName;
        }

        public string ForkName { get; set; } = string.Empty;

        private string BranchName { get; } = string.Empty;

        public override void Write(TextWriter stream, string projectName)
        {
            stream.WriteLine($"{projectName}.{Tags.Fork}={ForkName}");
            stream.WriteLine($"{projectName}.{Tags.Branch}={BranchName}");
        }
    }
}