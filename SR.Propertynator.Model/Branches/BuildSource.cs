using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model.Branches
{
    public abstract class BuildSource
    {
        public static BuildSource Stage => BuildSourceInvariantBranchStage.Instance;

        public static BuildSource Integration => BuildSourceInvariantBranchIntegration.Instance;

        public static BuildSource CreateCustomFork(string branchName, string forkName)
        {
            return new BuildSourceCustomFork(branchName, forkName);
        }

        public static BuildSource CreateFixedVersion(BuildVersion version)
        {
            return new BuildSourceFixedVersion(version);
        }

        public abstract void Write(TextWriter stream, IProject project);

        private abstract class BuildSourceInvariantBranch : BuildSource
        {
            private readonly string _branchName;

            protected BuildSourceInvariantBranch(string branchName)
            {
                _branchName = branchName;
            }

            public override void Write(TextWriter stream, IProject project)
            {
                stream.WriteLine($"{project.Name}.{Tags.Branch}={_branchName}");
            }
        }

        private sealed class BuildSourceInvariantBranchIntegration : BuildSourceInvariantBranch
        {
            private BuildSourceInvariantBranchIntegration() :
                base("integration")
            {
            }

            public static BuildSource Instance { get; } = new BuildSourceInvariantBranchIntegration();
        }

        private sealed class BuildSourceInvariantBranchStage : BuildSourceInvariantBranch
        {
            private BuildSourceInvariantBranchStage() :
                base("stage")
            {
            }

            public static BuildSource Instance { get; } = new BuildSourceInvariantBranchStage();
        }
    }
}