namespace SR.Propertynator.Model.BuildModes;

public abstract class BuildMode
{
    private readonly string _name;

    private BuildMode(string name)
    {
        _name = name;
    }

    static public BuildMode Binary { get; } = new BuildModeBinary();

    static public BuildMode Source { get; } = new BuildModeSource();

    static public BuildMode Ignore { get; } = new BuildModeIgnore();

    public void Write(TextWriter stream, string projectName)
    {
        stream.WriteLine($"{projectName}.{Tags.Mode}={_name}");
    }

    private sealed class BuildModeBinary : BuildMode
    {
        public BuildModeBinary() :
            base("binary")
        { }
    }

    private sealed class BuildModeSource : BuildMode
    {
        public BuildModeSource() :
            base("source")
        { }
    }

    private sealed class BuildModeIgnore : BuildMode
    {
        public BuildModeIgnore() :
            base("ignore")
        { }
    }
}