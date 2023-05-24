using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.BuildModes;

namespace SR.Propertynator.Model.Projects;

public abstract class ProjectBase : IProject, IWritable
{
    private readonly IProject _defaultProject;

    private BuildSource? _buildSource;

    private BuildMode? _modeBuild;

    private BuildMode? _modeDeveloper;

    private TestsConfig? _testsConfig;

    protected ProjectBase(IProject defaultProject)
    {
        _defaultProject = defaultProject;
    }

    public abstract ProjectType Type { get; }

    public abstract string Name { get; }

    public BuildMode BuildModeBuild
    {
        get => _modeBuild ?? _defaultProject.BuildModeBuild;
        set => _modeBuild = value;
    }

    public BuildMode BuildModeDeveloper
    {
        get => _modeDeveloper ?? _defaultProject.BuildModeDeveloper;
        set => _modeDeveloper = value;
    }

    public BuildSource BuildSource
    {
        get => _buildSource ?? _defaultProject.BuildSource;
        set => _buildSource = value;
    }

    public TestsConfig TestsConfig
    {
        get => _testsConfig ?? _defaultProject.TestsConfig;
        set => _testsConfig = value;
    }

    public void Write(TextWriter stream)
    {
        BuildModeBuild.Write(stream, Name);
        BuildModeDeveloper.Write(stream, Name);
        BuildSource.Write(stream, Name);
        TestsConfig.Write(stream, Name);
    }
}