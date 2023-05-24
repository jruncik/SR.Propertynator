namespace SR.Propertynator.Model.Branches
{
    public sealed class BuildSourceFixedVersion : BuildSource
    {
        public BuildSourceFixedVersion(BuildVersion version)
        {
            Version = version;
        }

        public BuildVersion Version { get; set; }

        public override void Write(TextWriter stream, string projectName)
        {
            stream.WriteLine($"{projectName}.{Tags.Tag}={Version}");
        }
    }
}