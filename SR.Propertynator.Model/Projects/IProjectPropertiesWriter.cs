using SR.Propertynator.Model.Branches;
using SR.Propertynator.Model.BuildModes;

namespace SR.Propertynator.Model.Projects;

public interface IProjectPropertiesWriter
{
    void WriteBuildMode(BuildMode buildMode);

    void WriteDeveloperMode(BuildMode buildMode);

    void WriteBranch(BuildSource buildSource);

    void WriteTestsConfig(TestsConfig testsConfig);
}