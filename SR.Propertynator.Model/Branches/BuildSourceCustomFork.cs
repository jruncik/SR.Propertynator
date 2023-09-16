using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model.Branches
{
    public sealed class BuildSourceCustomFork : BuildSource
    {
        public BuildSourceCustomFork(string branchName, string forkName)
        {
            BranchName = branchName;
            ForkName = forkName;
        }

        public string ForkName { get; set; }

        private string BranchName { get; }

        public override void Write(TextWriter stream, IProject project)
        {
            stream.WriteLine($"{project.Name}.{Tags.Fork}={ForkName}");
            stream.WriteLine($"{project.Name}.{Tags.Branch}={BranchName}");
        }
    }
}