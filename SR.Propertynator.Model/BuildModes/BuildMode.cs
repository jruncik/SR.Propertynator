using SR.Propertynator.Model.Projects;

namespace SR.Propertynator.Model.BuildModes
{
    public abstract class BuildMode
    {
        private readonly BuildModeType _buildModeType;

        private BuildMode(BuildModeType buildModeType)
        {
            _buildModeType = buildModeType;
        }

        public static BuildMode Binary { get; } = new BuildModeBinary();

        public static BuildMode Source { get; } = new BuildModeSource();

        public static BuildMode Ignore { get; } = new BuildModeIgnore();

        public void Write(TextWriter stream, IProject project)
        {
            stream.WriteLine($"{project.Name}.{Tags.Mode}={BuildModeTypeEnumHelperLower.ToString(_buildModeType)}");
        }

        private sealed class BuildModeBinary : BuildMode
        {
            public BuildModeBinary() :
                base(BuildModeType.Binary)
            {
            }
        }

        private sealed class BuildModeSource : BuildMode
        {
            public BuildModeSource() :
                base(BuildModeType.Source)
            {
            }
        }

        private sealed class BuildModeIgnore : BuildMode
        {
            public BuildModeIgnore() :
                base(BuildModeType.Ignore)
            {
            }
        }
    }
}