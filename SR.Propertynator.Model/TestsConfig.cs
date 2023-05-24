namespace SR.Propertynator.Model;

public sealed class TestsConfig
{
    public bool RunUnitTests { get; set; } = true;

    public bool RunIntegrationTests { get; set; } = false;

    public void Write(TextWriter stream, string projectName)
    {
        throw new NotImplementedException();
    }
}