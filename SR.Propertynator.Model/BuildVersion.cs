namespace SR.Propertynator.Model
{
    public sealed class BuildVersion
    {
        private readonly Version _version;

        public BuildVersion(int major, int minor, int build, int revision) :
            this(new Version(major, minor, build, revision))
        {
        }

        public BuildVersion(int major, int minor, int build) :
            this(new Version(major, minor, build))
        {
        }

        public BuildVersion(int major, int minor) :
            this(new Version(major, minor))
        {
        }

        public BuildVersion(string version) :
            this(new Version(version))
        {
        }

        public BuildVersion() :
            this(new Version())
        {
        }

        private BuildVersion(Version version)
        {
            _version = version;
        }

        public override string ToString()
        {
            return $"Build_{_version.ToString()}";
        }
    }
}