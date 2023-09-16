using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.BuildModes;

namespace SR.Propertynator.Model.Projects
{
    public interface IProject
    {
        ProjectType Type               { get; }
        string      Name               { get; }
        BuildMode   BuildModeBuild     { get; set; }
        BuildMode   BuildModeDeveloper { get; set; }
        BuildSource BuildSource        { get; set; }
        TestsConfig TestsConfig        { get; set; }
    }
}