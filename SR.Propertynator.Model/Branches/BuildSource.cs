namespace SR.Propertynator.Model.Branches;

public abstract class BuildSource
{
    public abstract void Write(TextWriter stream, string projectName);
}