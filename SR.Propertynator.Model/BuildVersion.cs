namespace SR.Propertynator.Model;

public sealed class BuildVersion
{
    private Version Version { get; } = new Version();

    public override string ToString()
    {
        return $"Build_{Version.ToString()}";
    }
}